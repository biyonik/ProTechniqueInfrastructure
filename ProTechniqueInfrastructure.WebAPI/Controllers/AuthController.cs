using Microsoft.AspNetCore.Mvc;
using ProTechniqueInfrastructure.Business.Abstract;
using ProTechniqueInfrastructure.Entities.DTOs.UserDtos;

namespace ProTechniqueInfrastructure.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        var userExists = await _authService.UserExistsAsync(userForRegisterDto.Email);
        if (!userExists.Success)
            return BadRequest(userExists.Message);
        var registerResult = await _authService.RegisterAsync(userForRegisterDto, userForRegisterDto.Password);
        var result = await _authService.CreateAccessTokenAsync(registerResult.Data);
        if (result.Success)
            return Ok(result.Data);
        return BadRequest(result.Message);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
        var userToLogin = await _authService.LoginAsync(userForLoginDto);
        if (!userToLogin.Success)
            return BadRequest(userToLogin.Message);
        
        var accessTokenResult = await _authService.CreateAccessTokenAsync(userToLogin.Data);
        if (accessTokenResult.Success)
            return Ok(accessTokenResult.Data);
        return BadRequest(accessTokenResult.Message);
    }
}