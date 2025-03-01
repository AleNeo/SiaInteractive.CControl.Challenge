using Microsoft.AspNetCore.Mvc;
using SiaInteractive.CControl.Challenge.Application.Interfaces;
using SiaInteractive.CControl.Challenge.Application.DTOs;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

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

    /// <summary>
    /// Creates a new WindowApp.
    /// </summary>
    /// <param name="windowAppCreateDto">The WindowApp creation DTO.</param>
    /// <returns>The created WindowApp.</returns>
    /// <response code="201">Returns the created WindowApp</response>
    /// <response code="400">If the creation fails</response>
    [HttpPost]
    [ProducesResponseType(typeof(WindowAppDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateWindowApp([FromBody] WindowAppCreateDto windowAppCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var windowAppDto = await _windowAppService.CreateWindowAppAsync(windowAppCreateDto);
        return CreatedAtAction(nameof(GetWindowAppById), new { id = windowAppDto.Id }, windowAppDto);
    }

    /// <summary>
    /// Gets a WindowApp by ID.
    /// </summary>
    /// <param name="id">The ID of the WindowApp.</param>
    /// <returns>The WindowApp details.</returns>
    /// <response code="200">Returns the WindowApp details</response>
    /// <response code="404">If the WindowApp is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(WindowAppDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetWindowAppById(Guid id)
    {
        var windowAppDto = await _windowAppService.GetWindowAppByIdAsync(id);
        if (windowAppDto == null)
        {
            return NotFound();
        }

        return Ok(windowAppDto);
    }

    /// <summary>
    /// Gets all WindowApps.
    /// </summary>
    /// <returns>A list of all WindowApps.</returns>
    /// <response code="200">Returns a list of all WindowApps</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WindowAppDto>), 200)]
    public async Task<IActionResult> GetAllWindowApps()
    {
        var windowAppDtos = await _windowAppService.GetAllWindowAppsAsync();
        return Ok(windowAppDtos);
    }

    /// <summary>
    /// Updates a WindowApp.
    /// </summary>
    /// <param name="id">The ID of the WindowApp to update.</param>
    /// <param name="windowAppUpdateDto">The WindowApp update DTO.</param>
    /// <returns>The updated WindowApp.</returns>
    /// <response code="200">Returns the updated WindowApp</response>
    /// <response code="400">If the update fails</response>
    /// <response code="404">If the WindowApp is not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(WindowAppDto), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
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

    /// <summary>
    /// Deletes a WindowApp.
    /// </summary>
    /// <param name="id">The ID of the WindowApp to delete.</param>
    /// <returns>No content if the WindowApp is deleted successfully.</returns>
    /// <response code="204">If the WindowApp is deleted successfully</response>
    /// <response code="404">If the WindowApp is not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteWindowApp(Guid id)
    {
        var result = await _windowAppService.DeleteWindowAppAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Gets a WindowApp by name and instance.
    /// </summary>
    /// <param name="windowAppName">The name of the WindowApp.</param>
    /// <param name="windowAppInstance">The instance of the WindowApp.</param>
    /// <returns>The WindowApp details.</returns>
    /// <response code="200">Returns the WindowApp details</response>
    /// <response code="404">If the WindowApp is not found</response>
    [HttpGet("name/{windowAppName}/instance/{windowAppInstance}")]
    [ProducesResponseType(typeof(WindowAppDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetWindowAppByNameAndInstance(string windowAppName, int windowAppInstance)
    {
        var windowAppDto = await _windowAppService.GetWindowAppByNameAndInstanceAsync(windowAppName, windowAppInstance);
        if (windowAppDto == null)
        {
            return NotFound();
        }

        return Ok(windowAppDto);
    }
}




