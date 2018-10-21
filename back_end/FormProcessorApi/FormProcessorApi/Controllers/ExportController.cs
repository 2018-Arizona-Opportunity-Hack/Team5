using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using FormProcessorApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormProcessorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly FormDetailsContext _context;

        public ExportController(FormDetailsContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "ExportToCsv")]
        public string ExportToCsv()
        {
            using (var stream = new System.IO.StreamWriter("temp.csv"))
            {
                var csv = new CsvWriter(stream);
                csv.WriteRecords(_context.FormDetails.Select(f => f).ToList());
            }

            return System.IO.File.ReadAllText("temp.csv");
        }
    }
}