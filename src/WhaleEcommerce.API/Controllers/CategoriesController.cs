using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WhaleEcommerce.API.Dtos;
using WhaleEcommerce.API.Extensions;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository,
                                    IMapper mapper,
                                    ICategoryService categoryService,
                                    INotifyer notifyer) : base(notifyer)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {
            var category = _mapper.Map<CategoryDto>(await _categoryRepository.GetById(id));

            if (category == null) return NotFound();

            return category;
        }

        [ClaimsAuthorize("Category", "Add")]
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Add(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoryService.Add(_mapper.Map<Category>(categoryDto));

            return CustomResponse(categoryDto);
        }

        [ClaimsAuthorize("Category", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> Update(Guid id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                NotifyError("The informed id is not the same id on the query");
                return CustomResponse(categoryDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return CustomResponse(categoryDto);
        }

        [ClaimsAuthorize("Category", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> Remove(Guid id)
        {
            await _categoryService.Remove(id);

            return CustomResponse();
        }
    }
}