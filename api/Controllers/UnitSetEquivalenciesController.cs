using System;
using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ExchangeApproval.Data.Queries;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace ExchangeApproval.Controllers
{
    [Route("api/equivalencies")]
    public class UnitSetEquivalenciesController : Controller
    {
        private readonly ExchangeDbContext _db;

        public UnitSetEquivalenciesController(ExchangeDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IEnumerable<UnitSetDecisionVM> ApprovalRequests(
                string[] universityNames,
                UWAUnitLevel[] uwaUnitLevels
            )
        {
            var unitSets = QueryUnitSets(this._db, universityNames, uwaUnitLevels).ToList();
            return unitSets
                .Where(us => us.EquivalentUWAUnitLevel.HasValue)
                .Select(us => new UnitSetDecisionVM
                {
                    ExchangeUniversityName = us.ExchangeUniversityName,
                    ExchangeUniversityHref = us.ExchangeUniversityHref,
                    UnitSetId = us.UnitSetId,
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
                    }).ToList(),
                    UWAUnits = us.UWAUnits.Select(u => new UnitVM
                    {
                        UnitId = u.Id,
                        UniversityName = ReferenceData.UWAName,
                        UniversityHref = ReferenceData.UWAHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href
                    }).ToList(),
                    EquivalentUnitLevel = new SelectOption<UWAUnitLevel>(
                        us.EquivalentUWAUnitLevel.Value,
                        us.EquivalentUWAUnitLevel.Value.GetLabel(),
                        true
                    )
                })
                .GroupBy(d => new
                {
                    d.ExchangeUniversityName,
                    ExchangeUnits = d.UWAUnits.Select(u => new { u.UniversityName, u.UnitCode, u.UnitName }),
                    UWAUnits = d.ExchangeUnits.Select(u => new { u.UnitCode, u.UnitName }),
                })
                .Select(g => g.OrderByDescending(d => d.LastUpdatedAt).First());
        }
    }
}
