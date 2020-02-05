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
    public class DeleteController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public DeleteController(ProductDbContext dbContext) => this.dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await dbContext.Products.Where(p => p.SoftDeleted).IgnoreQueryFilters().ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UnDelete(int id)
        {
            var product =await dbContext.Products.IgnoreQueryFilters().FirstAsync(p => p.Id == id);
            product.SoftDeleted = false;
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}