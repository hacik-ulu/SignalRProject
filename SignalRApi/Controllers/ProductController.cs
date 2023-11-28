using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(productList);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = true

            });
            return Ok("Ürün başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var deleteToProduct = _productService.TGetById(id);
            _productService.TDelete(deleteToProduct);
            return Ok("Ürün başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TAdd(new Product
            {
                ProductID = updateProductDto.ProductID,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus

            });
            return Ok("Ürün Bilgisi başarıyla güncellendi!");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.TGetById(id);
            return Ok(product);
        }
    }
}
