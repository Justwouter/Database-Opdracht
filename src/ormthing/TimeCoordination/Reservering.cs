namespace DBOpdracht;

public class Reservering{
    public int Id {get;set;}
    public int GastId {get;set;}
    public Gast? gast {get;set;}
    public Attractie ReservedAttraction {get;set;} = null!;
    public DateTimeBereik VindtPlaatsTijdens {get;set;} = null!;

}