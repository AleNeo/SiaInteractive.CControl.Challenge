using System; 
using System.Collections.Generic;
using System.Threading.Tasks; 
using SiaInteractive.CControl.Challenge.Domain.Entities;   

namespace SiaInteractive.CControl.Challenge.Domain.Interfaces;

public interface IWindowAppRepository
{
    Task<WindowApp> GetWindowAppByIdAsync(Guid id);
    Task<IEnumerable<WindowApp>> GetAllWindowAppsAsync();
    Task<Guid> AddWindowAppAsync(WindowApp windowApp);
    Task UpdateWindowAppAsync(WindowApp windowApp);
    Task DeleteWindowAppAsync(Guid id);
}