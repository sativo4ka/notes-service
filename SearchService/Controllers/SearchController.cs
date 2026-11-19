using Microsoft.AspNetCore.Mvc;
using SearchService.Models;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SearchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Введите поисковый запрос.");

            var client = _httpClientFactory.CreateClient("NotesService");

            var response = await client.GetAsync("/api/Notes");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode,
                    "Ошибка при получении заметок.");

            var notes = await response.Content.ReadFromJsonAsync<List<Note>>();

            if (notes == null)
                return Ok(new List<Note>());

            var result = notes.Where(note =>
                note.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                note.Content.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return Ok(result);
        }
    }
}
