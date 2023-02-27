using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HotelApp.Models.Enums;


namespace HotelApp.Models;

public class User:Base_Entity
{
    [Key]
    public Guid UserId { get; set; }
    
     public string FirstName { get; set; }
     
     public string LastName { get; set; }
    
    public string UserEmail { get; set; }
    
    public string UserPassword  { get; set; } //read about how to hash this 
    
    public Role RoleType { get; set; }
    
 
}