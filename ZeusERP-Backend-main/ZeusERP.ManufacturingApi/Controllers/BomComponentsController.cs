using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.ManufacturingApi.Controllers
{
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
        public IActionResult BomComps()
        {
            var result = _bomCompService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> BomCompsAsync()
        {
            var result = await _bomCompService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetBomCompById(int id)
        {
            var result = _bomCompService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetBomCompByIdAsync(int id)
        {
            var result = await _bomCompService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetBomCompDetailsDtoById(int id)
        {
            var result = _bomCompService.GetBomComponentDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetBomCompDetailsDtoByIdAsync(int id)
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
        public IActionResult Add(BillOfMaterialsComponent bomComp)
        {
            var result = _bomCompService.Add(bomComp);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(BillOfMaterialsComponent bomComp)
        {
            var result = await _bomCompService.AddAsync(bomComp);

            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] BillOfMaterialsComponent bomComp)
        {
            var result = _bomCompService.Update(bomComp);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BillOfMaterialsComponent bomComp)
        {
            var result = await _bomCompService.UpdateAsync(bomComp);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var bomToDelete = _bomCompService.GetById(id);
            var result = _bomCompService.Delete(bomToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(JsonConvert.SerializeObject(result.Message));
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var bomToDelete = await _bomCompService.GetByIdAsync(id);
            var result = await _bomCompService.DeleteAsync(bomToDelete.Data);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(result.Message);
        }
    }
}
