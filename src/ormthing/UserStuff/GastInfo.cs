namespace DBOpdracht;

public class GastInfo{
    public int Id {get;set;}
    
    public string LaatstBezochteURL = null!;
    public Gast Gast = null!;
    public Coordinate coordinate = new Coordinate();
 
    public GastInfo(Gast gast){
        this.Gast = gast;
    }

    public GastInfo(){}

    
}