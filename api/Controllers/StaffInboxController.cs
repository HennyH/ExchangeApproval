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
        [HttpGet]
        public ActionResult GetInbox(
            StudentApplicationStatus[] applicationStatuses,
            string[] studentNumbers,
            string[] studentOffices
        )
        {
            var applications = this._db.StudentApplications
                .Where(a =>
                    applicationStatuses == null
                    || applicationStatuses.Count() == 0
                    || applicationStatuses.Contains(StudentApplication.GetStatus(a)))
                .ToList();
            var inboxItems = applications.Select(a => new StaffInboxItemVM
            {
                StudentApplicationId = a.StudentApplicationId,
                StudentName = a.StudentName,
                StudentNumber = a.StudentNumber,
                LastUpdatedAt = a.LastUpdatedAt,
                ExchangeUniversity = a.ExchangeUniversityName,
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