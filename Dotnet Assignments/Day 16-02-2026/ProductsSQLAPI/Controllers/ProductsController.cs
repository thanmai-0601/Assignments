using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsSQLAPI.Models;

namespace ProductsSQLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CProducts>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CProducts>> GetCProducts(int id)
        {
            var cProducts = await _context.Products.FindAsync(id);

            if (cProducts == null)
            {
                return NotFound();
            }

            return cProducts;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCProducts(int id, CProducts cProducts)
        {
            if (id != cProducts.Id)
            {
                return BadRequest();
            }

            _context.Entry(cProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CProducts>> PostCProducts(CProducts cProducts)
        {
            _context.Products.Add(cProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCProducts", new { id = cProducts.Id }, cProducts);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCProducts(int id)
        {
            var cProducts = await _context.Products.FindAsync(id);
            if (cProducts == null)
            {
                return NotFound();
            }

            _context.Products.Remove(cProducts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
