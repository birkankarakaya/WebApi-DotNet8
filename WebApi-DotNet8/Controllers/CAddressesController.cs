using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_DotNet8.Data;
using WebApi_DotNet8.Entities;

namespace WebApi_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CAddressesController : ControllerBase
    {
        private readonly Context _context;


        public CAddressesController(Context context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CAddresses>>> GetAllCAddresses()
        {
            return await _context.CAddresses.Where(a => a.IsDelete == false).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CAddresses>> GetCAddress(int id)
        {
            var cAddress = await _context.CAddresses.FindAsync(id);

            if (cAddress == null)
            {
                return NotFound();
            }

            return cAddress;
        }


        [HttpPost]
        public async Task<ActionResult<CAddresses>> AddCAddress(CAddresses cAddress)
        {
            cAddress.CreateDate = DateTime.Now;
            cAddress.AddressStatus = true;
            cAddress.IsDelete = false;

            _context.CAddresses.Add(cAddress);
            await _context.SaveChangesAsync();

            cAddress.CreateDate = default;

            return CreatedAtAction("GetCAddress", new { id = cAddress.id }, cAddress);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCAddress(int id, CAddresses cAddress)
        {
            if (id != cAddress.id)
            {
                return BadRequest();
            }

            _context.Entry(cAddress).State = EntityState.Modified;

            await _context.SaveChangesAsync();
           
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCAddress(int id)
        {
            var cAddress = await _context.CAddresses.FindAsync(id);

            if (cAddress == null)
            {
                return NotFound();
            }

            //_context.CAddresses.Remove(cAddress);
            cAddress.IsDelete = true;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}