//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using Newtonsoft.Json;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using ZeusERP.Business.Abstract;
//using ZeusERP.Entities.Concrete;

//namespace ZeusERP.InventoryApi.Controllers
//{
//    [EnableCors("TCAPolicy")]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BillOfMaterialsController : ControllerBase
//    {
//        private IBomService _bomService;

//        public BillOfMaterialsController(IBomService bomService)
//        {
//            _bomService = bomService;
//        }

//        [HttpGet("GetAll")]
//        public IActionResult Boms()
//        {
//            var result = _bomService.GetList();
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }

//        [HttpGet("GetAllAsync")]
//        public async Task<IActionResult> BomsAsync()
//        {
//            var result = await _bomService.GetListAsync();
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpGet("GetList")]
//        public IActionResult GetBomListDto()
//        {
//            var result = _bomService.GetBomListDto();
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }

//        [HttpGet("GetListAsync")]
//        public async Task<IActionResult> GetBomListDtoAsync()
//        {
//            var result = await _bomService.GetBomListDtoAsync();
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }

//        [HttpGet("Get/{id}")]
//        public IActionResult GetBomById(int id)
//        {
//            var result = _bomService.GetById(id);
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpGet("GetAsync/{id}")]
//        public async Task<IActionResult> GetBomByIdAsync(int id)
//        {
//            var result = await _bomService.GetByIdAsync(id);
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpGet("GetDetails/{id}")]
//        public IActionResult GetBomDetailsDtoById(int id)
//        {
//            var result = _bomService.GetBomDetailsDtoById(id);
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpGet("GetDetailsAsync/{id}")]
//        public async Task<IActionResult> GetBomDetailsDtoByIdAsync(int id)
//        {
//            var result = await _bomService.GetBomDetailsDtoByIdAsync(id);
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }

//        [HttpPost("Add")]
//        public IActionResult Add(BillOfMaterials bom)
//        {
//            var result = _bomService.Add(bom);
//            if (result.Success)
//            {
//                return Ok(JsonConvert.SerializeObject(result.Message));
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpPost("AddAsync")]
//        public async Task<IActionResult> AddAsync(BillOfMaterials bom)
//        {
//            var result = await _bomService.AddAsync(bom);

//            if (result.Success)
//            {
//                return Ok(JsonConvert.SerializeObject(result.Message));
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpPut("Update/{id}")]
//        public IActionResult Update(int id, [FromBody] BillOfMaterials bom)
//        {
//            var result = _bomService.Update(bom);
//            if (result.Success)
//            {
//                return Ok(JsonConvert.SerializeObject(result.Message));
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpPut("UpdateAsync/{id}")]
//        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BillOfMaterials bom)
//        {
//            var result = await _bomService.UpdateAsync(bom);
//            if (result.Success)
//            {
//                return Ok(JsonConvert.SerializeObject(result.Message));
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }
//        [HttpDelete("Delete/{id}")]
//        public IActionResult Delete(int id)
//        {
//            var bomToDelete = _bomService.GetById(id);
//            var result = _bomService.Delete(bomToDelete.Data);
//            if (result.Success)
//            {
//                return Ok(JsonConvert.SerializeObject(result.Message));
//            }
//            return BadRequest(JsonConvert.SerializeObject(result.Message));
//        }

//        [HttpDelete("DeleteAsync/{id}")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            var bomToDelete = await _bomService.GetByIdAsync(id);
//            var result = await _bomService.DeleteAsync(bomToDelete.Data);
//            if (result.Success)
//            {
//                return Ok(JsonConvert.SerializeObject(result.Message));
//            }
//            return BadRequest(result.Message);
//        }
//    }
//}
