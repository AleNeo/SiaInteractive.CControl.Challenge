using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiaInteractive.CControl.Challenge.Application.Interfaces;
using SiaInteractive.CControl.Challenge.Application.DTOs;
using SiaInteractive.CControl.Challenge.Domain.Entities;
using SiaInteractive.CControl.Challenge.Domain.Interfaces;

namespace SiaInteractive.CControl.Challenge.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto)
    {
        var user = new User
        {
            UserName = userCreateDto.UserName,
            Name = userCreateDto.Name,
            LastName = userCreateDto.LastName,
            Email = userCreateDto.Email
        };

        var userId = await _userRepository.AddUserAsync(user);
        
       return new UserDto(userId,
            userCreateDto.UserName,
            userCreateDto.Name,
            userCreateDto.LastName,
            userCreateDto.Email); 
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null) return null;

        return new UserDto(user.Id,
            user.UserName,
            user.Name,
            user.LastName,
            user.Email);        
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        var userDtos = new List<UserDto>();

        foreach (var user in users)
        {
            userDtos.Add(new UserDto(user.Id,
            user.UserName,
            user.Name,
            user.LastName,
            user.Email)
            );
        }

        return userDtos;
    }

    public async Task<UserDto> UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null) return null;
       
        user.Name = userUpdateDto.Name;
        user.LastName = userUpdateDto.LastName;
        user.Email = userUpdateDto.Email;

        await _userRepository.UpdateUserAsync(user);
        
        return new UserDto(user.Id,
            user.UserName,
            user.Name,
            user.LastName,
            user.Email);  
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {        
        await _userRepository.DeleteUserAsync(userId);
        return true;
    }

    public async Task<bool> LoginAsync(string userName, string password)
    {
        // Implement login logic here (e.g., check password, generate token, etc.)
        return true; // Placeholder for actual implementation
    }

    public async Task LogoutAsync()
    {
        // Implement logout logic here (e.g., invalidate token, etc.)
    }
}
