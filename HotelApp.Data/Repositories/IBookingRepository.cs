using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IBookingRepository
{
    void Add(Booking book);
    void Update(Booking book);
    IEnumerable<Booking> GetAll();
    Booking GetById(Guid id);
    void Delete(Guid id);
}