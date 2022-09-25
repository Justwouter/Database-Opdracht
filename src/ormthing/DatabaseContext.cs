namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext{

    public DbSet<Attractie> Attractions {get;set;}
    public DbSet<Onderhoud> Maintenance {get;set;}
    public DbSet<Medewerker> Staff {get;set;}
    public DbSet<Gebruiker> Users {get;set;}
    public DbSet<Gast> Guests {get;set;}
    public DbSet<Reservering> Reservations {get;set;}

    public DbSet<GastInfo> GuestInfo {get;set;}
    public async Task<bool> Boek(GCNotificationStatus g, Attractie a, DateTimeBereik d){
        return true;
        
    }

    protected override void OnModelCreating(ModelBuilder builder){
        //Medewerker
            var StaffConfig = builder.Entity<Medewerker>();
            StaffConfig.ToTable("Medewerkers");
        //Gebruiker
            var UserConfig = builder.Entity<Gebruiker>();
            UserConfig.ToTable("Gebruikers");
            //UserConfig.HasData(new Gebruiker("GaryV2"));
            UserConfig.HasKey(k => k.Email);

        //Gast
            var GuestConfig = builder.Entity<Gast>();
            GuestConfig.ToTable("Gasten");

        //reservering 
            var ReservationsConfig = builder.Entity<Reservering>();
            ReservationsConfig.OwnsOne(res => res.VindtPlaatsTijdens);

        //Gastinfo
            var GuestInfoconfig = builder.Entity<GastInfo>();
            GuestInfoconfig.OwnsOne(ginfo => ginfo.coordinate);
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder){
        //builder.UseSqlServer("Server=AORUS-15P-W\\SQLEXPRESS;Initial Catalog=Week4DB;Integrated Security=true");
        builder.UseSqlServer("Server=DESKTOP-PRAETOR\\SQLEXPRESS;Initial Catalog=Week4DB;Integrated Security=true");
    }
}