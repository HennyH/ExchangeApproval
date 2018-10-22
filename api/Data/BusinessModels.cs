using ExchangeApproval.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApproval.api.Data
{
    public class StudentApplicationBO
    {
        public int ApplicationId { get; set; }
        public DateTime ApplicationSubmittedAt { get; set; }
        public DateTime ApplicationLastUpdatedAt { get; set; }
        public DateTime ApplicationCompletedAt { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public DateTime ExchangeDate { get; set; }
        public string Degree { get; set; }
        public string Major1st { get; set; }
        public string Major2nd { get; set; }
        public string ExchangeUniversityCountry { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public string ExchangeUniversityName { get; set; }
        public string Notes { get; set; }
        public IEnumerable<UnitSetBO> UnitSets { get; set; }
    }

    public class UnitSetBO
    {
        public int UnitSetId { get; set; }
        public IEnumerable<ExchangeUnitBO> ExchangeUnits { get; set; }
        public IEnumerable<UWAUnitBO> UWAUnits { get; set; }
        public bool? IsEquivalent { get; set; }
        public UWAUnitLevel? EquivalentUWAUnitLevel { get; set; }
        public bool? IsContextuallyApproved { get; set; }
        public int? EquivalencePrecedentApplicationId { get; set; }
    }

    public class ExchangeUnitBO
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
    }

    public class UWAUnitBO
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
    }
}
