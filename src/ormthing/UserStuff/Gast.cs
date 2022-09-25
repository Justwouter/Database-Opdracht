namespace DBOpdracht;

public class Gast : Gebruiker{
    public DateTime EersteBezoek;
    public DateTime GeboorteDatum;
    public int Credits;
    public Gast? Begeleidt;
    public Attractie? FavorieteAttractie;
    public GastInfo GastInformatie = new GastInfo();

    public Reservering? reservering;

    public Gast(string Email) : base(Email){}


    
}