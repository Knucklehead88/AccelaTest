using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if(!builder.IsConfigured)
        {
            builder.UseSqlite("Data Source=CliAppDb.db");
        }
    }        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
    }

}