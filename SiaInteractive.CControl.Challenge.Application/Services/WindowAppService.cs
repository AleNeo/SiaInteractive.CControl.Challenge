using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiaInteractive.CControl.Challenge.Application.Interfaces;
using SiaInteractive.CControl.Challenge.Application.DTOs;
using SiaInteractive.CControl.Challenge.Domain.Entities;
using SiaInteractive.CControl.Challenge.Domain.Interfaces;

namespace SiaInteractive.CControl.Challenge.Application.Services;

public class WindowAppService : IWindowAppService
{
    private readonly IWindowAppRepository _windowAppRepository;

    public WindowAppService(IWindowAppRepository windowAppRepository)
    {
        _windowAppRepository = windowAppRepository;
    }

    public async Task<WindowAppDto> CreateWindowAppAsync(WindowAppCreateDto windowAppCreateDto)
    {
        var windowApp = new WindowApp
        {
            AppName = windowAppCreateDto.AppName,
            AppInstance = windowAppCreateDto.AppInstance,
            XPosition = windowAppCreateDto.XPosition,
            YPosition = windowAppCreateDto.YPosition,
            Width = windowAppCreateDto.Width,
            Height = windowAppCreateDto.Height
        };

        var windowAppId = await _windowAppRepository.AddWindowAppAsync(windowApp);

        return new WindowAppDto(windowAppId,
            windowAppCreateDto.AppName,
            windowAppCreateDto.AppInstance,
            windowAppCreateDto.XPosition,
            windowAppCreateDto.YPosition,
            windowAppCreateDto.Width,
            windowAppCreateDto.Height);
    }

    public async Task<WindowAppDto> GetWindowAppByIdAsync(Guid windowAppId)
    {
        var windowApp = await _windowAppRepository.GetWindowAppByIdAsync(windowAppId);
        if (windowApp == null) return null;

        return new WindowAppDto(windowApp.Id,
            windowApp.AppName,
            windowApp.AppInstance,
            windowApp.XPosition,
            windowApp.YPosition,
            windowApp.Width,
            windowApp.Height);
    }

    public async Task<IEnumerable<WindowAppDto>> GetAllWindowAppsAsync()
    {
        var windowApps = await _windowAppRepository.GetAllWindowAppsAsync();
        var windowAppDtos = new List<WindowAppDto>();

        foreach (var windowApp in windowApps)
        {
            windowAppDtos.Add(new WindowAppDto(windowApp.Id,
                windowApp.AppName,
                windowApp.AppInstance,
                windowApp.XPosition,
                windowApp.YPosition,
                windowApp.Width,
                windowApp.Height));
        }

        return windowAppDtos;
    }

    public async Task<WindowAppDto> UpdateWindowAppAsync(Guid windowAppId, WindowAppUpdateDto windowAppUpdateDto)
    {
        var windowApp = await _windowAppRepository.GetWindowAppByIdAsync(windowAppId);
        if (windowApp == null) return null;
       
        windowApp.AppName = windowAppUpdateDto.AppName;
        windowApp.AppInstance = windowAppUpdateDto.AppInstance;
        windowApp.XPosition = windowAppUpdateDto.XPosition;
        windowApp.YPosition = windowAppUpdateDto.YPosition;
        windowApp.Width = windowAppUpdateDto.Width;
        windowApp.Height = windowAppUpdateDto.Height;

        await _windowAppRepository.UpdateWindowAppAsync(windowApp);
        
        return new WindowAppDto(windowApp.Id,
            windowApp.AppName,
            windowApp.AppInstance,
            windowApp.XPosition,
            windowApp.YPosition,
            windowApp.Width,
            windowApp.Height);
    }

    public async Task<bool> DeleteWindowAppAsync(Guid windowAppId)
    {
        var windowApp = await _windowAppRepository.GetWindowAppByIdAsync(windowAppId);
        if (windowApp == null) return false;

        await _windowAppRepository.DeleteWindowAppAsync(windowAppId);

        return true;
    }

    public async Task<WindowAppDto> GetWindowAppByNameAndInstanceAsync(string windowAppName, int windowAppInstance)
    {
        var windowApp = await _windowAppRepository.GetWindowAppByNameAndInstanceAsync(windowAppName, windowAppInstance);
        if (windowApp == null) return null;

        return new WindowAppDto(windowApp.Id,
            windowApp.AppName,
            windowApp.AppInstance,
            windowApp.XPosition,
            windowApp.YPosition,
            windowApp.Width,
            windowApp.Height);
    }
}