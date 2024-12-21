using Microsoft.AspNetCore.Mvc;
using Api.Constants;
using Microsoft.AspNetCore.Identity;


namespace Api.Models;

public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // Assign the User role by default
            await _userManager.AddToRoleAsync(user, UserRoles.User);
            
            // Or assign multiple roles
            // await _userManager.AddToRolesAsync(user, new[] { UserRoles.User, UserRoles.Manager });

            return Ok("User created successfully");
        }

        return BadRequest(result.Errors);
    }
}