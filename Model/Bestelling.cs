using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassenEnEvents.Model
{
    public delegate void BestellingEventHandeler(string message);
    internal class Bestelling<T>
    {
        private static int idTeller = 1;
        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set { _id = idTeller++; /*Console.WriteLine("set id to" + Id);*/ }
        }
        public T Item { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? Periode { get; set; } = null;
        public int Aantal { get; set; } = 1;
        public static event BestellingEventHandeler OnBestelling;

        public Bestelling()
        {
            Id = 0; //roep setter van Id om deze te updaten bij instantiatie van een object
        }

        public Tuple<int, int, double>? Bestel(T boek)
        {
            Item = boek;
            Datum = DateTime.Now;
            Console.WriteLine(boek.GetType());

            if (Item is Tijdschrift t) //een tijdschrift kan ook true returned (tijds. : boek) dus controleren we eerst of type een tijdschrijft is
            {
                OnBestelling?.Invoke($"Bestelling aangemaakt van tijdschrift [{t.ToString()}], op {Datum}. BestellingsId: {Id}");
                double totaalprijs = t.Prijs * Aantal;
                return new Tuple<int, int, double>(t.Isbn, Aantal, totaalprijs);
            }

            if (Item is Boek b)
            {
                OnBestelling?.Invoke($"Bestelling aangemaakt voor boek [{b.ToString()}], op {Datum}. BestellingsId: {Id}");
                double totaalprijs = b.Prijs * Aantal;
                return new Tuple<int, int, double>(b.Isbn, Aantal, totaalprijs);
            }

            return null;
        }
    }
}
