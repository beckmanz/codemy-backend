using codemy_backend.Models.Dtos;
using codemy_backend.Models.Dtos.Request;
using codemy_backend.Models.Dtos.Response;
using codemy_backend.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace codemy_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthInterface _authInterface;

    public AuthenticationController(IAuthInterface authInterface)
    {
        _authInterface = authInterface;
    }

    [HttpPost("signup")]
    public async Task<ActionResult<ResponseModel>> SignUp(SignUpRequestDto dto)
    {
        var response = await _authInterface.SignUp(dto);
        return Ok(response);
    }
    [HttpPost("signin")]
    public async Task<ActionResult<ResponseModel>> SignIn(SignInRequestDto dto)
    {
        var response = await _authInterface.SignIn(dto);
        return Ok(response);
    }
}