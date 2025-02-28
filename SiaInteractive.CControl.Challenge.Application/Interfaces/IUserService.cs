using SiaInteractive.CControl.Challenge.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SiaInteractive.CControl.Challenge.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<bool> LoginAsync(string userName, string password);
    Task LogoutAsync();
}
