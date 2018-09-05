using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class DecisionsSearchFilterVM
    {
        public IReadOnlyList<string> ExchangeUniversityNames { get; set; }
        public IReadOnlyList<UWAUnitContext> UWAUnitContextOptions { get; set; }
        public IReadOnlyList<UWAUnitLevel> UWAUnitLevelOptions { get; set; }
    }
}