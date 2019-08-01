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

// This is a generated sample ("Request", "language_sentiment_text")

// sample-metadata
//   title:
//   description: Analyze sentiment of text
//   usage: dotnet run [--text_content "I am so happy and joyful."]

using CommandLine;

namespace Google.Cloud.Language.V1.Samples
{
    // [START language_sentiment_text]
    using Google.Cloud.Language.V1;
    using System;

    public class LanguageSentimentText
    {
        /// <summary>
        /// Analyze sentiment of text
        /// </summary>
        public static void SampleAnalyzeSentiment(string textContent)
        {
            LanguageServiceClient languageServiceClient = LanguageServiceClient.Create();
            // string textContent = "I am so happy and joyful."
            AnalyzeSentimentRequest request = new AnalyzeSentimentRequest
            {
                Document = new Document
                {
                    Type = Document.Types.Type.PlainText,
                    Content = "I am so happy and joyful.",
                },
            };
            AnalyzeSentimentResponse response = languageServiceClient.AnalyzeSentiment(request);
            Sentiment sentiment = response.DocumentSentiment;
            Console.WriteLine($"Sentiment score: {sentiment.Score}");
            Console.WriteLine($"Magnitude: {sentiment.Magnitude}");
        }
    }

    // [END language_sentiment_text]

    public class LanguageSentimentTextMain {
        public static void Main(string[] args)
        {
            new Parser(with => with.CaseInsensitiveEnumValues = true).ParseArguments<Options>(args)
                .WithParsed<Options>(opts =>
                    LanguageSentimentText.SampleAnalyzeSentiment(opts.TextContent));
        }

        public class Options
        {
            [Option("text_content", Default = "I am so happy and joyful.")]
            public string TextContent { get; set; }
        }
    }
}