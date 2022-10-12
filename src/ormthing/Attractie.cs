namespace DBOpdracht;

public class Attractie{
    public int Id {get;set;}
    public String Naam {get;set;}   = null!;

    public List<Onderhoud> OnderhoudPunten = new List<Onderhoud>();

    public List<Reservering> Reserveringen = new List<Reservering>();

    public readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

    public Attractie(String Naam){
        this.Naam = Naam;
    }

    protected Attractie(){}

    public async Task<bool> OnderhoudBezig(DatabaseContext c){
        return await OnderhoudBezigOpTijdstip(c,new DateTimeBereik{Begin = DateTime.Now, Eind = DateTime.Now});
    }

    public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d){
        if(await OnderhoudBezigOpTijdstip(c,d) || await ReservatieOpTijdstip(c,d)){
            return false;
        }
        return true;
    }

    private async Task<bool> OnderhoudBezigOpTijdstip(DatabaseContext c, DateTimeBereik dt){
        var result = Task<bool>.Run(() => {
            foreach(Onderhoud task in c.Maintenance.AsEnumerable()){
                if(task.Target.Id == this.Id){
                    if(task.VindtPlaatsTijdens.Overlapt(dt)){
                        return true;
                    }
                }
            }
            return false;
        });
        return await result;
        
    }

    private async Task<bool> ReservatieOpTijdstip(DatabaseContext c, DateTimeBereik dt){
        //Arrow code let's go!
        var result = Task<bool>.Run(() =>{
            var AttractieHere = c.Attractions.Single(a => a.Id == this.Id);
            c.Entry(AttractieHere).Collection(r => r.Reserveringen).Load();
            var OurReservations = c.Entry(AttractieHere).Collection(r => r.Reserveringen).Query().Where(r => r.ReservedAttraction.Id == this.Id);
            foreach(var reservation in OurReservations){
                if(reservation.VindtPlaatsTijdens.Overlapt(dt)){
                    return true;
                }
            }
            return false;
        });
        return await result;
        //????
        // if(reservering.VindtPlaatsTijdens.Overlapt(dt)){
        //     return true;
        // }
        // return false;
    }

    
}