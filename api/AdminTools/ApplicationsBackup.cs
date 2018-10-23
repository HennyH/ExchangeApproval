using System.Collections.Generic;
using System.IO;
using ExchangeApproval.Data;
using CsvHelper;
using System.Linq;
using System;

namespace ExchangeApproval.AdminTools 
{
    public static class ApplicationsBackup {
        public static void UpdateApplicationsDB (ExchangeDbContext db, IEnumerable<StudentApplication> newUploadedApplications)
        {
            // using (var transaction = db.Database.BeginTransaction())
            // {
            //     db.RemoveRange();
            //     db.AddRange(newUploadedApplications);
            //     db.SaveChanges();
            //     transaction.Commit();
            // }
        }
    }
}