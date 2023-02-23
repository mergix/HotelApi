
using Hotel.DatabaseContext;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services;

public class DataService : IDataService
{
    
    private readonly ApplicationDbContext _db;
    
    public DataService(ApplicationDbContext context) 
    { 
        _db = context; 
        
    }
    
    public async Task<IEnumerable<Room>> GetRoomList()
    {
        return await _db.Room.ToListAsync();
    }

    public ICollection<Booking> GetBookingList()
    {
        return  _db.Booking.ToList();
    }
    
    public async Task<IEnumerable<User>> GetUserList()
    {
        return await _db.User.ToListAsync();
    }

    public async Task<Room> GetRoom(int id)
    {
        return await _db.Room.FindAsync(id);
    }

    public async Task<Booking> GetBooking(int id)
    {
        return await _db.Booking.FindAsync(id);
    }

    public async Task<User> GetUser(int id)
    {
        return await _db.User.FindAsync(id);
    }
    
    public async Task<User> Login(User user)
    {
        var check =  _db.User.FirstOrDefault(m => m.UserEmail == user.UserEmail && m.UserPassword == user.UserPassword);

        if (check != null)
        {
            user = check;
        }
        

        return  user ;
    }

    public async Task<Room> CreateRoom(Room room)
    {

    
        
        // _db.Booking.Where(p => p.Room.RoomId == room.RoomId)
        
        _db.Room.Add(room);
        await _db.SaveChangesAsync();

        return room;
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {

        // Booking test = new Booking();
        //
        //
        // test.Room.RoomId = booking.Room.RoomId;
        // test.User.UserId = booking.User.UserId;
        // test.DateIn= booking.DateIn;
        // test.DateOut = booking.DateOut;
        _db.Booking.Add(booking);
        await _db.SaveChangesAsync();

        return booking;
    }

    public async Task<User> CreateUser(User user)
    {
        var check = _db.User.FirstOrDefault(m => m.UserEmail == user.UserEmail && m.UserPassword == user.UserPassword);

        if (check == null)
        {
            _db.User.Add(user);
            await _db.SaveChangesAsync();
        }
        else
            user = check;

        
            return user;
    }

    public async Task UpdateRoom(Room room)
    {

        _db.Entry(room).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task UpdateBooking(Booking booking)
    {
        _db.Entry(booking).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _db.Entry(user).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteRoom(int id)
    {
      var deleteRoom = await   _db.Room.FindAsync(id);
      _db.Room.Remove(deleteRoom);
      await _db.SaveChangesAsync();
    }

    public async Task DeleteBooking(int id)
    {
        var deleteBooking = await   _db.Booking.FindAsync(id);
        _db.Booking.Remove(deleteBooking);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var deleteUser = await   _db.User.FindAsync(id);
        _db.User.Remove(deleteUser);
        await _db.SaveChangesAsync();
    }

    
}