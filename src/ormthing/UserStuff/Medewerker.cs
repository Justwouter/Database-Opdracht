namespace DBOpdracht;

public class Medewerker : Gebruiker{
    public List<Onderhoud> CoordineertOnderhoud = new List<Onderhoud>();
    public List<Onderhoud> DoetOnderhoud = new List<Onderhoud>();
    
    public Medewerker(string Email) : base(Email){}
}