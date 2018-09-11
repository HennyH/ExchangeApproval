using ExchangeApproval.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ExchangeApproval.ViewModels
{
    public class SelectOption<TValue>
    {
        private bool _isEnumType = false;

        public SelectOption()
        {
            this._isEnumType = typeof(TValue).IsEnum;
        }
        
        public SelectOption(string label, TValue value, bool selected = false) : base()
        {
            this.Label = label ?? throw new ArgumentNullException(nameof(label));
            this.Value = value;
            this.Selected = selected;
        }

        public SelectOption(TValue value, bool selected = false) : base()
        {
            if (this._isEnumType)
            {
                this.Label = EnumExtensions
                    .GetAttributeOfType<EnumMemberAttribute>(value as Enum)
                    ?.Value
                    ?? Enum.Format(typeof(TValue), value, "F");
            }
            else
            {
                this.Label = value.ToString();
            }
            
            this.Value = value;
            this.Selected = selected;

        }

        public string Label { get; set; }
        public TValue Value { get; set; }
        public bool Selected { get; set; } = false;
    }
}
