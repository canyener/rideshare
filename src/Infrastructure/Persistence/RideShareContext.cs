using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class RideShareContext : DbContext
{
  public RideShareContext(DbContextOptions<RideShareContext> options)
    : base(options)
  {
      Database.EnsureCreated();
  }

  public DbSet<TravelPlan> TravelPlans { get; set; }
}