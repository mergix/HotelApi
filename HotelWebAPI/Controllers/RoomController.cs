using Hotel.Services;
using HotelApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IDataService _dataService;

    public RoomController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IEnumerable<Room>> GetRoomsList()
    {
        return await _dataService.GetRoomList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRooms(int id)
    {
        return await _dataService.GetRoom(id);
    }

    [HttpPost]
    public async Task<ActionResult<Room>> PostRooms([FromBody] Room room)
    {
       
        var newRoom = await _dataService.CreateRoom(room);
        return CreatedAtAction(nameof(GetRooms), new { id = newRoom.RoomId }, newRoom);
    }

    [HttpPut]
    public async  Task<ActionResult> PutRooms(int id, [FromBody] Room room)
    {
        if (id != room.RoomId)
        {
            return BadRequest();
        }

        await _dataService.UpdateRoom(room);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteRoom(int id)
    {
        var roomToDelete = await _dataService.GetRoom(id);
        if (roomToDelete == null)
            return NotFound();

        await _dataService.DeleteRoom(roomToDelete.RoomId);
        return NoContent();
    }

    
}