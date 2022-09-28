namespace DBOpdracht;
using Microsoft.EntityFrameworkCore;


public class Gebruiker{
    
    public string Email {get;set;}
    
    public Gebruiker(string Email){
        this.Email = Email;
    }
    
}
