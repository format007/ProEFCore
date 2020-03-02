using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ch20.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        [EnableQuery()]
        public IQueryable<Product> GetAll()
        {
            return dbContext.Products;
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

        [HttpGet("joinquery")]
        public async Task<IActionResult> JoinQuery()
        {
            var result = from prod in dbContext.Products
                         join category in dbContext.Categories on prod.CategoryId equals category.Id
                         select new { prod.Id, prod.Name, CategoryId = category.Id, CategoryName = category.Name};
            return Ok(await result.ToListAsync());
        }

        [HttpGet("innerjoin")]
        public async Task<IActionResult> InnerJoinQuery()
        {
            var result = from prod in dbContext.Products
                         from category in dbContext.Categories.Where(c=>c.Id == prod.CategoryId)
                         select new { prod.Id, prod.Name, CategoryId = category.Id, CategoryName = category.Name };
            return Ok(await result.ToListAsync());
        }

        [HttpGet("groupjoin")]
        public async Task<IActionResult> GroupJoinQuery()
        {
            var result = from cat in await dbContext.Categories.ToListAsync()
                      join prod in await dbContext.Products.ToListAsync()
                        on cat.Id equals prod.CategoryId into prodGroup
                      select new { cat, prodGroup };

            //foreach(var obj in result)
            //{
            //    obj.ToString();
            //}

            return Ok(result);
        }

        [HttpGet("crossjoin")]
        public async Task<IActionResult> CrossJoin()
        {
            var result = from cat in dbContext.Categories
                         from prod in dbContext.Products
                         select new { cat, prod };

            return Ok(await result.ToListAsync());
        }

        [HttpGet("leftjoin")]
        public async Task<IActionResult> LeftJoin()
        {
            var result = from cat in dbContext.Categories
                         from prod in dbContext.Products.Where(p=> p.CategoryId == cat.Id).DefaultIfEmpty()
                         select new { cat, prod };

            return Ok(await result.ToListAsync());
        }

        [HttpGet("groupby1")]
        public async Task<IActionResult> GroupBy1()
        {
            var result = //from cat in dbContext.Categories
                         from prod in dbContext.Products.Where(p => p.CategoryId > 0)
                         group prod by prod.CategoryId into g
                         where g.Count() > 1
                         orderby g.Key
                         select new { g.Key, Count = g.Count() };

            return Ok(await result.ToListAsync());
        }

        private bool FilterPrice(double price)
        {
            return price < 10;
        }
    }
}