using System.Runtime.Serialization;

namespace GestBanque.Models
{
    [Serializable]
    internal class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException() : base("Solde Insuffisant")
        {
        }        
    }
}