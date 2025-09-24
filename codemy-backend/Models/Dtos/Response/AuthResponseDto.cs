namespace codemy_backend.Models.Dtos.Response;

public class AuthResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Token { get; set; }
    public static implicit operator AuthResponseDto(UserModel dto)
    {
        return new AuthResponseDto()
        {
            Id = dto.Id,
            Name = dto.Name,
        };
    }
}