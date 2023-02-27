using AutoMapper;
using Hotel.Services;
using Hotel.Services.BookingService;
using HotelApp.Models;
using HotelApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;

    public BookingController(IBookingService bookingService ,IMapper mapper)
    {
        _bookingService = bookingService;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    [ProducesResponseType(200,Type = typeof(IEnumerable<Booking>))]
    public IActionResult  GetBookingList()
    {
        var bookings = _mapper.Map<List<BookingDto>>(_bookingService.GetBookingList());
        return Ok(bookings) ;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(Guid id)
    {
        return await _bookingService.GetBookingByUserId(id);
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking([FromQuery] Guid userid,[FromQuery] Guid roomid,[FromBody] BookingDto booking)
    {
        var newBooking = await _bookingService.CreateBooking(userid,roomid,booking);
        return CreatedAtAction(nameof(GetBooking), new { id = newBooking.BookingId }, newBooking);
    }

    [HttpPut]
    public async  Task<ActionResult> PutBooking(Guid id, [FromBody] Booking booking)
    {
        if (id != booking.BookingId)
        {
            return BadRequest();
        }

         _bookingService.UpdateBooking(booking);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> deleteBooking(Guid id)
    {

        return null; // var bookingToDelete = await _dataService.GetBooking(id);
        // if (bookingToDelete == null)
        //     return NotFound();
        //
        // await _dataService.DeleteRoom(bookingToDelete.BookingId);
        // return NoContent();
    }
    
}
