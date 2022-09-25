namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

public class Starter{

    public static void Main(String[] args){
        DatabaseContext myContext = new DatabaseContext();
        //myContext.Users.Add(new Gebruiker("gary@brannan.com"));
        //myContext.Users.Add(new Gebruiker("Matt@MattGray.com"));
        myContext.SaveChanges();

        // var allUserEmails = myContext.Users.Where(user => user.Email.Contains("Matt")).ToList();
        // foreach (Gebruiker u in allUserEmails){
        //     Console.WriteLine(u.Email);
        // }
        Console.ReadLine();
        //myContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [Users]");
        //myContext.SaveChanges();
    }
}