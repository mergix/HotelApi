using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IRoomRepository
{
    void Add(Room room);
    void Update(Room room);
    IEnumerable<Room> GetAll();
    Room GetById(Guid id);
    void Delete(Guid id);
}