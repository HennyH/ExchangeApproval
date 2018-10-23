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
    }

    public class ExchangeUniversityFormVM
    {
        public string UniversityHomepage { get; set; }
        public string UniversityName { get; set; }
    }

    public class UnitFormVM
    {
        public string UnitName { get; set; }
        public string UnitCode { get; set; }
        public string UnitHref { get; set; }
    }

    public class UnitLevelOutcome
    {
        public bool? Value { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
    }

    public class ApprovalOutcome
    {
        public bool? Value { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }

        [NotMapped]
        public bool IsApproved { get { return Value.HasValue && Value.Value; } }
    }

    public class StaffApprovalFormVM
    {
        public UnitLevelOutcome EquivalentUnitLevel { get; set; }
        public ApprovalOutcome IsContextuallyApproved { get; set; }
        public ApprovalOutcome IsEquivalent { get; set; }
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
