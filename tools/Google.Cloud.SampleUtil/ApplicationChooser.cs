// Copyright 2019 Google LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Cloud.SampleUtil
{
    public class ApplicationChooser
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                throw new NotImplementedException("Interative mode isn't implemented yet.");
            }
            string sample = args[0];
            var assembly = Assembly.GetEntryAssembly();

            // Create a dictionary, so that we can easily look up a sample entry point with
            // a sample file name.
            var samples = assembly
                          .DefinedTypes
                          .Select(t => GetEntryPoint(t))
                          .Where(ep => ep != null && ep != assembly.EntryPoint)
                          .ToDictionary(ep => ep.DeclaringType.Name.Replace("Main", string.Empty), ep => ep);

            MethodBase main = samples[sample];
            if (main == null)
            {
                throw new ArgumentException($"Can't find sample: {sample}");
            }
            try
            {
                Task task = main.Invoke(null, new object[] { args }) as Task;
                if (task != null)
                {
                    task.GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                // Normally we fail due to an exception within the
                // code invoked via reflection.
                // Unwrap the TargetInvocationException that would otherwise
                // be wrapped in.
                if (e is TargetInvocationException tie)
                {
                    e = tie.InnerException;
                }
                Console.WriteLine("Exception: {0}", e);
            }
        }

        /// <summary>
        /// Returns the entry point for a sample, or null if no entry points can be used.
        /// An entry point taking string[] is preferred to one with no parameters.
        /// </summary>
        private static MethodBase GetEntryPoint(TypeInfo type)
        {
            if (type.IsGenericTypeDefinition || type.IsGenericType)
            {
                return null;
            }
            var methods = type.DeclaredMethods
                          .Where(m => m.IsStatic && m.Name == "Main" && !m.IsGenericMethodDefinition);

            MethodInfo parameterless = null;
            MethodInfo stringArrayParameter = null;

            foreach (MethodInfo method in methods)
            {
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length == 0)
                {
                    parameterless = method;
                }
                else
                {
                    if (parameters.Length == 1 &&
                            !parameters[0].IsOut &&
                            !parameters[0].IsOptional &&
                            parameters[0].ParameterType == typeof(string[]))
                    {
                        stringArrayParameter = method;
                    }
                }
            }

            // Entry point of a sample should always have parameters, but allow one
            // without parameters to be more resilient to sample style changes.
            return stringArrayParameter ?? parameterless;
        }
    }
}
