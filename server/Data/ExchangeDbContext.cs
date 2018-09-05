using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
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
            UnitApprovalRequest.OnModelCreating(modelBuilder);
        }

        public DbSet<UnitApprovalRequest> UnitApprovalRequests { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum UWAUnitContext { Elective, Core, Complementary };

    [JsonConverter(typeof(StringEnumConverter))]
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

    public class UnitApprovalRequest
    {
        public int Id { get; set; }
        public DateTime? DecisionDate { get; set; }
        [Required]
        public string ExchangeUniversityName { get; set; }
        [Required]
        public string ExchangeUnitName { get; set; }
        public string ExchangeUnitCode { get; set; }
        [Required]
        public string ExchangeUnitOutlineHref { get; set; }
        [Required]
        public UWAUnitContext UWAUnitContext { get; set; }
        public string UWAUnitName { get; set; }
        public string UWAUnitCode { get; set; }
        public UWAUnitLevel? UWAUnitLevel { get; set; }
        public bool? Approved { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UnitApprovalRequest>()
                .Property(p => p.UWAUnitContext)
                .HasConversion<string>();
            modelBuilder
                .Entity<UnitApprovalRequest>()
                .Property(p => p.UWAUnitLevel)
                .HasConversion<string>();

            modelBuilder
                .Entity<UnitApprovalRequest>()
                .HasData(CreateSeedUnitApprovalRequests().ToArray());
        }
    }
}