using System;


namespace SiaInteractive.CControl.Challenge.Application.DTOs;

public record WindowAppDto(Guid Id, string AppName, int AppInstance, int XPosition, int YPosition, int Width, int Height);
