using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ExchangeApproval.Data;

namespace ExchangeApproval.Utilities
{
    public static class EnumExtensions
    {
        public static IEnumerable<TEnum> ParseMany<TEnum>(IEnumerable<string> names)
        {
            var nameToValueMap = Enum
                .GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(v => new {
                    Name = (v as Enum)?.GetAttributeOfType<EnumMemberAttribute>()?.Value,
                    Value = v
                })
                .Where(i => i.Name != null)
                .Concat(
                    Enum
                        .GetNames(typeof(TEnum))
                        .Zip(Enum.GetValues(typeof(TEnum)).Cast<TEnum>(), (n, v) => new {
                            Name = n,
                            Value = v
                        })
                )
                .ToDictionary(i => i.Name, i => i.Value);

            return names.Select(n => nameToValueMap[n]);
        }

        public static T GetAttributeOfType<T>(this Enum val) where T : System.Attribute
        {
            var type = val.GetType();
            var memInfo = type.GetMember(val.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }

}