namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext{
    // (= null!;) Tell the compiler/intelisense to shut up about nullables when not initializing a value 
    public DbSet<Attractie> Attractions {get;set;} = null!;
    public DbSet<Onderhoud> Maintenance {get;set;} = null!;
    public DbSet<Medewerker> Staff {get;set;} = null!;
    public DbSet<Gebruiker> Users {get;set;} = null!;
    public DbSet<Gast> Guests {get;set;} = null!;
    public DbSet<Reservering> Reservations {get;set;} = null!;
    public DbSet<GastInfo> GuestInfo {get;set;} = null!;

    public async Task<bool> Boek(Gast g, Attractie a, DateTimeBereik d){
        using var transaction = this.Database.BeginTransaction();
        await a.Semaphore.WaitAsync();
        try { 
            var result = Task<bool>.Run(()=> {
                if(!a.Reserveringen.Any(r => r.VindtPlaatsTijdens.Overlapt(d))){
                    var reservering = new Reservering{gast = g, VindtPlaatsTijdens = d};
                    reservering.ReservedAttraction = a;
                    g.reserveringen.Add(reservering);
                    g.Credits -= 1;
                    this.SaveChanges();
                    return true;
                }
                return false;
            });
            var res = await result;
            transaction.Commit();
            return res; 
        }
        finally { 
            a.Semaphore.Release(); 
        }
    }

    protected override void OnModelCreating(ModelBuilder builder){
        //Attractie
            var AttractionConfig = builder.Entity<Attractie>();
            AttractionConfig.ToTable("Attracties");
            AttractionConfig.HasKey(k => k.Id);

        //Onderhoud
            var MaintenanceConfig = builder.Entity<Onderhoud>();
            MaintenanceConfig.ToTable("Onderhoud_taken");
            MaintenanceConfig.HasKey(k => k.Id);
            MaintenanceConfig.HasOne(attr => attr.Target)
                .WithMany(maint => maint.OnderhoudPunten)
                .HasForeignKey(k => k.Id).IsRequired(); //one to many with Attractie?

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
            GuestConfig.HasOne(g => g.Begeleider)
                .WithOne(g => g.Begeleid); //Zero or one with itself
            GuestConfig.HasMany(r => r.reserveringen)
                .WithOne(g => g.gast);

        //reservering 
            var ReservationsConfig = builder.Entity<Reservering>();
            ReservationsConfig.OwnsOne(res => res.VindtPlaatsTijdens);
            ReservationsConfig.HasOne(a => a.ReservedAttraction)
                .WithMany(r => r.Reserveringen); //One or Zero to many with Attractie?

        //Gastinfo
            var GuestInfoconfig = builder.Entity<GastInfo>();
            GuestInfoconfig.OwnsOne(ginfo => ginfo.coordinate);
            GuestInfoconfig.HasKey(k => k.Id);
            GuestInfoconfig.HasOne(g => g.Gast)
                .WithOne(gi => gi.GastInformatie)
                .HasForeignKey<Gast>(g => g.GastinfoId); //One to one with Gast/gastinfo?

        
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder){
        var pcname = Environment.MachineName;
        Console.WriteLine(pcname);
        builder.UseSqlServer("Server="+pcname+"\\SQLEXPRESS;Initial Catalog=Week4DB;Integrated Security=true");
        //builder.UseSqlServer("Server=DESKTOP-PRAETOR\\SQLEXPRESS;Initial Catalog=Week4DB;Integrated Security=true");
    }
}