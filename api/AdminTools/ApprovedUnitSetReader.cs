using System.Collections.Generic;
using System.IO;
using ExchangeApproval.Data;
using CsvHelper;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApproval.AdminTools
{
    public class EquivalenceUnitSetRow
    {
        public int UnitSetId { get; set; }
        public bool IsExchangeUnit { get; set; }
        public string UniversityCountry { get; set; }
        public string UniversityName { get; set; }
        public string UniversityHref { get; set; }
        public string UnitTitle { get; set; }
        public string UnitCode { get; set; }
        public string UnitHref { get; set; }
        public UWAUnitLevel EquivalentUWAUnitLevel { get; set; }
        public bool IsEquivalent { get; set; }
    }

    public static class EquivalenceUnitSetsReader
    {
        public static IList<(int line, string error)> ValidateRows(IReadOnlyCollection<EquivalenceUnitSetRow> rows)
        {
            var errors = new List<string>();
            /* +1 for 0 offset, and +1 for the header */
            var numberedRows = rows.Select((r, i) => new { LineNumber = i + 2, Row = r });

            var invalidUnitLevel = numberedRows
                .Where(r => r.Row.EquivalentUWAUnitLevel == UWAUnitLevel.Zero)
                .Select(r => (Row: r, LineNumber: r.LineNumber, Message: "Approved unit set cannot be equivalent to a level 0 unit."));
            var badUnitLevelForGroup = numberedRows
                .GroupBy(r => r.Row.UnitSetId)
                .Where(g => g.Select(r => r.Row.EquivalentUWAUnitLevel).Distinct().Count() > 1)
                .SelectMany(g => g)
                .Select(r => (Row: r, LineNumber: r.LineNumber, Message: "The group of unit sets must have the same equivalence level for each row."));
            var badIsEquivalentForGroup = numberedRows
                .GroupBy(r => r.Row.UnitSetId)
                .Where(g => g.Select(r => r.Row.IsEquivalent).Distinct().Count() > 1)
                .SelectMany(g => g)
                .Select(r => (Row: r, LineNumber: r.LineNumber, Message: "The group of unit sets must have the same 'is equivalent' value for each row."));
            var missingExchangeUnit = numberedRows
                .GroupBy(r => r.Row.UnitSetId)
                .Where(g => !g.Any(r => r.Row.IsExchangeUnit))
                .SelectMany(g => g)
                .Select(r => (Row: r, LineNumber: r.LineNumber, Message: "A unit set group must include at least one exchange unit."));
            var missingUnitCode = numberedRows
                .Where(r => string.IsNullOrWhiteSpace(r.Row.UnitCode))
                .Select(r => (Row: r, LineNumber: r.LineNumber, Message: "A unit set must include a unit code."));
            var missingUniversityName = numberedRows
                .Where(r => string.IsNullOrWhiteSpace(r.Row.UniversityName))
                .Select(r => (Row: r, LineNumber: r.LineNumber, Message: "A unit set must a university name."));
            return invalidUnitLevel
                .Union(badUnitLevelForGroup)
                .Union(missingExchangeUnit)
                .Union(missingUnitCode)
                .Union(badIsEquivalentForGroup)
                .Select(t => (t.LineNumber, t.Message))
                .ToList();
        }

        public static (IList<(int line, string error)> Errors, IEnumerable<UnitSet> unitSets) LoadEquivalencies(TextReader reader)
        {
            var csv = new CsvReader(reader);
            try
            {
                var rows = csv.GetRecords<EquivalenceUnitSetRow>().ToList();
                var errors = ValidateRows(rows);
                if (errors.Count > 0)
                {
                    return (errors, null);
                }
                var approvedUnitSets = rows
                    .GroupBy(r => r.UnitSetId)
                    .Select(g =>
                    {
                        var firstExchangeUnit = g.First(u => u.IsExchangeUnit);
                        return new UnitSet
                        {
                            IsEquivalent = firstExchangeUnit.IsEquivalent,
                            IsContextuallyApproved = null,
                            EquivalentUWAUnitLevel = firstExchangeUnit.EquivalentUWAUnitLevel,
                            ExchangeUniversityName = firstExchangeUnit.UniversityName,
                            ExchangeUniversityCountry = firstExchangeUnit.UniversityCountry,
                            ExchangeUniversityHref = firstExchangeUnit.UniversityHref,
                            ExchangeUnits = g
                                .Where(r => r.IsExchangeUnit)
                                .Select(r => new ExchangeUnit
                                {
                                    Code = r.UnitCode,
                                    Title = r.UnitTitle,
                                    Href = r.UnitHref
                                }).ToList(),
                            UWAUnits = g
                                .Where(r => !r.IsExchangeUnit)
                                .Select(r => new UWAUnit
                                {
                                    Code = r.UnitCode,
                                    Title = r.UnitTitle,
                                    Href = r.UnitHref
                                }).ToList()
                        };
                    });
                return (null, approvedUnitSets);
            }
            catch (ValidationException ex)
            {
                return (new[] { (0, ex.Message.Split(".").First()) }, null);
            }
        }

        public static IEnumerable<EquivalenceUnitSetRow> DumpEquivalencies(ExchangeDbContext db)
        {
            return db.UnitSets
                .Where(us => us.StudentApplicationId == null)
                .Select(us => new
                {
                    LastUpdated = us.StudentApplicationId == null ? (DateTime?)null : us.StudentApplication.LastUpdatedAt,
                    UniversityCountry = us.ExchangeUniversityCountry,
                    UniversityName = us.ExchangeUniversityName,
                    UniversityHref = us.ExchangeUniversityHref,
                    ExchangeUnits = us.ExchangeUnits.Select(u => new EquivalenceUnitSetRow
                    {
                        UnitSetId = us.UnitSetId,
                        IsExchangeUnit = true,
                        UniversityCountry = us.ExchangeUniversityCountry,
                        UniversityName = us.ExchangeUniversityName,
                        UniversityHref = us.ExchangeUniversityHref,
                        UnitTitle = u.Title,
                        UnitCode = u.Code,
                        UnitHref = u.Href,
                        IsEquivalent = us.IsEquivalent.GetValueOrDefault(),
                        EquivalentUWAUnitLevel = us.EquivalentUWAUnitLevel.GetValueOrDefault(UWAUnitLevel.One)
                    }).ToList(),
                    UWAUnits = us.UWAUnits.Select(u => new EquivalenceUnitSetRow
                    {
                        UnitSetId = us.UnitSetId,
                        IsExchangeUnit = false,
                        UniversityCountry = ReferenceData.UWACountry,
                        UniversityName = ReferenceData.UWAName,
                        UniversityHref = ReferenceData.UWAHref,
                        UnitTitle = u.Title,
                        UnitCode = u.Code,
                        UnitHref = u.Href,
                        IsEquivalent = us.IsEquivalent.GetValueOrDefault(),
                        EquivalentUWAUnitLevel = us.EquivalentUWAUnitLevel.GetValueOrDefault(UWAUnitLevel.One)
                    }).ToList()
                })
                .GroupBy(us => new
                {
                    us.UniversityCountry,
                    us.UniversityName,
                    UWAUnits = string.Join(',', us.UWAUnits.Select(u => u.UnitCode)),
                    ExchangeUnits = string.Join(',', us.ExchangeUnits.Select(u => u.UnitCode))
                })
                .Select(g => g.OrderByDescending(us => us.LastUpdated).First())
                .SelectMany(agg => agg.ExchangeUnits.Union(agg.UWAUnits))
                .OrderBy(r => r.UnitSetId)
                .ThenBy(r => r.IsExchangeUnit)
                .ThenBy(r => r.UnitCode)
                .ToList();
        }

        public static void UpdateEquivalenciesInDatabase(ExchangeDbContext db, IEnumerable<UnitSet> newManualUnitApprovals)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                var existingManualUnitSets = db.UnitSets.AsNoTracking().Where(u => u.StudentApplicationId == null).ToList();
                db.RemoveRange(existingManualUnitSets);
                db.AddRange(newManualUnitApprovals);
                db.SaveChanges();
                transaction.Commit();
            }
        }
    }
}