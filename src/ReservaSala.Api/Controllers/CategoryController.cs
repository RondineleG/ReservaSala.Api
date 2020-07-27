using Microsoft.AspNetCore.Mvc;
using ReservaSala.Api.Domain.Models;
using ReservaSala.Api.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaSala.Api.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Category>>GetAllAsync()
        {
            var catergories = await _categoryService.ListAsync();
            return catergories;
        }
         
    }
}
