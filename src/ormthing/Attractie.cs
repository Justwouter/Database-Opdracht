namespace DBOpdracht;

public class Attractie{
    public String Naam;

    public List<Onderhoud> OnderhoudPunten = new List<Onderhoud>();

    public Reservering reservering;

    public Attractie(String Naam){
        this.Naam = Naam;
    }

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
        foreach(Onderhoud task in c.Maintenance.AsEnumerable()){
            if(task.Target == this){
                if(task.VindtPlaatsTijdens.Overlapt(dt)){
                    return true;
                }
            }
        }
        return false;
    }

    private async Task<bool> ReservatieOpTijdstip(DatabaseContext c, DateTimeBereik dt){
        // foreach(Reservering task in c.Reservations.AsEnumerable()){
        //     if(task.ReservedAttractions.Contains(this)){
        //         foreach(Attractie attr in task.ReservedAttractions.AsEnumerable()){
        //             if(attr == this){
                        
        //             }
        //         }
        //     }
        // }
        //return false;
        if(reservering.VindtPlaatsTijdens.Overlapt(dt)){
            return true;
        }
        return false;
    }
}