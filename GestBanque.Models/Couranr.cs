namespace GestBanque.Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                    throw new InvalidOperationException("La ligne de crédit est strictement positive!");

                _ligneDeCredit = value;
            }
        }

        /// <summary>
        /// Constructeur de la classe Courant
        /// </summary>
        /// <param name="numero">Représente le numéro du compte</param>
        /// <param name="titulaire">Représente le propriétaire du compte</param>
        public Courant(string numero, Personne titulaire)
            : base(numero, titulaire)
        {
        }

        public Courant(string numero, Personne titulaire, double solde)
            : base(numero, titulaire, solde)
        {
        }

        public Courant(string numero, double ligneDeCredit, Personne titulaire)
            : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }

        protected override double CalculInteret()
        {
            return Solde * ((Solde < 0) ? .0975 : .03);
        }
    }
}