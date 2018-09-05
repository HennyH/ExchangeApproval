using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitApprovalRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DecisionDate = table.Column<DateTime>(nullable: true),
                    ExchangeUniversityName = table.Column<string>(nullable: false),
                    ExchangeUnitName = table.Column<string>(nullable: false),
                    ExchangeUnitCode = table.Column<string>(nullable: true),
                    ExchangeUnitOutlineHref = table.Column<string>(nullable: false),
                    UWAUnitContext = table.Column<string>(nullable: false),
                    UWAUnitName = table.Column<string>(nullable: true),
                    UWAUnitCode = table.Column<string>(nullable: true),
                    UWAUnitLevel = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitApprovalRequests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 1, true, new DateTime(1999, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS293.12", "Person Organization Control", "https://university.com", "University of Los Angeles", "MATH3.12", "Core", "GtThree", "Understanding Direction Series Fact" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 73, false, new DateTime(2016, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1020", "Ability Story Software", "https://university.com", "University of Philadelphia", "CHEM3.12", "Core", "GtThree", "Country Freedom" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 72, false, new DateTime(2012, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH3000", "Army Society Love Power", "https://university.com", "University of Columbus", "CHEM293.12", "Complementary", "One", "Music Science Meat Ability" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 71, true, new DateTime(2007, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT-1", "Library Strategy Art Player", "https://university.com", "University of San Diego", "ALGS4000", "Elective", "Two", "Theory Society Thing Instance" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 70, true, new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT293.12", "Policy Definition", "https://university.com", "University of Phoenix", "CITS10", "Complementary", "Three", "Power Organization System" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 69, true, new DateTime(2007, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH10", "Definition Internet Instance", "https://university.com", "University of Austin", "ART293.12", "Complementary", "Three", "Direction Technology" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 68, true, new DateTime(2005, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT1000", "Temperature Library", "https://university.com", "University of Detroit", "ANTH2000", "Complementary", "Two", "Camera Oven Week Equipment" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 67, true, new DateTime(1998, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP2000", "Internet Security Food Information", "https://university.com", "University of Dallas", "ANTH1000", "Core", "GtThree", "Method Definition Language Policy" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 66, true, new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART3000", "Government Child History Media", "https://university.com", "University of Austin", "INFR100-3", "Complementary", "Three", "Safety Food Map" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 65, null, null, "INFR-1", "Bird Security Society", "https://university.com", "University of Charlotte", "CHEM100-3", "Core", "GtThree", "Story Media Understanding" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 64, true, new DateTime(2015, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP10", "Boyfriend Economics Theory Paper", "https://university.com", "University of Charlotte", "ART10", "Core", "GtThree", "Freedom Freedom Music" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 63, null, null, "MATH1000", "Literature Society", "https://university.com", "University of Houston", "INFR293.12", "Complementary", "One", "Society Development" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 62, null, null, "ANTH3000", "Control Science", "https://university.com", "University of Dallas", "COMP3.12", "Core", "GtThree", "Player Product" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 61, null, null, "COMP4000", "Safety Development", "https://university.com", "University of Columbus", "MGMT3.12", "Core", "GtThree", "Series Way Person People" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 60, true, new DateTime(2014, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT-1", "Information Country Analysis", "https://university.com", "University of Los Angeles", "MGMT293.12", "Elective", "Three", "Equipment Economics" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 59, false, new DateTime(2014, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS10", "Activity Environment Information Society", "https://university.com", "University of San Diego", "STAT1020", "Core", "One", "Problem Literature Analysis" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 58, false, new DateTime(2012, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT-1", "Year Map", "https://university.com", "University of Indianapolis", "ALGS1020", "Core", "GtThree", "Computer Series" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 57, true, new DateTime(1996, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO3000", "Policy Art", "https://university.com", "University of Detroit", "BIO100-3", "Core", "One", "Exam Reading Basis" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 56, true, new DateTime(2007, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR10", "Idea Industry", "https://university.com", "University of Detroit", "ANTH-1", "Core", "Two", "Country Law Data Data" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 55, true, new DateTime(2004, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP1000", "Literature Bird", "https://university.com", "University of Indianapolis", "MATH3000", "Core", "Two", "Power Health Year Temperature" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 54, true, new DateTime(2015, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO-1", "Way Society Army", "https://university.com", "University of Los Angeles", "INFR2000", "Core", "Three", "Two Literature" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 53, false, new DateTime(2006, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO-1", "Movie Story Exam Video", "https://university.com", "University of Columbus", "ANTH293.12", "Core", "Two", "Development World Power Child" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 74, true, new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM3.12", "Knowledge Year Policy", "https://university.com", "University of Indianapolis", "CHEM100-3", "Complementary", "One", "Analysis Freedom Basis" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 52, true, new DateTime(2014, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH2000", "Thought Week Meat", "https://university.com", "University of San Jose", "ART1020", "Core", "One", "Army Paper Knowledge Management" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 75, true, new DateTime(1998, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM100-3", "Thing Science Product Community", "https://university.com", "University of Charlotte", "BIO3.12", "Complementary", "One", "Food Law" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 77, true, new DateTime(2016, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM200-2", "Reading Way Computer Ability", "https://university.com", "University of Charlotte", "ANTH1000", "Complementary", "Three", "Movie Activity" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 98, true, new DateTime(2004, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR3000", "Story Nature Two Quality", "https://university.com", "University of Philadelphia", "SCI1020", "Elective", "GtThree", "Internet Library" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 97, false, new DateTime(2010, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3.12", "Media Instance History", "https://university.com", "University of San Francisco", "CHEM293.12", "Elective", "Three", "Theory Language" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 96, true, new DateTime(2000, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO10", "Control Thanks", "https://university.com", "University of Dallas", "MGMT1020", "Complementary", "Three", "Series Thing" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 95, false, new DateTime(2003, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH10", "Theory Library Control", "https://university.com", "University of Charlotte", "COMP200-2", "Complementary", "GtThree", "Data Quality Thing Technology" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 94, null, null, "CHEM3000", "Player Physics Basis", "https://university.com", "University of Charlotte", "ALGS3030", "Complementary", "Three", "Organization Language Industry" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 93, true, new DateTime(2016, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3000", "Television Player Country System", "https://university.com", "University of New York", "MGMT3.12", "Elective", "Two", "Society Knowledge Science" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 92, false, new DateTime(1997, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM200-2", "Family Love Bird", "https://university.com", "University of San Francisco", "CHEM1020", "Core", "Two", "Law Development" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 91, null, null, "CHEM-1", "Way Literature Freedom Data", "https://university.com", "University of Fort Worth", "ART293.12", "Core", "One", "Boyfriend Method Meat History" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 90, true, new DateTime(2010, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI10", "Story Community", "https://university.com", "University of Austin", "STAT200-2", "Elective", "GtThree", "Law Thought Law Fact" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 89, true, new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1000", "Paper History Strategy", "https://university.com", "University of New York", "ART10", "Core", "Three", "Computer Physics Year Movie" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 88, true, new DateTime(2013, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS2000", "Fact Computer Thought Organization", "https://university.com", "University of Phoenix", "INFR3030", "Complementary", "GtThree", "Two Art Management Video" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 87, false, new DateTime(1999, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI100-3", "Player History", "https://university.com", "University of San Jose", "CITS1000", "Complementary", "One", "Year Development Power Data" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 86, null, null, "STAT200-2", "Language Computer", "https://university.com", "University of San Diego", "SCI293.12", "Elective", "Three", "Equipment Person Power Technology" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 85, false, new DateTime(2000, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3000", "Development Understanding", "https://university.com", "University of San Antonio", "BIO293.12", "Elective", "One", "System Freedom Development Law" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 84, true, new DateTime(2005, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI293.12", "Year Problem Art", "https://university.com", "University of Indianapolis", "MATH3030", "Complementary", "One", "Movie Analysis Freedom Environment" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 83, true, new DateTime(1999, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM293.12", "Library Library", "https://university.com", "University of Chicago", "COMP3.12", "Elective", "One", "Activity Quality Exam" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 82, true, new DateTime(2002, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM4000", "Management People Way Direction", "https://university.com", "University of Columbus", "INFR4000", "Complementary", "Two", "Safety Way" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 81, true, new DateTime(2001, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3030", "Ability Quality", "https://university.com", "University of Chicago", "ART3000", "Core", "Three", "Management Theory Language" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 80, true, new DateTime(2009, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH200-2", "Ability Thing Investment", "https://university.com", "University of Austin", "MATH4000", "Core", "Two", "Technology Security" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 79, null, null, "COMP-1", "Variety Software Paper Economics", "https://university.com", "University of Fort Worth", "SCI3000", "Core", "Two", "Quality Community Power" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 78, null, null, "CHEM2000", "Problem Bird", "https://university.com", "University of San Jose", "ALGS2000", "Elective", "Two", "Strategy Library Health Quality" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 76, null, null, "CHEM4000", "Child Society Safety", "https://university.com", "University of San Antonio", "MATH100-3", "Core", "Two", "Economics Technology Quality Music" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 51, true, new DateTime(1997, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM-1", "Method Year System History", "https://university.com", "University of Columbus", "BIO4000", "Core", "GtThree", "Theory World Variety Video" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 50, true, new DateTime(2000, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1000", "Oven Variety Love", "https://university.com", "University of San Antonio", "COMP1020", "Core", "One", "Two Thought Idea" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 49, true, new DateTime(2005, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH100-3", "Thought Basis Thought", "https://university.com", "University of New York", "CHEM3000", "Elective", "Three", "Control People" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 22, false, new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1020", "Power Player Policy Basis", "https://university.com", "University of San Antonio", "SCI3000", "Complementary", "GtThree", "Music Management" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 21, true, new DateTime(1996, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI2000", "Internet Security Data Thing", "https://university.com", "University of Fort Worth", "BIO293.12", "Core", "One", "History Ability Two" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 20, false, new DateTime(2005, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS293.12", "Community Thought Story", "https://university.com", "University of Columbus", "ALGS-1", "Complementary", "Two", "Freedom Understanding Thought" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 19, true, new DateTime(2007, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT3.12", "Army Method Love Theory", "https://university.com", "University of Fort Worth", "MGMT10", "Elective", "One", "Definition Story Analysis" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 18, true, new DateTime(2003, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM10", "Boyfriend Management Fact", "https://university.com", "University of San Antonio", "ANTH3.12", "Core", "One", "Definition Art Bird Information" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 17, null, null, "ANTH1020", "Control Method Freedom Library", "https://university.com", "University of Dallas", "MATH1000", "Core", "One", "Strategy Army Child" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 16, true, new DateTime(1995, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT2000", "Bird System", "https://university.com", "University of New York", "COMP1000", "Core", "GtThree", "Love Analysis Thought" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 15, true, new DateTime(2010, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT293.12", "Quality Story Variety", "https://university.com", "University of Austin", "SCI3030", "Complementary", "GtThree", "Control Activity Direction Map" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 14, false, new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1000", "World Story World Thing", "https://university.com", "University of Indianapolis", "MATH1020", "Complementary", "GtThree", "Organization Child Literature Product" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 13, true, new DateTime(2016, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3030", "Movie Information", "https://university.com", "University of Charlotte", "BIO-1", "Elective", "Three", "Analysis History Thing" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 12, false, new DateTime(2014, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH100-3", "Analysis Reading Thanks", "https://university.com", "University of Austin", "CITS2000", "Complementary", "One", "Year Language" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 11, true, new DateTime(1995, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR3000", "History Freedom Television Player", "https://university.com", "University of Detroit", "ART3.12", "Elective", "GtThree", "Society Meat" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 10, true, new DateTime(2012, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1000", "Product Direction Army Boyfriend", "https://university.com", "University of Houston", "CHEM-1", "Complementary", "Three", "Control Week Oven Knowledge" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 9, true, new DateTime(2001, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS2000", "Food Way Variety", "https://university.com", "University of Fort Worth", "CHEM-1", "Complementary", "Three", "Camera Activity Physics" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 8, true, new DateTime(2018, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3030", "Reading Reading Family Information", "https://university.com", "University of San Jose", "CITS4000", "Core", "Three", "Army Understanding Analysis Fact" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 7, true, new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR10", "Control Policy", "https://university.com", "University of San Diego", "CITS4000", "Complementary", "GtThree", "Child Basis Week Variety" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 6, true, new DateTime(2013, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR4000", "Policy Player Policy History", "https://university.com", "University of Charlotte", "ART4000", "Complementary", "GtThree", "Week Law Paper Television" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 5, true, new DateTime(1998, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1000", "Year Child", "https://university.com", "University of Austin", "CHEM1000", "Elective", "Three", "Society Idea Year" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 4, null, null, "ALGS100-3", "Problem Economics Camera", "https://university.com", "University of San Diego", "SCI200-2", "Core", "One", "Knowledge Policy Method" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 3, true, new DateTime(2010, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT1000", "Community Library Person Music", "https://university.com", "University of Chicago", "MATH100-3", "Complementary", "One", "Community Equipment Organization" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 2, false, new DateTime(1995, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR100-3", "Food Knowledge", "https://university.com", "University of Houston", "COMP2000", "Core", "Two", "World Software Law" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 23, null, null, "MGMT3.12", "Government Video Boyfriend Army", "https://university.com", "University of Jacksonville", "BIO2000", "Elective", "One", "Health Ability Literature" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 24, null, null, "CITS200-2", "Art Art", "https://university.com", "University of San Jose", "INFR200-2", "Core", "GtThree", "Security Society" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 25, null, null, "INFR3000", "Science Security Boyfriend", "https://university.com", "University of Phoenix", "CHEM200-2", "Elective", "Three", "Exam Idea Technology" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 26, false, new DateTime(1997, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3000", "Idea Strategy", "https://university.com", "University of Phoenix", "CITS2000", "Complementary", "One", "Freedom Environment" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 48, false, new DateTime(2004, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH10", "Reading Thing", "https://university.com", "University of Indianapolis", "ANTH2000", "Elective", "Three", "Area Week" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 47, true, new DateTime(2004, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH293.12", "Camera Direction", "https://university.com", "University of Detroit", "ALGS1020", "Complementary", "GtThree", "Organization Idea Exam Exam" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 46, true, new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR100-3", "Health Control", "https://university.com", "University of Austin", "STAT293.12", "Complementary", "Two", "Music Ability Reading" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 45, null, null, "CITS1020", "Country Ability", "https://university.com", "University of San Jose", "CHEM3.12", "Elective", "Three", "Development Food Way Physics" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 44, true, new DateTime(2011, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT200-2", "Strategy Activity Power", "https://university.com", "University of San Antonio", "SCI3000", "Elective", "Two", "Food Science Policy" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 43, true, new DateTime(2013, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM-1", "Idea Video Idea Person", "https://university.com", "University of Charlotte", "ALGS1020", "Elective", "Three", "Definition Reading Internet" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 42, false, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS1000", "Definition Child Investment Theory", "https://university.com", "University of Houston", "SCI1020", "Core", "Two", "Thanks Map" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 41, true, new DateTime(2012, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1020", "Reading Two", "https://university.com", "University of Columbus", "SCI1000", "Elective", "GtThree", "Two Definition Oven" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 40, true, new DateTime(1996, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM1020", "Government Analysis Problem Television", "https://university.com", "University of Indianapolis", "ALGS3.12", "Complementary", "GtThree", "Library Media" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 39, true, new DateTime(1997, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO4000", "Software Reading Video", "https://university.com", "University of Fort Worth", "INFR3.12", "Complementary", "GtThree", "Map Freedom Series Problem" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 99, false, new DateTime(2003, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP200-2", "Ability Literature Internet", "https://university.com", "University of Chicago", "CHEM293.12", "Complementary", "Two", "Theory Country" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 38, true, new DateTime(2003, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR2000", "Oven Fact Literature Health", "https://university.com", "University of San Diego", "MATH4000", "Elective", "One", "Camera Child" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 36, true, new DateTime(2006, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT1020", "Freedom Economics Video", "https://university.com", "University of Charlotte", "ALGS100-3", "Complementary", "Two", "Music Literature" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 35, true, new DateTime(2013, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP100-3", "Economics Family", "https://university.com", "University of Phoenix", "ANTH293.12", "Core", "Two", "Community Family Internet" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 34, true, new DateTime(1998, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3000", "Series Idea Paper", "https://university.com", "University of Detroit", "CHEM3030", "Core", "One", "Quality Direction Problem Way" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 33, true, new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3030", "Freedom Camera Literature", "https://university.com", "University of Chicago", "MGMT3030", "Complementary", "Two", "Law Art Security" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 32, true, new DateTime(2013, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT100-3", "Thing Information", "https://university.com", "University of Los Angeles", "MATH-1", "Elective", "Two", "Knowledge Television Series Person" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 31, null, null, "COMP4000", "Economics Basis Basis", "https://university.com", "University of Houston", "CITS293.12", "Complementary", "Three", "Paper Music" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 30, true, new DateTime(2014, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS293.12", "Boyfriend Theory Government Understanding", "https://university.com", "University of San Jose", "BIO10", "Complementary", "Two", "Direction Environment Health" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 29, true, new DateTime(2004, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH4000", "Player Software Theory", "https://university.com", "University of Detroit", "MGMT200-2", "Elective", "Two", "Economics Paper" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 28, true, new DateTime(1999, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI2000", "Area Definition Boyfriend", "https://university.com", "University of San Jose", "BIO100-3", "Elective", "One", "Bird Way Safety" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 27, true, new DateTime(1996, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM10", "Idea Player Family", "https://university.com", "University of San Antonio", "ANTH100-3", "Complementary", "One", "Strategy Child" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 37, true, new DateTime(2005, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM3030", "Media Power", "https://university.com", "University of Jacksonville", "STAT100-3", "Elective", "Three", "System Art Equipment Product" });

            migrationBuilder.InsertData(
                table: "UnitApprovalRequests",
                columns: new[] { "Id", "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUnitOutlineHref", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { 100, true, new DateTime(1997, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3.12", "History Area", "https://university.com", "University of San Antonio", "CHEM3030", "Complementary", "One", "Music Government Community" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitApprovalRequests");
        }
    }
}
