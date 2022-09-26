namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;

class DemografischRapport : Rapport
{
    private DatabaseContext context;
    public DemografischRapport(DatabaseContext context) => this.context = context;
    public override string Naam() => "Demografie";
    public override async Task<string> Genereer()
    {
        string ret = "Dit is een demografisch rapport: \n";
        ret += $"Er zijn in totaal { await AantalGebruikers() } gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
        var dateTime = new DateTime(2000, 1, 1);
        ret += $"Er zijn { await AantalSinds(dateTime) } bezoekers sinds { dateTime }\n";
        if (await AlleGastenHebbenReservering())
            ret += "Alle gasten hebben een reservering\n";
        else
            ret += "Niet alle gasten hebben een reservering\n";
        ret += $"Het percentage bejaarden is { await PercentageBejaarden() }\n";

        ret += $"De oudste gast heeft een leeftijd van { await HoogsteLeeftijd() } \n";

        ret += "De verdeling van de gasten per dag is als volgt: \n";
        var dagAantallen = await VerdelingPerDag();
        var totaal = dagAantallen.Select(t => t.aantal).Max();
        foreach (var dagAantal in dagAantallen)
            ret += $"{ dagAantal.dag }: { new string('#', (int)(dagAantal.aantal / (double)totaal * 20)) }\n";

        ret += $"{ await FavorietCorrect() } gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

        return ret;
    }
    private async Task<int> AantalGebruikers() => context.Users.Count();
    private async Task<bool> AlleGastenHebbenReservering() => context.Guests.Where<Gast>(gast => gast.reservering.Count() > 0).Count() == context.Guests.Count(); //Incredibly slow.
    private async Task<int> AantalSinds(DateTime sinds) => context.Guests.Where<Gast>(gast => gast.EersteBezoek > sinds).Count();
    private async Task<Gast> GastBijEmail(string email) => context.Guests.First<Gast>(gast => gast.Email == email); 
    private async Task<Gast?> GastBijGeboorteDatum(DateTime d) => context.Guests.First<Gast>(gast => gast.GeboorteDatum == d);
    private async Task<double> PercentageBejaarden() => (context.Guests.Where<Gast>(gast => (EF.Functions.DateDiffDay(gast.GeboorteDatum, DateTime.Now) / 365.25)>65).Count()/await AantalGebruikers())*100;
    private async Task<int> HoogsteLeeftijd() => context.Guests.Select(gast => (EF.Functions.DateDiffDay(gast.GeboorteDatum, DateTime.Now) / 365.25)).Min();
    private async Task<(string dag, int aantal)[]> VerdelingPerDag() => /* ... */;
    private async Task<int> FavorietCorrect() => /* ... */; 
}