using SiaInteractive.CControl.Challenge.Domain.Entities;
using SiaInteractive.CControl.Challenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SiaInteractive.CControl.Challenge.Infrastructure.Data.Repository;

public class WindowAppRepository : IWindowAppRepository
{
    private readonly ApplicationDbContext _context;

    public WindowAppRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<WindowApp> GetWindowAppByIdAsync(Guid id)
    {
        return await _context.WindowApps.FindAsync(id);
    }

    public async Task<IEnumerable<WindowApp>> GetAllWindowAppsAsync()
    {
        return await _context.WindowApps.ToListAsync();
    }

    public async Task<Guid> AddWindowAppAsync(WindowApp windowApp)
    {
        var entry = await _context.WindowApps.AddAsync(windowApp);
        await _context.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task UpdateWindowAppAsync(WindowApp windowApp)
    {
        _context.WindowApps.Update(windowApp);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWindowAppAsync(Guid id)
    {
        var windowApp = await GetWindowAppByIdAsync(id);
        if (windowApp != null)
        {
            _context.WindowApps.Remove(windowApp);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<WindowApp> GetWindowAppByNameAndInstanceAsync(string windowAppName, int windowAppInstance)
    {
        return await _context.WindowApps
            .FirstOrDefaultAsync(w => w.AppName == windowAppName && w.AppInstance == windowAppInstance);
    }
}
