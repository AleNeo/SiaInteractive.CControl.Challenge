using Microsoft.AspNetCore.Mvc;
using SiaInteractive.CControl.Challenge.Application.Interfaces;
using SiaInteractive.CControl.Challenge.Application.DTOs;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace SiaInteractive.CControl.Challenge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WindowAppController : ControllerBase
{
    private readonly IWindowAppService _windowAppService;

    public WindowAppController(IWindowAppService windowAppService)
    {
        _windowAppService = windowAppService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWindowApp([FromBody] WindowAppCreateDto windowAppCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var windowAppDto = await _windowAppService.CreateWindowAppAsync(windowAppCreateDto);
        return CreatedAtAction(nameof(GetWindowAppById), new { id = windowAppDto.Id }, windowAppDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWindowAppById(Guid id)
    {
        var windowAppDto = await _windowAppService.GetWindowAppByIdAsync(id);
        if (windowAppDto == null)
        {
            return NotFound();
        }

        return Ok(windowAppDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWindowApps()
    {
        var windowAppDtos = await _windowAppService.GetAllWindowAppsAsync();
        return Ok(windowAppDtos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWindowApp(Guid id, [FromBody] WindowAppUpdateDto windowAppUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var windowAppDto = await _windowAppService.UpdateWindowAppAsync(id, windowAppUpdateDto);
        if (windowAppDto == null)
        {
            return NotFound();
        }

        return Ok(windowAppDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWindowApp(Guid id)
    {
        var result = await _windowAppService.DeleteWindowAppAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}



