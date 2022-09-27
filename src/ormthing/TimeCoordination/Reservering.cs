namespace DBOpdracht;

public class Reservering{
    public int Id {get;set;}
    public int GastId {get;set;}
    public Gast? gast {get;set;}
    public List<Attractie> ReservedAttractions {get;set;}
    public DateTimeBereik VindtPlaatsTijdens {get;set;}

}