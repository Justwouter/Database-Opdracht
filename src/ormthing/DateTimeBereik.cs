namespace DBOpdracht;

public class DateTimeBereik{
    public DateTime Begin;
    public DateTime? Eind;

    public bool Eindigt(){
        if(Eind != null){
            return true;
        }
        return false;
    }

    public bool Overlapt(DateTimeBereik that){
        if(that.Eindigt()){
            if(that.Begin < this.Eind && that.Eind > this.Begin){
                return true;
            }
            return false;

        }
        else{
            if(that.Begin < this.Eind){
                return true;
            }
            return false;
        }
    }
}