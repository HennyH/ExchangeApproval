using ExchangeApproval.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApproval.ViewModels
{
    public class UnitVM
    {
        public UnitVM(UniversityUnit unit)
        {
            this.UniversityName = unit.University.Name;
            this.UniversityHref = unit.University.HomepageHref;
            this.UnitCode = unit.Code;
            this.UnitName = unit.Name;
            this.UnitHref = unit.OutlineHref;
            this.IsUWAUnit = unit.UWAUnitLevel != null;
            this.UWAUnitLevel = unit.UWAUnitLevel;
        }
        
        public string UniversityName { get; set; }
        public string UniversityHref { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitHref { get; set; }
        public bool IsUWAUnit { get; set; } = false;
        public UWAUnitLevel? UWAUnitLevel { get; set; } = null;
    }
}
