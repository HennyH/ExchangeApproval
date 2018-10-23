using System;
using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApproval.Controllers
{
    [Route("/api/inbox")]
    public class StaffInboxController : Controller
    {
        private readonly ExchangeDbContext _db;

        public StaffInboxController(ExchangeDbContext db)
        {
            this._db = db;
        }

        [Authorize]
        [HttpGet("students")]
        public ActionResult GetStudents()
        {
            var students = this._db.StudentApplications
                .Select(a => new { Name = a.StudentName, Number = a.StudentNumber })
                .Distinct()
                .Select(s => new SelectOption<string>(
                    s.Number,
                    $"{s.Name} ({s.Number})",
                    false
                ));
            return Json(students);
        }

        [Authorize]
        [HttpGet("s")]
        public ActionResult GetStudentOffices()
        {
            return Json(ReferenceData.UWAStudentOffices);
        }
    }
}