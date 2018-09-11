using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApproval.api.ViewModels
{
    public class SelectOption
    {
        public SelectOption(string label, string value, bool selected = false)
        {
            this.Label = label ?? throw new ArgumentNullException(nameof(label));
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
            this.Selected = selected;
        }

        public string Label { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; } = false;
    }
}
