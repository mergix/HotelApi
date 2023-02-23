using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    IEnumerable<User> GetAll();
    User GetById(int id);
    User GetByEmail(string email);
}