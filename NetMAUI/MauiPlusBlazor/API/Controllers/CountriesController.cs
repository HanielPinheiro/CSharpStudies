﻿using API.Data;
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
            try
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate")) 
                    return BadRequest($"Already exists a {nameof(Country)} with his name");

                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("retrieve")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItens()
        {
            try
            {
                return Ok(await _context.Countries.Include(x => x.States!).ThenInclude(x => x.Cities).ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("retrieveById/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItem(int id)
        {
            try
            {
                Country? country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

                if (country == null) return NotFound();

                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
                if (country == null) return NotFound();

                _context.Remove(country);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

    }
}
