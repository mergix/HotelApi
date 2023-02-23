using Hotel.Services;
using HotelApp.Models;
using HotelApp.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IDataService _dataService;

    public UserController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetUsersList()
    {
        return await _dataService.GetUserList();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUsers(int id)
    {
        return await _dataService.GetUser(id);
    }
    
    [HttpPost("/Login")]
    public async Task<ActionResult<User>> LoginUser([FromBody] LoginRequestModel user)
    {
        return await _dataService.Login(user);
    }
    [HttpPost]
    public async Task<ActionResult> PostUser([FromBody] RegisterUserRequestModel user)
    {
        var newUser = await _dataService.CreateUser(user);
        // return Ok(CreatedAtAction(nameof(GetUsers), new { id = newUser.UserId }, newUser));
        return Ok(newUser);
    }

    [HttpPut]
    public async  Task<ActionResult> PutUser(int id, [FromBody] User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        await _dataService.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteUser(int id)
    {
        var userToDelete = await _dataService.GetUser(id);
        if (userToDelete == null)
            return NotFound();

        await _dataService.DeleteRoom(userToDelete.UserId);
        return NoContent();
    }
    
    
}