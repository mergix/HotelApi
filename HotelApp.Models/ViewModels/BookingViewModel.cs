namespace HotelApp.Models.ViewModels;

public class BookingViewModel
{
    public Guid BookingId { get; set; }
    
    public DateTime DateIn { get; set; }
    
    public DateTime DateOut { get; set; }
    
    
    public Guid Roomid { get; set; }
    
    public Guid Userid { get; set; }
}