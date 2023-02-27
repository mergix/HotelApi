using HotelApp.Models;

namespace Hotel.Services.RoomService;

public interface IRoomService
{
    public  Task<IEnumerable<Room>> GetRoomList();
    
    public  Task<Room> GetRoomById(Guid id);
    
    
    public  Task<Room> CreateRoom( Room model);
    
    public  void UpdateRoom(Room model);
    
    public  void DeleteRoom(Guid id);
}