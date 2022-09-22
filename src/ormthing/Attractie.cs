namespace DBOpdracht;

public class Attractie{
    public String Naam;

    public Attractie(String Naam){
        this.Naam = Naam;
    }

    public async Task<bool> OnderhoudBezig(DatabaseContext c){
        return true;
        
    }

    public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d){
        return true;

    }
}