using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using static ExchangeApproval.Data.SeedSampleData;

namespace ExchangeApproval.Data
{
    public static class ReferenceData
    {
        public readonly static string UWAName = "University of Western Australia";
        public readonly static string UWAHref = "https://www.uwa.edu.au/";
    }

    public class ExchangeDbContext : DbContext
    {
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UWAStaffLogon.OnModelCreating(modelBuilder);
            ExchangeApplicationUnitSet.OnModelCreating(modelBuilder);

            var (unitSets, staffLogons) = LoadSampleData();
            modelBuilder
                .Entity<UWAStaffLogon>()
                .HasData(staffLogons.ToArray());
            modelBuilder
                .Entity<ExchangeApplicationUnitSet>()
                .HasData(unitSets.ToArray());
        }

        public DbSet<ExchangeApplicationUnitSet> ExchangeApplicationUnitSets { get; set; }
        public DbSet<UWAStaffLogon> StaffLogons { get; set; }
    }

    public enum UWAUnitContext { Elective, Core, Complementary };

    public enum UWAUnitLevel
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        GtFour
    };

    public static class UWAUnitLevelExtensions
    {
        public static string GetLabel(this UWAUnitLevel level)
        {
            switch (level)
            {
                case UWAUnitLevel.Zero:
                    return "Insufficent";
                case UWAUnitLevel.One:
                    return "1000";
                case UWAUnitLevel.Two:
                    return "2000";
                case UWAUnitLevel.Three:
                    return "3000";
                case UWAUnitLevel.Four:
                    return "4000";
                default:
                    return ">4000";
            }
        }
    }

    public enum StaffRole { StudentOffice, UnitCoordinator };

    public class UWAStaffLogon
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public StaffRole Role { get; set; }
        [Required]
        public byte[] Salt { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UWAStaffLogon>()
                .Property(l => l.Role)
                .HasConversion<string>();
        }

        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static string HashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                )
            );
        }
    }

    public enum ApplicationStatus
    {
        New,
        Incomplete,
        Completed,
        Deleted
    }

    public class ExchangeApplicationUnitSet
    {
        [Key]
        public int UnitSetId { get; set; }
        public int ApplicationId { get; set; }
        public DateTime ApplicationSubmittedAt { get; set; }
        public DateTime ApplicationLastUpdatedAt { get; set; }
        public DateTime ApplicationCompletedAt { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public DateTime ExchangeDate { get; set; }
        public string Major1st { get; set; }
        public string Major2nd { get; set; }
        public string ExchangeUniversityCountry { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public string ExchangeUniversityName { get; set; }
        public IList<ExchangeUnit> ExchangeUnits { get; set; }
        public IList<UWAUnit> UWAUnits { get; set; }
        public bool? IsEquivalent { get; set; }
        public int? EquivalencePrecedentId { get; set; }
        public bool? IsContextuallyApproved { get; set; }
        public UWAUnitLevel? EquivalentUWAUnitLevel { get; set; }
        public string Notes { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ExchangeApplicationUnitSet>()
                .Property(s => s.ExchangeUnits)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<IList<ExchangeUnit>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            modelBuilder
                .Entity<ExchangeApplicationUnitSet>()
                .Property(s => s.UWAUnits)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<IList<UWAUnit>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }

    public class ExchangeUnit
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
    }

    public class UWAUnit
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
    }
}