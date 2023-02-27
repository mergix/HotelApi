using Hotel.DatabaseContext;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    
    public UserRepository(ApplicationDbContext context) 
    { 
        _db = context;
    }
    
    public void Add(User user)
    {
        _db.User.Add(user);
        _db.SaveChanges();
    }

    public void Update(User user)
    {
        _db.Entry(user).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public IEnumerable<User> GetAll()
    {
        return _db.User.ToList();
    }

    public User GetById(Guid id)
    {

        var userById = _db.User.Find(id);
        return userById ;
    }
    
    public User GetByEmail(string email)
    {
        return _db.User.FirstOrDefault(m => m.UserEmail == email);
    }

    public void Delete(Guid id)
    {
        var deleteUser =   _db.User.Find(id);
        _db.User.Remove(deleteUser);
         _db.SaveChangesAsync();
    }
}