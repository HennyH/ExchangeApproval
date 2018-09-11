using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;


namespace ExchangeApproval.Data
{
    public static class SeedSampleData
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();

        static SeedSampleData()
        {
            AllocConsole();
        }

        private static int _NextID = 1;
        private static readonly Dictionary<string, List<int>> _NameToIdSet = new Dictionary<string, List<int>>();

        private static List<int> GetIds(string name, int count)
        {
            if (!_NameToIdSet.ContainsKey(name))
                _NameToIdSet[name] = Enumerable.Range(0, count).Select(_ => _NextID++).ToList();

            return _NameToIdSet[name];
        }

        public static int GetId(string name)
        {
            return GetIds(name, 1).Single();
        }
        

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

        public static IEnumerable<ExchangeApplicationUnitSet> CreateSeedExchangeApplicationUnitSets()
        {
            var staffLogons = CreateSeedUWAStaffLogons()
                .Where(l => l.Role == StaffRole.UnitCoordinator)
                .ToList();
            foreach (var id in GetIds("exchange-applications", 100))
            {
                foreach (var unitSet in CreateRandomExchangeApplication(id, staffLogons))
                {
                    yield return unitSet;
                };
            }
        }

        public static IEnumerable<UWAStaffLogon> CreateSeedUWAStaffLogons()
        {
            var users = new[]
            {
                new { Email = "ros@uwa.edu.au", Role = StaffRole.StudentOffice },
                new { Email = "mwise@uwa.edu.au", Role = StaffRole.UnitCoordinator }
            };
            return users.Zip(GetIds("staff-logons", users.Length), (u, id) =>
            {
                var salt = UWAStaffLogon.GenerateSalt();
                return new UWAStaffLogon
                {
                    Id = id,
                    Email = u.Email,
                    Role = u.Role,
                    Salt = salt,
                    PasswordHash = UWAStaffLogon.HashPassword("password", salt)
                };
            });
        }

        private static List<ExchangeApplicationUnitSet> CreateRandomExchangeApplication(int applicationId, List<UWAStaffLogon> unitCoordinators)
        {
            var unitSets = new List<ExchangeApplicationUnitSet>();
            var ids = GetIds("unit-sets" + applicationId.ToString(), Random.Next(2, 10));
            for (var k = 0; k < ids.Count; k++)
            {
                var id = ids[k];
                var unitContext = Random.Choose(Enum.GetValues(typeof(UWAUnitContext)).Cast<UWAUnitContext>().ToList());
                var unitLevel = Random.Choose(Enum.GetValues(typeof(UWAUnitLevel)).Cast<UWAUnitLevel>().ToList());
                var approvalDecidedUpon = Random.NextDouble() < 0.8 ? true : false;
                var equivalentPrecedent = unitContext == UWAUnitContext.Elective
                    ? (ExchangeApplicationUnitSet)null
                    : (
                        (k > 1 && Random.NextDouble() < 0.4)
                            ? unitSets[k - 1]
                            : null
                    );
                var equivlanceDecidedUpon = Random.NextDouble() < 0.5 ? true : false;
                var isMultiUnit = Random.NextDouble() < 0.2;
                var unitCoordinator = Random.Choose(unitCoordinators);

                unitSets.Add(new ExchangeApplicationUnitSet
                {
                    Id = id,
                    ApplicationId = applicationId,
                    ExchangeDate = new DateTime(Random.Next(2018, 2019), Random.Next(1, 13), Random.Next(1, 20)),
                    CourseCode = "BP0043",
                    ApprovalDecidedAt = approvalDecidedUpon
                        ? new DateTime(Random.Next(1995, 2019), Random.Next(1, 13), Random.Next(1, 20))
                        : (DateTime?)null,
                    IsApproved = approvalDecidedUpon
                        ? Random.NextDouble() < 0.5 ? true : false
                        : (bool?)null,
                    ExchangeUniversityName = Random.Choose(EXCHANGE_UNIVERSITIES),
                    ExchangeUniversityCountry = "England",
                    ExchangeUniversityHref = "https://university.com",
                    ExchangeUnits = isMultiUnit
                        ? new List<ExchangeUnit>
                        {
                            new ExchangeUnit
                            {
                                Code = "VM213",
                                Title = "Introduction to Solid Mechanics",
                                Href = "https://unit.com"
                            },
                            new ExchangeUnit
                            {
                                Code = "VM214",
                                Title = "Introduction to Fluid Mechanics",
                                Href = "https://unit.com"
                            },
                        }
                        : new List<ExchangeUnit>
                        {
                            new ExchangeUnit
                            {
                                Code = Random.Choose(UNITCODE_PREFIXES) + Random.Choose(UNITCODE_SUFFIX),
                                Title = string.Join(" ", Random.Sample(WORDS, Random.Next(2, 5))),
                                Href = "https://unit.com"
                            }
                        },
                    UWAUnits = new List<UWAUnit>
                    {
                        new UWAUnit
                        {
                            Code = isMultiUnit ? "ENG1002" : Random.Choose(UNITCODE_PREFIXES) + Random.Choose(UNITCODE_SUFFIX),
                            Title = isMultiUnit ? "Engineering Mechanics" : string.Join(" ", Random.Sample(WORDS, Random.Next(2, 5))),
                            Href = "https://unit.com",
                            Context = unitContext,
                            Level = unitLevel
                        }
                    },
                    EquivalenceDeciderId = unitContext == UWAUnitContext.Elective
                        ? null
                        : equivalentPrecedent?.EquivalenceDecider?.Id ?? (int?)unitCoordinator.Id,
                    EquivalenceDecidedAt = unitContext == UWAUnitContext.Elective || !equivlanceDecidedUpon
                        ? (DateTime?)null
                        : equivalentPrecedent?.EquivalenceDecidedAt ?? DateTime.Now,
                    IsEquivalent = unitContext == UWAUnitContext.Elective || !equivlanceDecidedUpon
                        ? (bool?)null
                        : equivalentPrecedent?.IsEquivalent ?? Random.NextDouble() < 0.6 ? true : false,
                    EquivalencePrecedentId = equivalentPrecedent?.Id,
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            UserEmail = unitCoordinator.Email,
                            Message = "Sample message",
                            PostedAt = new DateTime(Random.Next(2018, 2019), Random.Next(1, 13), Random.Next(1, 20))
                        }
                    }
                });
             }

            return unitSets;
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