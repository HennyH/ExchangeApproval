using System;
using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
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

        [HttpPost]
        public ActionResult SubmitApplication([FromBody]ApplicationFormVM form)
        {
            Console.WriteLine(form);
            var now = DateTime.UtcNow;
            var application = new StudentApplication
            {
                SubmittedAt = now,
                LastUpdatedAt = now,
                CompletedAt  = now,
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
                    SubmittedAt = now,
                    LastUpdatedAt = now,
                    CompletedAt  = now,
                    IsEquivalent = null,
                    IsContextuallyApproved = null,
                    EquivalentUWAUnitLevel = null,
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
                }).ToList()
            };
            this._db.Add(application);
            this._db.SaveChanges();
            return Json(form);
        }
    }
}