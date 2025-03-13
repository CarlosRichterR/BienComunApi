﻿using BienComun.Core.DTOs;
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

}
