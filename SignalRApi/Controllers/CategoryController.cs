﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntitiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_CategoryService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //Yöntem 2 AutoMapper
            _CategoryService.TAdd(_mapper.Map<Category>(createCategoryDto));
            return Ok("Kategori Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _CategoryService.TGetByID(id);
            _CategoryService.TDelete(value);
            return Ok("Kategori Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _CategoryService.TUpdate(_mapper.Map<Category>(updateCategoryDto));
            return Ok("Kategori Alanı Güncellendi");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _CategoryService.TGetByID(id);
            return Ok(value);
        }
    }
}
