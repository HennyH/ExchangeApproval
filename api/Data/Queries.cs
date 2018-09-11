using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.ViewModels;

namespace ExchangeApproval.Data
{
    public static class Queries
    {
        public static IQueryable<string> QueryExchangeUniversities(ExchangeDbContext db, string searchText)
        {
            var query = db.ExchangeApplicationUnitSets
                .Select(s => s.ExchangeUniversity)
                .Where(n => searchText == null || n.Contains(searchText))
                .Distinct();
        }

        public static IQueryable<UnitApprovalDecisionVM> QueryUnitApprovalDecisions(
                ExchangeDbContext db,
                IReadOnlyList<string> universityNames = null,
                IReadOnlyList<UWAUnitContext> uwaUnitContexts = null,
                IReadOnlyList<UWAUnitLevel> uwaUnitLevels = null
            )
        {
            /* Requests are only considered 'decisions' once they have been
             * decided upon. When one is decided upon the DecisionDate will be
             * set.
             */
            var query = db.ExchangeApplicationUnitSets
                .Where(s => s.UW);
            
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