using GreenCloud.Store.Application.Dtos;
using GreenCloud.Store.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenCloud.Store.API.Controllers
{
    [Route("api/[controller]")] // api/Products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsApplication productsApplication;

        public ProductsController(IProductsApplication productsApplication)
        {
            this.productsApplication = productsApplication;
        }

        [HttpGet] // GET http://falabella/api/Products
        public async Task<ActionResult<List<ProductForListDto>>> GetAll()
        {
            var products = await productsApplication.GetProducts();
            return products;
        }

        [HttpGet("{id:int}")] // GET http://falabella/api/Products/16
        public async Task<ActionResult<ProductDetailDto>> GetById(int id)
        {
            var product = await productsApplication.GetProduct(id);
            return product;
        }

        [HttpPost] // POST http://falabella/api/Products
        public async Task<ActionResult> Insert([FromBody] ProductForCreateDto productForCreateDto)
        {
            await productsApplication.InsertProduct(productForCreateDto);
            return Ok();
        }

        [HttpPut("{id:int}")] // PUT http://falabella/api/Products/16
        public async Task<ActionResult> Update(int id, [FromBody] ProductForEditDto productForEditDto)
        {
            await productsApplication.UpdateProduct(id, productForEditDto);
            return Ok();
        }

        [HttpDelete("{id:int}")] // DELETE http://falabella/api/Products/16
        public async Task<ActionResult> Delete(int id)
        {
            await productsApplication.DeleteProduct(id);
            return Ok();
        }
    }
}
