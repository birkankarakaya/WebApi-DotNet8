using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_DotNet8.Data;
using WebApi_DotNet8.Entities;

namespace WebApi_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;


        public CustomersController(Context context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var types = await _context.Customers.Where(a => a.IsDelete == false).ToListAsync();
            return Ok(types);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            var customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }


        [HttpPost]
        public async Task<ActionResult<Customers>> AddCustomer(string cName, string cSurname, string cMail, string cPhone, DateTime cBirthDate)
        {
            Customers customers = new Customers
            {
                CreateDate = DateTime.Now,
                CustomerName = cName,
                CustomerSurname = cSurname,
                CustomerMail = cMail,
                CustomerPhone = cPhone,
                CustomerBirthDate = cBirthDate,
                CustomerStatus = true,
                IsDelete = false
            };

            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customers customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            //_context.Customers.Remove(customer);
            customer.IsDelete = true;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
