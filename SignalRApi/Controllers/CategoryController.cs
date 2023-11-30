using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categoryList = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(categoryList);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = true
            });
            return Ok("Kategori Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleteToCategory = _categoryService.TGetById(id);
            _categoryService.TDelete(deleteToCategory);
            return Ok("Kategori başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryID = updateCategoryDto.CategoryId,
                Status = updateCategoryDto.Status
            });
            return Ok("Kategori başarıyla güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _mapper.Map<ResultCategoryDto>(_categoryService.TGetById(id));
            return Ok(category);
        }


    }
}
