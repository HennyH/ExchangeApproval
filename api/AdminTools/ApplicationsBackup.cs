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
                IEnumerable<StudentApplication> diff = newUploadedApplications.Except(db.StudentApplications.Where(s => s.StudentApplicationId != null));
                db.AddRange(diff);
                db.SaveChanges();
                transaction.Commit();
            }
        }
    }
}