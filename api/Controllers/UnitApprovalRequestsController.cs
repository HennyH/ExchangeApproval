using System;
using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ExchangeApproval.Data.Queries;
using System.Net;

namespace ExchangeApproval.Controllers
{
    [Route("api/requests")]
    public class UnitApprovalRequestsController : Controller
    {
        private readonly ExchangeDbContext _db;

        public UnitApprovalRequestsController(ExchangeDbContext db)
        {
            this._db = db;
        }

        [HttpGet("universities")]
        public IEnumerable<string> Universities()
        {
            return QueryExchangeUniversities(_db, null).ToList();
        }

        [HttpGet("filters")]
        public DecisionsSearchFilterVM Filters()
        {
            return new DecisionsSearchFilterVM
            {
                ExchangeUniversityNames = Universities()
                    .OrderByDescending(n => n)
                    .Select(n => new SelectOption<string>(n, n.ToString()))
                    .ToList(),
                UWAUnitContextOptions = Enum
                    .GetValues(typeof(UWAUnitContext))
                    .Cast<UWAUnitContext>()
                    .Select(c => new SelectOption<UWAUnitContext>(c, c.ToString(), true))
                    .ToList(),
                UWAUnitLevelOptions = Enum
                    .GetValues(typeof(UWAUnitLevel))
                    .Cast<UWAUnitLevel>()
                    .Select(l => new SelectOption<UWAUnitLevel>(l, l.GetLabel(), true))
                    .ToList()
            };
        }

        [HttpGet("decisions")]
        public IEnumerable<UnitSetDecisionVM> ApprovalRequests(
                string[] universityNames,
                UWAUnitLevel[] uwaUnitLevels
            )
        {
            var unitSets = QueryUnitSets(this._db, universityNames, uwaUnitLevels).ToList();
            return unitSets
                .Select(us => new UnitSetDecisionVM
                {
                    ExchangeUniversityName = us.ExchangeUniversityName,
                    ExchangeUniversityHref = us.ExchangeUniversityHref,
                    UnitSetId = us.UnitSetId,
                    DecisionDate = us.CompletedAt,
                    Approved =
                        us.IsEquivalent.HasValue
                        && us.IsEquivalent.Value
                        && us.EquivalentUWAUnitLevel.HasValue
                        && us.EquivalentUWAUnitLevel.Value != UWAUnitLevel.Zero,
                    ExchangeUnits = us.ExchangeUnits.Select(u => new UnitVM
                    {
                        UnitId = u.Id,
                        UniversityName = us.ExchangeUniversityName,
                        UniversityHref = us.ExchangeUniversityHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href
                    }),
                    UWAUnits = us.UWAUnits.Select(u => new UnitVM
                    {
                        UnitId = u.Id,
                        UniversityName = ReferenceData.UWAName,
                        UniversityHref = ReferenceData.UWAHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href
                    })
                })
                .GroupBy(d => new
                {
                    d.ExchangeUniversityName,
                    ExchangeUnits = d.UWAUnits.Select(u => new { u.UniversityName, u.UnitCode, u.UnitName }),
                    UWAUnits = d.ExchangeUnits.Select(u => new { u.UnitCode, u.UnitName }),
                })
                .Select(g => g.OrderByDescending(d => d.DecisionDate).First());
        }


        [Authorize]
        [HttpGet("/login")]
        public StatusCodeResult Login()
        {
            return new StatusCodeResult((int)HttpStatusCode.Accepted);
        }
    }
}
