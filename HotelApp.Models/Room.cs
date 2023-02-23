using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace HotelApp.Models;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public int RoomId { get; set; }
   
    
    public string? RoomName { get; set; }
    
    public string RoomPicture { get; set; }
    
    
    public decimal Cost { get; set; }
    
    
    public RoomType CategoryType { get; set; }
    
    public  State Status { get; set; }
    
    public enum State
    {
        Available = 0, 
        Booked = 1
    }

    public enum RoomType
    {
        SingleRoom ,
        DoubleRoom ,
        DeluxeRoom ,
        PresidentialSuite
    }
    
}