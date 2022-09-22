namespace DBOpdracht;

public class Gast : Gebruiker{
    public DateTime EersteBezoek;
    public DateTime GeboorteDatum;
    public int Credits;
    public Gast? Begeleidt;
    public Attractie? FavorieteAttractie;
    public GastInfo myInfo= new GastInfo();

    public Gast(string Email) : base(Email){}


    
}