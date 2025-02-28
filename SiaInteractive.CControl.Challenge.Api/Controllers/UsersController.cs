using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SiaInteractive.CControl.Challenge.Api.Models;

namespace SiaInteractive.CControl.Challenge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;


    public UsersController(UserManager<IdentityUser> userManager)
    {
       
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest();
        }

        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            return Ok(new { message = "user registered successfully!!!" });
        }
        return BadRequest(result.Errors);
    }


    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserByName(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest();
        }

        var user = await _userManager.FindByNameAsync(email);

        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }


    [HttpPatch("reset-password")]
    public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateModel model)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest();
        }

        var user = await _userManager.FindByNameAsync(model.Email);
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return NoContent();
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest();
        }

        var user = await _userManager.FindByNameAsync(email);

        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return NoContent();
    }


}
