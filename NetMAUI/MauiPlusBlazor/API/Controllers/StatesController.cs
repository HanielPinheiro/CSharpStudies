using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Route("retrieve")]
        [HttpPost]
        public async Task<IActionResult> RetrieveItens()
        {
            try
            {
                return Ok(await _context.States.Include(x => x.Cities!).ToListAsync());
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
