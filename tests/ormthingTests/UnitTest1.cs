namespace ormthingTests;
using DBOpdracht;

public class UnitTest1
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TestBoekRejects(bool IsReserved){
        DatabaseContext DBC = new DatabaseContext();
        
    }
}