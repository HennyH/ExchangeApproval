using ExchangeApproval.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApproval.ViewModels
{
    public class UnitVM
    {   
        public string UniversityName { get; set; }
        public string UniversityHref { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitHref { get; set; }
        public bool IsUWAUnit { get; set; } = false;
        public SelectOption<UWAUnitContext> UWAUnitContext { get; set; } = null;
        public SelectOption<UWAUnitLevel> UWAUnitLevel { get; set; } = null;
    }
}
