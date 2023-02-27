using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.RequestModels;

namespace Hotel.Services.RoomService;

public class RoomService:IRoomService
{
   
    private readonly IRoomRepository _roomRepository;
    
    public RoomService(IRoomRepository roomRepository) 
    { 
        
        _roomRepository = roomRepository;
    }


    public async Task<IEnumerable<Room>> GetRoomList()
    {
        return _roomRepository.GetAll();
    }

    public async Task<Room> GetRoomById(Guid id)
    {
        return _roomRepository.GetById(id);
    }

    public async Task<Room> CreateRoom(Room model)
    {
        var newRoom = new Room()
        {
            RoomId = Guid.NewGuid(),
            CategoryType = model.CategoryType,
            Cost = model.Cost,
            LastModified = DateTime.UtcNow,
            RoomName = model.RoomName,
            RoomPicture = model.RoomPicture,
            Status = model.Status
        };
       _roomRepository.Add(newRoom);
        return newRoom ;
    }

    public void  UpdateRoom(Room model)
    {
        _roomRepository.Update(model);
    }

    public void DeleteRoom(Guid id)
    {
        _roomRepository.Delete(id);
    }
}