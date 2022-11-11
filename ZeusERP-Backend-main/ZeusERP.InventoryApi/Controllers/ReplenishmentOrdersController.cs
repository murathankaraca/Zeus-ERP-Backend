using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.InventoryApi.Controllers
{
    [EnableCors("TCAPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplenishmentOrdersController : ControllerBase
    {
        private IOrderReplenishmentService _replenishmentService;

        public ReplenishmentOrdersController(IOrderReplenishmentService replenishmentService)
        {
            _replenishmentService = replenishmentService;
        }

        [HttpGet("GetAll")]
        public IActionResult Replenishments()
        {
            var result = _replenishmentService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> ReplenishmentsAsync()
        {
            var result = await _replenishmentService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetReplenishmentById(int id)
        {
            var result = _replenishmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetReplenishmentByIdAsync(int id)
        {
            var result = await _replenishmentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsById/{id}")]
        public IActionResult GetReplenishmentDetailsDtoById(int id)
        {
            var result = _replenishmentService.GetReplenishmentDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsByIdAsync/{id}")]
        public async Task<IActionResult> GetReplenishmentDetailsDtoByIdAsync(int id)
        {
            var result = await _replenishmentService.GetReplenishmentDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetDetails")]
        public IActionResult GetReplenishmentDetailsDto()
        {
            var result = _replenishmentService.GetReplenishmentDetailsDtos();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync")]
        public async Task<IActionResult> GetReplenishmentDetailsDtoAsync()
        {
            var result = await _replenishmentService.GetReplenishmentDetailsDtosAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpPost("Add")]
        public IActionResult Add(Replenishment replenishment)
        {
            var result = _replenishmentService.Add(replenishment);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Replenishment replenishment)
        {
            var result = await _replenishmentService.AddAsync(replenishment);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Replenishment replenishment)
        {
            var result = _replenishmentService.Update(replenishment);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Replenishment replenishment)
        {
            var result = await _replenishmentService.UpdateAsync(replenishment);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var replenishmentToDelete = _replenishmentService.GetById(id);
            var result = _replenishmentService.Delete(replenishmentToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var replenishmentToDelete = await _replenishmentService.GetByIdAsync(id);
            var result = await _replenishmentService.DeleteAsync(replenishmentToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
    }
}
