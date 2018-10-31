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
                ExchangeUniversityNameOptions = this._db.UnitSets
                    .Select(a => a.ExchangeUniversityName)
                    .Distinct()
                    .OrderBy(n => n)
                    .Select(n => new SelectOption<string>(n, n.ToString(), false))
                    .ToList(),
                UWAUnitLevelOptions = Enum
                    .GetValues(typeof(UWAUnitLevel))
                    .Cast<UWAUnitLevel>()
                    .Select(l => new SelectOption<UWAUnitLevel>(l, l.GetLabel(), false))
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
                    .Select(l => new SelectOption<StudentApplicationStatus>(l, l.ToString(), false))
                    .ToList()
            };
        }

        [HttpGet("student")]
        [ResponseCache(Duration = 30 /* min */ * 60 /* seconds */)]
        public StudentFiltersVM GetFiltersForStudents()
        {
            return new StudentFiltersVM
            {
                ExchangeUniversityNameOptions = this._db.UnitSets
                    .Select(a => a.ExchangeUniversityName)
                    .Distinct()
                    .OrderBy(n => n)
                    .Select(n => new SelectOption<string>(n, n.ToString(), false))
                    .ToList(),
                StudentOfficeOptions = ReferenceData.UWAStudentOffices
                    .Select(o => new SelectOption<string>(o, o, false))
                    .ToList(),
                UWAUnitLevelOptions = Enum
                    .GetValues(typeof(UWAUnitLevel))
                    .Cast<UWAUnitLevel>()
                    .Where(l => l != UWAUnitLevel.Zero)
                    .Select(l => new SelectOption<UWAUnitLevel>(l, l.GetLabel(), false))
                    .ToList()
            };
        }
    }
}
