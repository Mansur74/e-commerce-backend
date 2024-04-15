using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            Result result = _categoryService.Create(categoryDto);
            return StatusCode(201, result);

        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            DataResult<ICollection<CategoryDto>> result = _categoryService.GetAll();
            return StatusCode(200, result);

        }
    }
}
