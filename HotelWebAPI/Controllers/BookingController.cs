using AutoMapper;
using Hotel.Services;
using HotelApp.Models;
using HotelApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IDataService _dataService;
    private readonly IMapper _mapper;

    public BookingController(IDataService dataService ,IMapper mapper)
    {
        _dataService = dataService;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    [ProducesResponseType(200,Type = typeof(IEnumerable<Booking>))]
    public IActionResult  GetBookingList()
    {
        var bookings = _mapper.Map<List<BookingDto>>(_dataService.GetBookingList());
        return Ok(bookings) ;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        return await _dataService.GetBooking(id);
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking([FromBody] Booking booking)
    {
        var newBooking = await _dataService.CreateBooking(booking);
        return CreatedAtAction(nameof(GetBooking), new { id = newBooking.BookingId }, newBooking);
    }

    [HttpPut]
    public async  Task<ActionResult> PutBooking(int id, [FromBody] Booking booking)
    {
        if (id != booking.BookingId)
        {
            return BadRequest();
        }

        await _dataService.UpdateBooking(booking);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteBooking(int id)
    {
        var bookingToDelete = await _dataService.GetBooking(id);
        if (bookingToDelete == null)
            return NotFound();

        await _dataService.DeleteRoom(bookingToDelete.BookingId);
        return NoContent();
    }
    
}
