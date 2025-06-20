using BienComun.Core.DTOs;
using BienComun.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BienComun.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListController : ControllerBase
{
    private readonly IListService _listService;

    public ListController(IListService listService)
    {
        _listService = listService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateList([FromBody] CreateListRequest request)
    {
        await _listService.CreateListAsync(request);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLists()
    {
        var lists = await _listService.GetAllListsAsync();
        return Ok(lists);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteList(int id)
    {
        await _listService.DeleteListAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetListWithProducts(int id)
    {
        var list = await _listService.GetListWithProductsAsync(id);
        if (list == null) return NotFound();
        return Ok(list);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateList(int id, [FromBody] CreateListRequest request)
    {
        await _listService.UpdateListAsync(id, request);
        return Ok();
    }

    [HttpGet("{id}/contributions")]
    public async Task<IActionResult> GetListWithContributions(int id)
    {
        var contributions = await _listService.GetListProductContributionsAsync(id);
        if (contributions == null || !contributions.Any()) return NotFound();
        return Ok(contributions);
    }

}
