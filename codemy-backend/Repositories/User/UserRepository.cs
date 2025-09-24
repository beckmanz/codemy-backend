using Microsoft.EntityFrameworkCore;

namespace codemy_backend.Repositories.User;

public class UserRepository : IUserRepository
{   
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> CreateUserAsync(UserModel userModel)
    {
        var user = await _context.Users.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return user.Entity;
    }

    public async Task<UserModel> GetByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
}