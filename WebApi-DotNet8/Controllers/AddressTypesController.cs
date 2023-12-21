using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi_DotNet8.Data;
using WebApi_DotNet8.Entities;

namespace WebApi_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypesController : ControllerBase
    {
        private readonly Context _context;

        public AddressTypesController(Context context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAddressTypes()
        {
            var types = await _context.AddressTypes.Where(a => a.IsDelete == false).ToListAsync();
            return Ok(types);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AddressTypes>> GetAddressType(int id)
        {
            var addressType = await _context.AddressTypes.FindAsync(id);

            if (addressType == null)
            {
                return NotFound();
            }

            return addressType;
        }


        [HttpPost]
        public async Task<ActionResult<AddressTypes>> AddAddressType([FromBody] string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return BadRequest("TypeName cannot be null or empty.");
            }

            AddressTypes addressType = new AddressTypes
            {
                TypeName = typeName,
                CreateDate = DateTime.Now,
                TypeStatus = true,
                IsDelete = false
            };

            _context.AddressTypes.Add(addressType);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressType(int id, AddressTypes addressType)
        {
            if (id != addressType.ID)
            {
                return BadRequest();
            }

            _context.Entry(addressType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressType(int id)
        {
            var addressType = await _context.AddressTypes.FindAsync(id);
            if (addressType == null)
            {
                return NotFound();
            }

            //_context.AddressTypes.Remove(addressType);
            addressType.IsDelete = true;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}