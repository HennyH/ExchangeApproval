using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.api.Data;
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

        public static IEnumerable<UnitSetDecisionVM> QueryUnitApprovalDecisions(
                ExchangeDbContext db,
                IReadOnlyList<string> universityNames = null,
                IReadOnlyList<UWAUnitLevel> uwaUnitLevels = null
            )
        {
            var applications = QueryApplications(db)
                .Where(a => a.ApplicationCompletedAt != null);

            if (universityNames != null && universityNames.Count > 0)
            {
                applications = applications.Where(s => universityNames.Contains(s.ExchangeUniversityName));
            }

            var applicationUnitSets = applications.SelectMany(a => a.UnitSets.Select(us => new
            {
                Application = a,
                UnitSet = us
            }));

            if (uwaUnitLevels != null && uwaUnitLevels.Count > 0)
            {
                applicationUnitSets = applicationUnitSets.Where(s =>
                    s.UnitSet.EquivalentUWAUnitLevel.HasValue
                    && uwaUnitLevels.Contains(s.UnitSet.EquivalentUWAUnitLevel.Value)
                );
            }

            return applicationUnitSets.Select(aus => new UnitSetDecisionVM
            {
                UnitSetId = aus.UnitSet.UnitSetId,
                DecisionDate = aus.Application.ApplicationCompletedAt,
                Approved = aus.UnitSet.EquivalentUWAUnitLevel.HasValue
                    && aus.UnitSet.EquivalentUWAUnitLevel != UWAUnitLevel.Zero
                    && aus.UnitSet.IsEquivalent.HasValue
                    && aus.UnitSet.IsEquivalent.Value,
                ExchangeUniversityName = aus.Application.ExchangeUniversityName,
                ExchangeUniversityHref = aus.Application.ExchangeUniversityHref,
                ExchangeUnits = aus.UnitSet.ExchangeUnits.Select(eu => new UnitVM
                {
                    UniversityName = aus.Application.ExchangeUniversityName,
                    UniversityHref = aus.Application.ExchangeUniversityHref,
                    UnitCode = eu.Code,
                    UnitName = eu.Title,
                    UnitHref = eu.Href
                }),
                UWAUnits = aus.UnitSet.UWAUnits.Select(eu => new UnitVM
                {
                    UniversityName = ReferenceData.UWAName,
                    UniversityHref = ReferenceData.UWAHref,
                    UnitCode = eu.Code,
                    UnitName = eu.Title,
                    UnitHref = eu.Href
                }),
                EquivalentUnitLevel = aus.UnitSet.EquivalentUWAUnitLevel.HasValue
                    ? new SelectOption<UWAUnitLevel>(
                        aus.UnitSet.EquivalentUWAUnitLevel.Value,
                        aus.UnitSet.EquivalentUWAUnitLevel.Value.GetLabel(),
                        true
                    )
                    : null
            });
        }

        public static IQueryable<StudentApplicationBO> QueryApplications(ExchangeDbContext db)
        {
            return db.ExchangeApplicationUnitSets
                .GroupBy(us => us.ApplicationId)
                .Select(uss => new StudentApplicationBO
                {
                    ApplicationId = uss.FirstOrDefault().ApplicationId,
                    ApplicationSubmittedAt = uss.FirstOrDefault().ApplicationSubmittedAt,
                    ApplicationCompletedAt = uss.FirstOrDefault().ApplicationCompletedAt,
                    ExchangeDate = uss.FirstOrDefault().ExchangeDate,
                    StudentName = uss.FirstOrDefault().StudentName,
                    StudentNumber = uss.FirstOrDefault().StudentNumber,
                    Major1st = uss.FirstOrDefault().Major1st,
                    Major2nd = uss.FirstOrDefault().Major2nd,
                    ExchangeUniversityCountry = uss.FirstOrDefault().ExchangeUniversityCountry,
                    ExchangeUniversityName = uss.FirstOrDefault().ExchangeUniversityName,
                    ExchangeUniversityHref = uss.FirstOrDefault().ExchangeUniversityHref,
                    Notes = uss.FirstOrDefault().Notes,
                    UnitSets = uss.Select(us => new UnitSetBO
                    {
                        UnitSetId = us.UnitSetId,
                        ExchangeUnits = us.ExchangeUnits.Select(eu => new ExchangeUnitBO
                        {
                            Code = eu.Code,
                            Title = eu.Title,
                            Href = eu.Href
                        }),
                        UWAUnits = us.UWAUnits.Select(uwau => new UWAUnitBO
                        {
                            Code = uwau.Code,
                            Title = uwau.Title,
                            Href = uwau.Href
                        }),
                        EquivalentUWAUnitLevel = us.EquivalentUWAUnitLevel,
                        IsEquivalent = us.IsEquivalent,
                        IsContextuallyApproved = us.IsContextuallyApproved,
                        EquivalencePrecedentApplicationId = us.EquivalencePrecedentId
                    }),
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