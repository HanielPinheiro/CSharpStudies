using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> InsertItem(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [Route("retrieve")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItens()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [Route("retrieveById/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItem(int id)
        {
            Country? country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (country == null) return NotFound();

            return Ok(country);
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null) return NotFound();

            _context.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
