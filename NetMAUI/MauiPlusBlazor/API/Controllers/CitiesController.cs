using API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.DTO;
using Share.Entities;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {
            _context = context;
        }

        #region CRUD

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> InsertItem(City city)
        {
            try
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return Ok(city);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate")) 
                    return BadRequest($"Already exists a {nameof(City)} with his name");

                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }     

        [Route("retrieve/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItem(int id)
        {
            try
            {
                City? state = await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);

                if (state == null) return NotFound();

                return Ok(state);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }


        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> PutAsync(City city)
        {
            try
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
                return Ok(city);
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
                City? city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);
                if (city == null) return NotFound();

                _context.Remove(city);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        #endregion

        #region Others

        [Route("retrieveAll/{StateId:int}")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItens([FromQuery] PaginationDTO pagination, int StateId)
        {
            try
            {
                var queryable = _context.Cities.Where(x => x.StateId == StateId).AsQueryable();

                if (!string.IsNullOrWhiteSpace(pagination.Filter))
                    queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));

                return Ok(await queryable.Paginate(pagination).ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("totalPages/{StateId:int}")]
        [HttpPost]
        public async Task<IActionResult> GetTotalPages([FromQuery] PaginationDTO pagination, int StateId)
        {
            try
            {
                var query = _context.Cities.Where(x => x.StateId == StateId).AsQueryable();

                if (!string.IsNullOrWhiteSpace(pagination.Filter))
                    query = query.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));

                double count = await query.CountAsync();
                double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
                return Ok(totalPages);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }
        [AllowAnonymous]
        [HttpPost("combo/{stateId:int}")]
        public async Task<ActionResult> GetCombo(int stateId)
        {
            return Ok(await _context.Cities.Where(x => x.StateId == stateId).ToListAsync());
        }

        #endregion
    }
}
