using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormProcessorApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormProcessorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly FormDetailsContext _context;

        public ReportController(FormDetailsContext context)
        {
            _context = context;
        }

        // GET: api/Report/5
        [HttpGet("{id}", Name = "Get")]
        public string GetQuestionsAggregatedByTemplateId(int id)
        {
            Dictionary<string, int> answerCounts = new Dictionary<string, int>();
            foreach (FormDetails forms in _context.FormDetails.Where(f => f.TemplateId == id))
            {
                foreach(Question q in forms.Questions)
                {
                    foreach(Answer a in q.Answers)
                    {
                        if (answerCounts.ContainsKey())
                    }
                }
            }
        }

        // POST: api/Report
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Report/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
