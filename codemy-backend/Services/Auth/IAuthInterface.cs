using codemy_backend.Models.Dtos;
using codemy_backend.Models.Dtos.Request;
using codemy_backend.Models.Dtos.Response;

namespace codemy_backend.Services.Auth;

public interface IAuthInterface
{
    Task<ResponseModel> SignUp(SignUpRequestDto signUpRequestDto);
    Task<ResponseModel> SignIn(SignInRequestDto signInRequestDto);
}