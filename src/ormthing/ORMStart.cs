namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

// public class Starter{

//     public static void Main(String[] args){
//         DatabaseContext myContext = new DatabaseContext();
//         //myContext.Users.Add(new Gebruiker("gary@brannan.com"));
//         //myContext.Users.Add(new Gebruiker("Matt@MattGray.com"));
//         myContext.SaveChanges();

//         // var allUserEmails = myContext.Users.Where(user => user.Email.Contains("Matt")).ToList();
//         // foreach (Gebruiker u in allUserEmails){
//         //     Console.WriteLine(u.Email);
//         // }
//         Console.ReadLine();
//         //myContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [Users]");
//         //myContext.SaveChanges();
//     }
// }






public class MainClass
{
    private static async Task<T> Willekeurig<T>(DbContext c) where T : class => await c.Set<T>().OrderBy(r => EF.Functions.Random()).FirstAsync();
    public static async Task Main(string[] args)
    {
        Random random = new Random(1);
        using (DatabaseContext c = new DatabaseContext())
        {
            c.Attractions.RemoveRange(c.Attractions);
            c.Users.RemoveRange(c.Users);
            c.Guests.RemoveRange(c.Guests);
            c.Staff.RemoveRange(c.Staff);
            c.Reservations.RemoveRange(c.Reservations);
            c.Maintenance.RemoveRange(c.Maintenance);

            c.SaveChanges();

            foreach (string attractie in new string[] { "Reuzenrad", "Spookhuis", "Achtbaan 1", "Achtbaan 2", "Draaimolen 1", "Draaimolen 2" })
                c.Attractions.Add(new Attractie(attractie));

            c.SaveChanges();

            for (int i=0;i<40;i++)
                c.Staff.Add(new Medewerker($"medewerker{i}@mail.com"));
            c.SaveChanges();

            for (int i = 0; i < 10000; i++)
            {
                var geboren = DateTime.Now.AddDays(-random.Next(36500));
                var nieuweGast = new Gast($"gast{i}@mail.com") { GeboorteDatum = geboren, EersteBezoek = geboren + (DateTime.Now - geboren) * random.NextDouble(), Credits = random.Next(5), Id = i+1};
                if (random.NextDouble() > .6)
                    nieuweGast.FavorieteAttractie = await Willekeurig<Attractie>(c);
                c.Guests.Add(nieuweGast);
            }


            Gast gary = new Gast("Gary@hhs.nl") { GeboorteDatum = DateTime.Now, EersteBezoek = DateTime.Now, Credits = 200};
            gary.FavorieteAttractie = c.Attractions.ToList()[0];
            gary.reserveringen.Add(new Reservering() { ReservedAttraction = c.Attractions.ToList()[0]});
            //gary.reserveringen.Add(new Reservering() { ReservedAttraction = c.Attractions.ToList()[0]});
            c.Guests.Add(gary);

            c.SaveChanges();

            for (int i = 0; i < 10; i++)
                (await Willekeurig<Gast>(c)).Begeleider = await Willekeurig<Gast>(c);
            c.SaveChanges();


            Console.WriteLine("Finished initialization");

            Console.Write(await new DemografischRapport(c).Genereer());
            Console.ReadLine();
        }
    }
}



// SELECT TOP (2000) [Email]
//       ,[Id]
//       ,[EersteBezoek]
//       ,[GeboorteDatum]
//       ,[Credits]
//       ,[FavorieteAttractieId]
//       ,[GastinfoId]
//       ,[BegeleiderEmail]
//  FROM [Week4DB].[dbo].[Gasten]