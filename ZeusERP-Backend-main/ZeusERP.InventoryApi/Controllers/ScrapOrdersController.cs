using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

using ZeusERP.Business.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.InventoryApi.Controllers
{
    [EnableCors("TCAPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapOrdersController : ControllerBase
    {
        private IOrderScrapService _scrapService;

        public ScrapOrdersController(IOrderScrapService scrapService, IProductService productService)
        {
            _scrapService = scrapService;
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetScrapOrderById(int id)
        {
            var result = _scrapService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetScrapOrderByIdAsync(int id)
        {
            var result = await _scrapService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetScrapOrderDetailsDtoById(int id)
        {
            var result = _scrapService.GetScrapDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetScrapOrderDetailsDtoByIdAsync(int id)
        {
            var result = await _scrapService.GetScrapDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetList")]
        public IActionResult GetScrapOrderListDto()
        {
            var result = _scrapService.GetScrapListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetScrapOrderListDtoAsync()
        {
            var result = await _scrapService.GetScrapListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetAll")]
        public IActionResult ScrapOrders()
        {
            var result = _scrapService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> ScrapOrdersAsync()
        {
            var result = await _scrapService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("Add")]
        public IActionResult Add(Scrap scrap)
        {
            var result = _scrapService.Add(scrap);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Scrap scrap)
        {
            var result = await _scrapService.AddAsync(scrap);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Scrap scrap)
        {
            var result = _scrapService.Update(scrap);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Scrap scrap)
        {
            var result = await _scrapService.UpdateAsync(scrap);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var scrapToDelete = _scrapService.GetById(id);
            var result = _scrapService.Delete(scrapToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var scrapToDelete = await _scrapService.GetByIdAsync(id);
            var result = await _scrapService.DeleteAsync(scrapToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
    }
}
