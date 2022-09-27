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
        ret += $"Het percentage bejaarden is { await PercentageBejaarden() }%\n";

        ret += $"De oudste gast heeft een leeftijd van { await HoogsteLeeftijd() } \n";

        ret += "De verdeling van de gasten per dag is als volgt: \n";
        // var dagAantallen = await VerdelingPerDag();
        // var totaal = dagAantallen.Select(t => t.aantal).Max();
        // foreach (var dagAantal in dagAantallen)
        //     ret += $"{ dagAantal.dag }: { new string('#', (int)(dagAantal.aantal / (double)totaal * 20)) }\n";

        ret += $"{ await FavorietCorrect() } gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

        return ret;
    }
    private async Task<int> AantalGebruikers() => context.Users.Count();
    private async Task<bool> AlleGastenHebbenReservering() => context.Guests.Where<Gast>(gast => gast.reservering.Count() > 0).Count() == context.Guests.Count(); //Incredibly slow.
    private async Task<int> AantalSinds(DateTime sinds) => context.Guests.Where<Gast>(gast => gast.EersteBezoek > sinds).Count();
    private async Task<Gast> GastBijEmail(string email) => context.Guests.First<Gast>(gast => gast.Email == email); 
    private async Task<Gast?> GastBijGeboorteDatum(DateTime d) => context.Guests.First<Gast>(gast => gast.GeboorteDatum == d);
    private async Task<double> PercentageBejaarden() => ((double)(context.Guests.Where<Gast>(gast => (int)(EF.Functions.DateDiffDay(gast.GeboorteDatum, DateTime.Now)/365.25)>75).Count())/(double)(context.Guests.Count()))*100;
    private async Task<int> HoogsteLeeftijd() => context.Guests.Select(gast => (int)(EF.Functions.DateDiffDay(gast.GeboorteDatum, DateTime.Now) / 365.25)).Max();
    //private async Task<(string dag, int aantal)[]> VerdelingPerDag() => ;
    private async Task<int> FavorietCorrect() => context.Guests.Where(gast => gast.FavorieteAttractie !=null).Where(gast => gast.reservering.Count() > 0).Where(gast => gast.reservering.Any(r => r.ReservedAttractions.Contains(gast.FavorieteAttractie))).Count();
    //Check if guests have a favorite, check if they have/had reservations and if so, check if their favorite attraction was included in any reservation.
    //Currently don't really have a way to monitor if they have visited their favorite the most tho afaik. unless we go of reservations again but that would be annoying and tedious 











    /* Nothing to see here, just debug testing*/
    // public async Task<int> brithdaysDEBUG() => context.Guests.Where<Gast>(gast => gast.GeboorteDatum < (DateTime.Now).AddYears(-75)).Count();
    // public async Task<double> brithdaysDEBUGEFC() => ((double)(context.Guests.Where<Gast>(gast => ((int)(EF.Functions.DateDiffDay(gast.GeboorteDatum, DateTime.Now)/365.25))>75).Count())/(double)(context.Guests.Count()))*100;
    // public async Task<int> UserAmountDEBUG() => context.Guests.Count();

    // public async Task<double> birthdaysDEBUG_EFC_FULL(){
    //     int senior_amt = context.Guests.Where<Gast>(gast => ((int)(EF.Functions.DateDiffDay(gast.GeboorteDatum, DateTime.Now)/365.25))>75).Count();
    //     int guest_amt = context.Guests.Count();
    //     double senior_prct = ((double)senior_amt/(double)guest_amt);
    //     return senior_prct;
    // }
}