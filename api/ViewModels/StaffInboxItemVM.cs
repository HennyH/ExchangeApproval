using System;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class StaffInboxItemVM
    {
        public int StudentApplicationId { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string ExchangeUniversityName { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public SelectOption<StudentApplicationStatus> StudentApplicationStatus { get; set; }
    }
}