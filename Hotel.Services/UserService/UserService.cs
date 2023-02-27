using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.Enums;
using HotelApp.Models.RequestModels;
using HotelApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services;

public class UserService : IUserService
{
   
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository) 
    { 
       
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<User>> GetUserList()
    {
        return  _userRepository.GetAll();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return _userRepository.GetById(id);
    }
    
    public async Task<User> Login(LoginRequestModel user)
    {
        var existingUser =  _userRepository.GetByEmail(user.Username);

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
            UserId = Guid.NewGuid(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserEmail = model.UserEmail,
            UserPassword = model.UserPassword,
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

    public void  UpdateUser(User user)
    {
        _userRepository.Update(user);
    }



    public  void  DeleteUser(Guid id)
    {
      _userRepository.Delete(id);
    }
}