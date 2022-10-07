namespace GestBanque.Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();
        public string Nom { get; init; }

        public Compte? this[string numero]
        {
            get
            {
                _comptes.TryGetValue(numero, out Compte? compte);
                return compte;
            }
        }

        public Banque(string nom)
        {
            Nom = nom;
        }

        public void Ajouter(Compte compte)
        {
            compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            _comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            //if (!_comptes.ContainsKey(numero))
            //{
            //    throw new KeyNotFoundException($"la clé '{numero}' n'a été trouvée dans le dictionnaire");
            //}

            Compte compte = _comptes[numero];
            compte.PassageEnNegatifEvent -= PassageEnNegatifAction;
            _comptes.Remove(numero);            
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0;

            foreach (Compte compte in _comptes.Values)
                if (compte.Titulaire == titulaire)
                    total += compte;

            return total;
        }

        private void PassageEnNegatifAction(Compte compte)
        {
            Console.WriteLine($"Le compte {compte.Numero} vient de passer en négatif");
        }
    }
}