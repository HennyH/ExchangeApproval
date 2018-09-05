using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApproval.ViewModels
{
    public class ApplicationFormVM
    {
        public class StudentDetailsVM
        {
            public string Degree { get; set; }
            public string Email { get; set; }
            public string Major { get; set; }
            public string Major2nd { get; set; }
        }

        public class ExchangeUniversityDetailsVM
        {
            public string UniversityHomepage { get; set; }
            public string UniversityName { get; set; }
        }

        public List<UnitApprovalDecisionVM> ApprovalRequests { get; set; }
        public StudentDetailsVM Student { get; set; }
        public ExchangeUniversityDetailsVM ExchangeUniversity { get; set; }
    }
}
