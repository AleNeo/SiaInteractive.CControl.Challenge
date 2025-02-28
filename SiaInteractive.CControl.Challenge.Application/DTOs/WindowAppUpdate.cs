using System;

namespace SiaInteractive.CControl.Challenge.Application.DTOs;

public record WindowAppUpdateDto(string AppName, int AppInstance, int XPosition, int YPosition, int Width, int Height);