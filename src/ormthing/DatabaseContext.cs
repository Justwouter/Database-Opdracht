namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext{

    public async Task<bool> Boek(GCNotificationStatus g, Attractie a, DateTimeBereik d){
        return true;

    }

    protected override void OnModelCreating(ModelBuilder builder){
        

    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder){
        builder.UseSqlServer("Server=AORUS-15P-W\\SQLEXPRESS;Initial Catalog=YourDatabase;Integrated Security=true");
    }
}