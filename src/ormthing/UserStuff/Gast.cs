namespace DBOpdracht;

public class Gast : Gebruiker{
    public int Id {get;set;}
    public DateTime EersteBezoek;
    public DateTime GeboorteDatum;
    public int Credits;
    public Gast? Begeleider;
    public Attractie? FavorieteAttractie;
    public GastInfo GastInformatie;
    public List<Reservering> reservering = new List<Reservering>();

    public Gast(string Email) : base(Email){
        this.GastInformatie = new GastInfo(this);
    }


    
}