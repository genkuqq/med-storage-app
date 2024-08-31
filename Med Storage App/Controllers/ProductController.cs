using Med_Storage_App.Data;
using Med_Storage_App.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Med_Storage_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Database _db;
        public ProductController(Database db) {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _db.Products.ToListAsync();
            if (products == null || products.Count == 0) return NotFound("Products Not Found");
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> FindProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound("Product Not Found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (product == null) return BadRequest("Product cannot be null");
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product newProduct, int id)
        {
            if (id != newProduct.Id) return BadRequest("Product ID mismatch");
            var oldProduct = await _db.Products.FindAsync(newProduct.Id);
            if (oldProduct == null) return NotFound("Product Not Found");
            oldProduct.Name = newProduct.Name;
            oldProduct.No = newProduct.No;
            oldProduct.SerialNo = newProduct.SerialNo;
            oldProduct.LotNo = newProduct.LotNo;
            oldProduct.Quantity = newProduct.Quantity;
            oldProduct.ProductionDate = newProduct.ProductionDate;
            oldProduct.ExpiratioDate = newProduct.ExpiratioDate;
            await _db.SaveChangesAsync();
            return Ok(oldProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound("Product Not Found");
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
