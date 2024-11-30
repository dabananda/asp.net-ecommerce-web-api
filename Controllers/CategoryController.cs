using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Ecommerce_Web_API.DTOs;
using ASP.NET_Ecommerce_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Ecommerce_Web_API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();

        // GET: /api/categories => Read categories 
        [HttpGet]
        public IActionResult GetCategories(string? searchValue = "")
        {
            // if (!string.IsNullOrEmpty(searchValue))
            // {
            //     var searchedCategories = categories.Where(c => !string.IsNullOrEmpty(c.CategoryName) && c.CategoryName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
            //     return Ok(searchedCategories);
            // }

            var categoryList = categories.Select(c => new CategoryReadDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription,
                CategoryCreatedAt = c.CategoryCreatedAt
            }).ToList();

            return Ok(APIResponse<List<CategoryReadDto>>.SuccessfullResponse(categoryList, 200, "Category returned successfully"));
        }

        // POST: /api/categories => Create category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCreateDto categoryData)
        {
            // validation: category name can't be null
            // if (string.IsNullOrEmpty(categoryData.CategoryName))
            // {
            //     return BadRequest("Category name is required!");
            // }
            if (!ModelState.IsValid)
            {

            }

            // Creating categroy using category model
            var newCategory = new Category
            {
                CategoryID = Guid.NewGuid(),
                CategoryName = categoryData.CategoryName,
                CategoryDescription = categoryData.CategoryDescription,
                CategoryCreatedAt = DateTime.UtcNow,
            };
            categories.Add(newCategory);

            // Returning using CreateReadDto
            var categoryReadDto = new CategoryReadDto
            {
                CategoryID = newCategory.CategoryID,
                CategoryName = newCategory.CategoryName,
                CategoryDescription = newCategory.CategoryDescription,
                CategoryCreatedAt = newCategory.CategoryCreatedAt
            };

            return Created($"/api/categories/{categoryReadDto.CategoryID}", APIResponse<CategoryReadDto>.SuccessfullResponse(categoryReadDto, 201, "Category created successfully"));
        }

        // PUT: /api/categories/{categoryId} => Update category
        [HttpPut("{categoryId:Guid}")]
        public IActionResult UpdateCategory(Guid categoryId, [FromBody] CategoryUpdateDto categoryData)
        {
            if (categoryData == null)
            {
                return BadRequest("Category data is missing!");
            }

            var category = categories.FirstOrDefault(category => category.CategoryID == categoryId);
            if (category == null)
            {
                return NotFound("Category not found!");
            }

            // updating category name if not empty
            if (!string.IsNullOrEmpty(categoryData.CategoryName))
            {
                category.CategoryName = categoryData.CategoryName;
            }
            else
            {
                return BadRequest("Category name is required!");
            }

            // updating category description if not empty
            if (!string.IsNullOrWhiteSpace(categoryData.CategoryName))
            {
                category.CategoryDescription = categoryData.CategoryDescription;
            }

            return Ok(APIResponse<object>.SuccessfullResponse(null, 204, "Category updated successfully"));
        }

        // DELETE: /api/categories/{categoryId} => Delet a category
        [HttpDelete("{categoryId:Guid}")]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var delCategory = categories.FirstOrDefault(category => category.CategoryID == categoryId);
            if (delCategory == null)
            {
                return NotFound("Category not found!");
            }
            categories.Remove(delCategory);
            return Ok(APIResponse<object>.SuccessfullResponse(null, 204, "Category deleted successfully"));
        }
    }
}