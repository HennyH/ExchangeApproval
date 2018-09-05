using System;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class UnitApprovalDecisionVM
    {
        public int? Id { get; set; }
        public DateTime DecisionDate { get; set; }
        public string ExchangeUniversityName { get; set; }
        public string ExchangeUnitName { get; set; }
        public string ExchangeUnitCode { get; set;}
        public string ExchangeUnitOutlineHref { get; set; }
        public string UWAUnitName { get; set; }
        public string UWAUnitCode { get; set; }
        public UWAUnitLevel? UWAUnitLevel { get; set; }
        public UWAUnitContext UWAUnitContext  {get; set; }
        public bool Approved { get; set; }
    }
}