using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Module;
using Project1.DataAccess;
using Project1.Helpers;
using System.Linq;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly string _secretKey = "this_is_a_very_long_secret_key_1234567890"; 

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("Products")]
        [Authorize(Roles = "admin,user")]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpGet("Product/{id}")]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("Products")]
        public IActionResult Save([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpPut("Products")]
        public IActionResult Update([FromBody] Product product)
        {
            var result = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);

            if (result == null)
            {
                return NotFound();
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("Products")]
        public IActionResult Delete([FromBody] Product product)
        {
            var deleteProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);
            if (deleteProduct == null)
            {
                return NotFound();
            }
            _context.Products.Entry(deleteProduct).State = EntityState.Deleted;

            _context.SaveChanges();
            return Ok();
        }
    



    [HttpPost("LoginAdmin")]
public IActionResult LoginAdmin()
{
    var token = JwtHelper.GenerateJwtToken("admin", "admin", _secretKey, "yourissuer", "youraudience");
    return Ok(new { token });
}

[HttpPost("LoginUser")]
public IActionResult LoginUser()
{
    var token = JwtHelper.GenerateJwtToken("user", "user", _secretKey, "yourissuer", "youraudience");
    return Ok(new { token });
}

    }

    public class UserRoleChangeRequest
    {
        public string Username { get; set; }
        public string NewRole { get; set; }
    }
}
