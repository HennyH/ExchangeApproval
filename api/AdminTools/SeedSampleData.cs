using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using CsvHelper;
using ExchangeApproval.Data;

namespace ExchangeApproval.AdminTools
{
    public static class SeedSampleData
    {
        public static void SeedDatabase(ExchangeDbContext db)
        {
            /* Load default approvals */
            using (var reader = new StreamReader("api/AdminTools/approved-unit-sets.csv"))
            {
                var (errors, unitSets) = EquivalenceUnitSetsReader.LoadEquivalencies(reader);
                if (errors != null)
                {
                    Console.WriteLine(errors);
                    return;
                }
                EquivalenceUnitSetsReader.UpdateEquivalenciesInDatabase(db, unitSets);
            }

            db.Add(new StudentApplication
            {
                SubmittedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                StudentName = "Henry Hollingworth",
                StudentNumber = "21471423",
                Major1st = "Computer Science",
                ExchangeUniversityCountry = "Finalnd",
                ExchangeUniversityHref = "http://finalnd.com",
                ExchangeUniversityName = "Finland University",
                UnitSets = new UnitSet[]
                {
                    new UnitSet
                    {
                        ExchangeUniversityCountry = "Finalnd",
                        ExchangeUniversityHref = "http://finalnd.com",
                        ExchangeUniversityName = "Finland University",
                        IsContextuallyApproved = true,
                        IsEquivalent = null,
                        EquivalentUWAUnitLevel = UWAUnitLevel.Two,
                        ExchangeUnits = new ExchangeUnit[]
                        {
                            new ExchangeUnit
                            {
                                Code = "MATH-HARD",
                                Title = "The Hardest Math",
                                Href = "http://hard-math.com"
                            }
                        },
                        UWAUnits = new UWAUnit[]
                        {
                            new UWAUnit
                            {
                                Code = "MATH-1001",
                                Title = "Mathematics I",
                                Href = "http://uwa-unit.com"
                            },
                            new UWAUnit
                            {
                                Code = "MATH-1002",
                                Title = "Mathematics II",
                                Href = "http://uwa-unit.com"
                            }
                        }
                    }
                }
            });
            db.SaveChanges();
        }
    }
}