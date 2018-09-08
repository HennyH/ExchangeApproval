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
                ExchangeUniversityNames = Universities().ToList(),
                UWAUnitContextOptions = Enum.GetValues(typeof(UWAUnitContext)).Cast<UWAUnitContext>().ToList(),
                UWAUnitLevelOptions = Enum.GetValues(typeof(UWAUnitLevel)).Cast<UWAUnitLevel>().ToList()
            };
        }

        [HttpGet("decisions")]
        public IEnumerable<UnitApprovalDecisionVM> ApprovalRequests(
                string[] universityNames,
                string[] uwaContextTypes,
                string[] uwaUnitLevels
            )
        {
            Console.WriteLine(universityNames);
            return QueryUnitApprovalDecisions(
                _db,
                universityNames,
                EnumExtensions.ParseMany<UWAUnitContext>(uwaContextTypes).ToArray(),
                EnumExtensions.ParseMany<UWAUnitLevel>(uwaUnitLevels).ToArray()
            );
        }

        [HttpPost("application")]
        public JsonResult SubmitApplication(ApplicationFormVM formVm)
        {
            /* This method is a WIP, may not work... */
            InsertNewStudentApplication(_db, formVm);
            return new JsonResult("Hello");
        }
    }
}
