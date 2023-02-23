using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.RequestModels;
using HotelApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;
    private readonly IUserRepository _userRepository;
    
    public UserService(ApplicationDbContext context, IUserRepository userRepository) 
    { 
        _db = context;
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<User>> GetUserList()
    {
        return await _db.User.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _db.User.FindAsync(id);
    }
    
    public async Task<User> Login(LoginRequestModel user)
    {
        var existingUser =  _db.User.FirstOrDefault(m => m.UserEmail == user.Username && m.UserPassword == user.Password);

        if (existingUser == null)
        {
            return null;
        }
        return existingUser;
    }

    public async Task<UserViewModel> CreateUser(RegisterUserRequestModel model)
    {
        var existingUser = _userRepository.GetByEmail(model.UserEmail);

        var newUser = new User
        {
            // UserId = Guid.NewGuid(),
            UserId = 1,
            UserEmail = model.UserEmail,
            UserPassword = model.UserPassword
        };
        
        if (existingUser != null)
        {
            return null;
        }
        
        _userRepository.Add(newUser); 

        var viewModel = new UserViewModel()
        {
            UserId = newUser.UserId,
            UserEmail = newUser.UserEmail
        };

        return viewModel;
    }

    public async Task UpdateUser(User user)
    {
        _db.Entry(user).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var deleteUser = await   _db.User.FindAsync(id);
        _db.User.Remove(deleteUser);
        await _db.SaveChangesAsync();
    }
}