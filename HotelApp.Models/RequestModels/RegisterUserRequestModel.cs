using HotelApp.Models.Enums;

namespace HotelApp.Models.RequestModels;

public class RegisterUserRequestModel
{
    
    public string FirstName { get; set; }
     
    public string LastName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword  { get; set; } //read about how to hash this 
    
    public Role RoleType { get; set; }
}