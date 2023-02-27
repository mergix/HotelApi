using Hotel.Services;
using HotelApp.Models;
using HotelApp.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetUsersList()
    {
        return await _userService.GetUserList();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUsers(Guid id)
    {
        return await _userService.GetUserById(id);
    }
    
    [HttpPost("/Login")]
    public async Task<ActionResult<User>> LoginUser([FromBody] LoginRequestModel user)
    {
        return await _userService.Login(user);
    }
    [HttpPost]
    public async Task<ActionResult> PostUser([FromBody] RegisterUserRequestModel user)
    {
        var newUser = await _userService.CreateUser(user);
        // return Ok(CreatedAtAction(nameof(GetUsers), new { id = newUser.UserId }, newUser));
        return Ok(newUser);
    }

    [HttpPut]
    public async  Task<ActionResult> PutUser(Guid id, [FromBody] User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

         _userService.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteUser(Guid id)
    {
        var userToDelete = await _userService.GetUserById(id);
        if (userToDelete == null)
            return NotFound();

         _userService.DeleteUser(userToDelete.UserId);
        return NoContent();
    }
    
    
}