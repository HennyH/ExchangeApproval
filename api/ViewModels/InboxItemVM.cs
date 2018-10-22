using System;
using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class InboxItemVM
    {


        public int ApplicationID { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string ExchangeUniversityName { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}