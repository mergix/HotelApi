using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DatabaseContext;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<User> User { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Booking> Booking { get; set; }

}