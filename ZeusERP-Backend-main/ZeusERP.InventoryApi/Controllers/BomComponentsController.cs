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
    public class BomComponentsController : ControllerBase
    {
        private IBomComponentService _bomCompService;

        public BomComponentsController(IBomComponentService bomCompService)
        {
            _bomCompService = bomCompService;
        }

        [HttpGet("GetAll")]
        public IActionResult BomComponents()
        {
            var result = _bomCompService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> BomComponentsAsync()
        {
            var result = await _bomCompService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetBomComponentById(int id)
        {
            var result = _bomCompService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetBomComponentByIdAsync(int id)
        {
            var result = await _bomCompService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetBomComponentDetailsDtoById(int id)
        {
            var result = _bomCompService.GetBomComponentDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetBomComponentDetailsDtoByIdAsync(int id)
        {
            var result = await _bomCompService.GetBomComponentDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetListByOrderId/{id}")]
        public IActionResult GetBomComponentsDtoByOrderId(int id)
        {
            var result = _bomCompService.GetBomComponentDetailsDtoByOrderId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetListByOrderIdAsync/{id}")]
        public async Task<IActionResult> GetBomComponentsDtoByOrderIdAsync(int id)
        {
            var result = await _bomCompService.GetBomComponentDetailsDtoByOrderIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpPost("Add")]
        public IActionResult Add(BillOfMaterialsComponent bomComponent)
        {
            var result = _bomCompService.Add(bomComponent);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(BillOfMaterialsComponent bomComponent)
        {
            var result = await _bomCompService.AddAsync(bomComponent);

            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] BillOfMaterialsComponent bomComponent)
        {
            var result = _bomCompService.Update(bomComponent);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BillOfMaterialsComponent bomComponent)
        {
            var result = await _bomCompService.UpdateAsync(bomComponent);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var bomComponentToDelete = _bomCompService.GetById(id);
            var result = _bomCompService.Delete(bomComponentToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var bomComponentToDelete = await _bomCompService.GetByIdAsync(id);
            var result = await _bomCompService.DeleteAsync(bomComponentToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(result.Message);
        }
    }
}
