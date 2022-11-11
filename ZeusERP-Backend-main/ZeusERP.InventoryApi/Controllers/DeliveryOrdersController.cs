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
    public class DeliveryOrdersController : ControllerBase
    {
        private IOrderDeliveryService _deliveryService;

        public DeliveryOrdersController(IOrderDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet("GetAll")]
        public IActionResult Deliveries()
        {
            var result = _deliveryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> DeliveriesAsync()
        {
            var result = await _deliveryService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetList")]
        public IActionResult GetDeliveryListDto()
        {
            var result = _deliveryService.GetDeliveryListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetDeliveryListDtoAsync()
        {
            var result = await _deliveryService.GetDeliveryListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetTransferById(int id)
        {
            var result = _deliveryService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetTransferByIdAsync(int id)
        {
            var result = await _deliveryService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetDeliveryDetailsDtoById(int id)
        {
            var result = _deliveryService.GetDeliveryDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetDeliveryDetailsDtoByIdAsync(int id)
        {
            var result = await _deliveryService.GetDeliveryDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpPost("Add")]
        public IActionResult Add(Delivery delivery)
        {
            var result = _deliveryService.Add(delivery);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Delivery delivery)
        {
            var result = await _deliveryService.AddAsync(delivery);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Delivery delivery)
        {
            var result = _deliveryService.Update(delivery);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Delivery delivery)
        {
            var result = await _deliveryService.UpdateAsync(delivery);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deliveryToDelete = _deliveryService.GetById(id);
            var result = _deliveryService.Delete(deliveryToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deliveryToDelete = await _deliveryService.GetByIdAsync(id);
            var result = await _deliveryService.DeleteAsync(deliveryToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
    }
}
