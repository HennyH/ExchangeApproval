using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class StudentDetailsFormVM
    {
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string Major2nd { get; set; }
        public SelectOption<string> StudentOffice { get; set; }
    }

    public class ExchangeUniversityFormVM
    {
        public string UniversityHomepage { get; set; }
        public string UniversityName { get; set; }
        public string UniversityCountry { get; set; }
    }

    public class UnitFormVM
    {
        public string UnitName { get; set; }
        public string UnitCode { get; set; }
        public string UnitHref { get; set; }
    }

    public class StaffApprovalFormVM
    {
        public SelectOption<UWAUnitLevel?> EquivalentUnitLevel { get; set; }
        public SelectOption<bool?> IsContextuallyApproved { get; set; }
        public SelectOption<bool?> IsEquivalent { get; set; }
        public string Comments { get; set; }
    }

    public class UnitSetFormVM
    {
        public IEnumerable<UnitFormVM> ExchangeUnitsForm { get; set; }
        public IEnumerable<UnitFormVM> UWAUnitsFormForm { get; set; }
        public StaffApprovalFormVM StaffApprovalForm { get; set; }
    }

    public class ApplicationFormVM
    {
        public int? ApplicationId { get; set; }
        public StudentDetailsFormVM StudentDetailsForm { get; set; }
        public ExchangeUniversityFormVM ExchangeUniversityForm { get; set; }
        public IEnumerable<UnitSetFormVM> UnitSetForms { get; set; }
    }
}
