using System;


namespace SiaInteractive.CControl.Challenge.Application.DTOs;

public record UserDto(Guid UserId,  string UserName, string Name, string LastName, string Email);
