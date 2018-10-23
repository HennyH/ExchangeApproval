using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class StudentFiltersVM
    {
        public IReadOnlyList<SelectOption<string>> ExchangeUniversityNameOptions { get; set; }
        public IReadOnlyList<SelectOption<UWAUnitContext>> UWAUnitContextOptions { get; set; }
        public IReadOnlyList<SelectOption<UWAUnitLevel>> UWAUnitLevelOptions { get; set; }
        public IReadOnlyList<SelectOption<string>> StudentOfficeOptions { get; set; }
    }
}