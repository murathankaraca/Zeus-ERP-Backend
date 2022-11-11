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
    public class TransferOrdersController : ControllerBase
    {
        private IOrderTransferService _transferService;

        public TransferOrdersController(IOrderTransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet("GetAll")]
        public IActionResult Transfers()
        {
            var result = _transferService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> TransfersAsync()
        {
            var result = await _transferService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetList")]
        public IActionResult GetTransferListDto()
        {
            var result = _transferService.GetTransferListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetTransferListDtoAsync()
        {
            var result = await _transferService.GetTransferListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetTransferById(int id)
        {
            var result = _transferService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetTransferByIdAsync(int id)
        {
            var result = await _transferService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetTransferDetailsDtoById(int id)
        {
            var result = _transferService.GetTransferDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetTransferDetailsDtoByIdAsync(int id)
        {
            var result = await _transferService.GetTransferDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpPost("Add")]
        public IActionResult Add(Transfer transfer)
        {
            var result = _transferService.Add(transfer);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Transfer transfer)
        {
            var result = await _transferService.AddAsync(transfer);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Transfer transfer)
        {
            var result = _transferService.Update(transfer);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Transfer transfer)
        {
            var result = await _transferService.UpdateAsync(transfer);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var orderToDelete = _transferService.GetById(id);
            var result = _transferService.Delete(orderToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var orderToDelete = await _transferService.GetByIdAsync(id);
            var result = await _transferService.DeleteAsync(orderToDelete.Data);

            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
    }
}
