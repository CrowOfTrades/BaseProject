using BaseProject.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne(string name, decimal price, int quantity)
        {
            return Ok(await _productService.CreateOne(name, price, quantity));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOne(Guid id, string name, decimal price)
        {
            return Ok(await _productService.UpdateOne(id, name, price));
        }

        [HttpPatch]
        public async Task<IActionResult> EditQuantity(Guid id, int quantity)
        {
            return Ok(await _productService.UpdateQuantity(id, quantity));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            return Ok(await _productService.DeleteOne(id));
        }
    }
}
