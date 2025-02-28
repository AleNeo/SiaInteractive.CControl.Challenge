using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiaInteractive.CControl.Challenge.Domain.Entities;

namespace SiaInteractive.CControl.Challenge.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<Guid> AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid id);
}


