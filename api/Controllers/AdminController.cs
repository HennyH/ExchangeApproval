using System;
using System.Collections.Generic;
using System.Linq;
using ExchangeApproval.Data;
using ExchangeApproval.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ExchangeApproval.Data.Queries;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using ExchangeApproval.AdminTools;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ExchangeApproval.Controllers
{
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly ExchangeDbContext _db;

        public AdminController(ExchangeDbContext db)
        {
            this._db = db;
        }


        [Authorize]
        [HttpPost("equivalencies")]
        public ActionResult UpdateEquivalencies(IFormFile equivalencies)
        {
            try
            {
                using (var stream = equivalencies.OpenReadStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var (errors, unitSets) = EquivalenceUnitSetsReader.LoadEquivalencies(reader);
                    if (errors != null && errors.Count > 0)
                    {
                        return new JsonResult(errors.Select(e => $"Line {e.line}: {e.error}"))
                        {
                            StatusCode = (int)HttpStatusCode.BadRequest
                        };
                    }

                    EquivalenceUnitSetsReader.UpdateEquivalenciesInDatabase(this._db, unitSets);
                    return new StatusCodeResult((int)HttpStatusCode.NoContent);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new string[] { ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [Authorize]
        [HttpGet("equivalencies")]
        public FileStreamResult GetEquivalencies()
        {
            var equivalencies = EquivalenceUnitSetsReader.DumpEquivalencies(this._db);
            var memory = new MemoryStream();
            var writer = new StreamWriter(memory, Encoding.UTF8);
            var csv = new CsvHelper.CsvWriter(writer);
            csv.WriteHeader<EquivalenceUnitSetRow>();
            csv.NextRecord();
            csv.WriteRecords(equivalencies);
            csv.Flush();
            writer.Flush();
            memory.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(memory, "text/csv");
        }


        [Authorize]
        [HttpPost("applications")]
        public ActionResult UpdateApplications(IFormFile applications) 
        {
            try
            {
                using (var stream = applications.OpenReadStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var str = reader.ReadToEnd();

                    StudentApplication[] js = JsonConvert.DeserializeObject<StudentApplication[]>(str);
                    // ApplicationsBackup.UpdateApplicationsDB(this._db, js);
                    return new StatusCodeResult((int)HttpStatusCode.NoContent);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new string[] { ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [Authorize]
        [HttpGet("applications")]
        public FileStreamResult GetApplications()
        {
            var applications = this._db.StudentApplications.ToList();

            var memory = new MemoryStream();
            var writer = new StreamWriter(memory, Encoding.UTF8);
            JsonSerializer serializer = new JsonSerializer();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Serialize(writer, applications);
            writer.Flush();
            memory.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(memory, "application/json");
        }

        [Authorize]
        [HttpGet("login")]
        public StatusCodeResult Login()
        {
            return new StatusCodeResult((int)HttpStatusCode.Accepted);
        }
    }
}
