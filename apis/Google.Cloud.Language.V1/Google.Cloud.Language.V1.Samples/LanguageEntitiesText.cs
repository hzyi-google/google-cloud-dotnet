// Copyright 2019 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

// This is a generated sample ("Request", "language_entities_text")

// sample-metadata
//   title:
//   description: Analyze entities in text
//   usage: dotnet run [--text_content "California is a state."]

using CommandLine;

namespace Google.Cloud.Language.V1.Samples
{
    // [START language_entities_text]
    using Google.Cloud.Language.V1;
    using System;

    public class LanguageEntitiesText
    {
        /// <summary>
        /// Analyze entities in text
        /// </summary>
        public static void SampleAnalyzeEntities(string textContent)
        {
            LanguageServiceClient languageServiceClient = LanguageServiceClient.Create();
            // string textContent = "California is a state."
            AnalyzeEntitiesRequest request = new AnalyzeEntitiesRequest
            {
                Document = new Document
                {
                    Type = Document.Types.Type.PlainText,
                    Content = "California is a state.",
                },
            };
            AnalyzeEntitiesResponse response = languageServiceClient.AnalyzeEntities(request);
            foreach (Entity entity in response.Entities) {
                Console.WriteLine($"Entity name: {entity.Name}");
                Console.WriteLine($"Entity type: {entity.Type}");
                Console.WriteLine($"Entity salience score: {entity.Salience}");
                foreach (EntityMention mention in entity.Mentions) {
                    Console.WriteLine($"Mention: {mention.Text.Content}");
                    Console.WriteLine($"Mention type: {mention.Type}");
                }
            }
        }
    }

    // [END language_entities_text]

    public class LanguageEntitiesTextMain {
        public static void Main(string[] args)
        {
            new Parser(with => with.CaseInsensitiveEnumValues = true).ParseArguments<Options>(args)
                .WithParsed<Options>(opts =>
                    LanguageEntitiesText.SampleAnalyzeEntities(opts.TextContent));
        }

        public class Options
        {
            [Option("text_content", Default = "California is a state.")]
            public string TextContent { get; set; }
        }
    }
}