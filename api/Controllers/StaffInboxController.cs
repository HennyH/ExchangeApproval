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

        private StaffInboxItemVM MapApplicationToInboxItemVM(StudentApplication application)
        {
            return new StaffInboxItemVM
            {
                StudentApplicationId = application.StudentApplicationId,
                StudentName = application.StudentName,
                StudentNumber = application.StudentNumber,
                LastUpdatedAt = application.LastUpdatedAt,
                ExchangeUniversityName = application.ExchangeUniversityName,
                ExchangeUniversityHref = application.ExchangeUniversityHref,
                StudentApplicationStatus = new SelectOption<StudentApplicationStatus>(
                    StudentApplication.GetStatus(application),
                    StudentApplication.GetStatus(application).ToString(),
                    false
                )
            };
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
                .Select(MapApplicationToInboxItemVM);
            return Json(inboxItems);
        }

        [Authorize]
        [HttpGet("application")]
        public ActionResult GetInboxItem(int applicationId)
        {
            var application = this._db.StudentApplications.Find(applicationId);
            return Json(MapApplicationToInboxItemVM(application));
        }
    }
}