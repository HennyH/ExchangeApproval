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
        }

        public DbSet<ExchangeApplicationUnitSet> ExchangeApplicationUnitSets { get; set; }
        public DbSet<UWAStaffLogon> StaffLogons { get; set; }
    }

    public enum UWAUnitContext { Elective, Core, Complementary };

    public enum UWAUnitLevel
    {
        [EnumMember(Value = "1000")]
        One,
        [EnumMember(Value = "2000")]
        Two,
        [EnumMember(Value = "3000")]
        Three,
        [EnumMember(Value = ">4000")]
        GtThree
    };

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
            modelBuilder
                .Entity<UWAStaffLogon>()
                .HasData(CreateSeedUWAStaffLogons().ToArray());
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

    public class ExchangeApplicationUnitSet
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public DateTime ExchangeDate { get; set; }
        public string CourseCode { get; set; }
        public DateTime? ApprovalDecidedAt { get; set; }
        public bool? IsApproved { get; set; }
        public string ExchangeUniversityCountry { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public string ExchangeUniversityName { get; set; }
        public IList<ExchangeUnit> ExchangeUnits { get; set; }
        public IList<UWAUnit> UWAUnits { get; set; }
        public int? EquivalenceDeciderId { get; set; }
        public UWAStaffLogon EquivalenceDecider { get; set; } 
        public DateTime? EquivalenceDecidedAt { get; set; }
        public bool? IsEquivalent { get; set; }
        public int? EquivalencePrecedentId { get; set; }
        public ExchangeApplicationUnitSet EquivalencePrecedent { get; set; }
        public IList<Comment> Comments { get; set; }

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
            modelBuilder
                .Entity<ExchangeApplicationUnitSet>()
                .Property(s => s.Comments)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<IList<Comment>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            modelBuilder
                .Entity<ExchangeApplicationUnitSet>()
                .HasData(CreateSeedExchangeApplicationUnitSets().ToArray());
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
        public UWAUnitContext Context { get; set; }
        public UWAUnitLevel Level { get; set; }
    }

    public class Comment
    {
        public string UserEmail { get; set; }
        public DateTime PostedAt { get; set; }
        public string Message { get; set; }
    }
    
}