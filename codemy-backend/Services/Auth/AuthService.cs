using codemy_backend.Exceptions;
using codemy_backend.Models.Dtos.Request;
using codemy_backend.Models.Dtos.Response;
using codemy_backend.Repositories.User;
using codemy_backend.Services.Token;

namespace codemy_backend.Services.Auth;

public class AuthService : IAuthInterface
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenInterface  _tokenInterface;

    public AuthService(IUserRepository userRepository, ITokenInterface tokenInterface)
    {
        _userRepository = userRepository;
        _tokenInterface = tokenInterface;
    }

    public async Task<ResponseModel> SignIn(SignInRequestDto signInRequestDto)
    {
        var user = await _userRepository.GetByEmailAsync(signInRequestDto.Email);
        if (user is null)
        {
            throw new UnauthorizedException("Acesso negado.");
        }
        if (!BCrypt.Net.BCrypt.Verify(signInRequestDto.Password, user.PasswordHash))
        {
            throw new UnauthorizedException("Acesso negado.");
        }
        var token = _tokenInterface.GetAcessToken(user.Id, user.Name, user.Role);
        AuthResponseDto authDto = user;
        authDto.Token = token;
        var response = ResponseData<AuthResponseDto>.Success(authDto);
        return response;
    }

    public async Task<ResponseModel> SignUp(SignUpRequestDto signUpRequestDto)
    {
        var userEmailExist = await _userRepository.GetByEmailAsync(signUpRequestDto.Email);
        if (userEmailExist is not null)
        {
            throw new ConflictException("Email já existe!");
        }
        signUpRequestDto.Password = BCrypt.Net.BCrypt.HashPassword(signUpRequestDto.Password);
        UserModel newUser = signUpRequestDto;
        var user = await _userRepository.CreateUserAsync(newUser);
        
        var token = _tokenInterface.GetAcessToken(user.Id, user.Name, user.Role);

        AuthResponseDto authDto = user;
        authDto.Token = token;
        
        var response = ResponseData<AuthResponseDto>.Success(authDto);
        return response;
    }
}