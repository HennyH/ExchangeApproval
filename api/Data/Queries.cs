using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.ViewModels;

namespace ExchangeApproval.Data
{
    public static class Queries
    {
        public static IQueryable<string> QueryExchangeUniversities(ExchangeDbContext db, string name)
        {
            var query = db.UnitApprovalRequests.Where(r => r.DecisionDate != null);

            if (name != null)
            {
                query = query.Where(r => r.ExchangeUniversityName.Contains(name));
            }

            return query.Select(r => r.ExchangeUniversityName).Distinct();
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
            var query = db.UnitApprovalRequests.Where(r => r.DecisionDate != null);

            if (universityNames != null && universityNames.Count > 0)
            {
                query = query.Where(r => universityNames.Contains(r.ExchangeUniversityName));
            }
            if (uwaUnitContexts != null && uwaUnitContexts.Count > 0)
            {
                query = query.Where(r => uwaUnitContexts.Contains(r.UWAUnitContext));
            }
            if (uwaUnitLevels != null && uwaUnitLevels.Count > 0)
            {
                query = query.Where(r => r.UWAUnitLevel.HasValue && uwaUnitLevels.Contains(r.UWAUnitLevel.Value));
            }


            return query
                .GroupBy(r => new
                {
                    r.ExchangeUniversityName,
                    r.ExchangeUnitName,
                    r.ExchangeUnitCode,
                    r.UWAUnitContext,
                    r.UWAUnitCode,
                    r.UWAUnitName
                })
                .Select(g => g.OrderByDescending(r => r.DecisionDate).FirstOrDefault())
                .Select(r => new UnitApprovalDecisionVM
                {
                    DecisionDate = r.DecisionDate.Value,
                    ExchangeUniversityName = r.ExchangeUniversityName,
                    ExchangeUnitName = r.ExchangeUnitName,
                    ExchangeUnitCode = r.ExchangeUnitCode,
                    ExchangeUnitOutlineHref = r.ExchangeUnitOutlineHref,
                    UWAUnitName = r.UWAUnitName,
                    UWAUnitCode = r.UWAUnitCode,
                    UWAUnitLevel = r.UWAUnitLevel,
                    UWAUnitContext = r.UWAUnitContext,
                    Approved = r.Approved.Value
                });
        }
    }
}