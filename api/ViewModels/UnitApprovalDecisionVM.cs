using System;
using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class UnitSetDecisionVM
    {
        public int UnitSetId { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool? Approved { get; set; }
        public string ExchangeUniversityName { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public List<UnitVM> ExchangeUnits { get; set; }
        public List<UnitVM> UWAUnits { get; set; }
        public SelectOption<UWAUnitLevel> EquivalentUnitLevel { get; set; }
    }
}