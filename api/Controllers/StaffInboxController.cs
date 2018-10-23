using System;
using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public ActionResult GetInbox(
            StudentApplicationStatus[] applicationStatuses,
            string[] studentNumbers,
            string[] studentOffices
        )
        {
            var inboxItems = this._db.StudentApplications
                .Include(a => a.UnitSets)
                .ToList()
                .Where(a =>
                    applicationStatuses == null
                    || applicationStatuses.Count() == 0
                    || applicationStatuses.Contains(StudentApplication.GetStatus(a)))
                .Select(a => new StaffInboxItemVM
                {
                    StudentApplicationId = a.StudentApplicationId,
                    StudentName = a.StudentName,
                    StudentNumber = a.StudentNumber,
                    LastUpdatedAt = a.LastUpdatedAt,
                    ExchangeUniversityName = a.ExchangeUniversityName,
                    ExchangeUniversityHref = a.ExchangeUniversityHref,
                    StudentApplicationStatus = new SelectOption<StudentApplicationStatus>(
                        StudentApplication.GetStatus(a),
                        StudentApplication.GetStatus(a).ToString(),
                        false
                    )
                });
            return Json(inboxItems);
        }
    }
}