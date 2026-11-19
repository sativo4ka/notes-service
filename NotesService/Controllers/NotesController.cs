using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesService.Data;
using NotesService.Models;

namespace NotesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _context;

        public NotesController(NotesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAll()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetById(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> Create(Note note)
        {
            note.Id = 0;
            note.CreatedAt = DateTime.UtcNow;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Note updatedNote)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;

            await _context.SaveChangesAsync();

            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

