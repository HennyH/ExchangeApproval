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
                IReadOnlyList<UWAUnitContext> uwaUnitContexts = null,
                IReadOnlyList<UWAUnitLevel> uwaUnitLevels = null
            )
        {
            var query = db.ExchangeApplicationUnitSets.AsQueryable();

            if (universityNames != null && universityNames.Count > 0)
            {
                query = query.Where(s => universityNames.Any(n => s.ExchangeUniversityName == n));
            }
            if (uwaUnitContexts != null && uwaUnitContexts.Count > 0)
            {
                query = query.Where(s => s.UWAUnits.Any(u => uwaUnitContexts.Contains(u.Context)));
            }
            if (uwaUnitLevels != null && uwaUnitLevels.Count > 0)
            {
                query = query.Where(s => s.UWAUnits.Any(u => uwaUnitLevels.Contains(u.Level)));
            }

            return query
                .Where(s => s.EquivalenceDecidedAt.HasValue || s.ApprovalDecidedAt.HasValue)
                .Select(s => new UnitSetDecisionVM
                {
                    UnitSetId = s.Id,
                    ApprovedAt = (s.ApprovalDecidedAt ?? s.EquivalenceDecidedAt).Value,
                    Approved = (s.ApprovalDecidedAt ?? s.EquivalenceDecidedAt).HasValue
                        ? (bool?)(s.IsEquivalent == true || s.IsApproved == true)
                        : null, 
                    ExchangeUniversityName = s.ExchangeUniversityName,
                    ExchangeUniversityHref = s.ExchangeUniversityHref,
                    ExchangeUnits = s.ExchangeUnits.Select(u => new UnitVM
                    {
                        UniversityName = s.ExchangeUniversityName,
                        UniversityHref = s.ExchangeUniversityHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href,
                        IsUWAUnit = false,
                        UWAUnitLevel = null
                    }).ToList(),
                    UWAUnits = s.UWAUnits.Select(u => new UnitVM
                    {
                        UniversityName = "University of Western Australia",
                        UniversityHref = "https://uwa.edu.au",
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href,
                        IsUWAUnit = true,
                        UWAUnitLevel = new SelectOption<UWAUnitLevel>(u.Level, true),
                        UWAUnitContext = new SelectOption<UWAUnitContext>(u.Context, true),
                    }).ToList()
                })
                .GroupBy(d => new
                {
                    UWAUnits = d.UWAUnits.Select(u => new { u.UnitName, u.UnitCode, u.UniversityName }),
                    ExchangeUnits = d.ExchangeUnits.Select(u => new { u.UnitName, u.UnitCode, u.UniversityName })
                })
                .Select(g => g.OrderByDescending(d => d.ApprovedAt).FirstOrDefault());
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