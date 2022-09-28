namespace DBOpdracht;

public class Onderhoud{
    public int Id {get;set;}
    public string Probleem = null! ;
    public DateTimeBereik VindtPlaatsTijdens = new DateTimeBereik();
    public Attractie Target = null!;

    public List<Medewerker> medewerkers = new List<Medewerker>();
    public Onderhoud(string Probleem, Attractie Target){
        this.Probleem = Probleem;
        this.Target = Target;
    }

    public Onderhoud(){}
}