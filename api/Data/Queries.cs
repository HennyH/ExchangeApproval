using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.ViewModels;

namespace ExchangeApproval.Data
{
    public static class Queries
    {
        public static IQueryable<string> QueryExchangeUniversities(ExchangeDbContext db, string searchText)
        {
            return db.ExchangeApplicationUnitSets
                .Select(s => s.ExchangeUniversityName)
                .Where(n => searchText == null || n.Contains(searchText))
                .Distinct();
        }

        public static IQueryable<UnitSetDecisionVM> QueryUnitApprovalDecisions(
                ExchangeDbContext db,
                IReadOnlyList<string> universityNames = null,
                IReadOnlyList<UWAUnitLevel> uwaUnitLevels = null
            )
        {
            var query = db.ExchangeApplicationUnitSets.AsQueryable();

            if (universityNames != null && universityNames.Count > 0)
            {
                query = query.Where(s => universityNames.Any(n => s.ExchangeUniversityName == n));
            }
            if (uwaUnitLevels != null && uwaUnitLevels.Count > 0)
            {
                query = query.Where(s => s.EquivalentUWAUnitLevel.HasValue && uwaUnitLevels.Contains(s.EquivalentUWAUnitLevel.Value));
            }

            return query
                .GroupBy(s => new { s.UWAUnits, s.ExchangeUnits, s.ExchangeUniversityName })
                .SelectMany(g => g.Distinct())
                .OrderByDescending(s => s.LastUpdatedAt)
                .ThenByDescending(s => s.ExchangeUniversityName)
                .Select(s => new UnitSetDecisionVM
                {
                    UnitSetId = s.Id,
                    LastUpdatedAt = s.LastUpdatedAt,
                    Approved =
                        (s.RequiresEquivalenceDecision && s.IsEquivalent == true)
                        || (!s.RequiresEquivalenceDecision && s.EquivalentUWAUnitLevel != UWAUnitLevel.Zero),
                    ExchangeUniversityName = s.ExchangeUniversityName,
                    ExchangeUniversityHref = s.ExchangeUniversityHref,
                    ExchangeUnits = s.ExchangeUnits.Select(u => new UnitVM
                    {
                        UniversityName = s.ExchangeUniversityName,
                        UniversityHref = s.ExchangeUniversityHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href
                    }).ToList(),
                    UWAUnits = s.UWAUnits.Select(u => new UnitVM
                    {
                        UniversityName = "University of Western Australia",
                        UniversityHref = "https://uwa.edu.au",
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href,
                    }).ToList(),
                    EquivalentUnitLevel = s.EquivalentUWAUnitLevel == null
                        ? null
                        : new SelectOption<UWAUnitLevel>(s.EquivalentUWAUnitLevel.Value, true)
                });
        }

        public static bool QueryIsValidStaffLogon(ExchangeDbContext db, string email, string password)
        {
            var user = db.StaffLogons
                .Where(l => l.Email == email)
                .Select(l => new { l.Salt, l.PasswordHash })
                .FirstOrDefault();
            if (user == null)
                return false;
            return user.PasswordHash == UWAStaffLogon.HashPassword(password, user.Salt);
        }
    }
}