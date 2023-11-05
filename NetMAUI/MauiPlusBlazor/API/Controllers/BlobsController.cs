using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/blobs")]
    public class BlobsController : ControllerBase
    {
        private readonly DataContext _context;

        public BlobsController(DataContext context)
        {
            _context = context;
        }

        #region CRUD

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> SaveBlob(Blob blob)
        {
            try
            {
                _context.Add(blob);
                await _context.SaveChangesAsync();
                return Ok(blob);
            }
            catch (Exception ex)
            {
                if (ex.InnerException!.Message.Contains("duplicate"))
                    return BadRequest($"Already exists a {nameof(Blob)} with his name");

                return BadRequest($"{ex.Message} - {ex.InnerException!.Message}");
            }
        }

        [Route("retrieve/{name}")]
        [HttpPost]
        public async Task<IActionResult> GetBlobByName(string name)
        {
            try
            {
                return Ok(await _context.Blobs.Where(x => x.Name == name).FirstOrDefaultAsync());
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

        [Route("delete/{name}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(string name)
        {
            try
            {
                var blob = await _context.Blobs.FirstOrDefaultAsync(x => x.Name == name);
                if (blob == null) return NotFound();

                _context.Remove(blob);
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
