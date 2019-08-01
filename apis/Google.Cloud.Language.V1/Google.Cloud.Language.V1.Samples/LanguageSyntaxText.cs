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

// This is a generated sample ("Request", "language_syntax_text")

// sample-metadata
//   title:
//   description: Analyze syntax of text
//   usage: dotnet run [--text_content "This is a short sentence."]

using CommandLine;

namespace Google.Cloud.Language.V1.Samples
{
    // [START language_syntax_text]
    using Google.Cloud.Language.V1;
    using System;
    using System.Collections.Generic;

    public class LanguageSyntaxText
    {
        /// <summary>
        /// Analyze syntax of text
        /// </summary>
        public static void SampleAnalyzeSyntax(string textContent)
        {
            LanguageServiceClient languageServiceClient = LanguageServiceClient.Create();
            // string textContent = "This is a short sentence."
            AnalyzeSyntaxRequest request = new AnalyzeSyntaxRequest
            {
                Document = new Document
                {
                    Type = Document.Types.Type.PlainText,
                    Content = "This is a short sentence.",
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

    // [END language_syntax_text]

    public class LanguageSyntaxTextMain {
        public static void Main(string[] args)
        {
            new Parser(with => with.CaseInsensitiveEnumValues = true).ParseArguments<Options>(args)
                .WithParsed<Options>(opts =>
                    LanguageSyntaxText.SampleAnalyzeSyntax(opts.TextContent));
        }

        public class Options
        {
            [Option("text_content", Default = "This is a short sentence.")]
            public string TextContent { get; set; }
        }
    }
}