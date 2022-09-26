namespace DBOpdracht;

public class GastInfo{
    
    public string LaatstBezochteURL;
    public Gast gast;
    public int gastId;
    public Coordinate coordinate = new Coordinate();
 
    public GastInfo(Gast gast){
        this.gast = gast;
    }

    
}