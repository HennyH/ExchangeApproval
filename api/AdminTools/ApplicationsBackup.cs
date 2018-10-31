using System.Collections.Generic;
using System.IO;
using ExchangeApproval.Data;
using CsvHelper;
using System.Linq;
using System;

namespace ExchangeApproval.AdminTools
{
    public static class ApplicationsBackup {
        public static void UpdateApplicationsinDatabase (ExchangeDbContext db, IEnumerable<StudentApplication> newUploadedApplications)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                db.StudentApplications.RemoveRange(db.StudentApplications);
                db.SaveChanges();
                db.AddRange(newUploadedApplications);
                db.SaveChanges();
                transaction.Commit();
            }
        }
    }
}