using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ExchangeApproval.Utilities;
using static ExchangeApproval.Data.Queries;

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
        [Authorize]
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
            Console.WriteLine(universityNames);
            return QueryUnitApprovalDecisions(
                _db,
                universityNames,
                uwaUnitLevels
            );
        }
    }
}
