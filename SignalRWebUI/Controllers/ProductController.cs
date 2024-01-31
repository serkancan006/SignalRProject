using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7057/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7057/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString()
                                                }).ToList();
                ViewBag.v = values2;
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7057/api/Product", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7057/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Get product details
            var responseMessage = await client.GetAsync($"https://localhost:7057/api/Product/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            // Get category details
            var responseMessage2 = await client.GetAsync("https://localhost:7057/api/Category");
            if (!responseMessage2.IsSuccessStatusCode)
            {
                return View();
            }

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            List<SelectListItem> result = values2.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            ViewBag.v = result;
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7057/api/Product", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
