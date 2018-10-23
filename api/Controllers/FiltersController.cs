using System;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApproval.Controllers
{
    [Route("api/filters")]
    public class FiltersController : Controller
    {
        private readonly ExchangeDbContext _db;

        public FiltersController(ExchangeDbContext db)
        {
            this._db = db;
        }

        [Authorize]
        [HttpGet("staff")]
        public StaffFiltersVM GetFiltersForStaff()
        {
            return new StaffFiltersVM
            {
                ExchangeUniversityNames = this._db.StudentApplications
                    .Select(a => a.ExchangeUniversityName)
                    .OrderByDescending(n => n)
                    .Select(n => new SelectOption<string>(n, n.ToString(), false))
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
                    .ToList(),
                StudentOptions = this._db.StudentApplications
                    .Select(a => new { Name = a.StudentName, Number = a.StudentNumber })
                    .Distinct()
                    .Select(s => new SelectOption<string>(
                        s.Number,
                        $"{s.Name} ({s.Number})",
                        false
                    ))
                    .ToList(),
                StudentOfficeOptions = ReferenceData.UWAStudentOffices
                    .Select(o => new SelectOption<string>(o, o, false))
                    .ToList(),
                ApplicationStatusOptions = Enum
                    .GetValues(typeof(StudentApplicationStatus))
                    .Cast<StudentApplicationStatus>()
                    .Select(l => new SelectOption<StudentApplicationStatus>(l, l.ToString(), true))
                    .ToList()
            };
        }

        [HttpGet("students")]
        public StudentFiltersVM GetFiltersForStudents()
        {
            return new StudentFiltersVM
            {
                ExchangeUniversityNames = this._db.StudentApplications
                    .Select(a => a.ExchangeUniversityName)
                    .OrderByDescending(n => n)
                    .Select(n => new SelectOption<string>(n, n.ToString(), false))
                    .ToList(),
                UWAUnitContextOptions = Enum
                    .GetValues(typeof(UWAUnitContext))
                    .Cast<UWAUnitContext>()
                    .Select(c => new SelectOption<UWAUnitContext>(c, c.ToString(), true))
                    .ToList(),
                StudentOfficeOptions = ReferenceData.UWAStudentOffices
                    .Select(o => new SelectOption<string>(o, o, false))
                    .ToList(),
                UWAUnitLevelOptions = Enum
                    .GetValues(typeof(UWAUnitLevel))
                    .Cast<UWAUnitLevel>()
                    .Select(l => new SelectOption<UWAUnitLevel>(l, l.GetLabel(), true))
                    .ToList()
            };
        }
    }
}
