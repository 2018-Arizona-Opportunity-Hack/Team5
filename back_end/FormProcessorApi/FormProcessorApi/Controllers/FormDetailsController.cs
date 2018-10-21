using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormProcessorApi.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FormProcessorApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormDetailsController : ControllerBase
    {
        private readonly FormDetailsContext _context;

        public FormDetailsController(FormDetailsContext context)
        {
            _context = context;
        }
        
        // GET: api/FormDetails
        [HttpGet]
        public IEnumerable<FormDetails> GetFormDetails([FromRoute] bool templatesOnly)
        {
            return templatesOnly ? _context.FormDetails.Where(f => f.IsTemplate) : _context.FormDetails;
        }

        // GET: api/FormDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formDetails = await _context.FormDetails.FindAsync(id);

            if (formDetails == null)
            {
                return NotFound();
            }

            return Ok(formDetails);
        }

        // POST: api/FormDetails
        [HttpPost]
        public async Task<IActionResult> PostFormDetails([FromBody] FormDetails formDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FormDetails.Add(formDetails);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFormDetails", new { id = formDetails.FormDetailsId }, formDetails);
            return Created("GetFormDetails", formDetails.FormDetailsId);
        }

        [HttpPut]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<IActionResult> PutFormImage([FromRoute] int id, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formDetails = await _context.FormDetails.FindAsync(id);

            // OCR - loop through all regions, crop to region, send for ocr
            using (var stream = new MemoryStream())
            {
                await formDetails.FormImage.CopyToAsync(stream);
                foreach (Question q in formDetails.Questions)
                {
                    //FUNCTION CALL - CROP & SUBMIT FOR OCR, RETURN BLACK PIXEL COUNT & TEXT
                    // SAVE RESULTS TO formDetails
                    foreach (Answer a in q.Answers)
                    {
                        //SAME
                        // SAVE RESULTS TO formDetails
                    }
                }
            }

            _context.FormDetails.Add(formDetails);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/FormDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formDetails = await _context.FormDetails.FindAsync(id);
            if (formDetails == null)
            {
                return NotFound();
            }

            _context.FormDetails.Remove(formDetails);
            await _context.SaveChangesAsync();

            return Ok(formDetails);
        }

        private bool FormDetailsExists(int id)
        {
            return _context.FormDetails.Any(e => e.FormDetailsId == id);
        }
    }
}