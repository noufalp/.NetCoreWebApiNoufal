using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        //using generic repository design pattern
        private IRepository<Product> repository = null;
        public ProductController(IRepository<Product> _repository)
        {
            this.repository = _repository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<Product>> Get()
        {
            return await repository.GetAllAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Product> Get(int id)
        {
            return await repository.GetAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] Product value)
        {
            try
            {
                await repository.InsertAsync(value);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put([FromBody] Product value)
        {
            try
            {
                await repository.UpdateAsync(value);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = repository.GetAsync(id);
                if (product != null)
                {
                    await repository.DeleteAsync(id);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
