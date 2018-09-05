using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddStaffLogons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffLogons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    Salt = table.Column<byte[]>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLogons", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2012, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS-1", "Economics Bird", "University of Dallas", "CHEM4000", "Elective", "Two", "Thought Development Investment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(1996, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH100-3", "Music Thanks", "University of Austin", "MATH100-3", "Complementary", "Television History World Country" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3030", "Science Player Product Language", "University of Jacksonville", "STAT10", "Core", "Three", "Love Map" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2016, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS293.12", "Fact Equipment Strategy", "University of Austin", "STAT293.12", "Complementary", "Two", "Food Television Boyfriend Product" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART10", "Definition Environment", "University of Phoenix", "ANTH100-3", "Two", "Information Freedom Bird Music" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2014, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO-1", "Series Investment", "University of Phoenix", "SCI200-2", "Elective", "Two", "Software Language Knowledge Physics" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "MATH200-2", "Equipment Technology Series Literature", "University of Fort Worth", "COMP3000", "One", "Two Idea" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT100-3", "Ability Information", "University of Phoenix", "STAT4000", "Complementary", "One", "Thing Idea Instance" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2017, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1000", "Week Analysis Activity Direction", "University of Dallas", "ART4000", "Elective", "One", "Theory Health Industry" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS10", "Safety Player Ability Movie", "University of Dallas", "INFR10", "Core", "One", "Bird Country Problem" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ANTH100-3", "Story Paper Problem Power", "University of Houston", "MGMT4000", "Core", "One", "Freedom Definition" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM3.12", "Health Organization", "University of Chicago", "MGMT10", "Core", "Two", "Ability Food Method Week" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH-1", "Security Week", "University of Philadelphia", "CHEM2000", "Two", "Paper Thing Army Data" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(2016, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH3030", "Thanks Television Literature World", "University of Phoenix", "INFR3.12", "Core", "Activity Person Thought Activity" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR1000", "Child Reading", "University of Columbus", "COMP200-2", "Elective", "Two", "Environment Activity" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2002, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT1020", "Law World", "University of Columbus", "STAT10", "Elective", "Two", "Software Safety Law Food" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(2015, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART-1", "Meat Variety", "University of Philadelphia", "CHEM3.12", "Complementary", "Reading Management" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART200-2", "Method Idea Television", "University of Austin", "ART3000", "Elective", "GtThree", "Variety Data Reading Exam" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1998, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH3030", "Exam Safety", "University of Columbus", "STAT1020", "Core", "Three", "Week Definition" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "SCI-1", "Definition Computer Child Computer", "University of Fort Worth", "BIO3.12", "Core", "GtThree", "Army Idea Story Method" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART10", "Problem Area Thing System", "University of Dallas", "ANTH1020", "Elective", "Person Thing Instance World" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "BIO-1", "Exam Variety", "University of Austin", "CITS3.12", "Core", "Two", "Government Policy Variety Week" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH200-2", "System Economics", "University of San Antonio", "INFR100-3", "Complementary", "Three", "Story Year Year Internet" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2011, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR3.12", "Way Food Series Computer", "University of Austin", "MGMT1020", "Complementary", "One", "Community Art Fact" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { "ANTH293.12", "Video Economics Security Camera", "University of Jacksonville", "SCI4000", "Complementary", "Organization Instance" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1995, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS10", "Child Strategy Two", "University of Fort Worth", "SCI1020", "GtThree", "Camera Freedom" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1998, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1000", "Analysis Paper", "University of Charlotte", "COMP1020", "Two", "Control Literature Control Management" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS293.12", "Physics Idea", "University of San Diego", "Complementary", "Three", "Government Fact Information" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "BIO4000", "Camera Boyfriend Law", "University of Los Angeles", "ALGS3000", "Core", "GtThree", "Understanding Language Basis Strategy" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2004, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO200-2", "History Year", "University of Phoenix", "CHEM200-2", "Core", "One", "Data Management World Management" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART3030", "Method Theory", "University of Charlotte", "SCI10", "One", "Law Year" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI-1", "Exam Way Family", "University of Philadelphia", "STAT2000", "Complementary", "Three", "Thanks Paper" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2014, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1000", "System Media", "University of Indianapolis", "STAT3030", "Elective", "GtThree", "Product Product Activity" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { null, null, "STAT4000", "Strategy Technology History Theory", "University of Indianapolis", "CHEM200-2", "Complementary", "Oven Way" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2002, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS100-3", "People Year", "University of Jacksonville", "ALGS-1", "Complementary", "Three", "Area Movie Nature Activity" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { new DateTime(2017, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART293.12", "Equipment Science People", "University of Dallas", "MATH1020", "Literature Definition Society Two" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "MGMT293.12", "Bird Country", "University of Detroit", "INFR293.12", "GtThree", "Language Map Physics" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "SCI293.12", "Meat Software Media", "University of San Jose", "ANTH3.12", "Core", "Three", "Paper Reading Meat Army" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2007, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP-1", "Week Story Camera Physics", "University of Los Angeles", "INFR4000", "Core", "One", "Instance Science" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { new DateTime(2006, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS2000", "Software Society Country", "University of New York", "CHEM4000", "Temperature Economics Development Control" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2004, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3000", "Environment Organization Power Quality", "University of Charlotte", "BIO-1", "Core", "Three", "Understanding Safety Ability" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "COMP2000", "Library Fact Management", "University of Detroit", "INFR3030", "Elective", "Three", "History Food" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2014, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS2000", "Love Bird Physics Language", "University of San Antonio", "COMP3000", "Core", "Two", "Environment Basis" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1997, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH1020", "Player Two Safety", "University of New York", "ALGS293.12", "Complementary", "GtThree", "Variety Activity" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2004, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS200-2", "Story Bird System", "University of Indianapolis", "INFR200-2", "Core", "Two", "Activity People" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2011, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1000", "Law Analysis Television Product", "University of Jacksonville", "CITS200-2", "Core", "One", "Television Year Paper" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2003, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS293.12", "Series Health", "CITS1020", "Elective", "One", "Fact Reading World" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(2011, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1020", "Reading Thing Ability", "University of Chicago", "CITS3030", "Complementary", "Information Exam Management Control" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM4000", "Theory Power Country", "University of San Antonio", "CHEM3030", "Complementary", "Two", "Government Meat Food Literature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1996, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH4000", "Society Video Information Strategy", "University of Austin", "SCI3.12", "Complementary", "GtThree", "World People Safety" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2006, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1020", "Science Way Analysis", "University of Detroit", "STAT3.12", "Complementary", "System Environment Definition Paper" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS200-2", "Food Development", "University of Jacksonville", "CHEM1020", "Three", "Equipment Theory Series" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS200-2", "Power Map", "University of Chicago", "CHEM-1", "Elective", "GtThree", "Paper Child Person" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2007, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH1000", "Boyfriend Music Basis", "University of Dallas", "BIO-1", "Complementary", "Two", "Meat Meat Country" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2000, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT200-2", "Week Product Thing Player", "University of Detroit", "BIO293.12", "Complementary", "Development Bird" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(1998, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI10", "Bird Physics", "University of San Antonio", "MGMT2000", "Elective", "Idea Art Development" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM293.12", "Literature Library", "University of Chicago", "STAT4000", "Complementary", "Two", "Security Safety" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2007, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS200-2", "Way Two", "University of Charlotte", "CHEM-1", "Complementary", "One", "Movie Reading Health" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR200-2", "Camera Information Analysis Environment", "University of San Francisco", "CITS3.12", "Elective", "Three", "Paper Control" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2008, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART2000", "Video Development", "University of Austin", "CITS1020", "Two", "Activity Television Activity Power" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { "ALGS3000", "Government Definition", "University of Houston", "MATH3000", "Complementary", "Three", "Basis Week Movie Love" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP3000", "History Development", "University of Los Angeles", "ALGS1000", "Two", "Variety Thing" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(2018, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP1020", "Policy Strategy Organization", "MGMT1020", "Core", "Television Food" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS200-2", "Economics Definition Product Method", "University of San Jose", "STAT100-3", "Complementary", "Two", "Child Strategy Library" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { "INFR1000", "Player Theory Instance", "University of Houston", "ALGS10", "Complementary", "One", "Reading Exam Activity Data" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "BIO293.12", "Way Knowledge Management Policy", "University of Chicago", "MATH3.12", "GtThree", "Area Equipment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2008, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM100-3", "Policy Story", "SCI1000", "Two", "Music Meat" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "MATH1020", "Country Investment Idea Development", "University of Chicago", "MGMT3.12", "Core", "GtThree", "Literature Law Video Fact" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ANTH200-2", "Area Literature Understanding", "University of Fort Worth", "MATH1020", "One", "Quality Nature Language Bird" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2015, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP4000", "Ability Camera System", "University of New York", "BIO1020", "Core", "Society Bird Ability Literature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ART100-3", "Organization Physics", "University of Jacksonville", "CHEM3000", "Core", "GtThree", "Internet Year Direction Investment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2016, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR2000", "People Person", "University of Austin", "STAT3.12", "Core", "Three", "Two Power Management" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2001, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS-1", "Food Week Two Ability", "University of San Jose", "COMP10", "Two", "Library Strategy" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH2000", "Story Problem Week", "University of San Francisco", "ART200-2", "Elective", "GtThree", "Camera Problem Video Computer" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2017, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3000", "Safety Nature", "University of Chicago", "CHEM3000", "Core", "Two", "Information Boyfriend Person" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2017, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR4000", "Information Equipment Video", "University of Philadelphia", "STAT3000", "Three", "Temperature Knowledge Economics Reading" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ART2000", "Data Media Equipment", "University of Fort Worth", "MATH293.12", "Core", "One", "Freedom Security" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { true, new DateTime(2001, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS1000", "Technology Management System", "University of Los Angeles", "STAT1000", "Temperature Child Series Camera" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2004, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO4000", "Industry Physics Investment Week", "University of New York", "ANTH-1", "Elective", "GtThree", "Exam Library Player Language" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "COMP1000", "Story Health", "INFR293.12", "Elective", "GtThree", "Information Fact Equipment Control" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1020", "Television Television Investment", "University of Jacksonville", "ANTH4000", "GtThree", "Map Oven" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO-1", "Area Language Health Idea", "University of Philadelphia", "SCI100-3", "Core", "Policy Area Power" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH4000", "Army Nature Environment Society", "University of Charlotte", "BIO3000", "Security Temperature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "CHEM3000", "Basis Data Thought Television", "University of Phoenix", "MGMT1020", "GtThree", "Community Oven" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2011, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI100-3", "Meat Paper", "University of Austin", "STAT1000", "Three", "Two History" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI200-2", "Knowledge Economics", "University of Jacksonville", "CHEM3000", "Complementary", "Series Fact Freedom Movie" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(2013, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM3000", "Safety Software Area", "University of Jacksonville", "SCI2000", "Elective", "Ability Ability" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP4000", "Power Music", "University of Dallas", "SCI-1", "Two", "Idea Investment Basis" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1996, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR100-3", "Nature Direction Fact Two", "University of Fort Worth", "CITS1020", "Complementary", "Two", "History Investment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ART200-2", "Power History Way", "University of Phoenix", "INFR1020", "Complementary", "Two", "Person Economics" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { "MATH293.12", "Knowledge Bird People", "University of Charlotte", "SCI3030", "Area Quality" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { null, null, "STAT1000", "People Physics Method", "STAT200-2", "Complementary", "Policy Language" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ALGS3030", "Literature Media Product Video", "University of Philadelphia", "CITS3.12", "Complementary", "Three", "Equipment Love Literature Series" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2004, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM100-3", "Product Food Basis Safety", "University of San Diego", "CITS10", "Core", "Two", "Television Safety" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3000", "People Policy", "University of Chicago", "ART293.12", "One", "History Government Instance" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(2014, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR293.12", "Basis Internet Economics", "University of Los Angeles", "CITS4000", "Elective", "Child Television" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3.12", "History Investment Investment Bird", "University of Fort Worth", "CITS1000", "Two", "Movie Activity Understanding" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2016, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP10", "Quality Thing Video Management", "University of Dallas", "ANTH3000", "Complementary", "Two", "Country Movie" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "CHEM10", "Child Instance", "University of San Antonio", "COMP4000", "Three", "Year Information Data" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(1995, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART3000", "Technology Organization Community", "University of Indianapolis", "INFR2000", "Core", "Three", "History Movie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffLogons");

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1999, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS293.12", "Person Organization Control", "University of Los Angeles", "MATH3.12", "Core", "GtThree", "Understanding Direction Series Fact" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(1995, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR100-3", "Food Knowledge", "University of Houston", "COMP2000", "Core", "World Software Law" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT1000", "Community Library Person Music", "University of Chicago", "MATH100-3", "Complementary", "One", "Community Equipment Organization" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ALGS100-3", "Problem Economics Camera", "University of San Diego", "SCI200-2", "Core", "One", "Knowledge Policy Method" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1998, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1000", "Year Child", "University of Austin", "CHEM1000", "Three", "Society Idea Year" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR4000", "Policy Player Policy History", "University of Charlotte", "ART4000", "Complementary", "GtThree", "Week Law Paper Television" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR10", "Control Policy", "University of San Diego", "CITS4000", "GtThree", "Child Basis Week Variety" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2018, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3030", "Reading Reading Family Information", "University of San Jose", "CITS4000", "Core", "Three", "Army Understanding Analysis Fact" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2001, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS2000", "Food Way Variety", "University of Fort Worth", "CHEM-1", "Complementary", "Three", "Camera Activity Physics" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1000", "Product Direction Army Boyfriend", "University of Houston", "CHEM-1", "Complementary", "Three", "Control Week Oven Knowledge" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1995, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR3000", "History Freedom Television Player", "University of Detroit", "ART3.12", "Elective", "GtThree", "Society Meat" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2014, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH100-3", "Analysis Reading Thanks", "University of Austin", "CITS2000", "Complementary", "One", "Year Language" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2016, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3030", "Movie Information", "University of Charlotte", "BIO-1", "Three", "Analysis History Thing" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1000", "World Story World Thing", "University of Indianapolis", "MATH1020", "Complementary", "Organization Child Literature Product" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2010, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT293.12", "Quality Story Variety", "University of Austin", "SCI3030", "Complementary", "GtThree", "Control Activity Direction Map" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1995, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT2000", "Bird System", "University of New York", "COMP1000", "Core", "GtThree", "Love Analysis Thought" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { null, null, "ANTH1020", "Control Method Freedom Library", "University of Dallas", "MATH1000", "Core", "Strategy Army Child" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2003, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM10", "Boyfriend Management Fact", "University of San Antonio", "ANTH3.12", "Core", "One", "Definition Art Bird Information" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2007, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT3.12", "Army Method Love Theory", "University of Fort Worth", "MGMT10", "Elective", "One", "Definition Story Analysis" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2005, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS293.12", "Community Thought Story", "University of Columbus", "ALGS-1", "Complementary", "Two", "Freedom Understanding Thought" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(1996, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI2000", "Internet Security Data Thing", "University of Fort Worth", "BIO293.12", "Core", "History Ability Two" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1020", "Power Player Policy Basis", "University of San Antonio", "SCI3000", "Complementary", "GtThree", "Music Management" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "MGMT3.12", "Government Video Boyfriend Army", "University of Jacksonville", "BIO2000", "Elective", "One", "Health Ability Literature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "CITS200-2", "Art Art", "University of San Jose", "INFR200-2", "Core", "GtThree", "Security Society" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { "INFR3000", "Science Security Boyfriend", "University of Phoenix", "CHEM200-2", "Elective", "Exam Idea Technology" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(1997, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3000", "Idea Strategy", "University of Phoenix", "CITS2000", "One", "Freedom Environment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1996, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM10", "Idea Player Family", "University of San Antonio", "ANTH100-3", "One", "Strategy Child" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1999, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI2000", "Area Definition Boyfriend", "University of San Jose", "Elective", "One", "Bird Way Safety" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2004, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH4000", "Player Software Theory", "University of Detroit", "MGMT200-2", "Elective", "Two", "Economics Paper" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2014, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS293.12", "Boyfriend Theory Government Understanding", "University of San Jose", "BIO10", "Complementary", "Two", "Direction Environment Health" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "COMP4000", "Economics Basis Basis", "University of Houston", "CITS293.12", "Three", "Paper Music" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT100-3", "Thing Information", "University of Los Angeles", "MATH-1", "Elective", "Two", "Knowledge Television Series Person" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3030", "Freedom Camera Literature", "University of Chicago", "MGMT3030", "Complementary", "Two", "Law Art Security" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(1998, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3000", "Series Idea Paper", "University of Detroit", "CHEM3030", "Core", "Quality Direction Problem Way" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP100-3", "Economics Family", "University of Phoenix", "ANTH293.12", "Core", "Two", "Community Family Internet" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { new DateTime(2006, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT1020", "Freedom Economics Video", "University of Charlotte", "ALGS100-3", "Music Literature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2005, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM3030", "Media Power", "University of Jacksonville", "STAT100-3", "Three", "System Art Equipment Product" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2003, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR2000", "Oven Fact Literature Health", "University of San Diego", "MATH4000", "Elective", "One", "Camera Child" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1997, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO4000", "Software Reading Video", "University of Fort Worth", "INFR3.12", "Complementary", "GtThree", "Map Freedom Series Problem" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { new DateTime(1996, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM1020", "Government Analysis Problem Television", "University of Indianapolis", "ALGS3.12", "Library Media" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO1020", "Reading Two", "University of Columbus", "SCI1000", "Elective", "GtThree", "Two Definition Oven" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS1000", "Definition Child Investment Theory", "University of Houston", "SCI1020", "Core", "Two", "Thanks Map" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM-1", "Idea Video Idea Person", "University of Charlotte", "ALGS1020", "Elective", "Three", "Definition Reading Internet" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2011, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT200-2", "Strategy Activity Power", "University of San Antonio", "SCI3000", "Elective", "Two", "Food Science Policy" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "CITS1020", "Country Ability", "University of San Jose", "CHEM3.12", "Elective", "Three", "Development Food Way Physics" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR100-3", "Health Control", "University of Austin", "STAT293.12", "Complementary", "Two", "Music Ability Reading" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2004, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH293.12", "Camera Direction", "ALGS1020", "Complementary", "GtThree", "Organization Idea Exam Exam" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(2004, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH10", "Reading Thing", "University of Indianapolis", "ANTH2000", "Elective", "Area Week" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2005, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTH100-3", "Thought Basis Thought", "University of New York", "CHEM3000", "Elective", "Three", "Control People" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2000, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART1000", "Oven Variety Love", "University of San Antonio", "COMP1020", "Core", "One", "Two Thought Idea" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(1997, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM-1", "Method Year System History", "University of Columbus", "BIO4000", "Core", "Theory World Variety Video" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2014, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH2000", "Thought Week Meat", "University of San Jose", "ART1020", "One", "Army Paper Knowledge Management" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2006, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO-1", "Movie Story Exam Video", "University of Columbus", "ANTH293.12", "Core", "Two", "Development World Power Child" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2015, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO-1", "Way Society Army", "University of Los Angeles", "INFR2000", "Core", "Three", "Two Literature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2004, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP1000", "Literature Bird", "University of Indianapolis", "MATH3000", "Core", "Power Health Year Temperature" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2007, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR10", "Idea Industry", "University of Detroit", "ANTH-1", "Core", "Country Law Data Data" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(1996, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO3000", "Policy Art", "University of Detroit", "BIO100-3", "Core", "One", "Exam Reading Basis" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT-1", "Year Map", "University of Indianapolis", "ALGS1020", "Core", "GtThree", "Computer Series" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2014, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS10", "Activity Environment Information Society", "University of San Diego", "STAT1020", "Core", "One", "Problem Literature Analysis" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2014, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT-1", "Information Country Analysis", "University of Los Angeles", "MGMT293.12", "Three", "Equipment Economics" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { "COMP4000", "Safety Development", "University of Columbus", "MGMT3.12", "Core", "GtThree", "Series Way Person People" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "ANTH3000", "Control Science", "University of Dallas", "COMP3.12", "GtThree", "Player Product" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { null, null, "MATH1000", "Literature Society", "INFR293.12", "Complementary", "Society Development" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2015, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP10", "Boyfriend Economics Theory Paper", "University of Charlotte", "ART10", "Core", "GtThree", "Freedom Freedom Music" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { "INFR-1", "Bird Security Society", "University of Charlotte", "CHEM100-3", "Core", "GtThree", "Story Media Understanding" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ART3000", "Government Child History Media", "University of Austin", "INFR100-3", "Three", "Safety Food Map" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1998, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP2000", "Internet Security Food Information", "ANTH1000", "GtThree", "Method Definition Language Policy" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2005, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT1000", "Temperature Library", "University of Detroit", "ANTH2000", "Complementary", "Two", "Camera Oven Week Equipment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2007, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH10", "Definition Internet Instance", "University of Austin", "ART293.12", "Three", "Direction Technology" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT293.12", "Policy Definition", "University of Phoenix", "CITS10", "Complementary", "Power Organization System" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2007, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "STAT-1", "Library Strategy Art Player", "University of San Diego", "ALGS4000", "Elective", "Two", "Theory Society Thing Instance" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2012, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH3000", "Army Society Love Power", "University of Columbus", "CHEM293.12", "Complementary", "One", "Music Science Meat Ability" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2016, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1020", "Ability Story Software", "University of Philadelphia", "CHEM3.12", "GtThree", "Country Freedom" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM3.12", "Knowledge Year Policy", "University of Indianapolis", "CHEM100-3", "Complementary", "One", "Analysis Freedom Basis" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1998, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM100-3", "Thing Science Product Community", "University of Charlotte", "BIO3.12", "Complementary", "One", "Food Law" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "CHEM4000", "Child Society Safety", "University of San Antonio", "MATH100-3", "Two", "Economics Technology Quality Music" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2016, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM200-2", "Reading Way Computer Ability", "University of Charlotte", "ANTH1000", "Complementary", "Three", "Movie Activity" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { null, null, "CHEM2000", "Problem Bird", "University of San Jose", "ALGS2000", "Strategy Library Health Quality" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "COMP-1", "Variety Software Paper Economics", "University of Fort Worth", "SCI3000", "Core", "Two", "Quality Community Power" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2009, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH200-2", "Ability Thing Investment", "MATH4000", "Core", "Two", "Technology Security" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2001, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3030", "Ability Quality", "University of Chicago", "ART3000", "Three", "Management Theory Language" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { new DateTime(2002, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM4000", "Management People Way Direction", "University of Columbus", "INFR4000", "Complementary", "Safety Way" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { new DateTime(1999, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM293.12", "Library Library", "University of Chicago", "COMP3.12", "Activity Quality Exam" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2005, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI293.12", "Year Problem Art", "University of Indianapolis", "MATH3030", "One", "Movie Analysis Freedom Environment" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2000, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CITS3000", "Development Understanding", "University of San Antonio", "BIO293.12", "One", "System Freedom Development Law" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { null, null, "STAT200-2", "Language Computer", "University of San Diego", "SCI293.12", "Elective", "Equipment Person Power Technology" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(1999, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI100-3", "Player History", "University of San Jose", "CITS1000", "Complementary", "Year Development Power Data" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2013, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALGS2000", "Fact Computer Thought Organization", "University of Phoenix", "INFR3030", "GtThree", "Two Art Management Video" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI1000", "Paper History Strategy", "University of New York", "ART10", "Core", "Three", "Computer Physics Year Movie" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2010, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI10", "Story Community", "University of Austin", "STAT200-2", "Elective", "GtThree", "Law Thought Law Fact" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitName" },
                values: new object[] { "CHEM-1", "Way Literature Freedom Data", "University of Fort Worth", "ART293.12", "Boyfriend Method Meat History" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { false, new DateTime(1997, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHEM200-2", "Family Love Bird", "CHEM1020", "Core", "Law Development" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(2016, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3000", "Television Player Country System", "University of New York", "MGMT3.12", "Elective", "Two", "Society Knowledge Science" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { null, null, "CHEM3000", "Player Physics Basis", "University of Charlotte", "ALGS3030", "Complementary", "Three", "Organization Language Industry" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2003, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MATH10", "Theory Library Control", "University of Charlotte", "COMP200-2", "GtThree", "Data Quality Thing Technology" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitName" },
                values: new object[] { true, new DateTime(2000, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIO10", "Control Thanks", "University of Dallas", "MGMT1020", "Complementary", "Series Thing" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2010, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCI3.12", "Media Instance History", "University of San Francisco", "CHEM293.12", "Three", "Theory Language" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { new DateTime(2004, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "INFR3000", "Story Nature Two Quality", "University of Philadelphia", "SCI1020", "Elective", "GtThree", "Internet Library" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { false, new DateTime(2003, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "COMP200-2", "Ability Literature Internet", "University of Chicago", "CHEM293.12", "Two", "Theory Country" });

            migrationBuilder.UpdateData(
                table: "UnitApprovalRequests",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Approved", "DecisionDate", "ExchangeUnitCode", "ExchangeUnitName", "ExchangeUniversityName", "UWAUnitCode", "UWAUnitContext", "UWAUnitLevel", "UWAUnitName" },
                values: new object[] { true, new DateTime(1997, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGMT3.12", "History Area", "University of San Antonio", "CHEM3030", "Complementary", "One", "Music Government Community" });
        }
    }
}
