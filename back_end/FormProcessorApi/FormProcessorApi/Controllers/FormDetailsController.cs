using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormProcessorApi.Models;

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
        public IEnumerable<FormDetails> GetFormDetails()
        {
            return _context.FormDetails;
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

        // PUT: api/FormDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormDetails([FromRoute] int id, [FromBody] FormDetails formDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formDetails.FormDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(formDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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

            return CreatedAtAction("GetFormDetails", new { id = formDetails.FormDetailsId }, formDetails);
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