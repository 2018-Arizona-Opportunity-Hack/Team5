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

        [HttpGet("{id}")]
        public Question[] GetQuestions(int templateId)
        {
            return _context.FormDetails
                .Where(f => f.TemplateId == templateId && f.IsTemplate)
                .FirstOrDefault()
                .Questions;
        }

        [HttpGet("{id}")]
        public Dictionary<string, int> GetAggregatedAnswers(int templateId, int questionId)
        {
            Dictionary<string, int> answerCounts = new Dictionary<string, int>();
            foreach (FormDetails forms in _context.FormDetails.Where(f => f.TemplateId == templateId && !f.IsTemplate))
            {
                foreach(Question q in forms.Questions.Where(q => q.QuestionId == questionId))
                {
                    foreach(Answer a in q.Answers)
                    {
                        if (answerCounts.ContainsKey(a.Text))
                            answerCounts[a.Text]++;
                        else
                            answerCounts.Add(a.Text, 1);
                    }
                }
            }

            return answerCounts;
        }
    }
}
