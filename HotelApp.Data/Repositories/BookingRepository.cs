using Hotel.DatabaseContext;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _db;
    
    public BookingRepository(ApplicationDbContext context) 
    { 
        _db = context;
    }
    public void Add(Booking book)
    {
        _db.Booking.Add(book);
        _db.SaveChanges();
    }

    public void Update(Booking book)
    {
        _db.Entry(book).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public IEnumerable<Booking> GetAll()
    {
        return _db.Booking.ToList();
    }

    public Booking GetById(Guid id)
    {
        var bookingById = _db.Booking.Find(id);
        return bookingById ;
    }

    public void Delete(Guid id)
    {
        var deleteBooking =  _db.Booking.Find(id);
        _db.Booking.Remove(deleteBooking);
         _db.SaveChangesAsync();
    }
}