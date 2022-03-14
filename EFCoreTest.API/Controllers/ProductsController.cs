using EFCoreTest.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly NorthwindDBContext _context;

        public ProductsController(NorthwindDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromQuery] int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}
