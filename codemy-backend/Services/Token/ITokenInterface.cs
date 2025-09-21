namespace codemy_backend.Services.Token;

public interface ITokenInterface
{
    string GetAcessToken(int id, string name, UserRole role);
}