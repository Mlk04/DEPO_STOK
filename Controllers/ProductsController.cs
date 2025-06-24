using Microsoft.EntityFrameworkCore;
using DEPO_STOK.Data;
using DEPO_STOK.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DEPO_STOK.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly DepoDbContext _context;
        public ProductsController(DepoDbContext context) { _context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);

        }

        [HttpPost]
        public IActionResult AddMultiple([FromBody] List<Products> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
            return Ok(products);
        }

        [HttpPut("{id}/STOCKIN")]
        public IActionResult StockIn(int id, [FromQuery] int quantity)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.Stock += quantity;
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpPut("{id}/STOCKOUT")]
        public IActionResult StockOut(int id, [FromQuery] int quantity)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            if (product.Stock < quantity) return BadRequest("yetersiz stok!");


            product.Stock -= quantity;
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if(product ==null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
