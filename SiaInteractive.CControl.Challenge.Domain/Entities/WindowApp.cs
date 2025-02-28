using System.ComponentModel.DataAnnotations;
using System;

namespace SiaInteractive.CControl.Challenge.Domain.Entities;

public class WindowApp
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(350)]
    public string AppName { get; set; }

    [Required]
    public int AppInstance { get; set; }

    [Required]
    public int XPosition { get; set; }

    [Required]
    public int YPosition { get; set; }

    [Required]
    public int Width { get; set; }

    [Required]
    public int Height { get; set; }
}