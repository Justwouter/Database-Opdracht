namespace DBOpdracht;

public class Gast : Gebruiker{
    public int Id {get;set;}
    public DateTime EersteBezoek {get;set;}
    public DateTime GeboorteDatum {get;set;}
    public int Credits {get;set;}
    public Gast? Begeleider {get;set;}
    public Gast? Begeleid {get;set;}
    public Attractie? FavorieteAttractie {get;set;}
    public GastInfo GastInformatie;
    public int GastinfoId {get;set;}
    public List<Reservering> reserveringen {get;set;} = null!;

    public Gast(string Email) : base(Email){
        this.GastInformatie = new GastInfo(this);
    }


    
}