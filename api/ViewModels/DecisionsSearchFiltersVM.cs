using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class DecisionsSearchFilterVM
    {
        public IReadOnlyList<SelectOption<string>> ExchangeUniversityNames { get; set; }
        public IReadOnlyList<SelectOption<UWAUnitContext>> UWAUnitContextOptions { get; set; }
        public IReadOnlyList<SelectOption<UWAUnitLevel>> UWAUnitLevelOptions { get; set; }
    }
}