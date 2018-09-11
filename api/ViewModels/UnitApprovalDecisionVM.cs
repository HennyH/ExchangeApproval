using System;
using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class UnitSetDecisionVM
    {
        public int UnitSetId { get; set; }
        public List<UnitVM> ExchangeUnits { get; set; }
        public List<UnitVM> UWAUnits { get; set; }
    }
}