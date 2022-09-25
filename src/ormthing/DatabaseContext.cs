namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext{

    public DbSet<Gebruiker> Users {get;set;}

    public async Task<bool> Boek(GCNotificationStatus g, Attractie a, DateTimeBereik d){
        return true;

    }

    protected override void OnModelCreating(ModelBuilder builder){
        var UserConfig = builder.Entity<Gebruiker>();
        UserConfig.ToTable("Users");
        //UserConfig.HasData(new Gebruiker("GaryV2"));
        UserConfig.HasKey(k => k.Email);
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder){
        //builder.UseSqlServer("Server=AORUS-15P-W\\SQLEXPRESS;Initial Catalog=Week4DB;Integrated Security=true");
        builder.UseSqlServer("Server=DESKTOP-PRAETOR\\SQLEXPRESS;Initial Catalog=Week4DB;Integrated Security=true");
    }
}