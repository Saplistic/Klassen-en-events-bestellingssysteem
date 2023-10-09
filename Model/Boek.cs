using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassenEnEvents.Model
{
    internal class Boek
    {
        public int Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }
        private double prijs;
        public double Prijs
        {

            get { return prijs; }
            set
            {
                if (value > 50)
                {
                    prijs = 50;
                }
                else if (value < 5)
                {
                    prijs = 5;
                }
                else
                {
                    prijs = value;
                }
            }

        }
        public static List<Boek> Boeken { get; set; } = new List<Boek>();

        public Boek() {}
        public Boek(int Isbn, string Naam, string Uitgever, double Prijs)
        {
            this.Isbn = Isbn;
            this.Naam = Naam;
            this.Uitgever = Uitgever;
            this.Prijs = Prijs;
            Boeken.Add(this);
            Console.WriteLine("boek nr:" + Boeken.Count);
        }

        public override string ToString()
        {
            return $"Naam: {Naam}, Uitgever: {Uitgever}, Prijs: {Prijs}, Isbn: {Isbn}";
        }

        public virtual void Lees()
        {
            Console.WriteLine("Boek [" + this.ToString() + "] aan het lezen");
        }

    }
}
 