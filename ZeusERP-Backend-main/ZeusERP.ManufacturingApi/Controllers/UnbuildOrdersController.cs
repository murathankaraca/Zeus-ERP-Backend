using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeusERP.ManufacturingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnbuildOrdersController : ControllerBase
    {
        //private IOrderUnbuildService _unbuildService;

        //public UnbuildOrdersController(IOrderUnbuildService unbuildService)
        //{
        //    _unbuildService = unbuildService;
        //}
        //[HttpGet("Get/{id}")]
        //public IActionResult GetUnbuildOrderById(int id)
        //{
        //    var result = _unbuildService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetAsync/{id}")]
        //public async Task<IActionResult> GetUnbuildOrderByIdAsync(int id)
        //{
        //    var result = await _unbuildService.GetByIdAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetDetails/{id}")]
        //public IActionResult GetUnbuildOrderDetailsDtoById(int id)
        //{
        //    var result = _unbuildService.GetUnbuildDetailsDtoById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetDetailsAsync/{id}")]
        //public async Task<IActionResult> GetUnbuildOrderDetailsDtoByIdAsync(int id)
        //{
        //    var result = await _unbuildService.GetUnbuildDetailsDtoByIdAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetList")]
        //public IActionResult GetUnbuildOrderListDto()
        //{
        //    var result = _unbuildService.GetUnbuildListDto();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("GetListAsync")]
        //public async Task<IActionResult> GetUnbuildOrderListDtoAsync()
        //{
        //    var result = await _unbuildService.GetUnbuildListDtoAsync();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("GetAll")]
        //public IActionResult UnbuildOrders()
        //{
        //    var result = _unbuildService.GetList();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("GetAllAsync")]
        //public async Task<IActionResult> UnbuildOrdersAsync()
        //{
        //    var result = await _unbuildService.GetListAsync();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpPost("Add")]
        //public IActionResult Add(Unbuild unbuild)
        //{
        //    var result = _unbuildService.Add(unbuild);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpPost("Update")]
        //public IActionResult Update(Unbuild unbuild)
        //{
        //    var result = _unbuildService.Update(unbuild);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpDelete("Delete/{id}")]
        //public IActionResult Delete(Unbuild unbuild)
        //{
        //    var result = _unbuildService.Delete(unbuild);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
