using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DomainModels;
using ProductsAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [EnableCors("angularApplication")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetProductsAsync();

            return Ok(mapper.Map<List<Product>>(products));
        }

        [HttpGet]
        [Route("[controller]/{productId:guid}"), ActionName("GetProductAsync")]
        public async Task<IActionResult> GetProductAsync([FromRoute] Guid productId)
        {
            var product = await productRepository.GetProductAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Product>(product));
        }

        [HttpPut]
        [Route("[controller]/{productId:guid}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid productId, [FromBody] UpdateProductRequest request)
        {
            if (await productRepository.Exists(productId))
            {
                var updatedProduct = await productRepository.UpdateProduct(productId, mapper.Map<Models.Product>(request));
                if (updatedProduct != null)
                {
                    return Ok(mapper.Map<Product>(updatedProduct));
                }
            }
                return NotFound();
            
        }

        [HttpDelete]
        [Route("[controller]/{productId:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            if (await productRepository.Exists(productId))
            {
                var product = await productRepository.DeleteProduct(productId);
                return Ok(mapper.Map<Product>(product));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddProductAsync([FromBody] AddProductRequest request)
        {
            var product = await productRepository.AddProduct(mapper.Map<Models.Product>(request));
            return CreatedAtAction(nameof(GetProductAsync), new { productId = product.Id },
                mapper.Map<Product>(product));
        }
    }
}
