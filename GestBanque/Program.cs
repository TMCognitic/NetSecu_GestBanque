using GestBanque.Models;
using System.Data.Common;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque("Technofutur Bank");

            Personne chuckNorris = new Personne("Norris", "Chuck", new DateTime(1940, 3, 10));

            Courant compte1 = new Courant("00001", 500, chuckNorris);

            Epargne compte2 = new Epargne("00002", chuckNorris);

            banque.Ajouter(compte1);
            banque.Ajouter(compte2);

            banque["00001"]?.Depot(-500);
            banque["00001"]?.Depot(500);
            banque["00001"]?.Retrait(-750);
            banque["00001"]?.Retrait(750);

            banque["00002"]?.Depot(500);

            banque["00001"]?.AppliquerInteret();
            banque["00002"]?.AppliquerInteret();

            if (banque["00001"] is not null)
            {
                Console.WriteLine($"Solde du compte '{banque["00001"]!.Numero}' : {banque["00001"]!.Solde}");
            }

            if (banque["00002"] is not null)
            {
                Console.WriteLine($"Solde du compte '{banque["00002"]!.Numero}' : {banque["00002"]!.Solde}");
            }

            Console.WriteLine($"Avoir des comptes de {chuckNorris.Prenom} {chuckNorris.Nom} : {banque.AvoirDesComptes(chuckNorris)}");
        }
    }
}