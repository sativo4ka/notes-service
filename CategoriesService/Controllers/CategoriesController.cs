using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CategoriesService.Data;
using CategoriesService.Models;

namespace CategoriesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesDbContext _context;

        public CategoriesController(CategoriesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category updatedCategory)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
