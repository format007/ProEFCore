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
    public class ProdController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public ProdController(ProductDbContext dbContext) => this.dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbContext.Prods.Include(p => p.Supplier).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Prod product)
        {
            dbContext.Prods.Add(product);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), routeValues: new { product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            dbContext.Prods.Remove(new Prod() { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("sup/{id}")]
        public async Task<IActionResult> DeleteSupplier(long id)
        {
            var sup = await dbContext.FindAsync<Sup>(id);
            dbContext.Remove<Sup>(sup);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}