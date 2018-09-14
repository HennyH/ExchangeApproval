using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApproval.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeApplicationUnitSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationId = table.Column<int>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    StudentNumber = table.Column<string>(nullable: true),
                    ExchangeDate = table.Column<DateTime>(nullable: false),
                    CourseCode = table.Column<string>(nullable: true),
                    ExchangeUniversityCountry = table.Column<string>(nullable: true),
                    ExchangeUniversityHref = table.Column<string>(nullable: true),
                    ExchangeUniversityName = table.Column<string>(nullable: true),
                    ExchangeUnits = table.Column<string>(nullable: true),
                    UWAUnits = table.Column<string>(nullable: true),
                    IsEquivalent = table.Column<bool>(nullable: true),
                    EquivalencePrecedentId = table.Column<int>(nullable: true),
                    IsContextuallyApproved = table.Column<bool>(nullable: true),
                    EquivalentUWAUnitLevel = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeApplicationUnitSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeApplicationUnitSets_ExchangeApplicationUnitSets_EquivalencePrecedentId",
                        column: x => x.EquivalencePrecedentId,
                        principalTable: "ExchangeApplicationUnitSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffLogons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    Salt = table.Column<byte[]>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLogons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 1, 20933990, "BP004", null, 3, new DateTime(2016, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELECENG 3TP4\",\"Title\":\"Signal\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2016, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20933987", "[{\"Code\":\"ENSC3015\",\"Title\":\"People Reading Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 398, 20769897, "60110", null, 3, new DateTime(2012, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENEE503\",\"Title\":\"Energy\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ENVE3604\",\"Title\":\"Method Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 399, 20769896, "60110", null, 5, new DateTime(2012, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVIL ENG 581\",\"Title\":\"Water\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Activity Video Health Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 400, 20769895, "60110", null, 5, new DateTime(2012, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GEOMATICS ENGINEERING 637\",\"Title\":\"Earth Observation For The Environment\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Method Music Ability Player\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 401, 20769896, "60110", null, 5, new DateTime(2012, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENGG513\",\"Title\":\"Roles\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Thought Development Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 402, 20769894, "60110", null, 5, new DateTime(2012, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVIL ENG 587\",\"Title\":\"Site Assessment\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2011, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Theory Television Government\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 403, 20769897, "60110", null, 5, new DateTime(2012, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENEE573\",\"Title\":\"Engineering Aspects Of Sustainable Communities\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Person Week Video\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 397, 20769896, "60110", null, 3, new DateTime(2012, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENME341\",\"Title\":\"Fundamentals Of Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2011, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"ENVE3601\",\"Title\":\"Equipment Freedom\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 404, 10516674, "60110", null, 3, new DateTime(2012, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE360 AND CEE460\",\"Title\":\"Structural Engineering And Steel Structures 1\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2012, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10516670", "[{\"Code\":\"CIVL3110\",\"Title\":\"Series Technology Paper Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 406, 10516673, "60110", null, 3, new DateTime(2012, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE480\",\"Title\":\"Foundation Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2012, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10516670", "[{\"Code\":\"CIVL3120\",\"Title\":\"Science Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 407, 10516671, "60110", null, 3, new DateTime(2012, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE202\",\"Title\":\"Engineering Risk And Uncertainty\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2011, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10516670", "[{\"Code\":\"CIVL3150\",\"Title\":\"Player Government Reading Video\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 408, 10516674, "60110", null, 3, new DateTime(2012, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE461\",\"Title\":\"Reinforced Concrete 1\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2012, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10516670", "[{\"Code\":\"CIVL3112\",\"Title\":\"Environment Way Definition\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 409, 10516671, "60110", null, 4, new DateTime(2012, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE472\",\"Title\":\"Structural Dynamics 1\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2012, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10516670", "[{\"Code\":\"CIVL4110\",\"Title\":\"Variety Direction Army Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 410, 10516672, "60110", null, 4, new DateTime(2012, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE320\",\"Title\":\"Construction Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2012, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liang has suggested this equivalence after student suggested equivalent to CIVL2150 (which he signed 'no' to)", "10516670", "[{\"Code\":\"CIVL4150\",\"Title\":\"Idea Law Person Direction\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 411, 10516672, "60110", null, 4, new DateTime(2012, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE465\",\"Title\":\"Design Of Structural Systems\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2011, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liang has suggested this equivalence after student suggested equivalent to CIVL3140 (which he signed 'no' to)", "10516670", "[{\"Code\":\"CIVL4111\",\"Title\":\"Variety Thing Paper\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 405, 10516673, "60110", null, 3, new DateTime(2012, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE452\",\"Title\":\"Hydraulic Analysis And Design\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10516670", "[{\"Code\":\"CIVL3130\",\"Title\":\"Camera Literature Control\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 396, 20769896, "60110", null, 2, new DateTime(2012, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GLGY571\",\"Title\":\"Engineering Geology\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"CIVL2121\",\"Title\":\"Camera Paper System\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 395, 20769897, "60110", null, 2, new DateTime(2012, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GLGY209\",\"Title\":\"Intro To Geology 1\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2011, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20769893", "[{\"Code\":\"CIVL2121\",\"Title\":\"World Thanks People Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 394, 20775652, "61140", null, 2, new DateTime(2012, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENME341\",\"Title\":\"Fundamentals Of Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20775649", "[{\"Code\":\"MECH2403\",\"Title\":\"Software Internet Problem Reading\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 379, 20928629, "60110", null, 5, new DateTime(2013, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4185\",\"Title\":\"Natural Gas Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928627", "[{\"Code\":\"CHPR5522\",\"Title\":\"Music Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 380, 20505698, "61140", null, 3, new DateTime(2012, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVE2405\",\"Title\":\"Water Engineering II\",\"Href\":\"https://unit.com\"}]", "Leeds University", "https://university.com", "Leeds University", true, true, new DateTime(2011, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20505694", "[{\"Code\":\"CIVL3130\",\"Title\":\"Freedom Instance Control\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 381, 20505698, "61140", null, 3, new DateTime(2012, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVE3500\",\"Title\":\"Geotechnics III\",\"Href\":\"https://unit.com\"}]", "Leeds University", "https://university.com", "Leeds University", true, true, new DateTime(2012, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20505694", "[{\"Code\":\"CIVL3120\",\"Title\":\"Economics Player Food Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 382, 20748340, "51160", null, 3, new DateTime(2012, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4120\",\"Title\":\"Process Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20748336", "[{\"Code\":\"ENSC3019\",\"Title\":\"Power Thought Child\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 383, 20748339, "51160", null, 4, new DateTime(2012, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4110\",\"Title\":\"Chemical Reaction Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20748336", "[{\"Code\":\"CHPR4406\",\"Title\":\"Reading Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 384, 20748339, "51160", null, 4, new DateTime(2012, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4125\",\"Title\":\"Engineering Thermodynamics 2\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20748336", "[{\"Code\":\"CHPR4404\",\"Title\":\"Art Analysis Literature Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 385, 20748340, "51160", null, 5, new DateTime(2012, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4170\",\"Title\":\"Process Design Project\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20748336", "[{\"Code\":\"GENG5505\",\"Title\":\"Area Player Week Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 386, 20748339, "51160", null, 4, new DateTime(2012, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4520\",\"Title\":\"Industrial Process Technology, Specialisation Project\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20748336", "[{\"Code\":\"CHPR4401&CHPR4402\",\"Title\":\"Community Environment Problem Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 387, 20360216, "61140", null, 1, new DateTime(2012, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"APSC111\",\"Title\":\"Mechanics\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2012, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH1401\",\"Title\":\"Policy Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 388, 20360216, "61140", null, 2, new DateTime(2012, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH330\",\"Title\":\"Applied Thermo II\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2012, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH2403\",\"Title\":\"Investment Story Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 389, 20360216, "61140", null, 1, new DateTime(2012, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MINE201\",\"Title\":\"Intro To  Mining/ Mineral Processing\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2011, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MINE1160\",\"Title\":\"Bird Story People Computer\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 390, 20360213, "61140", null, 2, new DateTime(2012, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MTHE237\",\"Title\":\"Differential Equations And Computer Methods\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2012, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"GENG2140\",\"Title\":\"Organization Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 391, 20775651, "61140", null, 2, new DateTime(2012, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENGG317\",\"Title\":\"Mechanics Of Solids\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20775649", "[{\"Code\":\"CIVL2110\",\"Title\":\"Paper Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 392, 20775650, "61140", null, 2, new DateTime(2012, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENME493\",\"Title\":\"Machine Component Design\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20775649", "[{\"Code\":\"MECH2402\",\"Title\":\"Food Security Love Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 393, 20775653, "61140", null, 2, new DateTime(2012, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENGG513\",\"Title\":\"Roles\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20775649", "[{\"Code\":\"MECH2401\",\"Title\":\"Year Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 412, 20360215, "61140", null, 4, new DateTime(2012, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4185\",\"Title\":\"Mechanical Vibrations\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2011, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH4426\",\"Title\":\"Environment Software Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 413, 20360214, "61140", null, 5, new DateTime(2012, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4192\",\"Title\":\"Finite Element Methods In Strength Analysis\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"GENG5514\",\"Title\":\"Oven Analysis Player Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 414, 20360213, "61140", null, 5, new DateTime(2012, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4265\",\"Title\":\"Arctic And Marine Civil Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH GROUP B\",\"Title\":\"Problem Year\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 415, 20360215, "61140", null, 5, new DateTime(2012, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TGB4160\",\"Title\":\"Petroleum Geology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH GROUP B\",\"Title\":\"Language Week Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 435, 20361099, "61140", null, 3, new DateTime(2011, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG3001\",\"Title\":\"Process Dynamics And Control\",\"Href\":\"https://unit.com\"}]", "University College London", "https://university.com", "University College London", true, true, new DateTime(2011, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361095", "[{\"Code\":\"CHPR3433\",\"Title\":\"Analysis Exam\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 436, 20361096, "61140", null, 3, new DateTime(2011, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG2007\",\"Title\":\"Particulate Systems And Searation Processes\",\"Href\":\"https://unit.com\"}]", "University College London", "https://university.com", "University College London", true, true, new DateTime(2010, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361095", "[{\"Code\":\"CHPR3434\",\"Title\":\"Software Movie Management Product\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 437, 20361097, "61140", null, 3, new DateTime(2011, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG2002 AND CENG2006\",\"Title\":\"Mass Transfer Operations And Process Heat Transfer\",\"Href\":\"https://unit.com\"}]", "University College London", "https://university.com", "University College London", true, true, new DateTime(2010, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361095", "[{\"Code\":\"CHPR3530 AND CHPR2432\",\"Title\":\"Law Child\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 438, 20361097, "61140", null, 4, new DateTime(2011, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG2003\",\"Title\":\"Process Engineering\",\"Href\":\"https://unit.com\"}]", "University College London", "https://university.com", "University College London", true, true, new DateTime(2010, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361095", "[{\"Code\":\"MECH4400\",\"Title\":\"Equipment Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 439, 20368289, "51160", null, 2, new DateTime(2011, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV202\",\"Title\":\"Pump And Pipeline Hydraulics\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2011, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"CIVL2130\",\"Title\":\"Quality Strategy Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 440, 20368290, "51160", null, 2, new DateTime(2011, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV250 CIV251\",\"Title\":\"Geotechnical Engineering 2, Geotechnical Engineering 3\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2010, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"CIVL2122\",\"Title\":\"Television Thought Environment Week\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 441, 20368289, "51160", null, 2, new DateTime(2011, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV210,CIV212\",\"Title\":\"Structural Analysis1, Structural Analysis2\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2010, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"CIVL2110\",\"Title\":\"Definition Knowledge Policy Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 442, 20368289, "51160", null, 2, new DateTime(2011, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV123, 122\",\"Title\":\"Civil Engineering Design And Surveying, Civil Engingeering Design And Drawing\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2011, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"CIVL2150\",\"Title\":\"Paper Area Equipment Video\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 443, 20368289, "51160", null, 2, new DateTime(2011, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MAS250\",\"Title\":\"Further Civil Engineering Mathematics And Computing\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2011, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"GENG2140\",\"Title\":\"Thing Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 444, 20368289, "51160", null, 3, new DateTime(2011, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV233\",\"Title\":\"Open Channel Hydraulics\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2011, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"CIVL3130\",\"Title\":\"Language Two Society Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 445, 20368289, "51160", null, 5, new DateTime(2011, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV223\",\"Title\":\"Structural Engineering Design And Appraisal\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2011, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Environment Problem\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 446, 20368288, "51160", null, 5, new DateTime(2011, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV226\",\"Title\":\"Civil Structrual Engineering Design\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2011, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20368287", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Policy Computer\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 447, 20348229, "60110", null, 4, new DateTime(2011, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE321\",\"Title\":\"Transportation Systems\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2010, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20348227", "[{\"Code\":\"CIVL4180\",\"Title\":\"Government Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 448, 20348229, "60110", null, 3, new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE331\",\"Title\":\"Reinforced Concrete Design\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2011, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20348227", "[{\"Code\":\"CIVL3112\",\"Title\":\"Television Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 449, 20348231, "60110", null, 1, new DateTime(2011, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE341\",\"Title\":\"`\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2010, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20348227", "[{\"Code\":\"ENVE1601\",\"Title\":\"Television Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 434, 20361098, "61140", null, 3, new DateTime(2011, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG3003\",\"Title\":\"Chemical Reaction Engineering\",\"Href\":\"https://unit.com\"}]", "University College London", "https://university.com", "University College London", true, true, new DateTime(2011, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361095", "[{\"Code\":\"CHPR3432\",\"Title\":\"Freedom Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 378, 20741095, "BP004", null, 5, new DateTime(2013, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECON372\",\"Title\":\"Business Finance 2\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2012, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "This exchange unit is considered equivalent to a Finance major level 2 option unit but not high enough for a level 3 option unit", "20741091", "[{\"Code\":\"FINANCE LEVEL 2 OPTION UNIT\",\"Title\":\"Area Data History Product\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 433, 20508677, "60110", null, 5, new DateTime(2011, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME345\",\"Title\":\"Intrumentation, Measurements And Statistics\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2011, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508675", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Literature Television\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 431, 20508676, "60110", null, 3, new DateTime(2011, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME360\",\"Title\":\"Mechanical Design\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2011, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508675", "[{\"Code\":\"MECH3403\",\"Title\":\"Activity Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 416, 20360215, "61140", null, 5, new DateTime(2012, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4146\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"GROUP B\",\"Title\":\"Understanding Policy Boyfriend Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 417, 20360216, "61140", null, 4, new DateTime(2012, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4185\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH4426\",\"Title\":\"Law Exam Area Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 418, 20360214, "61140", null, 4, new DateTime(2012, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4192\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"MECH4407\",\"Title\":\"Development Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 419, 20360215, "61140", null, 5, new DateTime(2012, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4265\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"GROUP B\",\"Title\":\"Equipment Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 420, 20360213, "61140", null, 5, new DateTime(2012, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TGB4160\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20360212", "[{\"Code\":\"GROUP B\",\"Title\":\"Thing Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 421, 20361454, "61140", null, 4, new DateTime(2011, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EE3041\",\"Title\":\"Power Transmission And Distribution\",\"Href\":\"https://unit.com\"}]", "Hong Kong Polytechnic", "https://university.com", "Hong Kong Polytechnic", true, true, new DateTime(2011, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361451", "[{\"Code\":\"ELEC4307\",\"Title\":\"Knowledge Child Analysis Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 422, 20361452, "61140", null, 3, new DateTime(2011, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EE3051\",\"Title\":\"Systems And Control\",\"Href\":\"https://unit.com\"}]", "Hong Kong Polytechnic", "https://university.com", "Hong Kong Polytechnic", true, true, new DateTime(2011, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361451", "[{\"Code\":\"ELEC3306\",\"Title\":\"Art Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 423, 20361455, "61140", null, 4, new DateTime(2011, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EE4041\",\"Title\":\"Engineering Project Management\",\"Href\":\"https://unit.com\"}]", "Hong Kong Polytechnic", "https://university.com", "Hong Kong Polytechnic", true, true, new DateTime(2011, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20361451", "[{\"Code\":\"ELEC4332\",\"Title\":\"Bird Society Law Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 424, 20492167, "61110", null, 1, new DateTime(2011, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE305\",\"Title\":\"Electric Power Systems\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2010, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20492166", "[{\"Code\":\"ELEC1302\",\"Title\":\"Way Camera Library Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 425, 20508793, "60110", null, 4, new DateTime(2011, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE305\",\"Title\":\"Traffic Engineering\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2011, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508791", "[{\"Code\":\"CIVL4180\",\"Title\":\"Music Understanding Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 426, 20508793, "60110", null, 3, new DateTime(2011, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE327\",\"Title\":\"Reinforced Concrete Design\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2011, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508791", "[{\"Code\":\"CIVL3112\",\"Title\":\"Music Organization Product\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 427, 20508792, "60110", null, 2, new DateTime(2011, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE382\",\"Title\":\"Hydraulics\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2010, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508791", "[{\"Code\":\"CIVL2130\",\"Title\":\"Food Video Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 428, 20508792, "60110", null, 5, new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ST370\",\"Title\":\"Probability/Stats For Engrs\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2011, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508791", "[{\"Code\":\"GROUP D OPTION\",\"Title\":\"Organization Data Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 429, 20508679, "60110", null, 3, new DateTime(2011, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME370\",\"Title\":\"Vibration Mech Systems\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508675", "[{\"Code\":\"MECH3404\",\"Title\":\"History Series Freedom Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 430, 20508676, "60110", null, 2, new DateTime(2011, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME240\",\"Title\":\"Product Dissection\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508675", "[{\"Code\":\"MECH2402\",\"Title\":\"Paper Freedom Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 432, 20508678, "60110", null, 5, new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"AERSP306\",\"Title\":\"Aeronautics 1\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2011, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20508675", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Week Thought Camera Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 450, 20348231, "60110", null, 5, new DateTime(2011, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE311S\",\"Title\":\"Probability/Stats For Civil Engrs\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2011, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20348227", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Thanks Environment Industry Variety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 377, 20159208, "60450", null, 3, new DateTime(2013, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE10421\",\"Title\":\"\\\"Fluid Mechanics 1\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"MACE20002\",\"Title\":\"\\\"Applied Fluid Mechanics\\\"\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2013, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20159207", "[{\"Code\":\"ENSC3003\",\"Title\":\"System Exam Physics Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 375, 20159210, "60450", null, 2, new DateTime(2013, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE10421\",\"Title\":\"\\\"Fluid Mechanics\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"MACE10602\",\"Title\":\"\\\"Mechanics\\\"\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2013, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20159207", "[{\"Code\":\"ENSC2001\",\"Title\":\"Method Food Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 322, 20757112, "60110", null, 5, new DateTime(2013, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"AAE33400\",\"Title\":\"Aerodynamics\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20757109", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Ability System Government Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 323, 20757110, "60110", null, 3, new DateTime(2013, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME35200\",\"Title\":\"Machine Design 1\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20757109", "[{\"Code\":\"ENSC3001\",\"Title\":\"Country Analysis Community Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 324, 20926616, "61140", null, 4, new DateTime(2013, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH330\",\"Title\":\"Applied Thermodynamics\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20926615", "[{\"Code\":\"MECH4429\",\"Title\":\"Environment Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 325, 20926618, "61140", null, 3, new DateTime(2013, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MINE201\",\"Title\":\"Introduction To Mining And Mineral\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20926615", "[{\"Code\":\"ENSC3011\",\"Title\":\"Art Series Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 326, 20926619, "61140", null, 3, new DateTime(2013, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH328\",\"Title\":\"Dynamics And Vibration\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20926615", "[{\"Code\":\"ENSC3001\",\"Title\":\"Internet Information Bird\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 327, 20776728, "61140", null, 5, new DateTime(2013, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MINE359\",\"Title\":\"Reliability, Maintenance And Risk\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776725", "[{\"Code\":\"GENG5507\",\"Title\":\"Paper Development Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 321, 20757112, "60110", null, 5, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"AAE25100\",\"Title\":\"Introduction To Aerospace Design\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20757109", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Information Power Paper Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 328, 20918798, "61140", null, 3, new DateTime(2013, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC443\",\"Title\":\"Control Systems 1\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20918796", "[{\"Code\":\"ELEC3306\",\"Title\":\"Safety Nature Movie\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 330, 20918797, "61140", null, 3, new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC381\",\"Title\":\"Applications Of Electromagnetics\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20918796", "[{\"Code\":\"ELEC3303\",\"Title\":\"Strategy Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 331, 20918798, "61140", null, 2, new DateTime(2013, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC271\",\"Title\":\"Digital Systems\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20918796", "[{\"Code\":\"ELEC2301\",\"Title\":\"Exam Problem Strategy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 332, 20918799, "61140", null, 3, new DateTime(2013, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC353\",\"Title\":\"Electronics 2\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20918796", "[{\"Code\":\"ELEC3300\",\"Title\":\"Problem Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 333, 20524095, "61140", null, 4, new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CVEN40080\",\"Title\":\"Hydraulic Engineering Design\",\"Href\":\"https://unit.com\"}]", "University College Dublin", "https://university.com", "University College Dublin", true, true, new DateTime(2013, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20524094", "[{\"Code\":\"CIVL4130\",\"Title\":\"Internet Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 334, 20524098, "61140", null, 5, new DateTime(2013, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CVEN40210\",\"Title\":\"Soil Mechanics And Geotechnical Engineering\",\"Href\":\"https://unit.com\"}]", "University College Dublin", "https://university.com", "University College Dublin", true, true, new DateTime(2013, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20524094", "[{\"Code\":\"CIVL5232\",\"Title\":\"Temperature Problem Definition Boyfriend\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 336, 20524098, "61140", null, 4, new DateTime(2013, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CVEN40430\",\"Title\":\"Soil-Structure Interaction\",\"Href\":\"https://unit.com\"}]", "University College Dublin", "https://university.com", "University College Dublin", true, true, new DateTime(2013, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20524094", "[{\"Code\":\"CIVL4120\",\"Title\":\"Meat Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 329, 20918798, "61140", null, 3, new DateTime(2013, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC333\",\"Title\":\"Electric Machines\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2012, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20918796", "[{\"Code\":\"ENSC3016\",\"Title\":\"Family Science Television Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 320, 20757110, "60110", null, 5, new DateTime(2013, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"AAE45100\",\"Title\":\"Aircraft Design\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20757109", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Government Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 319, 20757112, "60110", null, 4, new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME56300\",\"Title\":\"Mechanical Vibrations\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20757109", "[{\"Code\":\"MECH4426\",\"Title\":\"Temperature Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 318, 20757113, "60110", null, 3, new DateTime(2013, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME58800\",\"Title\":\"Mechatronics: Integrated Design Of Electro-Mechanical Systems\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20757109", "[{\"Code\":\"MCTX3420\",\"Title\":\"Software Internet Product Equipment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 303, 21018012, "60110", null, 3, new DateTime(2013, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H23S07\",\"Title\":\"Steel Structures\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL3111\",\"Title\":\"Control Paper Problem\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 304, 21018013, "60110", null, 3, new DateTime(2013, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H23GGE\",\"Title\":\"Foundation And Earthworks\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL3120\",\"Title\":\"Physics Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 305, 21018013, "60110", null, 4, new DateTime(2013, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H24T01\",\"Title\":\"Traffic Engineering\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2012, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL4180\",\"Title\":\"Reading Health Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 306, 21018011, "60110", null, 3, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H24SFE\",\"Title\":\"Finite Element Analysis In Strutural Mechanics\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL3140\",\"Title\":\"Data Data Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 307, 20804419, "60110", null, 3, new DateTime(2013, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H81FLM\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"ENSC3003\",\"Title\":\"Video Week Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 308, 20804417, "60110", null, 3, new DateTime(2013, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H81ETD\",\"Title\":\"Engineering Thermodynamics\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"ENSC3006\",\"Title\":\"Thanks Government Meat System\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 309, 20804416, "60110", null, 5, new DateTime(2013, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H82PLD\",\"Title\":\"Plant Design\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2012, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"\",\"Title\":\"Reading Industry Television\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 310, 20804417, "60110", null, 3, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H81NMT\",\"Title\":\"Heat And Mass Transfer\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2012, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"ENSC3007\",\"Title\":\"Government Child Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 311, 20804416, "60110", null, 3, new DateTime(2013, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H83PDC\",\"Title\":\"Process Dynamics And Control\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2012, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"CHPR3433\",\"Title\":\"Thanks Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 312, 20804417, "60110", null, 3, new DateTime(2013, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H84PSD\",\"Title\":\"Process Synthesis And Design\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2012, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"ENSC3018\",\"Title\":\"Two Bird Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 313, 20804419, "60110", null, 3, new DateTime(2013, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H82PEP\",\"Title\":\"Engineering Project\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20804415", "[{\"Code\":\"MECH3402\",\"Title\":\"People Problem\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 314, 20919160, "42560", null, 3, new DateTime(2013, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COMO301\",\"Title\":\"Mathematical Modelling 1\",\"Href\":\"https://unit.com\"}]", "Otago University", "https://university.com", "Otago University", true, true, new DateTime(2013, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20919157", "[{\"Code\":\"MATH3327\",\"Title\":\"Quality Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 315, 20919161, "42560", null, 3, new DateTime(2013, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH302\",\"Title\":\"Complex Analysis\",\"Href\":\"https://unit.com\"}]", "Otago University", "https://university.com", "Otago University", true, true, new DateTime(2013, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20919157", "[{\"Code\":\"MATH3342\",\"Title\":\"Year Data Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 316, 20771942, "61140", null, 4, new DateTime(2013, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE 341\",\"Title\":\"Design Of Concrete Structures\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2013, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20771939", "[{\"Code\":\"CIVL4403\",\"Title\":\"Industry Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 317, 20771940, "61140", null, 5, new DateTime(2013, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE 332\",\"Title\":\"Project Development\",\"Href\":\"https://unit.com\"}]", "Pennsylvania State University", "https://university.com", "Pennsylvania State University", true, true, new DateTime(2013, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20771939", "[{\"Code\":\"GENG5505\",\"Title\":\"Quality Country Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 337, 20524097, "61140", null, 3, new DateTime(2013, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CVEN30010\",\"Title\":\"Soil Mechanics 2\",\"Href\":\"https://unit.com\"}]", "University College Dublin", "https://university.com", "University College Dublin", true, true, new DateTime(2012, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20524094", "[{\"Code\":\"CIVL3120\",\"Title\":\"Industry Direction\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 338, 20784709, "60110", null, 5, new DateTime(2013, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENGM2700\",\"Title\":\"Soil Structures Interaction 4\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"GROUP D OPTION\",\"Title\":\"Year Basis Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 339, 20784710, "60110", null, 1, new DateTime(2013, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COMS11500\",\"Title\":\"Introduction To C\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"CITS1002\",\"Title\":\"Story Physics Way Computer\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 340, 20784708, "60110", null, 3, new DateTime(2013, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG11300\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"ENSC3010\",\"Title\":\"Nature Ability Story Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 360, 20743679, "51160", null, 2, new DateTime(2013, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MIE440H1\",\"Title\":\"Mechanical Design Theory And Methodology\",\"Href\":\"https://unit.com\"}]", "University Of Toronto", "https://university.com", "University Of Toronto", true, true, new DateTime(2013, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20743675", "[{\"Code\":\"MECH2401\",\"Title\":\"Information Physics Ability\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 361, 20750778, "61190", null, 2, new DateTime(2013, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE180\",\"Title\":\"Geotechnical Principles\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2013, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20750777", "[{\"Code\":\"CIVL2121\",\"Title\":\"Food Law Boyfriend Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 362, 20750778, "61190", null, 3, new DateTime(2013, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE173\",\"Title\":\"Reinforced Concrete\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2013, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20750777", "[{\"Code\":\"CIVL3112\",\"Title\":\"Family Technology Security Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 363, 20741092, "BP004", null, 3, new DateTime(2013, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE240 AND ECE242\",\"Title\":\"Electronic Circuits 1 And Electronic Circuits 2\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2013, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20741091", "[{\"Code\":\"ENSC3017\",\"Title\":\"Health Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 364, 20741092, "BP004", null, 3, new DateTime(2013, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE207 NAD ECE380\",\"Title\":\"Signals And Systems And Analog Control Systems\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2012, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20741091", "[{\"Code\":\"ENSC3015\",\"Title\":\"Theory Instance Food Environment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 365, 20741093, "BP004", null, 3, new DateTime(2013, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE209 AND ECE331\",\"Title\":\"Electronic And Electrical Properties Electronic Devices\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2013, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20741091", "[{\"Code\":\"ENSC3014\",\"Title\":\"Technology Instance\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 366, 20741095, "BP004", null, 3, new DateTime(2013, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE361\",\"Title\":\"Power Systems And Components\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2013, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20741091", "[{\"Code\":\"ENSC3016\",\"Title\":\"Organization Law Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 367, 20760665, "61140", null, 5, new DateTime(2013, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE 571\",\"Title\":\"Industrial Ecology\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2013, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20760662", "[{\"Code\":\"GENG5505\",\"Title\":\"Community Computer Computer Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 368, 21129178, "BP004", null, 3, new DateTime(2013, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENG2015\",\"Title\":\"Design And Manufacture 2A\",\"Href\":\"https://unit.com\"}]", "University Of Glasgow", "https://university.com", "University Of Glasgow", true, true, new DateTime(2012, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21129175", "[{\"Code\":\"ENSC3002\",\"Title\":\"Society Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 369, 21129177, "BP004", null, 2, new DateTime(2013, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENG1003\",\"Title\":\"ENG1003: ANALOGUE ELECTRONICS 1\",\"Href\":\"https://unit.com\"},{\"Code\":\"ENG2053\",\"Title\":\"ENG2053: THERMODYNAMICS M2\",\"Href\":\"https://unit.com\"}]", "University Of Glasgow", "https://university.com", "University Of Glasgow", true, true, new DateTime(2013, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21129175", "[{\"Code\":\"ENSC2002\",\"Title\":\"Direction Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 370, 20159208, "60450", null, 1, new DateTime(2013, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PHYS10071\",\"Title\":\"Mathematics 1\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2013, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20159207", "[{\"Code\":\"MATH1001\",\"Title\":\"Child People Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 371, 20159210, "60450", null, 1, new DateTime(2013, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATS10221\",\"Title\":\"Materials Science 1\",\"Href\":\"https://unit.com\"},{\"Code\":\"MACE10010\",\"Title\":\"Structures\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2013, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20159207", "[{\"Code\":\"ENSC1002\",\"Title\":\"Economics Policy Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 372, 21018011, "60110", null, 5, new DateTime(2013, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H23GGE\",\"Title\":\"Foundation And Earthworks\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2012, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL5503\",\"Title\":\"Development Thought Government Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 373, 21018012, "60110", null, 5, new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H24HCR\",\"Title\":\"Coastal Engineering\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"GENG5501\",\"Title\":\"Ability Paper People Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 374, 20159211, "60450", null, 1, new DateTime(2013, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE10010\",\"Title\":\"\\\"Structures\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"MACE10152\",\"Title\":\"\\\"Materials\\\"\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2013, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20159207", "[{\"Code\":\"ENSC1002\",\"Title\":\"Freedom Video Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 359, 20947824, "61140", null, 3, new DateTime(2013, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV350\",\"Title\":\"Geotechnical Design\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2013, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20947822", "[{\"Code\":\"ENSC3009\",\"Title\":\"Love Science Map Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 376, 20159209, "60450", null, 2, new DateTime(2013, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE10392\",\"Title\":\"\\\"Electrical Energy Supply\",\"Href\":\"https://unit.com\"},{\"Code\":\"MACE11005\",\"Title\":\"Circuits\\\" And \\\"Thermodynamics\\\"\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2013, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20159207", "[{\"Code\":\"ENSC2002\",\"Title\":\"People History Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 358, 20947825, "61140", null, 3, new DateTime(2013, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV312\",\"Title\":\"Advanced Structural Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20947822", "[{\"Code\":\"ENSC3008\",\"Title\":\"Art Direction\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 356, 20947826, "61140", null, 1, new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHM1001\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2013, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20947822", "[{\"Code\":\"CHEM1001\",\"Title\":\"Industry Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 341, 20784708, "60110", null, 4, new DateTime(2013, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MENG33111\",\"Title\":\"Finte Element Anaylsis\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"MECH4405\",\"Title\":\"Society Food Country Method\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 342, 20784710, "60110", null, 4, new DateTime(2013, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENGM2400\",\"Title\":\"Structural Engineering 4\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"CIVL4111\",\"Title\":\"Safety Economics Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 343, 20784710, "60110", null, 5, new DateTime(2013, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EFACM0004\",\"Title\":\"Research Methodology And Project Management\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2012, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"GENG5505\",\"Title\":\"Product Organization Industry Understanding\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 344, 20784710, "60110", null, 5, new DateTime(2013, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG33900\",\"Title\":\"Civil Engineering Systems 3\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"GENG5505\",\"Title\":\"Problem Safety Ability Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 345, 20784711, "60110", null, 1, new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHEM10600\",\"Title\":\"Introductory Chemistry\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"CHEM1002 OR CHEM1001\",\"Title\":\"Literature Instance History Meat\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 346, 20784709, "60110", null, 4, new DateTime(2013, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENG33600\",\"Title\":\"Water Engineering 3\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2013, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20784707", "[{\"Code\":\"ENVE4609\",\"Title\":\"Library Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 347, 20760663, "61140", null, 4, new DateTime(2013, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENGINEERING 407\",\"Title\":\"Numerical Methods In Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2013, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20760662", "[{\"Code\":\"GENG4405\",\"Title\":\"Camera Direction Boyfriend Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 348, 20760666, "61140", null, 5, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHEMICAL ENGINEERING 623\",\"Title\":\"Chemical Reactor Desigm\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2012, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20760662", "[{\"Code\":\"CHPR5501\",\"Title\":\"Paper Week Equipment Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 349, 20760663, "61140", null, 5, new DateTime(2013, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENGINEERING 513\",\"Title\":\"The Role And Responsibilities Of The Professional Engineer\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2013, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20760662", "[{\"Code\":\"GENG5505\",\"Title\":\"Government Bird Variety Nature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 350, 20668331, "60110", null, 3, new DateTime(2013, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE470\",\"Title\":\"Structural Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2013, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20668327", "[{\"Code\":\"ENSC3008\",\"Title\":\"Meat Paper Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 351, 20668328, "60110", null, 3, new DateTime(2013, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE460\",\"Title\":\"Steel Structures 1\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2013, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20668327", "[{\"Code\":\"CIVL3111\",\"Title\":\"Method Language Safety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 352, 20668328, "60110", null, 3, new DateTime(2013, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CEE484\",\"Title\":\"Applied Soil Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Illinois", "https://university.com", "University Of Illinois", true, true, new DateTime(2013, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20668327", "[{\"Code\":\"CIVL3120\",\"Title\":\"Year Quality Paper Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 353, 20517118, "62110", null, 2, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME301\",\"Title\":\"Thermofluids\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2012, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517116", "[{\"Code\":\"MECH2403\",\"Title\":\"Map Exam\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 354, 20517117, "62110", null, 2, new DateTime(2013, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME320\",\"Title\":\"Heat Transfer\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2013, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517116", "[{\"Code\":\"CHPR2432\",\"Title\":\"Organization Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 355, 20497163, "61110", null, 3, new DateTime(2013, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CH6 3127\",\"Title\":\"Chemical Reaction Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Ottawa", "https://university.com", "University Of Ottawa", true, true, new DateTime(2012, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20497159", "[{\"Code\":\"CHPR3432\",\"Title\":\"Television Government Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 357, 20947826, "61140", null, 5, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV4180\",\"Title\":\"Structural Dynamics\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20947822", "[{\"Code\":\"CIVL5501\",\"Title\":\"Year Health Information Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 451, 21299039, "62550", null, 5, new DateTime(2016, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK4120\",\"Title\":\"Safety And Reliability Analysis\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21299035", "[{\"Code\":\"GENG5507\",\"Title\":\"Reading Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 452, 21108765, "62550", null, 4, new DateTime(2016, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMAT464\",\"Title\":\"Biomedical Materials Engineering\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21108763", "[{\"Code\":\"GENG4408\",\"Title\":\"Army Television\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 453, 21299548, "62550", null, 5, new DateTime(2016, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4175\",\"Title\":\"Energy From Wind And Tidal Currents\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21299545", "[{\"Code\":\"GENG5506\",\"Title\":\"Reading Direction Technology Nature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 549, 22180787, "BP004", null, 2, new DateTime(2018, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE 210\",\"Title\":\"Circuits\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", true, true, new DateTime(2018, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180783", "[{\"Code\":\"L2 ELECTIVE\",\"Title\":\"Player Art Health Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 550, 22180784, "BP004", null, 2, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 260\",\"Title\":\"Engineering Computation II\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", true, true, new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180783", "[{\"Code\":\"CITS2401\",\"Title\":\"Basis Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 551, 22180786, "BP004", null, 3, new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE 243\",\"Title\":\"Fluid Dynamics\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", true, true, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180783", "[{\"Code\":\"ENSC3003\",\"Title\":\"Investment Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 552, 20930515, "62550", null, 5, new DateTime(2018, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC489\",\"Title\":\"Capstone 1: Mechanical Engineering Design\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2018, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930511", "[{\"Code\":\"MECH5551\",\"Title\":\"Physics Safety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 553, 20930515, "62550", null, 5, new DateTime(2018, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC405\",\"Title\":\"Finite Element Analysis\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2018, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930511", "[{\"Code\":\"GENG5514\",\"Title\":\"Language People Music Product\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 554, 20930512, "62550", null, 4, new DateTime(2018, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EBIO461\",\"Title\":\"Principles Of Biomedical Engineering\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2018, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930511", "[{\"Code\":\"GENG4408\",\"Title\":\"Environment Safety Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 548, 22180784, "BP004", null, 2, new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE 116\",\"Title\":\"Numerical Methods And Stat\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", true, true, new DateTime(2018, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180783", "[{\"Code\":\"L2 ELECTIVE\",\"Title\":\"Security Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 555, 20930513, "62550", null, 5, new DateTime(2018, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECIV406\",\"Title\":\"Sustainability Issues In Construction\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930511", "[{\"Code\":\"GROUP A OPTION\",\"Title\":\"Equipment Control Knowledge Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 557, 21518090, "MPE", null, 5, new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MMKN65\",\"Title\":\"Project -Machine Design\",\"Href\":\"https://unit.com\"}]", "Lunds University", "https://university.com", "Lunds University", true, true, new DateTime(2018, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"MECH5551\",\"Title\":\"Software Video Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 558, 21518093, "MPE", null, 5, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"VBRN01\",\"Title\":\"Risk Assessment\",\"Href\":\"https://unit.com\"}]", "Lunds University", "https://university.com", "Lunds University", true, true, new DateTime(2017, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"GENG5507\",\"Title\":\"Reading Media Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 559, 21518093, "MPE", null, 5, new DateTime(2018, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MMVN05\",\"Title\":\"Numerical Fluid Dynamics And Heat Transfer\",\"Href\":\"https://unit.com\"}]", "Lunds University", "https://university.com", "Lunds University", true, true, new DateTime(2017, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"MECH5504\",\"Title\":\"Language Area\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 560, 21955815, "BP004", null, 2, new DateTime(2018, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EE 411 + ME 316T\",\"Title\":\"Circuits\",\"Href\":\"https://unit.com\"}]", "University Of Texas At Austin", "https://university.com", "University Of Texas At Austin", true, true, new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21955814", "[{\"Code\":\"ENSC2002\",\"Title\":\"Meat Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 561, 20964323, "MPE", null, 4, new DateTime(2017, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4156\",\"Title\":\"Viscous Flows And Boundary Layers\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2017, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20964319", "[{\"Code\":\"CHPR4407\",\"Title\":\"Way Definition\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 562, 20964321, "MPE", null, 5, new DateTime(2017, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4270\",\"Title\":\"Bioenergy: Technology And System\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2017, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20964319", "[{\"Code\":\"GROUP A OPTION\",\"Title\":\"Technology Government Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 556, 21518093, "MPE", null, 4, new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FMEN02\",\"Title\":\"Multibody Dynamics\",\"Href\":\"https://unit.com\"}]", "Lunds University", "https://university.com", "Lunds University", true, true, new DateTime(2018, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"MECH4426\",\"Title\":\"Meat Thought Art Country\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 547, 21966628, "BP004", null, 5, new DateTime(2017, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MKTG 341\",\"Title\":\"Introduction To Marketing\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21966626", "[{\"Code\":\"LEVEL 1 ELECTIVE\",\"Title\":\"Policy Reading Ability Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 546, 21966630, "BP004", null, 5, new DateTime(2017, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"KNES 253\",\"Title\":\"Intro Exer\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2017, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21966626", "[{\"Code\":\"LEVEL 1 BROADENING UNIT\",\"Title\":\"Control Development Management Definition\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 545, 21966627, "BP004", null, 3, new DateTime(2017, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENME341\",\"Title\":\"Fundamentals Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2017, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21966626", "[{\"Code\":\"ENSC3003\",\"Title\":\"Love Equipment Problem Army\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 530, 21327426, "62550", null, 5, new DateTime(2018, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE528\",\"Title\":\"Embedded Systems Architecture\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2018, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327422", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Instance Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 531, 21327425, "62550", null, 4, new DateTime(2018, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 521\",\"Title\":\"Thermal System Design And Optimization\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327422", "[{\"Code\":\"MECH4429\",\"Title\":\"Definition Two Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 532, 21116086, "62550", null, 5, new DateTime(2018, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENM383.2\",\"Title\":\"Strategic Decision And Risk Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2018, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21116084", "[{\"Code\":\"GENG5507\",\"Title\":\"Law Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 533, 21116088, "62550", null, 5, new DateTime(2018, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE329\",\"Title\":\"Structural Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2018, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21116084", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Environment History\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 534, 21116087, "62550", null, 5, new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BME343\",\"Title\":\"Biomedical Engineering Signal And Systems Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Texas, Austin", "https://university.com", "University Of Texas, Austin", true, true, new DateTime(2018, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21116084", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Industry Person Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 535, 21152213, "62550", null, 5, new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE417\",\"Title\":\"Acoustics/Audio Engineering\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2018, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21152212", "[{\"Code\":\"MECH5501\",\"Title\":\"Physics Government\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 536, 21116085, "62550", null, 5, new DateTime(2018, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ORI 390R 16\",\"Title\":\"Markov Decision Processes\",\"Href\":\"https://unit.com\"}]", "University Of Texas At Austin", "https://university.com", "University Of Texas At Austin", true, true, new DateTime(2018, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21116084", "[{\"Code\":\"GENG5507\",\"Title\":\"Theory Thanks Science Product\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 537, 21116085, "62550", null, 4, new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME344\",\"Title\":\"Dynamic Systems And Controls\",\"Href\":\"https://unit.com\"}]", "University Of Texas At Austin", "https://university.com", "University Of Texas At Austin", true, true, new DateTime(2018, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angus approved this for MPE(Mech) option as well", "21116084", "[{\"Code\":\"GENG4402\",\"Title\":\"Series Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 538, 21730933, "BP004", null, 2, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FREN002\",\"Title\":\"Elementary II\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2018, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21730932", "[{\"Code\":\"L2 ELECTIVE\",\"Title\":\"Series Boyfriend Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 539, 21730936, "BP004", null, 3, new DateTime(2018, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 014 + ME 083\",\"Title\":\"Mechanics Of Solids And Computational Mech Engr Lab\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2018, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21730932", "[{\"Code\":\"ENSC3004\",\"Title\":\"Government Computer Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 540, 21730933, "BP004", null, 1, new DateTime(2018, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PEAC 005\",\"Title\":\"Club Sports: Swimming\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21730932", "[{\"Code\":\"L1 ELECTIVE\",\"Title\":\"Safety Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 541, 21730934, "BP004", null, 1, new DateTime(2018, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PEAC 052\",\"Title\":\"5K/10 K Training\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21730932", "[{\"Code\":\"L1 ELECTIVE\",\"Title\":\"Player Strategy Society Activity\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 542, 21720291, "62550", null, 4, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"11563\",\"Title\":\"Concrete Technology\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "approved by academic member.", "21720288", "[{\"Code\":\"CIVL4403\",\"Title\":\"Week Ability Paper\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 543, 21720291, "62550", null, 4, new DateTime(2018, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"11351\",\"Title\":\"Advanced Concrete Structures\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "approved by academic member.", "21720288", "[{\"Code\":\"CIVL4403\",\"Title\":\"Camera Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 544, 21966628, "BP004", null, 3, new DateTime(2017, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECON 379\",\"Title\":\"The Economics Of Health\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2017, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21966626", "[{\"Code\":\"ECON3205\",\"Title\":\"Year Art Safety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 563, 20964320, "MPE", null, 5, new DateTime(2017, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TFY4300\",\"Title\":\"Energy And Environmental Physics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2017, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20964319", "[{\"Code\":\"GROUP A OPTION\",\"Title\":\"Freedom Freedom System Child\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 564, 21720291, "62550", null, 3, new DateTime(2018, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"62614\",\"Title\":\"Advanced Engineering Dynamics\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "awaiting a response", "21720288", "[{\"Code\":\"ENSC3001\",\"Title\":\"Map Music Investment Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 565, 21720292, "62550", null, 3, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"41681\",\"Title\":\"Material Science\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2017, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "awaiting a response", "21720288", "[{\"Code\":\"ENSC3002\",\"Title\":\"Family Software Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 566, 21720292, "62550", null, 5, new DateTime(2018, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"42171\",\"Title\":\"System Safety Reliability Engineering\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21720288", "[{\"Code\":\"GENG5507\",\"Title\":\"Library Information Physics Equipment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 586, 21518093, "62550", null, 4, new DateTime(2018, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FRTN01\",\"Title\":\"Real Time Systems\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", false, false, new DateTime(2017, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "that unit does not appear to be at a high enough level to replace GENG4405", "21518089", "[{\"Code\":\"GENG4405\",\"Title\":\"Thanks Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 587, 22072235, "BP004", null, 2, new DateTime(2018, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"62614\",\"Title\":\"Advanced Engineering Dynamics\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "The proposed unit is too advanced.  A better replacement would be 62694 Dynamics, course outline http://kurser.dtu.dk/N,course/2016-2017/62694", "22072231", "[{\"Code\":\"ENSC2001\",\"Title\":\"Theory Security Music Definition\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 588, 22072235, "BP004", null, 2, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"62643\",\"Title\":\"Mechanical Vibrations\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2017, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"ENSC2001\",\"Title\":\"Nature Library Movie\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 589, 21484073, "BP004", null, 4, new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4102\",\"Title\":\"Dynamics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", false, false, new DateTime(2018, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not high enough level", "21484069", "[{\"Code\":\"MECH4426\",\"Title\":\"Internet Environment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 590, 21327909, "62250", null, 5, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"42543\",\"Title\":\"Management Of Change In Engineering Systems\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"GENG5507\",\"Title\":\"Person Activity Quality Two\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 591, 20503327, "62550", null, 5, new DateTime(2018, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF630\",\"Title\":\"Technological Innovation And Entrepreneurship\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", false, false, new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Map Ability\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 592, 20503325, "62550", null, 5, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF570\",\"Title\":\"Human Factors, Technology And Organisational Issues\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", false, false, new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Information Product Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 593, 20503326, "62550", null, 5, new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEE100\",\"Title\":\"Societal Transition And Transformation - Energy And Climate Change\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", false, false, new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Industry Area Quality\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 594, 21335586, "62550", null, 5, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FEEG6013\",\"Title\":\"Group Design Project\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", false, false, new DateTime(2017, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"CIVL5551 AND CIVL5552\",\"Title\":\"Exam Fact Health Definition\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 595, 20771706, "62550", null, 4, new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE271\",\"Title\":\"Advanced Structural Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", false, false, new DateTime(2018, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20771705", "[{\"Code\":\"CIVL4403\",\"Title\":\"Society Activity\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 596, 21327426, "62550", null, 4, new DateTime(2018, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CBE 311\",\"Title\":\"Introduction To Transport Phenomena\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", false, false, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not high enough level", "21327422", "[{\"Code\":\"CHPR4407\",\"Title\":\"Economics Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 597, 21327424, "62550", null, 4, new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 520\",\"Title\":\"Advanced Thermodynamics I\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", false, false, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not equivalent. Not equivalent even if taken together with ME320L and ME302", "21327422", "[{\"Code\":\"MECH4429\",\"Title\":\"Theory Army\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 598, 21327425, "62550", null, 4, new DateTime(2018, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 320L\",\"Title\":\"Heat Transfer\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", false, false, new DateTime(2018, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not high enough level. Not equivalent even if taken together with ME302", "21327422", "[{\"Code\":\"MECH4429\",\"Title\":\"Law Definition\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 599, 21327426, "62550", null, 4, new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 302\",\"Title\":\"Applied Thermodynamics\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", false, false, new DateTime(2017, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not high enough level. Not equivalent even if taken together with ME320L", "21327422", "[{\"Code\":\"MECH4429\",\"Title\":\"Government Music Control\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 600, 21152213, "62550", null, 5, new DateTime(2018, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC368\",\"Title\":\"Introduction To Aerospace\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", false, false, new DateTime(2018, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "This one is also an undergrad unit and looks quite basic so I'm not inclined to approve it.", "21152212", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Investment Industry Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 585, 22072235, "BP004", null, 3, new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1450\",\"Title\":\"Basic Course In Road Pavements\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2018, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"ENSC3004\",\"Title\":\"Paper Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 529, 21327424, "62550", null, 5, new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME482/582\",\"Title\":\"Robot Engineering\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2018, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327422", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Government People Video Variety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 584, 22072232, "BP004", null, 3, new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"11957\",\"Title\":\"Sustainable Building Design\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2018, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"ENSC3008\",\"Title\":\"Equipment Language Bird Series\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 582, 21327908, "62550", null, 5, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"41632\",\"Title\":\"Robust Design Of Products And Mechanisms\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2017, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"GENG5507\",\"Title\":\"Data Temperature Map Method\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 567, 21720292, "62550", null, 5, new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"28870\",\"Title\":\"Energy And Sustainability\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21720288", "[{\"Code\":\"GENG5506\",\"Title\":\"Two Computer Basis Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 568, 21720290, "62550", null, 4, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"41744\",\"Title\":\"Precision Manufacturing\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21720288", "[{\"Code\":\"MECH4424\",\"Title\":\"Safety Reading\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 569, 21720290, "62550", null, 5, new DateTime(2018, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"28244\",\"Title\":\"Combustion And High Temperature Processes\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21720288", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Government Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 570, 21720291, "62550", null, 5, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"46211\",\"Title\":\"Offshore Wind Energy\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21720288", "[{\"Code\":\"GENG5506\",\"Title\":\"Idea Oven\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 571, 21484070, "62550", null, 4, new DateTime(2018, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM4155\",\"Title\":\"Numerical Models And Hydraulics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", false, false, new DateTime(2018, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "It only covers modelling fluids", "21484069", "[{\"Code\":\"GENG4405\",\"Title\":\"Management Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 572, 21484070, "62550", null, 4, new DateTime(2018, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4205\",\"Title\":\"Tribology And Surface Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", false, false, new DateTime(2018, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"MECH4428\",\"Title\":\"Thanks Software\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 573, 21484070, "62550", null, 4, new DateTime(2018, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TFNE2001\",\"Title\":\"Engineering Thermodynamics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", false, false, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is not a sufficiently advanced unit to credit to the MPE", "21484069", "[{\"Code\":\"MECH4429\",\"Title\":\"Science Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 574, 22180784, "62550", null, 2, new DateTime(2018, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE116\",\"Title\":\"Numerical Methods And Statistics\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", false, false, new DateTime(2018, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180783", "[{\"Code\":\"CITS2401\",\"Title\":\"Thing Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 575, 22180787, "62250", null, 2, new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE288\",\"Title\":\"Intro To Energy Systems\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", false, false, new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180783", "[{\"Code\":\"ENSC2001\",\"Title\":\"Society Data Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 576, 22180875, "62250", null, 3, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE265\",\"Title\":\"Sustainable Chemical Processes\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", false, false, new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180873", "[{\"Code\":\"ENSC3005/ENSC3018\",\"Title\":\"Art Camera Meat\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 577, 22180876, "62250", null, 1, new DateTime(2018, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PHY121\",\"Title\":\"Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", false, false, new DateTime(2018, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180873", "[{\"Code\":\"PHYS1001\",\"Title\":\"People Two Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 578, 22180877, "62250", null, 1, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE279\",\"Title\":\"Chemical Engineering Practice\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", false, false, new DateTime(2017, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180873", "[{\"Code\":\"ENSC1001\",\"Title\":\"Understanding Video\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 579, 21731431, "BP004", null, 3, new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA155\",\"Title\":\"Mathematical Methods Of Physics II\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", false, false, new DateTime(2018, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This unit is appears to be far too advanced", "21731429", "[{\"Code\":\"PHYS3011\",\"Title\":\"Temperature Data Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 580, 21327909, "62550", null, 5, new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"41030\",\"Title\":\"Mechatronics Engineering Design\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "No this is not a good match and he is unlikely to have the appropriate prerequisite knowledge", "21327905", "[{\"Code\":\"MECH5502\",\"Title\":\"Community Environment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 581, 21327909, "62550", null, 5, new DateTime(2018, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"42378\",\"Title\":\"Health, Environmental And Life Cycle Impacts In Different Assessment Frameworks\",\"Href\":\"https://unit.com\"}]", "Denmark Technical University", "https://university.com", "Denmark Technical University", false, false, new DateTime(2017, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "No, not a good match", "21327905", "[{\"Code\":\"GENG5507\",\"Title\":\"Thought System Map Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 583, 21952807, "BP004", null, 3, new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FYSB11\",\"Title\":\"Basic Quantum Mechanics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", false, false, new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21952806", "[{\"Code\":\"PHYS3001\",\"Title\":\"Investment Player\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 528, 21327426, "62550", null, 5, new DateTime(2018, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME 455\",\"Title\":\"Engineering Project Management\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2018, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327422", "[{\"Code\":\"GENG5505\",\"Title\":\"Information Industry Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 527, 21134794, "62550", null, 4, new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE475\",\"Title\":\"Hardware/Software Engineering Embedded Systems\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2018, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21134793", "[{\"Code\":\"ELEC4403\",\"Title\":\"Control Exam Week\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 526, 21335586, "62550", null, 5, new DateTime(2018, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENV3056\",\"Title\":\"Structural Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2017, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"CIVL5552\",\"Title\":\"Problem Series Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 473, 21730934, "62250", null, 3, new DateTime(2018, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME014/ME083\",\"Title\":\"Mechanics Of Solids/Computational Engineer Lab\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2017, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21730932", "[{\"Code\":\"ENSC3004\",\"Title\":\"Library Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 474, 21978830, "BP004", null, 3, new DateTime(2018, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA558\",\"Title\":\"Atom And Molecular Physics - Advanced\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21978828", "[{\"Code\":\"PHYS3001\",\"Title\":\"Instance People Law\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 475, 21731431, "BP004", null, 3, new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA352\",\"Title\":\"Quantum Mechanics, Advanced Couse\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21731429", "[{\"Code\":\"PHYS3001\",\"Title\":\"Definition Computer Two Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 476, 21978831, "BP004", null, 3, new DateTime(2018, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"IFA121\",\"Title\":\"Mathematical Methods Of Physics\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21978828", "[{\"Code\":\"PHYS3011\",\"Title\":\"Map Oven Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 477, 21731431, "BP004", null, 3, new DateTime(2018, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA260\",\"Title\":\"The Physics Of Galaxies\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21731429", "[{\"Code\":\"PHYS3003\",\"Title\":\"Problem World Control\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 478, 21731431, "BP004", null, 3, new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA223\",\"Title\":\"The Physics Of Stars\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2/10/17: Matthew didn't approve 1FA260 as equivalent to PHYS3003. But Ian McArthur did. Matthew further advised that 1FA223 taken together with 1FA203 will be a good match for PHYS3003. Both units are to be taken togther only if 1FA223(worth 10 credits) is not equivalent to UWA's 6 credits", "21731429", "[{\"Code\":\"PHYS3003\",\"Title\":\"Thing Person Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 479, 21731431, "BP004", null, 3, new DateTime(2018, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA203\",\"Title\":\"Syllabus For Observational Astrophysics I\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2/10/17: Refer to comments for 1FA223", "21731429", "[{\"Code\":\"PHYS3003\",\"Title\":\"Basis Data Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 480, 21327909, "62550", null, 5, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"KU103\",\"Title\":\"Tissue And Movement Biomechanics (KU)\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Physics Bird Policy Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 481, 21327907, "62550", null, 5, new DateTime(2018, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"34454\",\"Title\":\"Biophotonics And Optical Engineering\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Freedom Camera Direction People\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 482, 21327906, "62550", null, 5, new DateTime(2018, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"33281\",\"Title\":\"Biomaterials\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Camera Reading Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 483, 21327909, "62550", null, 5, new DateTime(2018, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"33236\",\"Title\":\"Labchip-1: Bio/Chemical Microsystems On Chips\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Safety Language Data Freedom\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 484, 21731431, "BP004", null, 3, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA205\\r\\nY,1FA526\",\"Title\":\"Astrophysics II\\r\\nY,Condensed Matter Physics\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2018, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21731429", "[{\"Code\":\"PHYS3012\",\"Title\":\"Television Quality Temperature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 485, 21518092, "62550", null, 5, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MMKN65\",\"Title\":\"Project-Machine Design\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"MECH5551\",\"Title\":\"Bird Video World Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 486, 21518092, "62550", null, 4, new DateTime(2018, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EDAN15\",\"Title\":\"Design Of Embedded Systems\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"ELEC4403\",\"Title\":\"Policy Paper Safety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 487, 21518090, "62550", null, 5, new DateTime(2018, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"VBRN01\",\"Title\":\"Risk Assessment\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"GENG5507\",\"Title\":\"Thing Science Army Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 472, 22180875, "62250", null, 3, new DateTime(2018, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE243\",\"Title\":\"Fluid Dynamics\",\"Href\":\"https://unit.com\"}]", "University Of Rochester", "https://university.com", "University Of Rochester", true, true, new DateTime(2018, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22180873", "[{\"Code\":\"ENSC3003\",\"Title\":\"Strategy Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 488, 21518092, "62550", null, 4, new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FMEN02\",\"Title\":\"Multibody Dynamics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"MECH4426\",\"Title\":\"Year Internet Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 471, 21301566, "62530", null, 5, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TTM4135\",\"Title\":\"Information Security\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21301563", "[{\"Code\":\"MDSC OPTION UNIT\",\"Title\":\"Information Quality\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 469, 21301565, "62530", null, 5, new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PK8106\",\"Title\":\"Knowledge Discovery(KD) And Data Mining(DM)\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21301563", "[{\"Code\":\"CITS5508\",\"Title\":\"Community Reading Direction Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 454, 21299547, "62550", null, 4, new DateTime(2016, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4515\",\"Title\":\"Thermal Energy, Specialisation Course\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21299545", "[{\"Code\":\"MECH4429\",\"Title\":\"Instance Theory Power Two\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 455, 21726616, "BP004", null, 3, new DateTime(2016, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH33200\",\"Title\":\"Fluid Dynamics 3\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21726615", "[{\"Code\":\"MATH3022\",\"Title\":\"Library Love Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 456, 21634711, "BP004", null, 3, new DateTime(2016, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"M2794.001300\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Seoul National University", "https://university.com", "Seoul National University", true, true, new DateTime(2015, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21634709", "[{\"Code\":\"ENSC3003\",\"Title\":\"Way Thing Player Bird\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 457, 22025194, "62550", null, 4, new DateTime(2017, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EE3001\",\"Title\":\"Engineering Electromagnetics And Radio Frequency Circuits\",\"Href\":\"https://unit.com\"}]", "Nanyang University Of Technology", "https://university.com", "Nanyang University Of Technology", true, true, new DateTime(2017, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "approved by program chair", "22025193", "[{\"Code\":\"ELEC4401\",\"Title\":\"Temperature Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 458, 22025195, "62550", null, 5, new DateTime(2017, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Modern Electrical Drives\",\"Href\":\"https://unit.com\"}]", "Nanyang University Of Technology", "https://university.com", "Nanyang University Of Technology", true, true, new DateTime(2016, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "approved by program chair", "22025193", "[{\"Code\":\"MPE (EE) A OPTION\",\"Title\":\"Health Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 459, 22025194, "62550", null, 5, new DateTime(2017, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Power System Modelling\",\"Href\":\"https://unit.com\"}]", "Nanyang University Of Technology", "https://university.com", "Nanyang University Of Technology", true, true, new DateTime(2016, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "approved by program chair", "22025193", "[{\"Code\":\"MPE (EE) A OPTION\",\"Title\":\"Freedom Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 460, 22025197, "62550", null, 5, new DateTime(2017, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Power Quality\",\"Href\":\"https://unit.com\"}]", "Nanyang University Of Technology", "https://university.com", "Nanyang University Of Technology", true, true, new DateTime(2016, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "approved by program chair", "22025193", "[{\"Code\":\"MPE (EE) A OPTION\",\"Title\":\"Activity Child\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 461, 21313159, "62550", null, 5, new DateTime(2018, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4175\",\"Title\":\"Fire Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21313157", "[{\"Code\":\"MPE(MECH) OPTION UNIT\",\"Title\":\"Basis Map Direction Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 462, 21313161, "62550", null, 5, new DateTime(2018, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4175\",\"Title\":\"Polymers And Composites\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21313157", "[{\"Code\":\"MPE(MECH) OPTION UNIT\",\"Title\":\"Instance Environment Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 463, 21484073, "62550", null, 5, new DateTime(2018, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK5115\",\"Title\":\"Risk Management In Projects\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"GENG5507\",\"Title\":\"Problem Problem Physics Country\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 464, 21484070, "62550", null, 5, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4205\",\"Title\":\"Tribology And Surface Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2017, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"MPE(MECH) OPTION UNIT\",\"Title\":\"Instance Television Society Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 465, 21484070, "62550", null, 4, new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4225\",\"Title\":\"Heat Pumping Processes And Systems\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "the Heat Pumping one is a bit more specialised than our MECH4429 but the level should be appropriate", "21484069", "[{\"Code\":\"MECH4429\",\"Title\":\"Food Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 466, 21484070, "62550", null, 5, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4400\",\"Title\":\"Engineering Design\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"MECH5551\",\"Title\":\"Understanding Meat\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 467, 21978830, "BP004", null, 3, new DateTime(2018, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1DT388\",\"Title\":\"Computer Graphics\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21978828", "[{\"Code\":\"CITS3003\",\"Title\":\"Environment Meat\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 468, 21301567, "62530", null, 4, new DateTime(2018, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMA4300\",\"Title\":\"Computer Intensive Statistical Methods\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21301563", "[{\"Code\":\"STAT4063\",\"Title\":\"Method Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 470, 21301565, "62530", null, 5, new DateTime(2018, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TDT4215\",\"Title\":\"Web Intelligence\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21301563", "[{\"Code\":\"CITS5505\",\"Title\":\"Paper Direction Community World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 302, 21018013, "60110", null, 3, new DateTime(2013, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H22H11\",\"Title\":\"Hydraulics I And Hydraulics 2\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"ENSC3010\",\"Title\":\"Oven Media Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 489, 21518091, "62550", null, 4, new DateTime(2018, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MMVN05\",\"Title\":\"Numerical Fluid Dynamics And Heat Transfer\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"CHPR4407\",\"Title\":\"Music Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 491, 21518091, "62550", null, 5, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FRTN01\",\"Title\":\"Real Time Systems\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"GENG5503\",\"Title\":\"Media Thing Technology Activity\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 511, 20503326, "62550", null, 5, new DateTime(2018, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MK545\",\"Title\":\"Offshore Wind Turbine Engineering\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2018, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"GENG5514\",\"Title\":\"Instance Economics Area Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 512, 20503325, "62550", null, 5, new DateTime(2018, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF550\",\"Title\":\"Subsea Technology\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2018, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Player Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 513, 21335587, "62550", null, 5, new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FEEG6010\",\"Title\":\"Advanced Finite Element Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2018, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"GENG5514\",\"Title\":\"System Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 514, 21335589, "62550", null, 5, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENV6152\",\"Title\":\"Project Economics And Management\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2017, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"GENG5505\",\"Title\":\"Problem Library Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 515, 21335587, "62550", null, 4, new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENV3020\",\"Title\":\"Geotechnical Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"CIVL4401\",\"Title\":\"Law System Year Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 516, 21335586, "62550", null, 4, new DateTime(2018, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENV3061\",\"Title\":\"Engineering Hydrology\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2018, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"ENVE4402\",\"Title\":\"Safety Definition Reading\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 517, 21335586, "62550", null, 5, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENV6109\",\"Title\":\"Transportation Engineering: Transport Management\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2018, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"CIVL5502\",\"Title\":\"Industry Television System Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 518, 20771706, "62550", null, 4, new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE218\",\"Title\":\"Numerical Methods For Engineer\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2018, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20771705", "[{\"Code\":\"GENG4405\",\"Title\":\"Player Bird Software\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 519, 20771708, "62550", null, 5, new DateTime(2018, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE185\",\"Title\":\"Capstone Design 1\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20771705", "[{\"Code\":\"GENG5505\",\"Title\":\"Media Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 520, 20771706, "62550", null, 5, new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE281\",\"Title\":\"Geotechnical Design\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2018, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20771705", "[{\"Code\":\"MPE(CIVIL) OPTION OR CIVL4401\",\"Title\":\"Society Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 521, 20503324, "62550", null, 5, new DateTime(2018, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF520\",\"Title\":\"Pipelines And Risers\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2018, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Idea Year Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 522, 20503325, "62550", null, 5, new DateTime(2018, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF600\",\"Title\":\"Marine Operations\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2017, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Boyfriend Physics Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 523, 20503324, "62550", null, 5, new DateTime(2018, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GEN530\",\"Title\":\"Nordic Models For Gender Equality And Welfare\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2018, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subject to special approval only. Otherwise not approved", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Quality Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 524, 20503327, "62550", null, 5, new DateTime(2018, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF570\",\"Title\":\"Human Factors, Technology And Organisational Issues\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2018, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subject to special approval only. Otherwise not approved", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Health Idea World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 525, 21335588, "62550", null, 5, new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CENV3015\",\"Title\":\"Design 3\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21335585", "[{\"Code\":\"CIVL5551\",\"Title\":\"Oven Way Thing Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 510, 20503326, "62550", null, 5, new DateTime(2018, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF515\",\"Title\":\"Offshore Field Developments\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2018, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Direction Thanks Theory Country\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 490, 21518093, "62550", null, 5, new DateTime(2018, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FHLN25\",\"Title\":\"Fracture Mechanics, Advanced Course\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21518089", "[{\"Code\":\"MECH5504\",\"Title\":\"Computer Video Definition Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 509, 20503326, "62550", null, 5, new DateTime(2018, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF610\",\"Title\":\"Offshore Wind Turbine Engineering\",\"Href\":\"https://unit.com\"}]", "Stavanger University", "https://university.com", "Stavanger University", true, true, new DateTime(2017, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20503323", "[{\"Code\":\"MPE(CIVIL) OPTION\",\"Title\":\"Internet Thing Two Understanding\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 507, 21327908, "62250", null, 5, new DateTime(2018, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"42543\",\"Title\":\"Management Of Change In Engineering Systems\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"GENG5507\",\"Title\":\"Community Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 492, 21952807, "BP004", null, 3, new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FYST37\",\"Title\":\"Advanced Quantum Mechanics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21952806", "[{\"Code\":\"PHYS3001\",\"Title\":\"System Software Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 493, 21952810, "BP004", null, 2, new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FYSB11\",\"Title\":\"Basic Quantum Mechanics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2018, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21952806", "[{\"Code\":\"PHYS2001\",\"Title\":\"Language Media Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 494, 22072235, "BP004", null, 3, new DateTime(2018, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"11411\",\"Title\":\"Basic Soil Mechanics\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2017, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"ENSC3009\",\"Title\":\"Equipment Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 495, 21978830, "BP004", null, 3, new DateTime(2018, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA521\",\"Title\":\"Quantum Physics\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2017, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21978828", "[{\"Code\":\"PHYS3001\",\"Title\":\"Bird Boyfriend Law Activity\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 496, 22072234, "BP004", null, 2, new DateTime(2018, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"2692\",\"Title\":\"Introduction To Programming And Data Processing\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"CITS2401\",\"Title\":\"Language Physics Week Bird\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 497, 22072233, "BP004", null, 3, new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"41312\",\"Title\":\"Basic Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"ENSC3010\",\"Title\":\"History Bird Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 498, 22072235, "BP004", null, 1, new DateTime(2018, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"2170\",\"Title\":\"Database Systems\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"CITS1402\",\"Title\":\"Safety Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 499, 22072233, "BP004", null, 2, new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"62694\",\"Title\":\"Dynamics\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "22072231", "[{\"Code\":\"ENSC2001\",\"Title\":\"Activity Library Organization Oven\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 500, 21484071, "BP004", null, 4, new DateTime(2018, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMR4222\",\"Title\":\"Machinery And Maintenance\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"MECH4426\",\"Title\":\"Area Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 501, 21484072, "BP004", null, 5, new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4215\",\"Title\":\"Concrete Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Movie Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 502, 21484070, "BP004", null, 5, new DateTime(2018, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK4185\",\"Title\":\"Industrial Systems Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21484069", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Year Knowledge Analysis Software\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 503, 21484071, "BP004", null, 4, new DateTime(2018, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMR4280\",\"Title\":\"Internal Combustion Engines\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2018, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not a particularly good match, but would be OK", "21484069", "[{\"Code\":\"MECH4429\",\"Title\":\"Quality Power Player Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 504, 21327906, "62550", null, 5, new DateTime(2018, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"41514\",\"Title\":\"Dynamics Of Machinery\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MECH5502\",\"Title\":\"Camera Player Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 505, 21327908, "62550", null, 5, new DateTime(2018, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"27008\",\"Title\":\"Life Science\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Army Meat Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 506, 21327907, "62550", null, 5, new DateTime(2018, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"33323\",\"Title\":\"Intro To Nantechnology\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2018, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"MPE(MECH) OPTION\",\"Title\":\"Internet Variety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 508, 21502833, "62550", null, 5, new DateTime(2017, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECIV405\",\"Title\":\"Construction Project Planning And Scheduling\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2017, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21502829", "[{\"Code\":\"GENG5505\",\"Title\":\"Love Meat Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 301, 21018013, "60110", null, 3, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H23SM3\",\"Title\":\"Concrete And Concrete Structures\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL3112\",\"Title\":\"Nature Internet Player Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 335, 20524098, "61140", null, 4, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CVEN40050\",\"Title\":\"Structural Design\",\"Href\":\"https://unit.com\"}]", "University College Dublin", "https://university.com", "University College Dublin", true, true, new DateTime(2013, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20524094", "[{\"Code\":\"CIVL4111\",\"Title\":\"Management Country\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 299, 21018011, "60110", null, 3, new DateTime(2013, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H22MOA\",\"Title\":\"Construction Project Management\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL3150\",\"Title\":\"Literature Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 97, 21108764, "62550", null, 4, new DateTime(2016, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECHM424\",\"Title\":\"Transport Analysis\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21108763", "[{\"Code\":\"CHPR4407\",\"Title\":\"Security Science Bird\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 98, 20932921, "62550", null, 4, new DateTime(2016, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC445\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"MECH4426\",\"Title\":\"Technology History\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 99, 20932918, "62550", null, 5, new DateTime(2016, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC405\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"GENG5514\",\"Title\":\"Ability Temperature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 100, 20932920, "62550", null, 5, new DateTime(2016, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC403 AND EMEC342\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"MECH5502\",\"Title\":\"Reading Variety Child Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 101, 21325656, "BP004", null, 3, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1MA060\",\"Title\":\"Applied Mathematics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2015, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"MATH3021\",\"Title\":\"Power Problem Media People\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 102, 21325655, "BP004", null, 5, new DateTime(2015, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1MA209\",\"Title\":\"Financial Derivatives\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Thought Ability Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 96, 21328725, "62550", null, 5, new DateTime(2016, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE521\",\"Title\":\"Structural Dynamics And Earthquake Engineering\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2016, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21328723", "[{\"Code\":\"CIVL5501\",\"Title\":\"Method Safety Strategy Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 103, 21325657, "BP004", null, 3, new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1MA007\",\"Title\":\"Algebraic Structures\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2015, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"MATH3031\",\"Title\":\"Safety Temperature Camera Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 105, 21325657, "BP004", null, 3, new DateTime(2015, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA121\",\"Title\":\"Mathematical Methods Of Physics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2015, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"PHYS3011\",\"Title\":\"Love Government Technology Equipment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 106, 21325656, "BP004", null, 5, new DateTime(2015, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"5PU028\",\"Title\":\"Basic Swedish I\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2014, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Security Bird World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 107, 21325656, "BP004", null, 5, new DateTime(2015, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"5PU029\",\"Title\":\"Basic Swedish II\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2015, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Instance Meat Safety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 108, 21308013, "BP004", null, 3, new DateTime(2015, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"NUMBER THEORY III\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Durham University", "https://university.com", "Durham University", true, true, new DateTime(2015, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21308011", "[{\"Code\":\"MATH3031\",\"Title\":\"Food Activity People\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 109, 21325655, "BP004", null, 5, new DateTime(2015, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1MA032\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Uppsala University", "https://university.com", "Uppsala University", true, true, new DateTime(2014, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Variety Product\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 110, 21308014, "BP004", null, 3, new DateTime(2015, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH3091\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Durham University", "https://university.com", "Durham University", true, true, new DateTime(2015, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21308011", "[{\"Code\":\"MATH3021\",\"Title\":\"Understanding Product Safety\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 104, 21325654, "BP004", null, 2, new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"1FA140\",\"Title\":\"Statistical Mechanics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2015, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21325653", "[{\"Code\":\"PHYS2002\",\"Title\":\"Knowledge Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 95, 21328724, "62550", null, 5, new DateTime(2016, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE455\",\"Title\":\"Engineering Project Management\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2016, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21328723", "[{\"Code\":\"GENG5505\",\"Title\":\"Camera Two Equipment Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 94, 21328725, "62550", null, 4, new DateTime(2016, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE411\",\"Title\":\"Reinforced Concrete Design\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2015, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21328723", "[{\"Code\":\"CIVL4403\",\"Title\":\"Quality Reading Instance Computer\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 93, 21141449, "62550", null, 4, new DateTime(2016, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME471\",\"Title\":\"Automatic Control\",\"Href\":\"https://unit.com\"}]", "University Of Washington", "https://university.com", "University Of Washington", true, true, new DateTime(2016, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141447", "[{\"Code\":\"GENG4402\",\"Title\":\"Government Product Government\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 78, 20930721, "62550", null, 4, new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC4543\",\"Title\":\"Fuzzy Systems And Neural Networks\",\"Href\":\"https://unit.com\"}]", "University Of Hong Kong", "https://university.com", "University Of Hong Kong", true, true, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "YES (as a group B option)", "20930718", "[{\"Code\":\"CITS4404\",\"Title\":\"Security Management Oven\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 79, 21703347, "BP004", null, 2, new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GEOLOGY 401\",\"Title\":\"Physical Hydrogeology\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21703343", "[{\"Code\":\"ENVT2251\",\"Title\":\"Industry Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 80, 21490257, "BP004", null, 3, new DateTime(2016, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MA312\",\"Title\":\"Partial Differential Equations For Engineering\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2016, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21490253", "[{\"Code\":\"MATH3022\",\"Title\":\"Food Analysis Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 81, 21721967, "BP004", null, 2, new DateTime(2016, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"STAT473\",\"Title\":\"Generalized Linear Models\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2016, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21721963", "[{\"Code\":\"STAT2402\",\"Title\":\"Video Understanding Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 82, 21721966, "BP004", null, 2, new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"STAT471\",\"Title\":\"Sampling And Experimental Design\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2015, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21721963", "[{\"Code\":\"STAT2401\",\"Title\":\"Community Paper Temperature Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 83, 21498248, "BP004", null, 3, new DateTime(2016, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH328\",\"Title\":\"Dynamics And Vibrations\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2016, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21498245", "[{\"Code\":\"ENSC3001\",\"Title\":\"Basis Thing Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 84, 21482633, "BP004", null, 3, new DateTime(2016, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Quantum Mechanics III\",\"Href\":\"https://unit.com\"}]", "Nagoya University", "https://university.com", "Nagoya University", true, true, new DateTime(2016, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21482629", "[{\"Code\":\"PHYS3011\",\"Title\":\"Food Information Exam System\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 85, 21307484, "62550", null, 4, new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4220\",\"Title\":\"Understanding And Quantifying Environmental Impacts On Ecosystems\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"ENVE4401\",\"Title\":\"Science Quality Music\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 86, 21503228, "BP004", null, 3, new DateTime(2016, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME014\",\"Title\":\"Mechanics Of Materials\",\"Href\":\"https://unit.com\"},{\"Code\":\"CE101\",\"Title\":\"Materials And Structures Lab\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2016, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21503226", "[{\"Code\":\"ENSC3004\",\"Title\":\"Television Quality Society Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 87, 21503227, "BP004", null, 3, new DateTime(2016, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE180\",\"Title\":\"Geotechnical Principles\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2016, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21503226", "[{\"Code\":\"ENSC3009\",\"Title\":\"Child Oven Series\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 88, 20935730, "62550", null, 5, new DateTime(2016, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC499R\",\"Title\":\"Capstone 2\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20935729", "[{\"Code\":\"MECH5552\",\"Title\":\"People Technology Community Week\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 89, 20935731, "62550", null, 4, new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC321\",\"Title\":\"Thermodynamics 2\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20935729", "[{\"Code\":\"MECH4429\",\"Title\":\"Person Ability World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 90, 21714845, "BP004", null, 2, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EG1008 AND EG2004\",\"Title\":\"Principles Of Electronics And Fluid Mechanics And Thermodynamics\",\"Href\":\"https://unit.com\"}]", "University Of Aberdeen", "https://university.com", "University Of Aberdeen", true, true, new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21714843", "[{\"Code\":\"ENSC2002\",\"Title\":\"Camera Movie Camera People\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 91, 21520950, "BP004", null, 2, new DateTime(2016, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"2204A/B AND 2205A/B\",\"Title\":\"Thermodynamics I And Electrical Circuits I\",\"Href\":\"https://unit.com\"}]", "Western University", "https://university.com", "Western University", true, true, new DateTime(2015, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21520948", "[{\"Code\":\"ENSC2002\",\"Title\":\"Meat Ability Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 92, 21520951, "BP004", null, 2, new DateTime(2016, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"2402\",\"Title\":\"Applied Mathematics ODE\",\"Href\":\"https://unit.com\"}]", "Western University", "https://university.com", "Western University", true, true, new DateTime(2016, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21520948", "[{\"Code\":\"MATH2021\",\"Title\":\"Product Definition Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 111, 21327907, "BP004", null, 3, new DateTime(2015, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EGEN335\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2014, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"ENSC3003\",\"Title\":\"Country Quality\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 112, 21327909, "BP004", null, 3, new DateTime(2015, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EGEN205\",\"Title\":\"Mechanics Of Mtls\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2014, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"ENSC3004\",\"Title\":\"Activity Knowledge Computer\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 113, 21327906, "BP004", null, 3, new DateTime(2015, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BFIN458\",\"Title\":\"Commerical Bank Management\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2014, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"FINA3304\",\"Title\":\"Boyfriend Thought Ability\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 114, 21327908, "BP004", null, 3, new DateTime(2015, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BFIN466\",\"Title\":\"Investments II\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"FINA3324\",\"Title\":\"Person Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 134, 20938855, "62550", null, 5, new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM5171\",\"Title\":\"Water Resources Management\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20938853", "[{\"Code\":\"ENVE5551\",\"Title\":\"Map Theory Food Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 135, 20938854, "62550", null, 5, new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM5135\",\"Title\":\"Planning Of Hydro Power\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20938853", "[{\"Code\":\"GENG5506\",\"Title\":\"Data Society Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 136, 21137937, "BP004", null, 2, new DateTime(2014, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH240 &ECSE 200\",\"Title\":\"Thermo Dynamics\",\"Href\":\"https://unit.com\"}]", "Mcgill University", "https://university.com", "Mcgill University", true, true, new DateTime(2013, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"ENSC2002\",\"Title\":\"Movie Variety Understanding Year\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 137, 21137938, "BP004", null, 3, new DateTime(2014, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVE 225\",\"Title\":\"Environmental Engineering\",\"Href\":\"https://unit.com\"}]", "Mcgill University", "https://university.com", "Mcgill University", true, true, new DateTime(2014, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"ENSC3013\",\"Title\":\"Method Safety Industry Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 138, 21137936, "BP004", null, 3, new DateTime(2014, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH 331\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Mcgill University", "https://university.com", "Mcgill University", true, true, new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"ENSC3003\",\"Title\":\"Map Instance Industry Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 139, 21137935, "BP004", null, 3, new DateTime(2014, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EPSC 221\",\"Title\":\"General Geology\",\"Href\":\"https://unit.com\"}]", "Mcgill University", "https://university.com", "Mcgill University", true, true, new DateTime(2014, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"ENSC3009\",\"Title\":\"Fact Army\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 140, 21137935, "BP004", null, 3, new DateTime(2014, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVE 207\",\"Title\":\"Solid Mechanics\",\"Href\":\"https://unit.com\"}]", "Mcgill University", "https://university.com", "Mcgill University", true, true, new DateTime(2014, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"ENSC3004\",\"Title\":\"Fact Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 141, 20776066, "60110", null, 5, new DateTime(2014, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4185\",\"Title\":\"Natural Gas Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"GROUP C OPTION\",\"Title\":\"System Nature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 142, 20776065, "60110", null, 4, new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4240\",\"Title\":\"System Simulation\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"GENG4405\",\"Title\":\"Way Equipment Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 143, 20776065, "60110", null, 4, new DateTime(2014, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4140\",\"Title\":\"Process Control\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"GENG4402\",\"Title\":\"Exam Video Year Boyfriend\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 144, 20776068, "60110", null, 5, new DateTime(2014, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4150\",\"Title\":\"Energy Management And Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"GENG5506\",\"Title\":\"Computer Variety Freedom Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 145, 20776065, "60110", null, 5, new DateTime(2014, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4155\",\"Title\":\"Reaction Kinetics And Catalysts\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"CHPR5501\",\"Title\":\"Way Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 146, 20776066, "60110", null, 4, new DateTime(2014, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMT4280\",\"Title\":\"Extractive Metallurgy\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"GENG4403\",\"Title\":\"Definition Oven Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 147, 20776068, "60110", null, 3, new DateTime(2014, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPG4145\",\"Title\":\"Reservoir Fluids And Flow\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"PETR3511\",\"Title\":\"Instance Meat\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 148, 20776726, "61140", null, 3, new DateTime(2014, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH346\",\"Title\":\"Heat Transfer\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776725", "[{\"Code\":\"ENSC3007\",\"Title\":\"Science Literature Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 133, 20938856, "62550", null, 5, new DateTime(2015, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM4105\",\"Title\":\"Hydrology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20938853", "[{\"Code\":\"SCIE5500\",\"Title\":\"Paper Software System Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 77, 20930722, "62550", null, 5, new DateTime(2016, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC4147\",\"Title\":\"Power System Analysis And Control\",\"Href\":\"https://unit.com\"}]", "University Of Hong Kong", "https://university.com", "University Of Hong Kong", true, true, new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930718", "[{\"Code\":\"ELEC5505\",\"Title\":\"Story Economics Economics Meat\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 132, 20938855, "62550", null, 4, new DateTime(2015, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM4106\",\"Title\":\"Hydrological Modelling\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20938853", "[{\"Code\":\"ENVE4402\",\"Title\":\"Control Instance Knowledge Reading\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 130, 21153275, "62550", null, 5, new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM5135\",\"Title\":\"Planning Of Hydro Power\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21153273", "[{\"Code\":\"ENVE5551\",\"Title\":\"Society Way Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 115, 21327906, "BP004", null, 3, new DateTime(2015, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EGEN203\",\"Title\":\"Applied Mechanics\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327905", "[{\"Code\":\"ENSC3004\",\"Title\":\"Music Data Area\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 300, 21018013, "60110", null, 2, new DateTime(2013, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H21VII\",\"Title\":\"Engineering Surveying 1\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL2150\",\"Title\":\"Investment Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 117, 20932918, "62550", null, 5, new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC403\",\"Title\":\"CAE IV - Design Integration\",\"Href\":\"https://unit.com\"},{\"Code\":\"EMEC342\",\"Title\":\"Mech Component Design\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"MECH5502\",\"Title\":\"Security Boyfriend Story Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 118, 20932918, "62550", null, 5, new DateTime(2015, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC405\",\"Title\":\"Finite Element Analysis\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"GENG5514\",\"Title\":\"Love Government Series\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 119, 20932921, "62550", null, 4, new DateTime(2015, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC445\",\"Title\":\"Mechanical Vibrations\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2014, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"MECH4426\",\"Title\":\"Video Series\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 120, 21302582, "BP004", null, 2, new DateTime(2015, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MAS222\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21302579", "[{\"Code\":\"MATH2501\",\"Title\":\"Problem Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 121, 21494054, "BP004", null, 3, new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EE2003\",\"Title\":\"Semiconductor Fundamentals\",\"Href\":\"https://unit.com\"}]", "Nanyang University Of Technology", "https://university.com", "Nanyang University Of Technology", true, true, new DateTime(2015, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21494052", "[{\"Code\":\"ENSC3014\",\"Title\":\"Law Government Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 122, 21112556, "62550", null, 4, new DateTime(2015, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EGEN505\",\"Title\":\"Advanced Engineering Analysis\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112552", "[{\"Code\":\"GENG4405\",\"Title\":\"Industry Problem Product Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 123, 21112553, "62550", null, 5, new DateTime(2015, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE422\",\"Title\":\"Intro To Modern Controls\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112552", "[{\"Code\":\"GENG5503\",\"Title\":\"Policy Internet Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 124, 21302582, "BP004", null, 2, new DateTime(2015, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH248\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2015, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21302579", "[{\"Code\":\"MATH2501\",\"Title\":\"World Country\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 125, 21327318, "BP004", null, 1, new DateTime(2015, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"APPLIED MATHEMATICS FOR ENGINEERING II 2411\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Western Ontario", "https://university.com", "University Of Western Ontario", true, true, new DateTime(2014, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21327315", "[{\"Code\":\"MATH1002\",\"Title\":\"Television World Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 126, 21112553, "62550", null, 5, new DateTime(2015, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMAT 550\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112552", "[{\"Code\":\"MECH5504\",\"Title\":\"Nature System Computer Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 127, 21112554, "62550", null, 4, new DateTime(2015, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC 360\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112552", "[{\"Code\":\"MECH4424\",\"Title\":\"Data Internet Family Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 128, 21153275, "62550", null, 4, new DateTime(2015, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM4105\",\"Title\":\"Hydrology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21153273", "[{\"Code\":\"ENVE4402\",\"Title\":\"Freedom Camera Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 129, 21153274, "62550", null, 5, new DateTime(2015, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM5171\",\"Title\":\"Water Resources Management\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21153273", "[{\"Code\":\"GENG5506\",\"Title\":\"Boyfriend Data Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 131, 20751402, "BP004", null, 3, new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Industrial Robotics\",\"Href\":\"https://unit.com\"}]", "Maladarlen University", "https://university.com", "Maladarlen University", true, true, new DateTime(2015, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20751399", "[{\"Code\":\"ENSC3001\",\"Title\":\"Temperature Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 76, 21317915, "62550", null, 5, new DateTime(2016, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE417\",\"Title\":\"Acoustics/Audio Engineering\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Could also be considered a Group A option as research expertise (Roberto Togneri and Jie Pan) in this area in Faculty", "21317911", "[{\"Code\":\"GROUP B\",\"Title\":\"Activity Equipment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 75, 21317915, "62550", null, 5, new DateTime(2016, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE407\",\"Title\":\"Introduction To Microfabrication\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Could also be considered a Group A option as research expertise (MRG) in this area in School of EE", "21317911", "[{\"Code\":\"GROUP B\",\"Title\":\"Music Year Story Music\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 74, 21317913, "62550", null, 5, new DateTime(2016, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE414\",\"Title\":\"Introduction To VLSI Design\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"ELEC5503\",\"Title\":\"People Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 21, 21499362, "BP004", null, 2, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CS1231\",\"Title\":\"Discrete Structures\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2016, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21499359", "[{\"Code\":\"CITS2211\",\"Title\":\"Way Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 22, 21371815, "BP004", null, 3, new DateTime(2016, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVE3390\",\"Title\":\"Structural Analysis 2\",\"Href\":\"https://unit.com\"}]", "Leeds University", "https://university.com", "Leeds University", true, true, new DateTime(2015, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21371811", "[{\"Code\":\"ENSC3008\",\"Title\":\"Nature Family Area Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 23, 21728217, "BP004", null, 3, new DateTime(2016, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"40120463\",\"Title\":\"Materials Processing And Engineering Materials\",\"Href\":\"https://unit.com\"}]", "Tsinghua University", "https://university.com", "Tsinghua University", true, true, new DateTime(2016, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "These units are delivered in Chinese only. Not suitable for non-native speakers.", "21728215", "[{\"Code\":\"ENSC3002\",\"Title\":\"Child Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 24, 20930720, "62550", null, 5, new DateTime(2016, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC4343\",\"Title\":\"Design Of Digital Integrated Circuits\",\"Href\":\"https://unit.com\"}]", "University Of Hong Kong", "https://university.com", "University Of Hong Kong", true, true, new DateTime(2016, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930718", "[{\"Code\":\"ELEC5502\",\"Title\":\"Technology Society Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 25, 20930719, "62550", null, 4, new DateTime(2016, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC3245\",\"Title\":\"Control And Instrumentation\",\"Href\":\"https://unit.com\"}]", "University Of Hong Kong", "https://university.com", "University Of Hong Kong", true, true, new DateTime(2016, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930718", "[{\"Code\":\"GENG4402\",\"Title\":\"Health Bird Nature Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 26, 20930721, "62550", null, 4, new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ELEC3242\",\"Title\":\"Communications Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Hong Kong", "https://university.com", "University Of Hong Kong", true, true, new DateTime(2016, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930718", "[{\"Code\":\"ELEC4402\",\"Title\":\"Instance Food Media Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 27, 10226621, "60550", null, 5, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4250\",\"Title\":\"Multiphase Transport\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10226617", "[{\"Code\":\"CHPR5521\",\"Title\":\"Community Safety Two Television\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 28, 10226618, "60550", null, 5, new DateTime(2016, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4150\",\"Title\":\"Petrochemistry And Oil Refinery\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "10226617", "[{\"Code\":\"CHPR5501\",\"Title\":\"Child Player\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 29, 21500864, "BP004", null, 3, new DateTime(2016, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"4460\",\"Title\":\"International Financial Management I\",\"Href\":\"https://unit.com\"}]", "Vienna University Of Business", "https://university.com", "Vienna University Of Business", true, true, new DateTime(2015, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21500862", "[{\"Code\":\"FINA3326\",\"Title\":\"Health Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 30, 21500864, "BP004", null, 2, new DateTime(2016, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"4145\",\"Title\":\"Small Business Management And Entrepreneurship: Finance\",\"Href\":\"https://unit.com\"}]", "Vienna University Of Business", "https://university.com", "Vienna University Of Business", true, true, new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21500862", "[{\"Code\":\"MKTG2301\",\"Title\":\"Map Ability Community Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 31, 21500866, "BP004", null, 2, new DateTime(2016, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"4597\",\"Title\":\"Corporate Finance\",\"Href\":\"https://unit.com\"}]", "Vienna University Of Business", "https://university.com", "Vienna University Of Business", true, true, new DateTime(2016, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21500862", "[{\"Code\":\"FINA2222\",\"Title\":\"Information Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 32, 21131294, "BP004", null, 3, new DateTime(2016, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EGEN205\",\"Title\":\"Mechanics Of Mtls\",\"Href\":\"https://unit.com\"}]", "University Of Montana", "https://university.com", "University Of Montana", true, true, new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21131293", "[{\"Code\":\"ENSC3004\",\"Title\":\"Basis Bird Exam\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 33, 21307895, "BP004", null, 3, new DateTime(2016, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FINM14120\",\"Title\":\"Portfolio Management\",\"Href\":\"https://unit.com\"},{\"Code\":\"FINM14033\",\"Title\":\"Financial Markets\",\"Href\":\"https://unit.com\"}]", "ESSEC", "https://university.com", "ESSEC", true, true, new DateTime(2016, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307893", "[{\"Code\":\"FINA3324\",\"Title\":\"Health Method\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 34, 21307895, "BP004", null, 2, new DateTime(2016, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CPTC14\",\"Title\":\"Financial Statement Analysis\",\"Href\":\"https://unit.com\"}]", "ESSEC", "https://university.com", "ESSEC", true, true, new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307893", "[{\"Code\":\"FINA2207\",\"Title\":\"Strategy Health Computer\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 35, 21108766, "62550", null, 5, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ETME470\",\"Title\":\"Renewable Energy Applications\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21108763", "[{\"Code\":\"GENG5506\",\"Title\":\"Basis Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 20, 21499362, "BP004", null, 3, new DateTime(2016, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CS3241\",\"Title\":\"Computer Graphics\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2016, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21499359", "[{\"Code\":\"CITS3003\",\"Title\":\"Law Security Investment Environment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 36, 21299549, "62550", null, 4, new DateTime(2016, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMR4275\",\"Title\":\"Modelling Simulation And Analysis Of Dynamic Systems\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21299545", "[{\"Code\":\"GENG4405\",\"Title\":\"Exam World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 19, 21299549, "62550", null, 4, new DateTime(2016, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4108\",\"Title\":\"Dynamics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21299545", "[{\"Code\":\"MECH4426\",\"Title\":\"Thought Temperature Instance Nature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 17, 20933990, "BP004", null, 3, new DateTime(2016, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH3FF3\",\"Title\":\"Partial Diff. Equations\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2016, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20933987", "[{\"Code\":\"MATH3022\",\"Title\":\"Exam Two Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 2, 21978580, "BP004", null, 1, new DateTime(2016, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"VV225\",\"Title\":\"Applied Calculus\",\"Href\":\"https://unit.com\"}]", "Shanghai Jiatong University", "https://university.com", "Shanghai Jiatong University", true, true, new DateTime(2016, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21978579", "[{\"Code\":\"MATH1001\",\"Title\":\"Quality Ability Boyfriend\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 3, 21978580, "BP004", null, 1, new DateTime(2016, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"VM211\",\"Title\":\"Introduction To Sold Mechanics\",\"Href\":\"https://unit.com\"}]", "Shanghai Jiatong University", "https://university.com", "Shanghai Jiatong University", true, true, new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21978579", "[{\"Code\":\"ENSC1002\",\"Title\":\"Community Variety Bird Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 4, 20930942, "62550", null, 5, new DateTime(2016, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"42171\",\"Title\":\"System Safety And Reliability Engineering\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20930941", "[{\"Code\":\"GENG5507\",\"Title\":\"Literature Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 5, 21303166, "MPE", null, 5, new DateTime(2016, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Power System Operation\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21303163", "[{\"Code\":\"ELEC5505\",\"Title\":\"Paper Information Variety Player\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 6, 21303164, "MPE", null, 5, new DateTime(2016, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"31320\",\"Title\":\"Robust And Fult Tolerant Control\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21303163", "[{\"Code\":\"GENG5503\",\"Title\":\"Policy Love Definition Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 7, 21303164, "MPE", null, 5, new DateTime(2016, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"31631/31632\",\"Title\":\"Intergrated Analog Electronics\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21303163", "[{\"Code\":\"ELEC5502\",\"Title\":\"Thought Thought Direction\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 8, 21303164, "MPE", null, 5, new DateTime(2016, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Semiconductor Technology\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21303163", "[{\"Code\":\"ELEC5508\",\"Title\":\"Love Society Method Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 9, 21303167, "MPE", null, 5, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"VLSI Design\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21303163", "[{\"Code\":\"ELEC5503\",\"Title\":\"Ability Knowledge Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 10, 20717074, "62550", null, 4, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"6532\",\"Title\":\"Digital Communication And Modulation\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20717073", "[{\"Code\":\"ELEC4402\",\"Title\":\"Technology Ability Story Boyfriend\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 11, 20717077, "62550", null, 5, new DateTime(2016, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"42171\",\"Title\":\"System Safety And Reliability Engineering\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2016, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20717073", "[{\"Code\":\"GENG5507\",\"Title\":\"Player Language Organization Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 12, 21486968, "bp004", null, 3, new DateTime(2016, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EN3034\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Cardiff University", "https://university.com", "Cardiff University", true, true, new DateTime(2016, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21486965", "[{\"Code\":\"ENSC3003\",\"Title\":\"Literature Army Method Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 13, 21721188, "BP004", null, 2, new DateTime(2016, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MENG11202\",\"Title\":\"Thermodynamics I\",\"Href\":\"https://unit.com\"},{\"Code\":\"EENG11001\",\"Title\":\"Linear Circuits\",\"Href\":\"https://unit.com\"}]", "University Of Bristol", "https://university.com", "University Of Bristol", true, true, new DateTime(2015, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21721186", "[{\"Code\":\"ENSC2002\",\"Title\":\"Policy World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 14, 21726932, "BP004", null, 3, new DateTime(2016, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE110\",\"Title\":\"Introduction To Electronics\",\"Href\":\"https://unit.com\"}]", "University Of Illonois", "https://university.com", "University Of Illonois", true, true, new DateTime(2015, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ECE110 appears to be a first year introduction unit which covers a lot of territory. However looking over the UIUC curriculum (https://www.ece.illinois.edu/academics/ugrad/curriculum/ee-curriculum-06.asp) this the only unit they do in circuits so I assume it is the capstone electronics and circuits unit for their undergraduate EE degree which is equivalent to our Engineering Science. And units at UICU are quite demanding (9 labs and final project).", "21726929", "[{\"Code\":\"ENSC3017\",\"Title\":\"Security Camera Problem Direction\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 15, 20933989, "BP004", null, 3, new DateTime(2016, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELECENG 3PI4\",\"Title\":\"Energy Conversion\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2016, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20933987", "[{\"Code\":\"ENSC3016\",\"Title\":\"Year Camera Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 16, 20933990, "BP004", null, 3, new DateTime(2016, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH3DC3\",\"Title\":\"Discrete Dynamical Sys. Chaos\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2016, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20933987", "[{\"Code\":\"MATH3031\",\"Title\":\"Family Strategy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 18, 21299549, "62550", null, 4, new DateTime(2016, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TFY4185\",\"Title\":\"Measurement Techniques\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21299545", "[{\"Code\":\"MECH4424\",\"Title\":\"World Analysis Direction\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 149, 20776727, "61140", null, 4, new DateTime(2014, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH482\",\"Title\":\"Noise Control\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776725", "[{\"Code\":\"MECH4404\",\"Title\":\"Child Security Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 37, 20937026, "62550", null, 5, new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV ENG 748\",\"Title\":\"Seismic Design And Analysis Of Steel\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2016, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20937024", "[{\"Code\":\"CIVL5501\",\"Title\":\"Reading Direction Method\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 39, 20937025, "62550", null, 5, new DateTime(2016, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV ENG 6T04\",\"Title\":\"Transportation Engineering II - Modelling Transit And ITS\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2015, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20937024", "[{\"Code\":\"CIVL5502\",\"Title\":\"Policy Family\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 59, 21307483, "62550", null, 4, new DateTime(2016, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Multiphase Transport\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"CHPR4407\",\"Title\":\"Boyfriend Oven Thing Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 60, 21307482, "62550", null, 4, new DateTime(2016, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Surface And Colloid Chemistry\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"CHPR4405\",\"Title\":\"Thing Thought Government Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 61, 21307483, "62550", null, 5, new DateTime(2016, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Biofuels And Biorefineries\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"GENG5506\",\"Title\":\"Computer Equipment Environment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 62, 20935730, "62550", null, 5, new DateTime(2016, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC499R\",\"Title\":\"Capstone 2\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20935729", "[{\"Code\":\"MECH5552\",\"Title\":\"Analysis World Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 63, 20935732, "62550", null, 4, new DateTime(2016, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EMEC321\",\"Title\":\"Thermodynamics 2\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20935729", "[{\"Code\":\"MECH4429\",\"Title\":\"Boyfriend Television Week\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 64, 21131295, "BP004", null, 2, new DateTime(2016, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BFIN441\",\"Title\":\"Advanced Analysis Of Financial Statements\",\"Href\":\"https://unit.com\"}]", "University Of Montana", "https://university.com", "University Of Montana", true, true, new DateTime(2016, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21131293", "[{\"Code\":\"FINA2207\",\"Title\":\"Language Movie\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 65, 21131297, "BP004", null, 3, new DateTime(2016, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BFIN357\",\"Title\":\"Financial Markets And Institutions\",\"Href\":\"https://unit.com\"}]", "University Of Montana", "https://university.com", "University Of Montana", true, true, new DateTime(2015, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21131293", "[{\"Code\":\"FINA3304\",\"Title\":\"Love Information Safety Nature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 66, 21131294, "BP004", null, 2, new DateTime(2016, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BFIN460\",\"Title\":\"Derivative Securities And Risk Management\",\"Href\":\"https://unit.com\"}]", "University Of Montana", "https://university.com", "University Of Montana", true, true, new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21131293", "[{\"Code\":\"FINA2204\",\"Title\":\"Two Law Literature Government\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 67, 21131297, "BP004", null, 3, new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BFIN402\",\"Title\":\"Investment Fundamentals And Portfolio Management\",\"Href\":\"https://unit.com\"}]", "University Of Montana", "https://university.com", "University Of Montana", true, true, new DateTime(2016, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21131293", "[{\"Code\":\"FINA3324\",\"Title\":\"Activity Environment Development Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 68, 21126502, "62550", null, 5, new DateTime(2016, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"OFF600\",\"Title\":\"Marine Operations\",\"Href\":\"https://unit.com\"}]", "University Of Stavanger", "https://university.com", "University Of Stavanger", true, true, new DateTime(2015, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21126499", "[{\"Code\":\"GENG5501\",\"Title\":\"Video Theory Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 69, 21714488, "BP004", null, 1, new DateTime(2016, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BSNS102\",\"Title\":\"Quantitative Analysis For Business\",\"Href\":\"https://unit.com\"}]", "University Of Otago", "https://university.com", "University Of Otago", true, true, new DateTime(2016, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21714487", "[{\"Code\":\"STAT1400\",\"Title\":\"Product Community Library Child\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 70, 21317915, "62550", null, 5, new DateTime(2016, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE454\",\"Title\":\"Power Systems Analysis\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"ELEC5505\",\"Title\":\"Week Power Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 71, 21108765, "62550", null, 4, new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ETME360\",\"Title\":\"\\\"Measurement And Instrumentation Applications\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"EMEC445\",\"Title\":\"\\\"Mechanical Vibrations\\\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21108763", "[{\"Code\":\"MECH4424\",\"Title\":\"Control Music Software Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 72, 21317915, "62550", null, 5, new DateTime(2016, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE422\",\"Title\":\"Introduction To Modern Control\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"GENG5503\",\"Title\":\"Language Television Ability Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 73, 21317914, "62550", null, 4, new DateTime(2016, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE321\",\"Title\":\"Introduction To Feedback Controls\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"GENG4402\",\"Title\":\"Theory World Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 58, 21307482, "62550", null, 5, new DateTime(2016, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Natural Gas\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2015, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"CHPR5521\",\"Title\":\"Data Security Boyfriend\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 38, 20937026, "62550", null, 5, new DateTime(2016, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIV ENG 727\",\"Title\":\"Structural Control And Seismic Isolation\",\"Href\":\"https://unit.com\"}]", "Mcmaster University", "https://university.com", "Mcmaster University", true, true, new DateTime(2016, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20937024", "[{\"Code\":\"CIVL5501\",\"Title\":\"Environment Language Freedom\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 57, 21307484, "62550", null, 5, new DateTime(2016, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Advanced Control Of Industrial Processes\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"GENG5503\",\"Title\":\"Security Law Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 55, 21307482, "62550", null, 5, new DateTime(2016, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Petrochemistry And Oil Refining\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"GENG5504\",\"Title\":\"Camera Week Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 40, 21498249, "BP004", null, 3, new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH328\",\"Title\":\"Dynamics And Vibrations\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2016, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21498245", "[{\"Code\":\"ENSC3001\",\"Title\":\"Series Army Security\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 41, 21498249, "BP004", null, 3, new DateTime(2016, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COMM322\",\"Title\":\"Financial Management Stategy\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2016, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21498245", "[{\"Code\":\"FINA3326\",\"Title\":\"Society Thing Two Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 42, 21317914, "62550", null, 5, new DateTime(2016, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE454\",\"Title\":\"Power Systems Analysis\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"ELEC5505\",\"Title\":\"Product Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 43, 21317914, "62550", null, 5, new DateTime(2016, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE414\",\"Title\":\"Introduction To VLSI Design\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"ELEC5503\",\"Title\":\"Week Television Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 44, 21317914, "62550", null, 4, new DateTime(2016, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE321\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"GENG4402\",\"Title\":\"Person Language Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 45, 21317915, "62550", null, 5, new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EELE422\",\"Title\":\"Introduction To Modern Control\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2016, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21317911", "[{\"Code\":\"GENG5503\",\"Title\":\"Law Meat Oven Activity\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 46, 21714491, "BP004", null, 2, new DateTime(2016, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH272\",\"Title\":\"Discrete Mathematics\",\"Href\":\"https://unit.com\"}]", "University Of Otago", "https://university.com", "University Of Otago", true, true, new DateTime(2016, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21714487", "[{\"Code\":\"CITS2211\",\"Title\":\"Thing Two Two\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 47, 21714491, "BP004", null, 3, new DateTime(2016, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COSC244\",\"Title\":\"Data-Communications, Networks, Internet\",\"Href\":\"https://unit.com\"}]", "University Of Otago", "https://university.com", "University Of Otago", true, true, new DateTime(2016, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21714487", "[{\"Code\":\"CITS3002\",\"Title\":\"Television Management Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 48, 21714488, "BP004", null, 2, new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COSC242\",\"Title\":\"Algorithms And Data Structures\",\"Href\":\"https://unit.com\"}]", "University Of Otago", "https://university.com", "University Of Otago", true, true, new DateTime(2016, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21714487", "[{\"Code\":\"CITS2200\",\"Title\":\"Analysis Society Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 49, 21300578, "62550", null, 4, new DateTime(2016, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Control Engineering And Tutorial\",\"Href\":\"https://unit.com\"}]", "Nagoya University", "https://university.com", "Nagoya University", true, true, new DateTime(2016, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21300576", "[{\"Code\":\"GENG4402\",\"Title\":\"People Investment Exam Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 50, 21300578, "62550", null, 4, new DateTime(2016, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Numerical Analysis\",\"Href\":\"https://unit.com\"}]", "Nagoya University", "https://university.com", "Nagoya University", true, true, new DateTime(2016, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21300576", "[{\"Code\":\"GENG4405\",\"Title\":\"Country Week\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 51, 21300578, "62550", null, 4, new DateTime(2016, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Water And Waste Engineering\",\"Href\":\"https://unit.com\"}]", "Nagoya University", "https://university.com", "Nagoya University", true, true, new DateTime(2015, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21300576", "[{\"Code\":\"ENVE4401\",\"Title\":\"Policy History Bird Method\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 52, 21721964, "BP004", null, 2, new DateTime(2016, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"STAT473\",\"Title\":\"Generalized Linear Models\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2016, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21721963", "[{\"Code\":\"STAT2402\",\"Title\":\"Boyfriend Way Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 53, 21721965, "BP004", null, 2, new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"STAT471\",\"Title\":\"Design And Analysis Of Experiments\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2016, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21721963", "[{\"Code\":\"STAT2401\",\"Title\":\"Literature Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 54, 21307483, "62550", null, 4, new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Reactor Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"CHPR4406\",\"Title\":\"Media Problem Television\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 56, 21307484, "62550", null, 5, new DateTime(2016, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Heat And Combustion Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2016, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307481", "[{\"Code\":\"CHPR5520\",\"Title\":\"Area Freedom History Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 150, 20776729, "61140", null, 4, new DateTime(2014, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MINE451\",\"Title\":\"Chemical Extraction Of Metals\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776725", "[{\"Code\":\"GENG4403\",\"Title\":\"Definition Family Information History\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 116, 20932918, "62550", null, 5, new DateTime(2015, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EIND477\",\"Title\":\"Quality Assurance\",\"Href\":\"https://unit.com\"}]", "Montana State University", "https://university.com", "Montana State University", true, true, new DateTime(2015, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20932917", "[{\"Code\":\"GENG5507\",\"Title\":\"System Exam Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 152, 20921107, "51160", null, 3, new DateTime(2014, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC E 331\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Alberta", "https://university.com", "University Of Alberta", true, true, new DateTime(2014, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20921103", "[{\"Code\":\"ENSC3003\",\"Title\":\"Meat Story Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 247, 20506129, "61140", null, 5, new DateTime(2013, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Automotive Engines\",\"Href\":\"https://unit.com\"}]", "Comillas Pontificial University", "https://university.com", "Comillas Pontificial University", true, true, new DateTime(2013, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20506126", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Direction Boyfriend Technology Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 248, 20506127, "61140", null, 5, new DateTime(2013, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Renewable Energies\",\"Href\":\"https://unit.com\"}]", "Comillas Pontificial University", "https://university.com", "Comillas Pontificial University", true, true, new DateTime(2013, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20506126", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Law Way Ability\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 249, 20506129, "61140", null, 5, new DateTime(2013, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Metrology\",\"Href\":\"https://unit.com\"}]", "Comillas Pontificial University", "https://university.com", "Comillas Pontificial University", true, true, new DateTime(2013, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20506126", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Data Economics Music\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 250, 20506127, "61140", null, 5, new DateTime(2013, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Creating Web Pages\",\"Href\":\"https://unit.com\"}]", "Comillas Pontificial University", "https://university.com", "Comillas Pontificial University", true, true, new DateTime(2013, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20506126", "[{\"Code\":\"GROUP C OPTION\",\"Title\":\"Area People Instance\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 251, 20506130, "61140", null, 5, new DateTime(2013, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"\",\"Title\":\"Environmental Impact And Renewable Energy\",\"Href\":\"https://unit.com\"}]", "Comillas Pontificial University", "https://university.com", "Comillas Pontificial University", true, true, new DateTime(2013, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20506126", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Understanding Society Video Instance\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 252, 21151391, "BP004", null, 3, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PEME3321\",\"Title\":\"Chemical Engineering Thermodynamics\",\"Href\":\"https://unit.com\"}]", "Leeds University", "https://university.com", "Leeds University", true, true, new DateTime(2013, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21151388", "[{\"Code\":\"ENSC3006\",\"Title\":\"Boyfriend Map Theory Law\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 246, 21141279, "BP004", null, 4, new DateTime(2014, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"2492\",\"Title\":\"Control Theory\",\"Href\":\"https://unit.com\"}]", "Technical University Of Denmark", "https://university.com", "Technical University Of Denmark", true, true, new DateTime(2013, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"GENG4402\",\"Title\":\"Meat Army Bird Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 253, 20753884, "51160", null, 5, new DateTime(2013, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MVKF15\",\"Title\":\"Introduction To Vehicle Engineering\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20753883", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Variety Understanding Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 255, 20753375, "51160", null, 3, new DateTime(2013, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME4213\",\"Title\":\"Vibration Theory And Applications\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20753373", "[{\"Code\":\"MECH3404\",\"Title\":\"Food Science Video Reading\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 256, 20753375, "51160", null, 3, new DateTime(2013, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME3221\",\"Title\":\"Energy Conversion Processes\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20753373", "[{\"Code\":\"MECH3401\",\"Title\":\"Bird Power Ability\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 257, 20753376, "51160", null, 4, new DateTime(2013, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME5106\",\"Title\":\"Engineering Acoustics\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2012, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20753373", "[{\"Code\":\"MECH4404\",\"Title\":\"Science Movie\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 258, 20753375, "51160", null, 4, new DateTime(2013, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME4227\",\"Title\":\"Internal Combustion Engines\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2013, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20753373", "[{\"Code\":\"MECH4409\",\"Title\":\"Bird Instance Music\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 259, 20181870, "60110", null, 4, new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4120\",\"Title\":\"Coadtal Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL4130\",\"Title\":\"Language Love Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 151, 20776726, "61140", null, 5, new DateTime(2014, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH435\",\"Title\":\"Internal Combustion Engines\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suitable as a general Group B option", "20776725", "[{\"Code\":\"ELECTIVE\",\"Title\":\"Industry Power\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 254, 20753374, "51160", null, 3, new DateTime(2013, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME4255\",\"Title\":\"Materials Failure\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2013, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20753373", "[{\"Code\":\"MECH3405\",\"Title\":\"Art Oven\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 245, 20776065, "60110", null, 3, new DateTime(2014, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4165\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"ENSC3018\",\"Title\":\"Quality Love Information Two\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 244, 20776067, "60110", null, 4, new DateTime(2014, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4250\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"CHPR4407\",\"Title\":\"Quality Government Person\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 243, 20776065, "60110", null, 5, new DateTime(2014, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4170\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"CHPR5520\",\"Title\":\"Analysis Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 228, 21312102, "BP004", null, 1, new DateTime(2014, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COM131\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21312099", "[{\"Code\":\"MKTG1203\",\"Title\":\"Library Control Area\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 229, 21114399, "BP004", null, 1, new DateTime(2014, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MANG1001\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21114395", "[{\"Code\":\"MANG1001\",\"Title\":\"Government Food\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 230, 21116687, "BP004", null, 2, new DateTime(2014, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CS 124\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Vermont", "https://university.com", "University Of Vermont", true, true, new DateTime(2014, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21116683", "[{\"Code\":\"CITS2200\",\"Title\":\"Country Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 231, 21118947, "BP004", null, 3, new DateTime(2014, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH 328\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3001\",\"Title\":\"Management Physics Instance\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 232, 20762077, "61140", null, 5, new DateTime(2014, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL580\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2014, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"GENG5502\",\"Title\":\"Physics Understanding Meat Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 233, 21137935, "BP004", null, 4, new DateTime(2014, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENSC3001\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"MECH463 AND PHYS306\",\"Title\":\"Map Temperature Quality Love\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 234, 21312102, "BP004", null, 2, new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECONS222\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21312099", "[{\"Code\":\"ECONS2234\",\"Title\":\"Management Basis Temperature Music\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 235, 21118947, "BP004", null, 3, new DateTime(2014, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL330\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3008\",\"Title\":\"Week Freedom Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 236, 21114397, "BP004", null, 5, new DateTime(2014, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MANG3030\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21114395", "[{\"Code\":\"UNSPECIFIED OPTION IN THE FINANCE MAJOR\",\"Title\":\"Boyfriend Story Exam\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 237, 21118948, "BP004", null, 3, new DateTime(2014, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH270 AND MECH213\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3002\",\"Title\":\"Power Industry Series\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 238, 20762076, "61140", null, 5, new DateTime(2014, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL417\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2014, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"GENG5501\",\"Title\":\"Movie Freedom Development Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 239, 20762079, "61140", null, 5, new DateTime(2014, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL507\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2014, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"CIVL5501\",\"Title\":\"Two Government\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 240, 20762078, "61140", null, 5, new DateTime(2014, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL523\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2014, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"GENG5505\",\"Title\":\"Food Analysis Person Freedom\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 241, 21310672, "BP004", null, 3, new DateTime(2014, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"HIST2406\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21310668", "[{\"Code\":\"HIST3002\",\"Title\":\"Freedom Country Boyfriend Environment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 242, 20776068, "60110", null, 3, new DateTime(2014, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4130\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"ENSC3007\",\"Title\":\"Nature Meat Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 261, 20181871, "60110", null, 4, new DateTime(2013, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMR4195\",\"Title\":\"Design Of Offshore Structures\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL4170\",\"Title\":\"Internet Direction Two Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 262, 20181872, "60110", null, 5, new DateTime(2013, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4182\",\"Title\":\"Nuclear Power, Introduction\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"\",\"Title\":\"Analysis Reading Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 263, 20181872, "60110", null, 5, new DateTime(2013, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4160\",\"Title\":\"Aero Dynamics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"\",\"Title\":\"Area Development Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 264, 20181872, "60110", null, 3, new DateTime(2013, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4220\",\"Title\":\"Concrete Structures 2\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL3112\",\"Title\":\"Physics Ability Boyfriend Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 284, 20928540, "60110", null, 5, new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4145\",\"Title\":\"Port And Coastal Facilities\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928538", "[{\"Code\":\"GROUP C OR B OPTION\",\"Title\":\"Reading Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 285, 20991153, "BP004", null, 3, new DateTime(2013, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4100\",\"Title\":\"Geotechnical Eng\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20991149", "[{\"Code\":\"ENSC3009\",\"Title\":\"Instance Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 286, 20517898, "51160", null, 4, new DateTime(2013, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4135\",\"Title\":\"Engineering Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517896", "[{\"Code\":\"CIVL4402\",\"Title\":\"Fact Product Movie Area\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 287, 20517899, "51160", null, 3, new DateTime(2013, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4192\",\"Title\":\"Finite Element Methods In Strength Analysis\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517896", "[{\"Code\":\"CIVL3140\",\"Title\":\"Health Government System\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 288, 20517898, "51160", null, 5, new DateTime(2013, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4108\",\"Title\":\"Dynamics, Advanced Course\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517896", "[{\"Code\":\"CIVL5501\",\"Title\":\"Year Variety Analysis Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 289, 20517900, "51160", null, 5, new DateTime(2013, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK5115\",\"Title\":\"Risk Management In Projects\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517896", "[{\"Code\":\"GENG5505\",\"Title\":\"Health Basis Area\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 290, 20517898, "51160", null, 4, new DateTime(2013, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TVM5125\",\"Title\":\"Hydraulic Design\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected as equivalent to ENSC3010", "20517896", "[{\"Code\":\"CIVL4402\",\"Title\":\"Food Equipment Thanks Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 291, 20517898, "51160", null, 3, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4105\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20517896", "[{\"Code\":\"ENSC3010\",\"Title\":\"Development Health Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 292, 20915270, "60110", null, 5, new DateTime(2013, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPG4140\",\"Title\":\"Natural Gas\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20915269", "[{\"Code\":\"GROUP D OPTION UNIT\",\"Title\":\"Health Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 293, 20915273, "60110", null, 5, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GEOG2007\",\"Title\":\"Effects Of Climate Change\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20915269", "[{\"Code\":\"GROUP D OPTION UNIT\",\"Title\":\"Environment Child\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 294, 20915272, "60110", null, 5, new DateTime(2013, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"SOS2501\",\"Title\":\"Norwegian Society\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20915269", "[{\"Code\":\"GROUP D OPTION UNIT\",\"Title\":\"Development Development Economics Organization\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 295, 20915270, "60110", null, 5, new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"SOK1151\",\"Title\":\"Macroeconomics For Managers\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20915269", "[{\"Code\":\"GROUP D OPTION UNIT\",\"Title\":\"Control Way Law Internet\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 296, 20991151, "BP004", null, 3, new DateTime(2013, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TIØ4566\",\"Title\":\"Strategic Purchasing And Supply Management, Specialization Course\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20991149", "[{\"Code\":\"MGMT3308\",\"Title\":\"Society Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 297, 20991151, "BP004", null, 3, new DateTime(2013, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"GEOG3518\",\"Title\":\"Knowledge Management In A Global Economy\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20991149", "[{\"Code\":\"INMT3234\",\"Title\":\"Security Week Music Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 298, 21018011, "60110", null, 2, new DateTime(2013, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"H21G11\",\"Title\":\"Geotechnics 1\",\"Href\":\"https://unit.com\"}]", "Nottingham University", "https://university.com", "Nottingham University", true, true, new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21018009", "[{\"Code\":\"CIVL2121\",\"Title\":\"Quality Camera Nature Problem\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 283, 20928542, "60110", null, 5, new DateTime(2013, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TIO4536\",\"Title\":\"Innovation And Entrepreneurship, Specialization\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928538", "[{\"Code\":\"GROUP C OPTION\",\"Title\":\"Direction Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 227, 21137938, "BP004", null, 3, new DateTime(2014, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH329\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2014, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21137934", "[{\"Code\":\"ENSC3002\",\"Title\":\"Reading Music Strategy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 282, 20928541, "60110", null, 5, new DateTime(2013, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"NFUT0001\",\"Title\":\"Norwegian For Foreigners\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928538", "[{\"Code\":\"GROUP C OPTION\",\"Title\":\"Library Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 280, 20923619, "60110", null, 4, new DateTime(2013, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMR4190\",\"Title\":\"Finite Element Methods In Structural Analaysis\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20923616", "[{\"Code\":\"MECH4405\",\"Title\":\"Oven Economics Data\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 265, 20181872, "60110", null, 3, new DateTime(2013, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK5100\",\"Title\":\"Project Planning And Control\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL3150\",\"Title\":\"Thing History Security Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 266, 20181869, "60110", null, 4, new DateTime(2013, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA5200\",\"Title\":\"Project Planning And Analysis\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL4150\",\"Title\":\"Two Exam\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 267, 20181871, "60110", null, 3, new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4198\",\"Title\":\"Structural Design, Advanced Course\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL3111\",\"Title\":\"Idea Person Idea\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 268, 20181869, "60110", null, 4, new DateTime(2013, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4170\",\"Title\":\"Steel Structures\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL4111\",\"Title\":\"World People Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 269, 20505283, "60110", null, 4, new DateTime(2013, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4270\",\"Title\":\"Coastal Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20505282", "[{\"Code\":\"CIVL4130\",\"Title\":\"Science Law Community Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 270, 20505285, "60110", null, 5, new DateTime(2013, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TEP4112\",\"Title\":\"Turbulent Flows\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20505282", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Data Camera Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 271, 20750625, "60110", null, 3, new DateTime(2013, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4145\",\"Title\":\"Reactor Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20750623", "[{\"Code\":\"CHPR3432\",\"Title\":\"History Control Technology Software\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 272, 20750626, "60110", null, 2, new DateTime(2013, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4150\",\"Title\":\"Petrochemistry And Oil Refinery\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20750623", "[{\"Code\":\"PETR2510\",\"Title\":\"Person Understanding Series Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 273, 20750624, "60110", null, 3, new DateTime(2013, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4135\",\"Title\":\"Chemical Process System Engineering\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20750623", "[{\"Code\":\"CHPR3531\",\"Title\":\"Ability History Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 274, 20750624, "60110", null, 3, new DateTime(2013, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKP4115\",\"Title\":\"Surface And Colloid Chemistry\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20750623", "[{\"Code\":\"CHPR3434\",\"Title\":\"Software Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 275, 20181872, "60110", null, 3, new DateTime(2013, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4105\",\"Title\":\"Geotechnics, Design Methods\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL3120\",\"Title\":\"Oven Boyfriend Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 276, 20928631, "60110", null, 4, new DateTime(2013, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPG4150\",\"Title\":\"Reservoir Recovery Techniques\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928627", "[{\"Code\":\"PETR4512\",\"Title\":\"Way Thanks Community\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 277, 20919159, "BP004", null, 4, new DateTime(2013, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK5100 OR TET4851\",\"Title\":\"Project Planning And Management Or Experts In Team - Future Energy For Sustainable Development\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20919157", "[{\"Code\":\"MECH4400\",\"Title\":\"Year Boyfriend Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 278, 20928172, "60110", null, 5, new DateTime(2013, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK5100\",\"Title\":\"Project Planning And Control\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928171", "[{\"Code\":\"GENG5505\",\"Title\":\"Variety Problem Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 279, 20923620, "60110", null, 5, new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TBA4116\",\"Title\":\"Geotechnical Engineering, Advanced Course\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20923616", "[{\"Code\":\"GENG5502\",\"Title\":\"Media Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 281, 20923617, "60110", null, 5, new DateTime(2013, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TPK5160\",\"Title\":\"Risk Analysis\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2013, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20923616", "[{\"Code\":\"GENG5507\",\"Title\":\"Industry Music Internet Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 226, 20762077, "61140", null, 5, new DateTime(2014, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL518\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "UBC", "https://university.com", "UBC", true, true, new DateTime(2013, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"GENG5507\",\"Title\":\"Language Way Army Science\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 260, 20181872, "60110", null, 4, new DateTime(2013, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TKT4201\",\"Title\":\"Structural Dynamics 1\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2012, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20181868", "[{\"Code\":\"CIVL4110\",\"Title\":\"Quality Story Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 224, 21140273, "BP004", null, 3, new DateTime(2014, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH213 AND MECH270\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21140271", "[{\"Code\":\"ENSC3002\",\"Title\":\"Exam Internet Fact\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 172, 21119727, "BP004", null, 3, new DateTime(2014, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CPE106\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2013, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21119726", "[{\"Code\":\"ENSC3003\",\"Title\":\"Direction Problem\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 173, 21141280, "BP004", null, 3, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MGT6117\",\"Title\":\"International Finance\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2013, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved by UWA but Sheffield may not allow enrollment as this is a level 6 unit(Graduate Level)", "21141278", "[{\"Code\":\"ECON3236\",\"Title\":\"Food Food Series\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 174, 21141282, "BP004", null, 5, new DateTime(2014, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MGT6091\",\"Title\":\"Issues In Finance\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved by UWA but Sheffield may not allow enrollment as this is a level 6 unit(Graduate Level)", "21141278", "[{\"Code\":\"LEVEL 2 FINACE OPTION UNIT\",\"Title\":\"Freedom Control\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 175, 21120930, "BP004", null, 3, new DateTime(2014, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BUS422\",\"Title\":\"Investments And Portfolio Management\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21120928", "[{\"Code\":\"FINA3324\",\"Title\":\"Knowledge Week Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 176, 21120932, "BP004", null, 2, new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ACC411\",\"Title\":\"Business Valuation\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21120928", "[{\"Code\":\"FINA2207\",\"Title\":\"Child Analysis World\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 177, 21004175, "BP004", null, 2, new DateTime(2014, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH2413, MECH2405, MECH2414\",\"Title\":\"Engineering Mechanics, Fundamentals Of Electrical And Electronic Engineering, Thermofluids\",\"Href\":\"https://unit.com\"},{\"Code\":\"MECH2419\",\"Title\":\"Properties Of Materials\",\"Href\":\"https://unit.com\"}]", "University Of Hong Kong", "https://university.com", "University Of Hong Kong", true, true, new DateTime(2014, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21004172", "[{\"Code\":\"ENSC2001\",\"Title\":\"Knowledge Literature Meat Story\",\"Href\":\"https://uwa.edu.au\"},{\"Code\":\"ENSC2002\",\"Title\":\"Organization Love Player Year\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 171, 20944806, "BP004", null, 3, new DateTime(2014, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CN2122\",\"Title\":\"CHEMICAL\",\"Href\":\"https://unit.com\"}]", "National University Of Singapore", "https://university.com", "National University Of Singapore", true, true, new DateTime(2014, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20944805", "[{\"Code\":\"ENSC3003\",\"Title\":\"Way Economics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 178, 21151401, "BP004", null, 3, new DateTime(2014, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE30500\",\"Title\":\"Semiconductor Devices\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2014, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21151397", "[{\"Code\":\"ENSC3014\",\"Title\":\"Science Reading Movie\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 180, 21151398, "BP004", null, 3, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MGMT41100\",\"Title\":\"Investment Management\",\"Href\":\"https://unit.com\"},{\"Code\":\"MGMT41200\",\"Title\":\"Financial Markets And Institutions\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2013, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21151397", "[{\"Code\":\"FINA3324\",\"Title\":\"Analysis Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 181, 21112410, "53560", null, 3, new DateTime(2014, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE421\",\"Title\":\"Introduction To Signal Processing\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"ENSC3015\",\"Title\":\"Food Information Player Quality\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 182, 21112413, "53560", null, 3, new DateTime(2014, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE453\",\"Title\":\"Electric Motor Drives\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"ENSC3016\",\"Title\":\"Year Development Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 183, 21112410, "53560", null, 2, new DateTime(2014, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PY301\",\"Title\":\"Introduction To Quantum Mechanics\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2013, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"PHYS2001\",\"Title\":\"Person Movie Art\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 184, 21120929, "BP004", null, 3, new DateTime(2014, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MAE308\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21120928", "[{\"Code\":\"ENSC3003\",\"Title\":\"Two Organization Understanding\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 185, 21120931, "BP004", null, 3, new DateTime(2014, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MAE314\",\"Title\":\"Solid Mechanics\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21120928", "[{\"Code\":\"ENSC3004\",\"Title\":\"Physics Theory Paper Physics\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 179, 21151400, "BP004", null, 3, new DateTime(2014, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE25500\",\"Title\":\"Electronic Circuit Analysis And Design\",\"Href\":\"https://unit.com\"},{\"Code\":\"ECE27000\",\"Title\":\"Introduction To Digital System Design\",\"Href\":\"https://unit.com\"}]", "Purdue University", "https://university.com", "Purdue University", true, true, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21151397", "[{\"Code\":\"ENSC3017\",\"Title\":\"Management Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 170, 21149245, "BP004", null, 1, new DateTime(2014, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH207\",\"Title\":\"Calculus 3\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2014, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"MATH1002\",\"Title\":\"Internet Language Literature Oven\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 169, 21149244, "BP004", null, 2, new DateTime(2014, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ME212\",\"Title\":\"Dynamics\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2013, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC2001\",\"Title\":\"Fact Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 168, 21149245, "BP004", null, 2, new DateTime(2014, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE230\",\"Title\":\"Physical Chemistry 1\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2013, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC2002\",\"Title\":\"Reading Map\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 153, 20921104, "51160", null, 3, new DateTime(2014, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC E 380\",\"Title\":\"Advanced Strength Of Materials\",\"Href\":\"https://unit.com\"}]", "University Of Alberta", "https://university.com", "University Of Alberta", true, true, new DateTime(2014, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20921103", "[{\"Code\":\"ENSC3004\",\"Title\":\"Basis Power Bird\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 225, 21126287, "BP004", null, 3, new DateTime(2014, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECM2114\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Exeter", "https://university.com", "University Of Exeter", true, true, new DateTime(2014, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21126283", "[{\"Code\":\"ENSC3004\",\"Title\":\"Thing Method Area Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 155, 20921107, "51160", null, 4, new DateTime(2014, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC E 340\",\"Title\":\"Applied Thermodynamics\",\"Href\":\"https://unit.com\"}]", "University Of Alberta", "https://university.com", "University Of Alberta", true, true, new DateTime(2013, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20921103", "[{\"Code\":\"MECH4429\",\"Title\":\"Direction Two Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 156, 20921105, "51160", null, 5, new DateTime(2014, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC E 409\",\"Title\":\"Experimental Design Project\",\"Href\":\"https://unit.com\"}]", "University Of Alberta", "https://university.com", "University Of Alberta", true, true, new DateTime(2014, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20921103", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Week Bird Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 157, 20921107, "51160", null, 4, new DateTime(2014, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC E 451\",\"Title\":\"Vibrations And Sound\",\"Href\":\"https://unit.com\"}]", "University Of Alberta", "https://university.com", "University Of Alberta", true, true, new DateTime(2014, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20921103", "[{\"Code\":\"MECH4426\",\"Title\":\"Music Art Exam Law\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 158, 21149245, "BP004", null, 3, new DateTime(2014, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BMAN20072\",\"Title\":\"Investment Analysis\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"FINA3324\",\"Title\":\"Exam Community Internet Oven\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 159, 21149243, "BP004", null, 3, new DateTime(2014, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"BMAN20112\",\"Title\":\"Strategy In Financial Context\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul advised this is fine but will advise against it if student has ambitions to take Honours in Finance", "21149241", "[{\"Code\":\"FINA3326\",\"Title\":\"Understanding Theory World Basis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 160, 20510948, "61140", null, 4, new DateTime(2014, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"462/562\",\"Title\":\"Foundation Engineering 1\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2014, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20510944", "[{\"Code\":\"CIVL4401\",\"Title\":\"Method Boyfriend Literature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 161, 20510947, "61140", null, 3, new DateTime(2014, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"331\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2013, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20510944", "[{\"Code\":\"ENSC3010\",\"Title\":\"World Child Analysis Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 162, 20510947, "61140", null, 3, new DateTime(2014, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"308\",\"Title\":\"Structural Analysis\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2013, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20510944", "[{\"Code\":\"ENSC3008\",\"Title\":\"Community Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 163, 20510948, "61140", null, 4, new DateTime(2014, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"411/511\",\"Title\":\"Reinforced Concrete Design\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2013, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20510944", "[{\"Code\":\"CIVL4403\",\"Title\":\"People Equipment Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 164, 20510946, "61140", null, 4, new DateTime(2014, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"440/540\",\"Title\":\"Design Of Hydraulic Systems\",\"Href\":\"https://unit.com\"}]", "University Of New Mexico", "https://university.com", "University Of New Mexico", true, true, new DateTime(2014, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20510944", "[{\"Code\":\"CIVL4402\",\"Title\":\"Fact Information Industry\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 165, 21141280, "BP004", null, 3, new DateTime(2014, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MGT6077\",\"Title\":\"Financial Markets And Investment Management\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved by UWA but Sheffield may not allow enrollment as this is a level 6 unit(Graduate Level)", "21141278", "[{\"Code\":\"FINA3324\",\"Title\":\"Freedom People\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 166, 21141279, "BP004", null, 3, new DateTime(2014, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC208\",\"Title\":\"Fluids Engineering\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"ENSC3003\",\"Title\":\"Power Definition Development Society\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 167, 21149244, "BP004", null, 2, new DateTime(2014, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHE230 &PHYS222\",\"Title\":\"Physical Chemistry 1\",\"Href\":\"https://unit.com\"}]", "University Of Waterloo", "https://university.com", "University Of Waterloo", true, true, new DateTime(2014, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student would need to make up study of AC circuits by personal study", "21149241", "[{\"Code\":\"ENSC2002\",\"Title\":\"Science Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 186, 21141280, "BP004", null, 3, new DateTime(2014, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC312\",\"Title\":\"Advanced Mechanics Of Solids\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"ENSC3004\",\"Title\":\"Industry Thing Art Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 187, 21112410, "53560", null, 2, new DateTime(2014, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MA401\",\"Title\":\"Differential Equations II\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2013, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"MATH2501\",\"Title\":\"History Literature Year Video\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 154, 20921107, "51160", null, 4, new DateTime(2014, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MEC E 420\",\"Title\":\"Feedback Control Design Of Dynamic\",\"Href\":\"https://unit.com\"}]", "University Of Alberta", "https://university.com", "University Of Alberta", true, true, new DateTime(2014, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20921103", "[{\"Code\":\"GENG4402\",\"Title\":\"Boyfriend Meat Temperature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 189, 21141280, "BP004", null, 5, new DateTime(2014, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MGT227\",\"Title\":\"Issues In Corporate Governance\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"FINANCE LEVEL 2 OPTION UNIT\",\"Title\":\"Boyfriend System Language\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 209, 21118945, "BP004", null, 3, new DateTime(2014, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL330\",\"Title\":\"Structural Analysis\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3008\",\"Title\":\"Army Theory\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 210, 21307894, "BP004", null, 1, new DateTime(2014, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MA242\",\"Title\":\"Calculus III\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21307893", "[{\"Code\":\"MATH1002\",\"Title\":\"Thanks Definition Player\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 211, 20776067, "60110", null, 5, new DateTime(2014, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"FY2290\",\"Title\":\"Energy And Resources\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20776064", "[{\"Code\":\"GROUP B OPTION\",\"Title\":\"Activity Freedom Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 212, 21140272, "BP004", null, 3, new DateTime(2014, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECHANICAL ENGINEERING 473\",\"Title\":\"Fundamentals Of Kinematics And Dynamics Of Machines\",\"Href\":\"https://unit.com\"}]", "University Of Calgary", "https://university.com", "University Of Calgary", true, true, new DateTime(2014, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21140271", "[{\"Code\":\"ENSC3001\",\"Title\":\"Physics Science Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 213, 21118945, "BP004", null, 3, new DateTime(2014, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH328\",\"Title\":\"Dynamics And Vibration\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3001\",\"Title\":\"Software Thing\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 214, 21118947, "BP004", null, 3, new DateTime(2014, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH 370\",\"Title\":\"Principles Of Materials Processing\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3002\",\"Title\":\"Management Child Series Year\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 215, 20928542, "60110", null, 3, new DateTime(2014, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMT4266\",\"Title\":\"Metal Fabrication And Forming - Microstructure And Crystal Plasticity\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928538", "[{\"Code\":\"ENSC3002\",\"Title\":\"Theory Society Literature Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 216, 20928542, "60110", null, 4, new DateTime(2014, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"TMM4205\",\"Title\":\"Tribology And Surface Technology\",\"Href\":\"https://unit.com\"}]", "Norwegian University Of Science And Technology", "https://university.com", "Norwegian University Of Science And Technology", true, true, new DateTime(2014, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20928538", "[{\"Code\":\"MECH4407\",\"Title\":\"Law Way Bird Equipment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 217, 21149243, "BP004", null, 3, new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE20002\\r\\nY,AND CHEN10092\",\"Title\":\"Applied Fluid Mechanics And Transport Phenomena 2\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Only in combination", "21149241", "[{\"Code\":\"ENSC3003\",\"Title\":\"Direction Ability Information\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 218, 20762076, "61140", null, 5, new DateTime(2014, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL507\",\"Title\":\"Dynamics Of Structures 1\",\"Href\":\"https://unit.com\"}]", "University Of British Columbia", "https://university.com", "University Of British Columbia", true, true, new DateTime(2014, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"CIVIL MAJOR OPT\",\"Title\":\"Fact Development\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 219, 20762078, "61140", null, 5, new DateTime(2014, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CIVL523\",\"Title\":\"Project Management For Engineers\",\"Href\":\"https://unit.com\"}]", "University Of British Columbia", "https://university.com", "University Of British Columbia", true, true, new DateTime(2014, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20762075", "[{\"Code\":\"GENG5505\",\"Title\":\"Basis Story\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 220, 21140274, "BP004", null, 3, new DateTime(2014, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH270 AND  MECH213\",\"Title\":\"Manufacturing Methods And  Manufacturing Methods And\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taken together", "21140271", "[{\"Code\":\"ENSC3002\",\"Title\":\"Strategy Ability Ability\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 221, 21312100, "BP004", null, 1, new DateTime(2014, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"COM111\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21312099", "[{\"Code\":\"ACCT1101\",\"Title\":\"Literature Temperature Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 223, 21310669, "BP004", null, 5, new DateTime(2014, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"HIST246\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2014, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21310668", "[{\"Code\":\"BROADENING\",\"Title\":\"Power Policy\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 188, 21141280, "BP004", null, 5, new DateTime(2014, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MGT230\",\"Title\":\"Introduction To Corporate Finance And Asset Pricing\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"FINANCE LEVEL 2 OPTION UNIT\",\"Title\":\"Basis Video Management\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 208, 21149244, "BP004", null, 1, new DateTime(2014, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHEM10101\",\"Title\":\"Introductory Chemistry\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"CHEM1002\",\"Title\":\"Product Analysis Problem Bird\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 207, 21149242, "BP004", null, 3, new DateTime(2014, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE20002\",\"Title\":\"\\\"Applied Fluid Mechanics\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"CHEN10092\",\"Title\":\"\\\"Transport Phenomena 2\\\"\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC3003\",\"Title\":\"Family Direction Method\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 222, 21114396, "BP004", null, 3, new DateTime(2014, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MATH3044\",\"Title\":\"\",\"Href\":\"https://unit.com\"}]", "University Of Southampton", "https://university.com", "University Of Southampton", true, true, new DateTime(2014, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21114395", "[{\"Code\":\"STAT3062\",\"Title\":\"Understanding Theory Knowledge\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 205, 21149242, "BP004", null, 3, new DateTime(2014, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"PHYS20252\",\"Title\":\"Fundemantals Of Solid State Phyics\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC3014\",\"Title\":\"Media Meat Technology Analysis\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 206, 21149245, "BP004", null, 3, new DateTime(2014, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"EEEN10029\",\"Title\":\"Electronic Circuit Design\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC3017\",\"Title\":\"Strategy Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 191, 21141279, "BP004", null, 5, new DateTime(2014, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECN220\",\"Title\":\"Money, Banking And Finance\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"FINANCE LEVEL 2 OPTION UNIT\",\"Title\":\"Country Law Health\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 192, 21133496, "BP004", null, 3, new DateTime(2014, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MET353\",\"Title\":\"Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Kansas State University", "https://university.com", "Kansas State University", true, true, new DateTime(2014, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21133492", "[{\"Code\":\"ENSC3003\",\"Title\":\"Food Thanks\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 193, 21133493, "BP004", null, 3, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CE533\",\"Title\":\"Mechanics Of Materials\",\"Href\":\"https://unit.com\"}]", "Kansas State University", "https://university.com", "Kansas State University", true, true, new DateTime(2014, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21133492", "[{\"Code\":\"ENSC3004\",\"Title\":\"Story Freedom Organization Thought\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 194, 21112410, "53560", null, 3, new DateTime(2014, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE404\",\"Title\":\"Introduction To Solid-State Devices\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"ENSC3014\",\"Title\":\"Year Week Television Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 195, 21149245, "BP004", null, 3, new DateTime(2014, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"CHEN20010\",\"Title\":\"Momentum, Heat And Mass Transfer\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC3007\",\"Title\":\"Development Society Year\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 196, 21149244, "BP004", null, 3, new DateTime(2014, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MACE11005\",\"Title\":\"Thermodynamics\",\"Href\":\"https://unit.com\"}]", "University Of Manchester", "https://university.com", "University Of Manchester", true, true, new DateTime(2014, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21149241", "[{\"Code\":\"ENSC3006\",\"Title\":\"Thing Instance Technology\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 190, 21141281, "BP004", null, 5, new DateTime(2014, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECN357\",\"Title\":\"Modern Finance\",\"Href\":\"https://unit.com\"}]", "University Of Sheffield", "https://university.com", "University Of Sheffield", true, true, new DateTime(2014, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21141278", "[{\"Code\":\"FINANCE LEVEL 2 OPTION UNIT\",\"Title\":\"Organization Investment\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 198, 21126972, "BP004", null, 3, new DateTime(2014, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MVKN45\",\"Title\":\"Applied Computational Fluid Mechanics\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2013, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21126971", "[{\"Code\":\"ENSC3003\",\"Title\":\"Basis Definition Way\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 199, 21126974, "BP004", null, 3, new DateTime(2014, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"KTE170\",\"Title\":\"Mass Transfer Processes In Environmental Engineering\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2014, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "MJ has approved KTE170 to be counted as equivalent towards ENSC3005 & ENSC3019 for this student. This unit has double the usual credit attached to it. But he has said that he made a mistake in approving it for ENSC3019 but willing to let it remain for this student. Thus KTE170 is considered an equivalent only for ENSC3005", "21126971", "[{\"Code\":\"ENSC3005\",\"Title\":\"Music Library Science Library\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 200, 20925111, "60110", null, 4, new DateTime(2014, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ENG4001\",\"Title\":\"\\\"Acoustics And Audio Technology\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"MACE11602\",\"Title\":\"\\\"Mechanics (Aero/Mech)\\\"\",\"Href\":\"https://unit.com\"}]", "University Of Glasgow", "https://university.com", "University Of Glasgow", true, true, new DateTime(2014, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "20925109", "[{\"Code\":\"MECH4404\",\"Title\":\"Love Camera\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 201, 21112410, "53560", null, 3, new DateTime(2014, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE301\",\"Title\":\"\\\"Linear Systems\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"ECE421\",\"Title\":\"\\\"Introduction To Signal Processing\\\"\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"ENSC3015\",\"Title\":\"Love Week Way Media\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 202, 21112410, "53560", null, 3, new DateTime(2014, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE302\",\"Title\":\"\\\"Microelectronics\\\"\",\"Href\":\"https://unit.com\"},{\"Code\":\"ECE212\",\"Title\":\"\\\"Fundamentals Of Logic Design\\\"\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"ENSC3017\",\"Title\":\"Government Software\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 203, 21112410, "53560", null, 3, new DateTime(2014, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"ECE305\",\"Title\":\"Electric Power Systems\",\"Href\":\"https://unit.com\"}]", "North Carolina State University", "https://university.com", "North Carolina State University", true, true, new DateTime(2014, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21112409", "[{\"Code\":\"ENSC3016\",\"Title\":\"Society Industry Nature\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 204, 21118948, "BP004", null, 3, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"MECH321\",\"Title\":\"Solid Mechanics II\",\"Href\":\"https://unit.com\"}]", "Queen's University", "https://university.com", "Queen's University", true, true, new DateTime(2013, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21118944", "[{\"Code\":\"ENSC3004\",\"Title\":\"Fact Language Variety Quality\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "ExchangeApplicationUnitSets",
                columns: new[] { "Id", "ApplicationId", "CourseCode", "EquivalencePrecedentId", "EquivalentUWAUnitLevel", "ExchangeDate", "ExchangeUnits", "ExchangeUniversityCountry", "ExchangeUniversityHref", "ExchangeUniversityName", "IsContextuallyApproved", "IsEquivalent", "LastUpdatedAt", "Notes", "StudentNumber", "UWAUnits" },
                values: new object[] { 197, 21126973, "BP004", null, 3, new DateTime(2014, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Code\":\"KETF20\",\"Title\":\"Chemical Engineering, Project Laboratory\",\"Href\":\"https://unit.com\"}]", "Lund University", "https://university.com", "Lund University", true, true, new DateTime(2013, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "21126971", "[{\"Code\":\"ENSC3018\",\"Title\":\"Year Control Knowledge Area\",\"Href\":\"https://uwa.edu.au\"}]" });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 50, "liang.cheng@staff.uwa.edu", "sGXIwTjnf71RzEjf763EjazOjoeHZ1lDbhhHHy/woD0=", "UnitCoordinator", new byte[] { 54, 19, 135, 92, 127, 13, 90, 195, 144, 166, 106, 154, 236, 174, 107, 104 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 49, "belinda.sykes)@staff.uwa.edu", "k5bRb1smdPdoehJtdaW1e2iz1UkftgT5qXzXwcRCRJU=", "UnitCoordinator", new byte[] { 41, 22, 104, 146, 225, 78, 27, 253, 1, 174, 139, 124, 177, 159, 67, 130 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 48, "barry.lehane@staff.uwa.edu", "qsBhWDHLkbqsfkGvS7NQk1J5KhfLN99fvtFFvKT1/R0=", "UnitCoordinator", new byte[] { 207, 173, 88, 30, 50, 72, 247, 23, 107, 2, 124, 201, 216, 2, 48, 238 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 47, "paul.lloyd@staff.uwa.edu", "wZ+Hb/Rsu99P/39Z6Ghd86eHX6GdolDuMiUwjhU0eOI=", "UnitCoordinator", new byte[] { 100, 174, 72, 221, 142, 209, 25, 196, 119, 167, 218, 113, 237, 170, 13, 95 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 46, "richard.durham@staff.uwa.edu", "m69C3EKdiqqCwjzgoG+HFDuowPhy/XP1cxcp2/6XZE8=", "UnitCoordinator", new byte[] { 12, 26, 200, 95, 170, 89, 98, 177, 138, 186, 60, 229, 155, 119, 94, 110 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 45, "mike.johns@staff.uwa.edu", "x4z73yFO9g2qwdsOfRlXVbhKDH5gypTY8uIprKtbjw8=", "UnitCoordinator", new byte[] { 165, 137, 234, 174, 90, 158, 16, 119, 108, 32, 185, 182, 235, 79, 83, 78 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 42, "michael.johns@staff.uwa.edu", "fDYE8TpEmEaEcddOTf9KFFSTiq1FH8W4gODULvq5exg=", "UnitCoordinator", new byte[] { 27, 73, 140, 28, 156, 247, 210, 33, 72, 120, 58, 70, 39, 124, 47, 187 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 43, "cosimo.faiello@staff.uwa.edu", "7qYjrnvmSMXAMwJqFUvBi6fZN+BN9c4+l7x2ovSAu2o=", "UnitCoordinator", new byte[] { 228, 227, 190, 201, 246, 109, 116, 37, 52, 95, 167, 237, 242, 237, 172, 84 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 41, "business.school@staff.uwa.edu", "xlvGBpTAu99UoIt03XnWcmjw2WhbbPbtptsrvH9dsK8=", "UnitCoordinator", new byte[] { 21, 84, 227, 36, 47, 95, 60, 125, 104, 207, 47, 125, 243, 111, 88, 182 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 40, "farid.boussaid@staff.uwa.edu", "1FCR1JMsMOSAUK6i5GRTfp7OvfWjB4OZxLEnW00sfxs=", "UnitCoordinator", new byte[] { 210, 142, 224, 166, 180, 230, 35, 18, 26, 45, 131, 190, 208, 174, 128, 54 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 39, "belinda.sykes@staff.uwa.edu", "ncA/GFGBMUe5Iq+Qcp1K8FTr/2knI7U6RGS5ImVasao=", "UnitCoordinator", new byte[] { 227, 206, 99, 239, 125, 1, 39, 53, 210, 91, 254, 6, 86, 225, 196, 149 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 51, "yinong.liu@staff.uwa.edu", "nwauPGpgdp9EGAS12LQvA29K5crE1lhTTLNx5Y4G+Gc=", "UnitCoordinator", new byte[] { 253, 144, 185, 20, 144, 162, 77, 123, 96, 154, 176, 104, 67, 109, 159, 232 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 37, "andy.fourie@staff.uwa.edu", "tKqTyHL9Wln0YRKyUr75kZkrpYRlEYW4P7RxDzSi7iA=", "UnitCoordinator", new byte[] { 30, 74, 218, 208, 141, 183, 2, 246, 120, 49, 146, 108, 178, 169, 47, 64 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 44, "sabbia.tilli@staff.uwa.edu", "7PIDmzw7Ax5jNmTn5lveOR1+P1I04pQyiLqWS/1IFIY=", "UnitCoordinator", new byte[] { 178, 224, 19, 251, 255, 82, 0, 175, 26, 38, 212, 207, 37, 225, 7, 51 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 38, "brett.nener@staff.uwa.edu", "sUjKhki34nth4GBQUGHq1cvtY2XvRgUOlGWFabetQ1Q=", "UnitCoordinator", new byte[] { 95, 72, 188, 175, 154, 156, 245, 33, 119, 235, 195, 119, 209, 172, 69, 80 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 59, "ghulam.mubashar.hassan@staff.uwa.edu", "dQ0AZyDDX/4IWW4nsTSfwUCnOYF6XAFxj2CUOsTi1F8=", "UnitCoordinator", new byte[] { 149, 148, 85, 217, 239, 114, 96, 204, 35, 95, 231, 76, 196, 152, 28, 19 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 53, "melinda.hodkiewicz@staff.uwa.edu", "lUsOzKfi9ZYtH+RYnebw5Flnz2rDd1Y1O5jk0wX4cWw=", "UnitCoordinator", new byte[] { 218, 130, 40, 30, 20, 244, 82, 112, 38, 172, 89, 223, 102, 143, 229, 176 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 68, "jeremy.leggoe.&.einar.fridjonssonn@staff.uwa.edu", "wRJkiPqCPw9r0THEMEEhBVabfrDu4JmUWt4Kevr0pBg=", "UnitCoordinator", new byte[] { 156, 48, 202, 38, 9, 106, 224, 206, 184, 73, 150, 134, 204, 194, 64, 148 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 36, "peter.lloyd@staff.uwa.edu", "hh31WhVYk0ZC5eAK6HYNjJVVlzCfLuRo7VHDMsBfvVw=", "UnitCoordinator", new byte[] { 245, 36, 10, 76, 202, 14, 227, 92, 50, 174, 8, 211, 213, 33, 204, 213 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 67, "ghulam.hassan@staff.uwa.edu", "qC5ue+InTaZn2pmsMWV6vH48wap1fw4l4zWU7Yrr17I=", "UnitCoordinator", new byte[] { 50, 59, 194, 119, 83, 74, 55, 157, 150, 134, 157, 194, 224, 138, 139, 248 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 66, "victor.sreeram@staff.uwa.edu", "K/R+nyOaVkCaOGOSiKaR9w/GQiLSh8vnMXFQUg9pSds=", "UnitCoordinator", new byte[] { 49, 81, 107, 234, 7, 36, 51, 31, 251, 150, 53, 230, 121, 182, 17, 195 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 65, "karol.miller@staff.uwa.edu", "h7yF4lHPeZH33IDA4V5351YuuYrIvR/lgUB/cojUkHU=", "UnitCoordinator", new byte[] { 73, 56, 157, 167, 216, 191, 231, 83, 132, 125, 38, 205, 102, 173, 189, 192 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 64, "brendan.graham@staff.uwa.edu", "YGI+GtCJ+3bpaZmge4zh8+mzbl5By1cAIF3slT12cl8=", "UnitCoordinator", new byte[] { 49, 224, 15, 2, 169, 133, 120, 201, 212, 147, 164, 123, 39, 225, 94, 176 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 63, "sharon.tan@staff.uwa.edu", "apvIaCbQQTJu/z/XmouFJFru1Jdea9+CW+cKPh8SuLs=", "UnitCoordinator", new byte[] { 230, 167, 16, 74, 88, 157, 255, 182, 198, 97, 236, 235, 209, 209, 226, 101 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 62, "farhad.aslani@staff.uwa.edu", "drdAeR/6L3kGfcQaPNPxS369M+dWJ5BKS3yZJfFOb7g=", "UnitCoordinator", new byte[] { 46, 97, 39, 36, 164, 79, 71, 212, 151, 104, 111, 9, 236, 56, 206, 229 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 61, "maatakiri@staff.uwa.edu", "W71uQ+A3gA7e7s+BOAOfm4bZ0N0CmQ9cEE2zP+K6CiQ=", "UnitCoordinator", new byte[] { 93, 141, 70, 113, 109, 255, 216, 107, 26, 228, 53, 180, 191, 26, 2, 109 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 60, "jianxin.li@staff.uwa.edu", "zy6CX2+n+yfBR0p34MMRXwmxjS99UXFH8AT3M121Od0=", "UnitCoordinator", new byte[] { 216, 193, 137, 89, 221, 116, 45, 73, 73, 71, 195, 81, 165, 134, 186, 3 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 58, "matthew.young@staff.uwa.edu", "Ws9czIKbSYc96fjC4AKGHLvNm+a718JxbB+2QvlJCnE=", "UnitCoordinator", new byte[] { 147, 153, 195, 142, 186, 39, 249, 1, 4, 50, 180, 201, 106, 32, 253, 55 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 57, "darren.grasso@staff.uwa.edu", "eXlNeyeExC5W89oHpzzi94zsxYj6OZvbVsrwGnphgqU=", "UnitCoordinator", new byte[] { 124, 115, 189, 177, 137, 48, 58, 189, 56, 205, 114, 138, 55, 241, 84, 168 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 56, "elena.pasternak@staff.uwa.edu", "pPnhOdVhcCZCd2WqSQaa7mnUheMdfcIPdhiXyWhcTvE=", "UnitCoordinator", new byte[] { 213, 219, 209, 215, 163, 255, 50, 97, 8, 18, 92, 220, 150, 135, 200, 167 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 55, "amitava.datta@staff.uwa.edu", "/LzPY9xc2mQdyFtTDU0eQEiZim+4msKvuREfpjXZNVQ=", "UnitCoordinator", new byte[] { 137, 97, 224, 46, 148, 20, 69, 243, 163, 149, 250, 119, 164, 30, 93, 135 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 54, "angus.tavner@staff.uwa.edu", "HLtg6uGRQlLPxzkB5hD+H4j+wZslX8mWDA20h8Veo2o=", "UnitCoordinator", new byte[] { 97, 125, 241, 159, 115, 219, 124, 245, 147, 193, 32, 220, 58, 55, 82, 71 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 52, "chari.p@staff.uwa.edu", "Zd59g1UIqVzrdbnvWOCRVHWLpe11wr3PXXgjiMT9zIo=", "UnitCoordinator", new byte[] { 191, 32, 133, 248, 84, 247, 168, 184, 173, 102, 24, 225, 194, 20, 179, 75 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 35, "dianne.hesterman@staff.uwa.edu", "oe5hBmWj/Isk/X3c4D571qNkUcRzNdSVA/03R/g2K/o=", "UnitCoordinator", new byte[] { 44, 49, 223, 28, 143, 5, 36, 115, 255, 246, 49, 203, 160, 59, 238, 0 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 17, "brendam.graham@staff.uwa.edu", "Rl73fyU7Zg3A3GrQwP6cGxS+ad6zmce5cLvvYFNJx7Y=", "UnitCoordinator", new byte[] { 12, 211, 69, 90, 145, 30, 135, 221, 230, 38, 214, 24, 125, 22, 58, 202 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 33, "melinda.h@staff.uwa.edu", "28l5Ssfim8NyiIaQB8vZexr5a2CEHxW3M6pa1aqNt/o=", "UnitCoordinator", new byte[] { 91, 124, 142, 204, 83, 37, 110, 82, 117, 160, 39, 70, 106, 61, 252, 101 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 13, "rachel.cardell-oliver@staff.uwa.edu", "CA+PpCQTdeSEFYd6VTjvj+tj2TnXkh58lYAEaJIhisw=", "UnitCoordinator", new byte[] { 17, 95, 75, 67, 136, 105, 231, 228, 152, 225, 74, 255, 32, 63, 242, 146 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 12, "du.huynh@staff.uwa.edu", "G0eTewPE1AdtVAz8ny5JaQUMpKxZPK3b/gLke8vJ4/k=", "UnitCoordinator", new byte[] { 25, 64, 34, 177, 31, 174, 163, 184, 91, 196, 111, 180, 191, 112, 169, 50 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 11, "adam.wittek@staff.uwa.edu", "DJtwDyYGJpYGoqUw+r+3bF5DeAQesEbYtRT5YMewc3Y=", "UnitCoordinator", new byte[] { 162, 179, 161, 153, 241, 111, 135, 182, 228, 244, 182, 246, 17, 148, 167, 34 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 10, "jie.pan@staff.uwa.edu", "9Gu6+WxFBtYReUPNJEWJMbaOVuIlLDa/25T/R8c8XTg=", "UnitCoordinator", new byte[] { 144, 15, 163, 97, 185, 100, 28, 31, 73, 33, 41, 206, 20, 229, 100, 127 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 9, "adrian.keating@staff.uwa.edu", "DWn7GsbjPhLg51hSTWqJjXqIpdadUfUlkZX2u0vNdbQ=", "UnitCoordinator", new byte[] { 73, 103, 126, 209, 88, 175, 157, 165, 171, 247, 216, 38, 55, 38, 113, 73 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 8, "herbert.iu@staff.uwa.edu", "CvusZ964Yod0NKnRGlxIb2KtV1R3jMPseK5dcL1wwQY=", "UnitCoordinator", new byte[] { 199, 22, 137, 89, 111, 255, 43, 31, 19, 90, 9, 53, 142, 4, 196, 86 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 14, "james.doherty@staff.uwa.edu", "YBjdqHsIULZcf2a/DUvt8st1Oh41uFr/VPijLXHGFJw=", "UnitCoordinator", new byte[] { 127, 231, 62, 222, 237, 238, 116, 211, 29, 128, 34, 210, 60, 209, 176, 191 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 7, "hui.tong.chua@staff.uwa.edu", "Xqalp5sherIAqfvpwpcX8pXdYdfxhiut+suk0qPNcaw=", "UnitCoordinator", new byte[] { 32, 118, 91, 226, 241, 0, 82, 151, 162, 126, 92, 37, 88, 89, 187, 188 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 5, "robeto.togneri@staff.uwa.edu", "dX1uvV2qxOalxsY2Dno08ThfXzCnG6mCrvhDMxUMJyk=", "UnitCoordinator", new byte[] { 185, 251, 185, 228, 147, 143, 212, 167, 230, 21, 135, 143, 10, 139, 121, 152 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 4, "tongming.zhou@staff.uwa.edu", "pzHAjqswg+gKmDbKewitxaz/3Pr/PgmbDbmowT070XA=", "UnitCoordinator", new byte[] { 8, 24, 223, 101, 68, 108, 103, 98, 184, 112, 124, 219, 130, 171, 104, 139 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 3, "ali.karrech@staff.uwa.edu", "rUJcQH8qBA09O7FTPmE14FqXIjMUCtywJvSlETC7zIQ=", "UnitCoordinator", new byte[] { 104, 202, 94, 37, 54, 99, 27, 79, 21, 213, 16, 171, 154, 189, 238, 65 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 2, "des.hill@staff.uwa.edu", "wWfqE2HpST5034g9709qO8jxrEWQCTBGHE9xElA+Z+I=", "UnitCoordinator", new byte[] { 11, 171, 117, 168, 11, 0, 108, 137, 59, 111, 74, 43, 139, 255, 159, 5 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 1, "@staff.uwa.edu", "NpjJC9lNMxzRzy6A51QYKu70x6jqGCz9wchnkufO2Tc=", "UnitCoordinator", new byte[] { 72, 121, 204, 73, 27, 132, 255, 107, 117, 252, 40, 142, 91, 8, 43, 89 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 69, "john.brookes@staff.uwa.edu", "6z/eaSvJMwWa+p5hE3TOVOwkbBpvSXlfHiwz/PqTuDE=", "UnitCoordinator", new byte[] { 148, 91, 156, 213, 16, 132, 174, 130, 29, 239, 221, 2, 57, 146, 83, 203 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 6, "jeremy.leggoe@staff.uwa.edu", "K/ZO8GQqGRmaZKzmYBKwOR5fdkj6X1ZAKDctzxSOTXk=", "UnitCoordinator", new byte[] { 159, 77, 190, 96, 44, 181, 209, 208, 91, 167, 211, 106, 139, 43, 90, 57 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 34, "nicole.jones@staff.uwa.edu", "gQgPVGMbi9n5MVSzGNk1bbvQjFNGPtYf3LbDgCWgvZs=", "UnitCoordinator", new byte[] { 155, 70, 225, 131, 210, 99, 18, 167, 139, 219, 187, 64, 21, 74, 181, 112 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 15, "tim.sercombe@staff.uwa.edu", "/YHpTvCebG12I1rtZjwarGf/IBztd4kAdXUxuBT8H90=", "UnitCoordinator", new byte[] { 59, 209, 55, 151, 213, 143, 206, 11, 251, 82, 172, 171, 50, 158, 205, 103 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 18, "arcady.dyskin@staff.uwa.edu", "Bv+jK/RfIne1Vbv10L4TOXd0VBOo4Ju799hg307kjdY=", "UnitCoordinator", new byte[] { 204, 115, 230, 84, 0, 232, 81, 252, 95, 161, 152, 2, 193, 198, 202, 127 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 32, "david.huang@staff.uwa.edu", "PqYsWM82jfIeNzRnV+Ry0rLp3tK1wbA18BbOfkXP+Gc=", "UnitCoordinator", new byte[] { 31, 85, 236, 172, 203, 25, 73, 105, 85, 6, 117, 115, 244, 115, 196, 197 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 31, "lyndon.while@staff.uwa.edu", "473kGlDvNLs52J7zeihFnmT93aBvo6evawzUuSIouuw=", "UnitCoordinator", new byte[] { 251, 203, 150, 154, 150, 57, 164, 6, 94, 62, 160, 112, 141, 54, 2, 97 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 30, "carolyn.oldham@staff.uwa.edu", "cvHzYv69CxT8I/A8C0LMCDeFOqDlqSivhD0BnuTmI14=", "UnitCoordinator", new byte[] { 211, 229, 241, 87, 211, 19, 65, 155, 205, 107, 225, 98, 165, 73, 242, 251 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 29, "matilda.ross@staff.uwa.edu", "6qsttGS149L9/PqVI/XRNoJHQXZFU/Pr3KSEtcggs/c=", "UnitCoordinator", new byte[] { 165, 2, 162, 25, 79, 219, 7, 149, 25, 141, 68, 239, 86, 160, 104, 231 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 28, "tyrone.fernando@staff.uwa.edu", "S9WLtt6yxqtkmHwpD9Y4iOfee5fOtcvZBe0B4UKkYHk=", "UnitCoordinator", new byte[] { 193, 165, 11, 215, 65, 69, 51, 210, 93, 33, 67, 230, 44, 77, 221, 108 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 27, "ho.ching.iu@staff.uwa.edu", "sx5g9SUPFEKCX4s/UoxkNVAtGcyosfDE23xFL6LI+7M=", "UnitCoordinator", new byte[] { 241, 131, 24, 192, 245, 101, 45, 86, 181, 192, 144, 73, 180, 42, 115, 107 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 16, "roberto.togneri@staff.uwa.edu", "xzulv5uhAuWe66iY7wBqBR+9ySM+SAyAH59LsiH5IfE=", "UnitCoordinator", new byte[] { 182, 90, 126, 76, 32, 97, 230, 180, 89, 145, 57, 111, 203, 30, 194, 62 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 26, "ian.mcarthur@staff.uwa.edu", "SlrUQdKGYL8TSXpad20f5M2xMkY8aEJ7LDJ0kUZXbJU=", "UnitCoordinator", new byte[] { 194, 104, 192, 107, 133, 8, 38, 1, 244, 251, 61, 146, 240, 58, 60, 5 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 24, "matthew.hipsey@staff.uwa.edu", "IM2g2q5gXlnu7R72PAnRo6s+kFYfvAxHGuf3XBsbcH0=", "UnitCoordinator", new byte[] { 131, 117, 241, 251, 26, 212, 11, 145, 125, 183, 134, 36, 0, 197, 206, 98 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 23, "scott.draper@staff.uwa.edu", "KTh1GqRDK/yqWoDZKVZicHl1JtEP146c4r0AqcNAMsI=", "UnitCoordinator", new byte[] { 229, 142, 37, 10, 59, 208, 24, 26, 39, 83, 66, 254, 226, 89, 150, 84 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 22, "business.sub-dean@staff.uwa.edu", "1v/kZkvyQ2AE26luMpzWrWVtl3pCWgpggWQ4HK++T68=", "UnitCoordinator", new byte[] { 182, 47, 108, 167, 82, 54, 233, 59, 87, 171, 7, 10, 132, 234, 126, 127 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 21, "nazim.khan@staff.uwa.edu", "Vt1tRsLX64u61+Dzar67VObPnaUL7klNlNZoHeFXZNY=", "UnitCoordinator", new byte[] { 115, 234, 61, 248, 179, 153, 115, 240, 2, 118, 175, 1, 233, 88, 19, 145 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 20, "keith.smettem@staff.uwa.edu", "SGogOjxt0vhhxPOZi8rseBmQ+WurKrVSJWW5orOQFQ8=", "UnitCoordinator", new byte[] { 61, 48, 48, 129, 63, 199, 112, 169, 9, 148, 37, 78, 187, 41, 221, 207 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 19, "chris.mcdonald@staff.uwa.edu", "vW+yGRhZ3FnrQGAuxxwHALWyCT9x8MIDxjEZwSC5l2A=", "UnitCoordinator", new byte[] { 84, 223, 67, 195, 33, 14, 135, 197, 125, 244, 94, 243, 234, 99, 73, 50 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 25, "barry.doyle@staff.uwa.edu", "Hsp9wfFk6xPJz5y/0qyXTJBzs6zx81naRIDilv6sSZE=", "UnitCoordinator", new byte[] { 231, 111, 0, 42, 13, 237, 231, 223, 224, 213, 191, 48, 242, 42, 52, 170 } });

            migrationBuilder.InsertData(
                table: "StaffLogons",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Salt" },
                values: new object[] { 70, "ros@uwa.edu.au", "8tCdsR8FVz2wD9PF2oAqeRRfXh0udaFUmueKJnf0qJg=", "StudentOffice", new byte[] { 173, 175, 208, 86, 18, 82, 94, 44, 157, 209, 93, 195, 168, 138, 40, 49 } });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeApplicationUnitSets_EquivalencePrecedentId",
                table: "ExchangeApplicationUnitSets",
                column: "EquivalencePrecedentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeApplicationUnitSets");

            migrationBuilder.DropTable(
                name: "StaffLogons");
        }
    }
}
