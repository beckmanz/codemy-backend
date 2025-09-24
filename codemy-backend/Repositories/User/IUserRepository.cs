using codemy_backend.Models.Dtos;

namespace codemy_backend.Repositories.User;

public interface IUserRepository
{
    Task<UserModel> CreateUserAsync(UserModel userModel);
    Task<UserModel> GetByEmailAsync(string email);
}