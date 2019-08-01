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

// This is a generated sample ("Request", "language_syntax_gcs")

// sample-metadata
//   title:
//   description: Analyze syntax of text in GCS
//   usage: dotnet run [--gcs_urs "gs://cloud-samples-data/language/syntax-sentence.txt"]

using CommandLine;

namespace Google.Cloud.Language.V1.Samples
{
    // [START language_syntax_gcs]
    using Google.Cloud.Language.V1;
    using System;
    using System.Collections.Generic;

    public class LanguageSyntaxGcs
    {
        /// <summary>
        /// Analyze syntax of text in GCS
        /// </summary>
        public static void SampleAnalyzeSyntax(string gcsUrs)
        {
            LanguageServiceClient languageServiceClient = LanguageServiceClient.Create();
            // string gcsUrs = "gs://cloud-samples-data/language/syntax-sentence.txt"
            AnalyzeSyntaxRequest request = new AnalyzeSyntaxRequest
            {
                Document = new Document
                {
                    Type = Document.Types.Type.PlainText,
                    GcsContentUri = "gs://cloud-samples-data/language/syntax-sentence.txt",
                },
            };
            AnalyzeSyntaxResponse response = languageServiceClient.AnalyzeSyntax(request);
            IEnumerable<Token> tokens = response.Tokens;
            foreach (Token token in tokens) {
                Console.WriteLine($"Part of speech: {token.PartOfSpeech.Tag}");
                Console.WriteLine($"Text: {token.Text.Content}");
            }
        }
    }

    // [END language_syntax_gcs]

    public class LanguageSyntaxGcsMain {
        public static void Main(string[] args)
        {
            new Parser(with => with.CaseInsensitiveEnumValues = true).ParseArguments<Options>(args)
                .WithParsed<Options>(opts =>
                    LanguageSyntaxGcs.SampleAnalyzeSyntax(opts.GcsUrs));
        }

        public class Options
        {
            [Option("gcs_urs", Default = "gs://cloud-samples-data/language/syntax-sentence.txt")]
            public string GcsUrs { get; set; }
        }
    }
}