using codemy_backend.Models.Dtos.Response;

namespace codemy_backend.Models.Dtos.Request;

public class SignUpRequestDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public static implicit operator UserModel(SignUpRequestDto dto)
    {
        return new UserModel()
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = dto.Password,
            Role = dto.Role
        };
    }
}