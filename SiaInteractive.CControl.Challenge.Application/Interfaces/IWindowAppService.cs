using SiaInteractive.CControl.Challenge.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SiaInteractive.CControl.Challenge.Application.Interfaces;

public interface IWindowAppService
{
    Task<WindowAppDto> CreateWindowAppAsync(WindowAppCreateDto windowAppCreateDto);
    Task<WindowAppDto> GetWindowAppByIdAsync(Guid windowAppId);
    Task<IEnumerable<WindowAppDto>> GetAllWindowAppsAsync();
    Task<WindowAppDto> UpdateWindowAppAsync(Guid windowAppId, WindowAppUpdateDto windowAppUpdateDto);
    Task<bool> DeleteWindowAppAsync(Guid windowAppId);
}