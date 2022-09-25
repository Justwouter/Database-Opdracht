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
        if(that.Eindigt()){ //null Safety
            // b1<a2 && b2>a1
            if(that.Begin < this.Eind && that.Eind > this.Begin){
                return true;
            }
            return false;
        }
        //If either Maintenance or a reservation has no end, 
        //we assume that it will last until the heat death of the universe or until a cosmic ray flips the bit. 
        //Whatever comes first.
        else{
            if(that.Begin < this.Eind){
                return true;
            }
            return false;
        }
    }
}