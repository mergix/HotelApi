using Hotel.DatabaseContext;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Repositories;

public class RoomRepository :IRoomRepository
{
    
    private readonly ApplicationDbContext _db;
    
    public RoomRepository(ApplicationDbContext context) 
    { 
        _db = context;
    }
    public void Add(Room room)
    {
        _db.Room.Add(room);
        _db.SaveChanges();
    }

    public void Update(Room room)
    {
        _db.Entry(room).State = EntityState.Modified;
        _db.SaveChanges();
    }

    public IEnumerable<Room> GetAll()
    {
        return _db.Room.ToList();
    }

    public Room GetById(Guid id)
    {
        var roomById = _db.Room.Find(id);
        return roomById ;
    }

    public void Delete(Guid id)
    {
        var deleteRoom =   _db.Room.Find(id);
        _db.Room.Remove(deleteRoom);
         _db.SaveChanges();
    }
}