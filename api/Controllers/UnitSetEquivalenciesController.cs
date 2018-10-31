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
        [ResponseCache(Duration = 30 /* min */ * 60 /* seconds */)]
        public IEnumerable<UnitSetDecisionVM> ApprovalRequests(
                string[] universityNames,
                UWAUnitLevel[] uwaUnitLevels
            )
        {
            var results = QueryUnitSets(this._db, universityNames, uwaUnitLevels).ToList();
            var groups = results
                .Where(r => r.UnitSet.EquivalentUWAUnitLevel.HasValue)
                .Select(r => new UnitSetDecisionVM
                {
                    ExchangeUniversityName = r.UnitSet.ExchangeUniversityName,
                    ExchangeUniversityHref = r.UnitSet.ExchangeUniversityHref,
                    UnitSetId = r.UnitSet.UnitSetId,
                    Approved =
                        r.UnitSet.IsEquivalent.HasValue
                        && r.UnitSet.IsEquivalent.Value
                        && r.UnitSet.EquivalentUWAUnitLevel.HasValue
                        && r.UnitSet.EquivalentUWAUnitLevel.Value != UWAUnitLevel.Zero,
                    ExchangeUnits = r.ExchangeUnits.Select(u => new UnitVM
                    {
                        UnitId = u.Id,
                        UniversityName = r.UnitSet.ExchangeUniversityName,
                        UniversityHref = r.UnitSet.ExchangeUniversityHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href
                    }).ToList(),
                    UWAUnits = r.UWAUnits.Select(u => new UnitVM
                    {
                        UnitId = u.Id,
                        UniversityName = ReferenceData.UWAName,
                        UniversityHref = ReferenceData.UWAHref,
                        UnitCode = u.Code,
                        UnitName = u.Title,
                        UnitHref = u.Href
                    }).ToList(),
                    EquivalentUnitLevel = new SelectOption<UWAUnitLevel>(
                        r.UnitSet.EquivalentUWAUnitLevel.Value,
                        r.UnitSet.EquivalentUWAUnitLevel.Value.GetLabel(),
                        true
                    )
                })
                .GroupBy(d => new
                {
                    d.ExchangeUniversityName,
                    ExchangeUnits = string.Join(',', d.ExchangeUnits.Select(u => u.UnitCode)),
                    UWAUnits = string.Join(',', d.UWAUnits.Select(u => u.UnitCode)),
                })
                .ToList();
            return groups.Select(g => g.OrderByDescending(d => d.LastUpdatedAt).First());
        }
    }
}
