using Hotel.DatabaseContext;
using HotelApp.Models;

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
        
    }

    public IEnumerable<User> GetAll()
    {
        return null;
    }

    public User GetById(int id)
    {
        return null;
    }
    
    public User GetByEmail(string email)
    {
        return _db.User.FirstOrDefault(m => m.UserEmail == email);
    }
}