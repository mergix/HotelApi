using Hotel.Services;
using Hotel.Services.RoomService;
using HotelApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService ;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IEnumerable<Room>> GetRoomsList()
    {
        return await _roomService.GetRoomList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRooms(Guid id)
    {
        return null; //await _dataService.GetRoom(id);
    }

    [HttpPost]
    public async Task<ActionResult<Room>> PostRooms([FromBody] Room room)
    {
       
        var newRoom = await _roomService.CreateRoom(room);
        return CreatedAtAction(nameof(GetRooms), new { id = newRoom.RoomId }, newRoom);
    }

    [HttpPut]
    public async  Task<ActionResult> PutRooms(Guid id, [FromBody] Room room)
    {
        if (id != room.RoomId)
        {
            return BadRequest();
        }

         _roomService.UpdateRoom(room);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteRoom(Guid id)
    {
        // var roomToDelete = await _dataService.GetRoom(id);
        // if (roomToDelete == null)
        //     return NotFound();
        //
        // await _dataService.DeleteRoom(roomToDelete.RoomId);
        // return NoContent();
        return null;
    }

    
}