using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhaleEcommerce.API.Dtos;
using WhaleEcommerce.API.Extensions;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository,
                                  IProductService productService,
                                  IMapper mapper)
        {
            _productRepository = productRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var productDto = await GetById(id);

            if (productDto == null) return NotFound();

            return productDto;
        }

        [ClaimsAuthorize("Product", "Add")]
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add(ProductDto productDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Add(_mapper.Map<Product>(productDto));

            return CustomResponse(productDto);
        }

        [ClaimsAuthorize("Product", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductDto productDto)
        {
            if (id != productDto.Id) return CustomResponse("The informed id's is not the same");

            var updatedProduct = await GetProduct(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            updatedProduct.Name = productDto.Name;
            updatedProduct.Description = productDto.Description;
            updatedProduct.Value = productDto.Value;
            updatedProduct.Active = productDto.Active;

            await _productService.Update(_mapper.Map<Product>(updatedProduct));

            return CustomResponse(productDto);
        }

        [ClaimsAuthorize("Product", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductDto>> Remove(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            await _productService.Remove(id);

            return CustomResponse(product);
        }

        private async Task<ProductDto> GetProduct(Guid id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetProductCategory(id));
        }
    }
}