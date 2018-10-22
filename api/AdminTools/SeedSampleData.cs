using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using CsvHelper;
using ExchangeApproval.Data;

namespace ExchangeApproval.AdminTools
{
    public static class SeedSampleData
    {
        public static void SeedDatabase(ExchangeDbContext db)
        {
            /* Load default approvals */
            using (var reader = new StreamReader("api/AdminTools/approved-unit-sets.csv"))
            {
                var (errors, unitSets) = EquivalenceUnitSetsReader.LoadEquivalencies(reader);
                if (errors != null)
                {
                    Console.WriteLine(errors);
                    return;
                }
                EquivalenceUnitSetsReader.UpdateEquivalenciesInDatabase(db, unitSets);
            }
        }
    }
}