using System.Collections.Generic;
using ExchangeApproval.Data;

namespace ExchangeApproval.ViewModels
{
    public class StaffFiltersVM : StudentFiltersVM
    {
        public IReadOnlyList<SelectOption<string>> StudentOptions { get; set; }
        public IReadOnlyList<SelectOption<StudentApplicationStatus>> ApplicationStatusOptions { get; set; }
    }
}