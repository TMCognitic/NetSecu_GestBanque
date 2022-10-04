namespace GestBanque.Models.Interfaces
{
    public interface IBanker : ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }

        void AppliquerInteret();
    }
}