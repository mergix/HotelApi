using HotelApp.Models;
using HotelApp.Models.RequestModels;
using HotelApp.Models.ViewModels;

namespace Hotel.Services;

public interface IUserService
{
    public  Task<IEnumerable<User>> GetUserList();

    public  Task<User> GetUserById(Guid id);

    public  Task<User> Login(LoginRequestModel user);

    public  Task<UserViewModel> CreateUser(RegisterUserRequestModel model);

    public void UpdateUser(User user);

    public void DeleteUser(Guid id);
}