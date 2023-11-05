using API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.Entities;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        #region CRUD

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> InsertItem(Categorie categorie)
        {
            try
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return Ok(categorie);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                    return BadRequest($"Already exists a {nameof(Categorie)} with his name");

                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("retrieve")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItens()
        {
            try
            {
                return Ok(await _context.Categories.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("retrieve/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItem(int id)
        {
            try
            {
                Categorie? country = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

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
        public async Task<ActionResult> PutAsync(Categorie categorie)
        {
            try
            {
                _context.Update(categorie);
                await _context.SaveChangesAsync();
                return Ok(categorie);
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
                var categorie = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (categorie == null) return NotFound();

                _context.Remove(categorie);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        #endregion
    }
}
