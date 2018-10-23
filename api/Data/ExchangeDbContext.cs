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

namespace ExchangeApproval.Data
{
    public static class ReferenceData
    {
        public readonly static string UWACountry = "Australia";
        public readonly static string UWAName = "University of Western Australia";
        public readonly static string UWAHref = "https://www.uwa.edu.au/";
        public readonly static string[] UWAStudentOffices = new string[]
        {
            "Arts and Law", "Business School",
            "Design and Education",
            "Engineering and Mathematical Sciences",
            "Health and Medical Sciences",
            "Science",
            "Bachelor of Philosophy (Honours)",
            "Ph.D and Master by Research Students",
            "School of Indigenous Studies"
        };
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
            StudentApplication.OnModelCreating(modelBuilder);
        }

        public DbSet<StudentApplication> StudentApplications { get; set; }
        public DbSet<UnitSet> UnitSets { get; set; }
        public DbSet<ExchangeUnit> ExchangeUnits { get; set; }
        public DbSet<UWAUnit> UWAUnits { get; set; }
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

    public enum UWAStaffRole { StudentOffice, UnitCoordinator };

    public class UWAStaffLogon
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public UWAStaffRole Role { get; set; }
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
            var salt = UWAStaffLogon.GenerateSalt();
            var passwordHash = UWAStaffLogon.HashPassword("password", salt);
            modelBuilder
                .Entity<UWAStaffLogon>()
                .HasData(new UWAStaffLogon
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Role = UWAStaffRole.StudentOffice,
                });
            modelBuilder
                .Entity<UWAStaffLogon>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd();
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

    public enum StudentApplicationStatus
    {
        New,
        Incomplete,
        Completed,
        Deleted
    }

    public class StudentApplication
    {
        public int StudentApplicationId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public string Major1st { get; set; }
        public string Major2nd { get; set; }
        public string ExchangeUniversityCountry { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public string ExchangeUniversityName { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<UnitSet> UnitSets { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentApplication>()
                .HasMany(a => a.UnitSets)
                .WithOne(us => us.StudentApplication)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class UnitSet
    {
        [Key]
        public int UnitSetId { get; set; }
        public int? StudentApplicationId { get; set; }
        public virtual StudentApplication StudentApplication { get; set; }
        public string ExchangeUniversityCountry { get; set; }
        public string ExchangeUniversityHref { get; set; }
        public string ExchangeUniversityName { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public virtual ICollection<ExchangeUnit> ExchangeUnits { get; set; }
        public virtual ICollection<UWAUnit> UWAUnits { get; set; }
        public bool? IsEquivalent { get; set; }
        public bool? IsContextuallyApproved { get; set; }
        public UWAUnitLevel? EquivalentUWAUnitLevel { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UnitSet>()
                .HasMany(a => a.ExchangeUnits)
                .WithOne(us => us.UnitSet)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder
                .Entity<UnitSet>()
                .HasMany(a => a.UWAUnits)
                .WithOne(us => us.UnitSet)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ExchangeUnit
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public int? UnitSetId { get; set; }
        public virtual UnitSet UnitSet { get; set; }
    }

    public class UWAUnit
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public int? UnitSetId { get; set; }
        public virtual UnitSet UnitSet { get; set; }
    }
}