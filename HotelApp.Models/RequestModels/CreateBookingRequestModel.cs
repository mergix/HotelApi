namespace HotelApp.Models.RequestModels;

public class CreateBookingRequestModel
{
    public int BookingId { get; set; }
    
    
    public DateTime DateIn { get; set; }
    
    public DateTime DateOut { get; set; }
    

}