namespace ormthingTests;
using DBOpdracht;
using ormthing;

public class TestDatabaseContext
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async void TestBoekRejectsWhenReserved(bool reserved){
        DatabaseContext DBC = new DatabaseContext();
        Attractie Achtbaan1 = new Attractie("Achtbaan");
        DBC.Attractions.Add(Achtbaan1);
        Gast Bob = new Gast("Bob@hhs.nl");
        DateTimeBereik DTB = new DateTimeBereik();
        DTB.Begin =  DateTime.Now;
        DTB.Eind = DateTime.Now.AddDays(1);
        if(reserved){
            Reservering r = new Reservering(){VindtPlaatsTijdens = DTB};
            Bob.reserveringen.Add(r);
            Achtbaan1.Reserveringen.Add(r);
        }
        Assert.Equal(reserved, !await DBC.Boek(Bob,Achtbaan1,DTB));
    }
}