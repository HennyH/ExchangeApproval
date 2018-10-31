using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApproval.Data
{
    public static class Queries
    {
        public static IQueryable<string> QueryExchangeUniversities(ExchangeDbContext db, string searchText)
        {
            return db.StudentApplications
                .Select(s => s.ExchangeUniversityName)
                .Where(n => searchText == null || n.Contains(searchText))
                .Distinct();
        }

        public static IEnumerable<(UnitSet UnitSet, List<ExchangeUnit> ExchangeUnits, List<UWAUnit> UWAUnits)> QueryUnitSets(
                ExchangeDbContext db,
                IReadOnlyList<string> universityNames = null,
                IReadOnlyList<UWAUnitLevel> uwaUnitLevels = null
            )
        {
            return db.UnitSets
                .AsNoTracking()
                .Include(u => u.ExchangeUnits)
                .Include(u => u.UWAUnits)
                .Where(a =>
                    universityNames == null ||
                    universityNames.Count() == 0
                    || universityNames.Contains(a.ExchangeUniversityName))
                .Where(us =>
                        uwaUnitLevels == null ||
                        uwaUnitLevels.Count() == 0 ||
                        !us.EquivalentUWAUnitLevel.HasValue ||
                        uwaUnitLevels.Contains(us.EquivalentUWAUnitLevel.Value))
                .ToList()
                .Select(us => (
                    UnitSet: us,
                    ExchangeUnits: us.ExchangeUnits.ToList(),
                    UWAUnits: us.UWAUnits.ToList()
                ));
        }

        public static IQueryable<StudentApplication> QueryApplications(ExchangeDbContext db)
        {
            return db.StudentApplications.AsQueryable();
        }

        public static bool QueryIsValidStaffLogon(ExchangeDbContext db, string email, string password)
        {
            var user = db.StaffLogons
                .Where(l => l.Username == email)
                .Select(l => new { l.Salt, l.PasswordHash })
                .FirstOrDefault();
            if (user == null)
                return false;
            return user.PasswordHash == UWAStaffLogon.HashPassword(password, user.Salt);
        }
    }
}