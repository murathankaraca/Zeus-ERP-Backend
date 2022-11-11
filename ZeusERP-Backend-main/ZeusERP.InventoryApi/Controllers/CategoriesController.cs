using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ZeusERP.Business.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.InventoryApi.Controllers
{
    [EnableCors("TCAPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public CategoriesController(
            ICategoryService categoryService,
            IProductService productService
            )
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult Categories()
        {
            var result = _categoryService.GetList();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> CategoriesAsync()
        {
            var result = await _categoryService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> CategoryById(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> CategoryDetailsDtoById(int id)
        {
            var result = await _categoryService.GetCategoryDetailsByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetListAsync")]
        public async Task<IActionResult> CategoryListDtoAsync()
        {
            var result = await _categoryService.GetCategoryListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Category category)
        {
            var result = await _categoryService.AddAsync(category);

            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Category category)
        {
            var result = await _categoryService.UpdateAsync(category);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var prodToDelete = _categoryService.GetById(id);
            var result = _categoryService.Delete(prodToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var catToDelete = await _categoryService.GetByIdAsync(id);

            var result = await _categoryService.DeleteAsync(catToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

    }
}
