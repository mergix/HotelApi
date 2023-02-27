using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    IEnumerable<User> GetAll();
    User GetById(Guid id);
    User GetByEmail(string email);

    void Delete(Guid id);
}