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

        /// <summary>
        /// Get a list of Question objects from the defined template.
        /// </summary>
        /// <param name="templateId">The internal ID of the template.</param>
        /// <returns>An array of Questions</returns>
        [HttpGet("{templateId:int}", Name = "GetQuestions")]
        public Question[] GetQuestions(int templateId)
        {
            return _context.FormDetails
                .Where(f => f.TemplateId == templateId && f.IsTemplate)
                .FirstOrDefault()
                .Questions;
        }

        /// <summary>
        /// Gets all answers, aggregated, to a question from all completed forms of a specified template.
        /// </summary>
        /// <param name="templateId">The template on which the parent form is based.</param>
        /// <param name="questionText">The text of the question to query.</param>
        /// <returns>A dictionary of answer text and their responses as percentage of total.</returns>
        [HttpGet(Name = "GetAggregatedAnswers")]
        public Dictionary<string, double> GetAggregatedAnswers([FromRoute]int templateId, [FromRoute]string questionText)
        {
            int totalResponses = 0;
            Dictionary<string, int> answerCounts = new Dictionary<string, int>();
            foreach (FormDetails forms in _context.FormDetails.Where(f => f.TemplateId == templateId && !f.IsTemplate))
            {
                Question q = forms.Questions.FirstOrDefault(qu => qu.Text == questionText);
                foreach (Answer a in q.Answers)
                {
                    totalResponses++;

                    if (!a.Selected)
                        continue;

                    if (answerCounts.ContainsKey(a.Text))
                        answerCounts[a.Text]++;
                    else
                        answerCounts.Add(a.Text, 1);
                }
            }

            Dictionary<string, double> final = new Dictionary<string, double>();
            foreach (var kvp in answerCounts)
            {
                final.Add(kvp.Key, kvp.Value / totalResponses);
            }
            return final;
        }
    }
}
