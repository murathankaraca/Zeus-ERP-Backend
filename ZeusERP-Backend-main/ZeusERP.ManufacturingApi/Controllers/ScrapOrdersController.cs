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
    public class ScrapOrdersController : ControllerBase
    {
        //private IOrderScrapService _scrapService;

        //public ScrapOrdersController(IOrderScrapService scrapService, IProductService productService)
        //{
        //    _scrapService = scrapService;
        //}
        //[HttpGet("Get/{id}")]
        //public IActionResult GetScrapOrderById(int id)
        //{
        //    var result = _scrapService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetAsync/{id}")]
        //public async Task<IActionResult> GetScrapOrderByIdAsync(int id)
        //{
        //    var result = await _scrapService.GetByIdAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetDetails/{id}")]
        //public IActionResult GetScrapOrderDetailsDtoById(int id)
        //{
        //    var result = _scrapService.GetScrapDetailsDtoById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetDetailsAsync/{id}")]
        //public async Task<IActionResult> GetScrapOrderDetailsDtoByIdAsync(int id)
        //{
        //    var result = await _scrapService.GetScrapDetailsDtoByIdAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetList")]
        //public IActionResult GetScrapOrderListDto()
        //{
        //    var result = _scrapService.GetScrapListDto();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("GetListAsync")]
        //public async Task<IActionResult> GetScrapOrderListDtoAsync()
        //{
        //    var result = await _scrapService.GetScrapListDtoAsync();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("GetAll")]
        //public IActionResult ScrapOrders()
        //{
        //    var result = _scrapService.GetList();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpGet("GetAllAsync")]
        //public async Task<IActionResult> ScrapOrdersAsync()
        //{
        //    var result = await _scrapService.GetListAsync();
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpPost("Add")]
        //public IActionResult Add(Scrap scrap)
        //{
        //    var result = _scrapService.Add(scrap);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpPost("Update")]
        //public IActionResult Update(Scrap scrap)
        //{
        //    var result = _scrapService.Update(scrap);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpDelete("Delete/{id}")]
        //public IActionResult Delete(Scrap scrap)
        //{
        //    var result = _scrapService.Delete(scrap);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
