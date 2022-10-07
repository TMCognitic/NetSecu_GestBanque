using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestBanque.ExoCarwash
{
    public class Carwash
    {
        private CarwashDelegate _carwash;

        public Carwash()
        {
            //_carwash += Preparer;
            //_carwash += Laver;
            //_carwash += Secher;
            //_carwash += Finaliser;
            //ou
            //Méthode anonyme classique
            _carwash += delegate(Voiture voiture) { Console.WriteLine($"Je prépare la voiture : {voiture.Plaque}"); };
            //Lambda de type Instruction
            _carwash += (voiture) => { Console.WriteLine($"Je lave la voiture : {voiture.Plaque}"); };
            //Lambda de type Expression
            _carwash += (voiture) => Console.WriteLine($"Je sèche la voiture : {voiture.Plaque}");
            _carwash += (voiture) => Console.WriteLine($"Je finalise la voiture : {voiture.Plaque}");
        }

        public void Traiter(Voiture v)
        {
            _carwash.Invoke(v);
        }

        private void Preparer(Voiture voiture)
        {
            Console.WriteLine($"Je prépare la voiture : {voiture.Plaque}");
        }

        private void Laver(Voiture voiture)
        {
            Console.WriteLine($"Je lave la voiture : {voiture.Plaque}");
        }

        private void Secher(Voiture voiture)
        {
            Console.WriteLine($"Je sèche la voiture : {voiture.Plaque}");
        }

        private void Finaliser(Voiture voiture)
        {
            Console.WriteLine($"Je finalise la voiture : {voiture.Plaque}");
        }
    }
}
