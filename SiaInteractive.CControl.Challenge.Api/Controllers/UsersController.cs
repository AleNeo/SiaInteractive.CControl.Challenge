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

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="model">The registration model containing email and password.</param>
    /// <returns>A message indicating the user has been registered successfully.</returns>
    /// <response code="200">If the user is registered successfully</response>
    /// <response code="400">If the registration fails</response>
    [HttpPost("register")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(400)]
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

    /// <summary>
    /// Gets a user by email.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <returns>The user details.</returns>
    /// <response code="200">Returns the user details</response>
    /// <response code="400">If the email is null or empty</response>
    /// <response code="404">If the user is not found</response>
    [HttpGet("{email}")]
    [ProducesResponseType(typeof(IdentityUser), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
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

    /// <summary>
    /// Resets the password of a user.
    /// </summary>
    /// <param name="model">The update model containing email and new password.</param>
    /// <returns>No content if the password is updated successfully.</returns>
    /// <response code="204">If the password is updated successfully</response>
    /// <response code="400">If the update fails</response>
    [HttpPatch("reset-password")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
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

    /// <summary>
    /// Deletes a user by email.
    /// </summary>
    /// <param name="email">The email of the user to delete.</param>
    /// <returns>No content if the user is deleted successfully.</returns>
    /// <response code="204">If the user is deleted successfully</response>
    /// <response code="400">If the email is null or empty</response>
    /// <response code="404">If the user is not found</response>
    [HttpDelete("{email}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
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
