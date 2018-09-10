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
                    Id = r.Id,
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

        public static void InsertNewStudentApplication(ExchangeDbContext db, ApplicationFormVM formVm)
        {
            db.Add(new ExchangeApplication
            {
                StudentEmail = formVm.Student.Email,
                Degree = formVm.Student.Degree,
                Major = formVm.Student.Major,
                Major2nd = formVm.Student.Major2nd,
                ExchangeUniversityName = formVm.ExchangeUniversity.UniversityName,
                ExchangeUniversityHref = formVm.ExchangeUniversity.UniversityHomepage,
                UnitApprovalRequests = formVm.ApprovalRequests.Select(r =>
                {
                    if (r.Id.HasValue)
                    {
                        return new UnitApprovalRequest { Id = r.Id.Value };
                    }

                    return new UnitApprovalRequest
                    {
                        DecisionDate = null,
                        Approved = null,
                        ExchangeUniversityName = r.ExchangeUniversityName,
                        ExchangeUnitCode = r.ExchangeUnitCode,
                        ExchangeUnitName = r.ExchangeUnitName,
                        ExchangeUnitOutlineHref = r.ExchangeUnitOutlineHref,
                        UWAUnitCode = r.UWAUnitCode,
                        UWAUnitContext = r.UWAUnitContext,
                        UWAUnitLevel = r.UWAUnitLevel,
                        UWAUnitName = r.UWAUnitName
                    };
                }).ToList()
            });
            db.SaveChanges();
        }

    }
}