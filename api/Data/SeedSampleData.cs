using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ExchangeApproval.Data
{
    public static class SeedSampleData
    {
        readonly static Random Random = new Random();

        public static T Choose<T>(this Random rnd, IReadOnlyList<T> choices)
        {
            var index = rnd.Next(choices.Count);
            return choices[index];
        }

        public static IReadOnlyList<T> Sample<T>(this Random rnd, IReadOnlyList<T> choices, int numberOfSamples)
        {
            return Enumerable.Range(0, numberOfSamples).Select(i => rnd.Choose(choices)).ToArray();
        }

        public static IEnumerable<UnitApprovalRequest> CreateSeedUnitApprovalRequests()
        {
            for (var i = 1; i <= 100; i++)
            {
                yield return CreateRandomUnitApprovalRequest(i);
            }
        }

        public static UnitApprovalRequest CreateRandomUnitApprovalRequest(int id)
        {
            var decidedUpon = Random.NextDouble() < 0.8 ? true : false;
            var x = new UnitApprovalRequest()
            {
                Id = id,
                DecisionDate = decidedUpon
                    ? new DateTime(Random.Next(1995, 2019), Random.Next(1, 13), Random.Next(1, 20))
                    : (DateTime?)null,
                ExchangeUniversityName = Random.Choose(EXCHANGE_UNIVERSITIES),
                ExchangeUnitName = string.Join(" ", Random.Sample(WORDS, Random.Next(2, 5))),
                ExchangeUnitCode = Random.Choose(UNITCODE_PREFIXES) + Random.Choose(UNITCODE_SUFFIX),
                ExchangeUnitOutlineHref = "https://university.com",
                UWAUnitName = string.Join(" ", Random.Sample(WORDS, Random.Next(2, 5))),
                UWAUnitCode = Random.Choose(UNITCODE_PREFIXES) + Random.Choose(UNITCODE_SUFFIX),
                UWAUnitLevel = Random.Choose(Enum.GetValues(typeof(UWAUnitLevel)).Cast<UWAUnitLevel>().ToList()),
                UWAUnitContext = Random.Choose(Enum.GetValues(typeof(UWAUnitContext)).Cast<UWAUnitContext>().ToList()),
                Approved = decidedUpon
                    ? Random.NextDouble() < 0.8 ? true : false
                    : (bool?)null
            };
            return x;
        }

        public readonly static string[] UNITCODE_PREFIXES = new string[]
        {
            "ART",
            "MATH",
            "SCI",
            "COMP",
            "CITS",
            "ANTH",
            "CHEM",
            "BIO",
            "STAT",
            "INFR",
            "MGMT",
            "ALGS"
        };

        public readonly static string[] UNITCODE_SUFFIX = new string[]
        {
            "1000",
            "2000",
            "3000",
            "4000",
            "1020",
            "3030",
            "10",
            "100-3",
            "200-2",
            "3.12",
            "293.12",
            "-1"
        };

        public readonly static string[] EXCHANGE_UNIVERSITIES = new string[]
        {
            "University of New York",
            "University of Los Angeles",
            "University of Chicago",
            "University of Houston",
            "University of Philadelphia",
            "University of Phoenix",
            "University of San Antonio",
            "University of San Diego",
            "University of Dallas",
            "University of San Jose",
            "University of Austin",
            "University of Jacksonville",
            "University of San Francisco",
            "University of Indianapolis",
            "University of Columbus",
            "University of Fort Worth",
            "University of Charlotte",
            "University of Detroit"
        };

        public readonly static string[] WORDS = new string[]
        {
            "people",
            "history",
            "way",
            "art",
            "world",
            "information",
            "map",
            "two",
            "family",
            "government",
            "health",
            "system",
            "computer",
            "meat",
            "year",
            "thanks",
            "music",
            "person",
            "reading",
            "method",
            "data",
            "food",
            "understanding",
            "theory",
            "law",
            "bird",
            "literature",
            "problem",
            "software",
            "control",
            "knowledge",
            "power",
            "ability",
            "economics",
            "love",
            "internet",
            "television",
            "science",
            "library",
            "nature",
            "fact",
            "product",
            "idea",
            "temperature",
            "investment",
            "area",
            "society",
            "activity",
            "story",
            "industry",
            "media",
            "thing",
            "oven",
            "community",
            "definition",
            "safety",
            "quality",
            "development",
            "language",
            "management",
            "player",
            "variety",
            "video",
            "week",
            "security",
            "country",
            "exam",
            "movie",
            "organization",
            "equipment",
            "physics",
            "analysis",
            "policy",
            "series",
            "thought",
            "basis",
            "boyfriend",
            "direction",
            "strategy",
            "technology",
            "army",
            "camera",
            "freedom",
            "paper",
            "environment",
            "child",
            "instance"
        }.Select(w => new CultureInfo("en-US", false).TextInfo.ToTitleCase(w)).ToArray();
    }
}