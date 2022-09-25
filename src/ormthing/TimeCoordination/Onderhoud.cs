namespace DBOpdracht;

public class Onderhoud{
    public string Probleem;
    public DateTimeBereik VindtPlaatsTijdens = new DateTimeBereik();
    public Attractie Target;

    public List<Medewerker> medewerkers = new List<Medewerker>();
    public Onderhoud(string Probleem, Attractie Target){
        this.Probleem = Probleem;
        this.Target = Target;
    }
}