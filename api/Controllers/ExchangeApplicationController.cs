using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApproval.Controllers
{
    [Route("/api/application")]
    public class ExchangeApplicationController : Controller
    {
        private readonly ExchangeDbContext _db;

        public ExchangeApplicationController(ExchangeDbContext db)
        {
            this._db = db;
        }

        private static StudentApplication MapApplicationFormToApplication(ExchangeDbContext db, ApplicationFormVM form, bool asStaff)
        {
            var now = DateTime.UtcNow;
            var newApplication = new StudentApplication
            {
                SubmittedAt = now,
                LastUpdatedAt = now,
                StudentName = form.StudentDetailsForm.Name,
                StudentNumber = form.StudentDetailsForm.Email,
                Major1st = form.StudentDetailsForm.Major,
                Major2nd = form.StudentDetailsForm.Major2nd,
                ExchangeUniversityCountry = null,
                ExchangeUniversityName  = form.ExchangeUniversityForm.UniversityName,
                ExchangeUniversityHref = form.ExchangeUniversityForm.UniversityHomepage,
                Notes = null,
                UnitSets = form.UnitSetForms.Select(f => new UnitSet
                {
                    ExchangeUniversityName  = form.ExchangeUniversityForm.UniversityName,
                    ExchangeUniversityHref = form.ExchangeUniversityForm.UniversityHomepage,
                    IsEquivalent = asStaff
                        ? f.StaffApprovalForm.IsEquivalent.IsApproved
                        : (bool?)null,
                    IsContextuallyApproved = asStaff
                        ? f.StaffApprovalForm.IsContextuallyApproved.IsApproved
                        : (bool?)null,
                    EquivalentUWAUnitLevel = asStaff
                        ? (UWAUnitLevel?)Enum.Parse(typeof(UWAUnitLevel), f.StaffApprovalForm.EquivalentUnitLevel.Label)
                        : (UWAUnitLevel?)null,
                    ExchangeUnits = f.ExchangeUnitsForm.Select(u => new ExchangeUnit
                    {
                        Code = u.UnitCode,
                        Title = u.UnitName,
                        Href = u.UnitHref
                    }).ToList(),
                    UWAUnits = f.UWAUnitsFormForm?.Select(u => new UWAUnit
                    {
                        Code = u.UnitCode,
                        Title = u.UnitName,
                        Href = u.UnitHref
                    }).ToList() ?? new List<UWAUnit>(),
                }).ToList(),
            };
            /* Preserve when the student submitted the application */
            if (asStaff && form.ApplicationId.HasValue)
            {
                var oldApplication = db.StudentApplications.FirstOrDefault(a => a.StudentApplicationId == form.ApplicationId);
                if (oldApplication != null)
                {
                    newApplication.SubmittedAt = oldApplication.SubmittedAt;
                }
            }
            return newApplication;
        }

        [HttpPost("submit")]
        public ActionResult SubmitApplication([FromBody]ApplicationFormVM form)
        {
            var application = MapApplicationFormToApplication(this._db, form, asStaff: false);
            this._db.Add(application);
            this._db.SaveChanges();
            return Json(form);
        }

        [Authorize]
        [HttpPost("update")]
        public ActionResult UpdateApplication([FromBody]ApplicationFormVM form)
        {
            var now = DateTime.UtcNow;

            using (var transaction = this._db.Database.BeginTransaction())
            {
                var newVersion = MapApplicationFormToApplication(this._db, form, asStaff: true);
                var oldVersion = this._db.StudentApplications.FirstOrDefault(a => a.StudentApplicationId == form.ApplicationId);
                this._db.Remove(oldVersion);
                this._db.Add(newVersion);
                this._db.SaveChanges();
                transaction.Commit();
            }

            return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}