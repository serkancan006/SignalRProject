using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_ProductService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList().Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductName = y.ProductName,
                ProductID = y.ProductID,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            //Yöntem 2 AutoMapper
            _ProductService.TAdd(_mapper.Map<Product>(createProductDto));
            return Ok("Product Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetByID(id);
            _ProductService.TDelete(value);
            return Ok("Product Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _ProductService.TUpdate(_mapper.Map<Product>(updateProductDto));
            return Ok("Product Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetByID(id);
            return Ok(value);
        }
    }
}
