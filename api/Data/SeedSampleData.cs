using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using CsvHelper;

namespace ExchangeApproval.Data
{
    public static class SeedSampleData
    {
        //[DllImport("kernel32")]
        //static extern bool AllocConsole();

        //static SeedSampleData()
        //{
        //    AllocConsole();
        //}

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

        public static string ToTitleCase(this string s)
        {
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(s);
        }

        public static (IList<ExchangeApplicationUnitSet>, IList<UWAStaffLogon>) LoadSampleData()
        {
            var unitSets = new List<ExchangeApplicationUnitSet>();
            var uwaStaffLogons = new List<UWAStaffLogon>();
            byte[] salt;

            UWAUnitLevel guessUnitLevel(string unitCode)
            {
                var n = unitCode.Trim("ABCDEFGHIJKLMNOPQRSTUVQXYZ".ToArray()).ToArray().FirstOrDefault();
                switch (n)
                {
                    case '1':
                        return UWAUnitLevel.One;
                    case '2':
                        return UWAUnitLevel.Two;
                    case '3':
                        return UWAUnitLevel.Three;
                    case '4':
                        return UWAUnitLevel.Four;
                    default:
                        return UWAUnitLevel.GtFour;
                }
            }

            try
            {
                using (var parser = new StreamReader("api/Data/sample-data.csv"))
                using (var csv = new CsvReader(parser))
                {
                    while (csv.Read())
                    {
                        var approvedText = csv.GetField(0);
                        var yearText = csv.GetField(1);
                        var studentNumberText = csv.GetField(2);
                        var courseCodeText = csv.GetField(3);
                        var decisionDateText = csv.GetField(4);
                        var exchangeUniText = csv.GetField(5);
                        var exchangeCountryText = csv.GetField(6);
                        var uwaUnitCodesText = csv.GetField(7);
                        var exchangeUnitCodesText = csv.GetField(8);
                        var exchangeUnitTitleText = csv.GetField(9);
                        var approvedByText = csv.GetField(10);
                        var commentsText = csv.GetField(11);

                        bool isApproved = approvedText == "Y";
                        DateTime exchangeDate = new DateTime(int.Parse(yearText), Random.Next(1, 12), Random.Next(1, 20));
                        string studentNumber = studentNumberText.Trim();
                        string courseCode = courseCodeText.Trim();
                        DateTime approvedAt = exchangeDate.AddDays(-60);
                        string exchangeUniversityName = exchangeUniText.Trim().ToTitleCase();
                        string exchangeCountryName = exchangeUniText.Trim().ToTitleCase();
                        string[] uwaUnitCodes = uwaUnitCodesText.Trim().Split(" & ").Select(c => c.Trim().ToUpperInvariant()).ToArray();
                        string[] exchangeUnitCodes = exchangeUnitCodesText.Trim().Split(" & ").Select(c => c.Trim().ToUpperInvariant()).ToArray();
                        string[] exchangeUnitTitles = exchangeUnitTitleText.Trim().Split(" & ").Select(n => n.Trim().ToTitleCase()).ToArray();
                        string[] signedOffByEmails = approvedByText
                            .Trim()
                            .Split(" and ")
                            .Select(n => n.Trim().ToLowerInvariant().Replace(" ", "."))
                            .Select(n => $"{n}@staff.uwa.edu")
                            .ToArray();
                        string comments = commentsText.Trim();

                        unitSets.Add(new ExchangeApplicationUnitSet
                        {
                            Id = unitSets.Count + 1,
                            ApplicationId = int.Parse(studentNumber) % 200,
                            StudentNumber = studentNumber,
                            ExchangeDate = exchangeDate,
                            CourseCode = courseCode,
                            ApprovalDecidedAt = approvedAt,
                            IsApproved = isApproved,
                            ExchangeUniversityCountry = exchangeCountryName,
                            ExchangeUniversityName = exchangeUniversityName,
                            ExchangeUniversityHref = "https://university.com",
                            ExchangeUnits = exchangeUnitCodes.Zip(exchangeUnitTitles, (code, title) => new ExchangeUnit
                            {
                                Code = code,
                                Title = title,
                                Href = "https://unit.com"
                            }).ToList(),
                            UWAUnits = uwaUnitCodes.Select(code => new UWAUnit
                            {
                                Code = code,
                                Title = string.Join(" ", Random.Sample(WORDS, Random.Next(2, 5))),
                                Href = "https://uwa.edu.au",
                                Level = guessUnitLevel(code),
                                Context = Random.Choose(new[] { UWAUnitContext.Core, UWAUnitContext.Complementary })
                            }).ToList(),
                            EquivalencePrecedentUnitSetId = null,
                            EquivalencePrecedentUnitSet = null,
                            UnitEquivalenceDecisions = signedOffByEmails.Select(e => new UnitEquivalenceDecision
                            {
                                DecisionMakerEmail = e,
                                DecidedAt = approvedAt,
                                IsEquivalent = isApproved,
                                Comment = new Comment
                                {
                                    UserEmail = e,
                                    PostedAt = approvedAt,
                                    Message = comments
                                }
                            }).ToList()
                        });

                        foreach (var staffEmail in signedOffByEmails)
                        {
                            if (uwaStaffLogons.Any(l => l.Email == staffEmail))
                                continue;
                            salt = UWAStaffLogon.GenerateSalt();
                            uwaStaffLogons.Add(new UWAStaffLogon
                            {
                                Id = uwaStaffLogons.Count + 1,
                                Email = staffEmail,
                                Role = StaffRole.UnitCoordinator,
                                Salt = salt,
                                PasswordHash = UWAStaffLogon.HashPassword("password", salt)
                            });
                        }
                    }
                }

                salt = UWAStaffLogon.GenerateSalt();
                uwaStaffLogons.Add(new UWAStaffLogon
                {
                    Id = uwaStaffLogons.Count + 1,
                    Email = "ros@uwa.edu.au",
                    Role = StaffRole.StudentOffice,
                    Salt = salt,
                    PasswordHash = UWAStaffLogon.HashPassword("password", salt)
                });

                return (unitSets, uwaStaffLogons);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}\n{1}", ex.Message, ex.StackTrace);
                return (unitSets, uwaStaffLogons);
            }
        }
    }
}