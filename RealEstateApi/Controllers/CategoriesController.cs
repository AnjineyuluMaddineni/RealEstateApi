using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Data;
using RealEstateApi.Models;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Categories);
        }
        //Get api/CategoriesController/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound("No record found against this id " + id);
            }
            return Ok(category);
        }
        //Get api/CategoriesController/GetSortCategories
        [HttpGet("[action]")]
        public IActionResult SortCategories()
        {
            return Ok(_dbContext.Categories.OrderByDescending(x => x.Name));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category categoryobj)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No record found against this id " + id);
            }
            else
            {
                category.Name = categoryobj.Name;
                category.ImageUrl = categoryobj.ImageUrl;
                _dbContext.SaveChanges();
                return Ok("Record updated successfully");
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No record found against this id " + id);
            }
            else
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return Ok("Record deleted");
            }


        }
    }
}
