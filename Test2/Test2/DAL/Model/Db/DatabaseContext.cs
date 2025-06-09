using Microsoft.EntityFrameworkCore;

namespace Test2.DAL.Model.Db;

public class DatabaseContext : DbContext
{
    public DbSet<Available_Program> AvailablePrograms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<Purchase_History> PurchaseHistories { get; set; }
    public DbSet<Washing_Machine> WashingMachines { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Customer>().HasData(
            new Customer() {CustomerId = 1, FirstName = "Vitalii", LastName = "Korytnyi", PhoneNumber = null},
            new Customer() {CustomerId = 2, FirstName = "Michal", LastName = "Pazio", PhoneNumber = "+48-123-456-789"}
        );

        modelBuilder.Entity<Washing_Machine>().HasData(
            new Washing_Machine() {WashingMachineId = 1, MaxWeight = 10, SerialNumber = "TK/6662/31"},
            new Washing_Machine() {WashingMachineId = 2, MaxWeight = 16, SerialNumber = "TN/6102/52"}
        );

        modelBuilder.Entity<Program>().HasData(
            new Program() {ProgramId = 1, DurationMinutes = 20, Name = "Washing", TemperatureCelsius = 20},
            new Program() {ProgramId = 2, DurationMinutes = 30, Name = "Drying", TemperatureCelsius = 15}
        );

        modelBuilder.Entity<Available_Program>().HasData(
            new Available_Program() { AvailableProgramId = 1, ProgramId = 1, Price = 100, WashingMachineId = 1 },
            new Available_Program() { AvailableProgramId = 2, ProgramId = 2, Price = 150, WashingMachineId = 2 }
        );

        modelBuilder.Entity<Purchase_History>().HasData(
            new Purchase_History() {AvailableProgramId = 1, CustomerId = 1, PurchaseDate = new DateTime(2025, 10, 1), Rating = 5},
            new Purchase_History() {AvailableProgramId = 2, CustomerId = 2, PurchaseDate = new DateTime(2025, 8, 20), Rating = null},
            new Purchase_History() {AvailableProgramId = 1, CustomerId = 2, PurchaseDate = new DateTime(2024, 12, 31), Rating = 4}
        );
        
        base.OnModelCreating(modelBuilder);
    }
}