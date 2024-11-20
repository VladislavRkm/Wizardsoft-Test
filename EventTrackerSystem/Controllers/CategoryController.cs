using EventTrackerCore.Abstractions;
using EventTrackerCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllCategories()
    {
        var categories = await _service.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        var category = await _service.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }


    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(Category category)
    {
        if (category == null)
        {
            return BadRequest("Category cannot be null.");
        }

        var newCategory = new Category
        {
            Name = category.Name,
            ParentId = category.ParentId,
        };

        await _service.AddCategoryAsync(newCategory);
        return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        await _service.UpdateCategoryAsync(category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _service.DeleteCategoryAsync(id);
        return NoContent();
    }

}
