using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HotelApp.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    // public string UserName { get; set; }
    
    public string UserEmail { get; set; }
    
    public string UserPassword  { get; set; } //read about how to hash this 
    
    // public ICollection<Booking> Bookings { get; set; }



    public Role RoleType { get; set; }
    
    public enum Role
    {
        Customer = 1,
        Admin = 2
    }
}