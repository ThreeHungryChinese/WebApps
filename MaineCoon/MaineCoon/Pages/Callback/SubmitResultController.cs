using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Data;
using MaineCoon.Models;

namespace MaineCoon.Pages.Callback
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitResultController : ControllerBase
    {
        private readonly MaineCoonContext _context;

        public SubmitResultController(MaineCoonContext context)
        {
            _context = context;
        }

        // GET: api/SubmitResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestRecord>>> GetQuestRecord()
        {
            return await _context.QuestRecord.ToListAsync();
        }

        // GET: api/SubmitResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestRecord>> GetQuestRecord(int id)
        {
            var questRecord = await _context.QuestRecord.FindAsync(id);

            if (questRecord == null)
            {
                return NotFound();
            }

            return questRecord;
        }

        // PUT: api/SubmitResult/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestRecord(int id, QuestRecord questRecord)
        {
            if (id != questRecord.id)
            {
                return BadRequest();
            }

            _context.Entry(questRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestRecordExists(id))
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

        // POST: api/SubmitResult
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<QuestRecord>> PostQuestRecord(QuestRecord questRecord)
        {
            _context.QuestRecord.Add(questRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestRecord", new { id = questRecord.id }, questRecord);
        }

        // DELETE: api/SubmitResult/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestRecord>> DeleteQuestRecord(int id)
        {
            var questRecord = await _context.QuestRecord.FindAsync(id);
            if (questRecord == null)
            {
                return NotFound();
            }

            _context.QuestRecord.Remove(questRecord);
            await _context.SaveChangesAsync();

            return questRecord;
        }

        private bool QuestRecordExists(int id)
        {
            return _context.QuestRecord.Any(e => e.id == id);
        }
    }
}
