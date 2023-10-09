using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassenEnEvents.Model
{
    public enum VerschijningsPerioden
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }

    internal class Tijdschrift : Boek
    {
        public VerschijningsPerioden VerschijningsPeriode;

        public Tijdschrift() { }
        public Tijdschrift(int Isbn, string Naam, string Uitgever, double Prijs) : base(Isbn, Naam, Uitgever, Prijs) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Lees()
        {
            Console.WriteLine("Tijdschrift [" + this.ToString() + "] aan het lezen");
        }
    }
}
