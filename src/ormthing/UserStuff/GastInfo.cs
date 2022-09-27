namespace DBOpdracht;

public class GastInfo{
    public int Id {get;set;}
    
    public string LaatstBezochteURL;
    public Gast Gast;
    public Coordinate coordinate = new Coordinate();
 
    public GastInfo(Gast gast){
        this.Gast = gast;
    }

    public GastInfo(){}

    
}