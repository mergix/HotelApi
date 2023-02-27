namespace HotelApp.Models.DTO;

public class BookingDto
{
    public Guid BookingId { get; set; }
    
    public DateTime DateIn { get; set; }
    
    public DateTime DateOut { get; set; }
    
}