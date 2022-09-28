namespace DBOpdracht;

public class Attractie{
    public int Id {get;set;}
    public String Naam = null!;

    public List<Onderhoud> OnderhoudPunten = new List<Onderhoud>();

    public Reservering? reservering;

    public Attractie(String Naam){
        this.Naam = Naam;
    }

    public Attractie(){}

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
                if(task.Target == this){
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
        var result = Task<bool>.Run(() =>{
            foreach(Reservering task in c.Reservations.AsEnumerable()){
                if(task.ReservedAttractions.Contains(this)){
                    foreach(Attractie attr in task.ReservedAttractions.AsEnumerable()){
                        if(attr.Naam == this.Naam){
                            if(attr.reservering != null && attr.reservering.VindtPlaatsTijdens.Overlapt(dt)){
                                return true;
                            }
                        }
                    }
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