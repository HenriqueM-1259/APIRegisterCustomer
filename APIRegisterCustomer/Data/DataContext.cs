using APIRegisterCustomer.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
namespace APIRegisterCustomer.Data
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotEnv.Load();
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasMany(u => u.Clients)
           .WithOne(c => c.User)
           .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.AddressId);
        }
    }
}
