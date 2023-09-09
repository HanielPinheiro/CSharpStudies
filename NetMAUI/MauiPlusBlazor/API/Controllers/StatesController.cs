using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.DTOs;
using Share.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> InsertItem(State state)
        {
            try
            {
                _context.Add(state);
                await _context.SaveChangesAsync();
                return Ok(state);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate")) 
                    return BadRequest($"Already exists a {nameof(State)} with his name");

                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("retrieveAll/{CountryId:int}")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItens([FromQuery] PaginationDTO pagination, int CountryId)
        {
            try
            {
                var queryable = _context.States.Where(x => x.CountryId == CountryId).Include(x => x.Cities!).AsQueryable();

                if (!string.IsNullOrWhiteSpace(pagination.Filter))
                    queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));

                return Ok(await queryable.Paginate(pagination).ToListAsync());
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
                State? state = await _context.States.Include(x => x.Cities!).FirstOrDefaultAsync(x => x.Id == id);

                if (state == null) return NotFound();

                return Ok(state);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("totalPages/{CountryId:int}")]
        [HttpPost]
        public async Task<IActionResult> GetTotalPages([FromQuery] PaginationDTO pagination, int CountryId)
        {
            try
            {
                var query = _context.States.Where(x => x.CountryId == CountryId).AsQueryable();
                
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

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> PutAsync(State state)
        {
            try
            {
                _context.Update(state);
                await _context.SaveChangesAsync();
                return Ok(state);
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
                State? state = await _context.States.FirstOrDefaultAsync(x => x.Id == id);
                if (state == null) return NotFound();

                _context.Remove(state);
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
