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

// This is a generated sample ("Request", "analyze_text_sentiment")

// sample-metadata
//   title:
//   description: This sample demonstrates analyzing the sentiment of text
//   usage: dotnet run

using CommandLine;

namespace Google.Cloud.Language.V1.Samples
{
    // [START analyze_text_sentiment]
    using Google.Cloud.Language.V1;
    using System;

    public class AnalyzeTextSentiment
    {
        /// <summary>
        /// This sample demonstrates analyzing the sentiment of text
        /// </summary>
        public static void SampleAnalyzeSentiment()
        {
            LanguageServiceClient languageServiceClient = LanguageServiceClient.Create();
            AnalyzeSentimentRequest request = new AnalyzeSentimentRequest
            {
                Document = new Document
                {
                    Type = Document.Types.Type.PlainText,
                    Content = "I am so happy",
                },
            };
            AnalyzeSentimentResponse response = languageServiceClient.AnalyzeSentiment(request);
            Console.WriteLine(response);
        }
    }

    // [END analyze_text_sentiment]

    public class AnalyzeTextSentimentMain {
        public static void Main(string[] args)
        {
            AnalyzeTextSentiment.SampleAnalyzeSentiment();
        }
    }
}