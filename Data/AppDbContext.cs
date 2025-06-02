
using MemoApp.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Memo> Memos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Memo>().HasData(
            new Memo { Id = 1, Title = "Car Free Day", Content = "Go for a ride on the highway", CreatedAt = new DateTime(2025, 6, 1), UpdatedAt = new DateTime(2025, 6, 1) },
            new Memo { Id = 2, Title = "Shopping", Content = "Buy some groceries", CreatedAt = new DateTime(2025, 6, 1), UpdatedAt = new DateTime(2025, 6, 1) }
        );
        modelBuilder.Entity<WeatherForecast>()
            .Property(weatherforecast => weatherforecast.Date)
            .HasColumnType("date");
    }
}