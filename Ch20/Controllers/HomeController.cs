using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch20.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ch20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        private static Func<ProductDbContext, string, IEnumerable<Product>> search =
            EF.CompileQuery((ProductDbContext context, string searchStr) =>
                context.Products.Where(prod => EF.Functions.Like(prod.Name, searchStr))
            .Include(p => p.Supplier)
            );

        public HomeController(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll([FromQuery]string searchStr)
        {
            var Prods = string.IsNullOrEmpty(searchStr) 
                ? dbContext.Products.Include(p=>p.Supplier) 
                : search(dbContext, searchStr);

            return await Task.FromResult(
                Ok(Prods));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            var existing = await dbContext.Products.FindAsync(product.Id);
            if (existing == null)
            {
                dbContext.Products.Add(product);
                //dbContext.Entry(product).Property("Created").CurrentValue = DateTime.Now;
            }
            else
            {
                dbContext.Entry(existing).State = EntityState.Detached;
                dbContext.Products.Update(product);
            }
            await dbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
        {
            dbContext.Attach(product);
            product.SoftDeleted = true;
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("servereval")]
        public async Task<IActionResult> ServerAvaluated()
        {
            return Ok(await dbContext.Products.Where(p => p.Price < 10).ToListAsync());
        }

        [HttpGet("clienteval")]
        public async Task<IActionResult> ClientAvaluated()
        {
            return Ok(await dbContext.Products.Where(p => FilterPrice(p.Price)).ToListAsync());
        }

        private bool FilterPrice(double price)
        {
            return price < 10;
        }
    }
}