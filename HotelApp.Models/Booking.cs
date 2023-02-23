using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Models;
using System.ComponentModel.DataAnnotations;

public class Booking
{
    [Key]
    public int BookingId { get; set; }
    
    public DateTime DateIn { get; set; }
    
    public DateTime DateOut { get; set; }
    
    public Room Room { get; set; }
    
    public User User { get; set; }
    
    
    
}