using KlassenEnEvents.Model;
using System.Transactions;

namespace KlassenEnEvents
{
    internal class Program
    {
        public static void Bestelling(string bericht)
        {
            Console.WriteLine(bericht);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Bestelling<Boek>.OnBestelling += Bestelling;

            var boek1 = new Boek(456451, "NPel", "test", 7);
            var boek2 = new Boek(216487, "Ngix", "saml", 11);
            var tijdschrift1 = new Tijdschrift(137699, "Ngix", "saml", 51);
            var tijdschrift2 = new Tijdschrift(791846, "Folk", "NesG", 2);

            Bestelling<Boek> bestelling1 = new Bestelling<Boek> { };
            bestelling1.Aantal = 4;
            Bestelling<Boek> bestelling2 = new Bestelling<Boek> { };
            bestelling2.Aantal = 1;
            Bestelling<Boek> bestelling3 = new Bestelling<Boek> { };
            Bestelling<Boek> bestelling4 = new Bestelling<Boek> { };

            bestelling1.Bestel(boek1);
            bestelling2.Bestel(boek2);
            bestelling3.Bestel(tijdschrift1);
            bestelling4.Bestel(tijdschrift2);

            int keuze;
            int isbn;
            double prijsWaarde;

            do
            {
                Console.WriteLine("---=Boekwinkel Menu=---" +
                    "\n1) Een boek toevoegen" +
                    "\n2) Een tijdschrift toevoegen" +
                    "\n3) Alle boeken weergeven");

                if (!int.TryParse(Console.ReadLine(), out keuze))
                {
                    keuze = -1;
                }

                switch (keuze)
                {
                    case 1:
                        Boek nieuwBoek = new Boek();

                        Console.WriteLine("Geef de naam in van je boek:");
                        nieuwBoek.Naam = Console.ReadLine();

                        Console.WriteLine("Geef de naam in van de auteur:");
                        nieuwBoek.Uitgever = Console.ReadLine();


                        Console.WriteLine("Geef de prijs in van je tijdschrift (5 - 50):");
                        if (!double.TryParse(Console.ReadLine(), out prijsWaarde))
                        {
                            break;
                        }
                        nieuwBoek.Prijs = prijsWaarde;

                        Console.WriteLine("Geef het ISBN nummer in van je boek:");
                        if (!int.TryParse(Console.ReadLine(), out isbn))
                        {
                            break;
                        }
                        nieuwBoek.Isbn = isbn;

                        Boek.Boeken.Add(nieuwBoek);
                        Console.WriteLine("Succesvol een boek aangemaakt " + nieuwBoek.ToString());
                        break;
                    case 2:
                        Tijdschrift nieuwTijdschrift = new Tijdschrift();

                        Console.WriteLine("Geef de naam in van je tijdschrift:");
                        nieuwTijdschrift.Naam = Console.ReadLine();
                        nieuwTijdschrift.Naam = Console.ReadLine();

                        Console.WriteLine("Geef de naam in van de auteur:");
                        nieuwTijdschrift.Uitgever = Console.ReadLine();

                        Console.WriteLine("Geef de prijs in van je tijdschrift (5 - 50):");
                        if (!double.TryParse(Console.ReadLine(), out prijsWaarde))
                        {
                            break;
                        }
                        nieuwTijdschrift.Prijs = prijsWaarde;

                        Console.WriteLine("Geef het ISBN nummer in van je tijdschrift:");
                        if (!int.TryParse(Console.ReadLine(), out isbn))
                        {
                            break;
                        }
                        nieuwTijdschrift.Isbn = isbn;

                        Boek.Boeken.Add(nieuwTijdschrift);
                        Console.WriteLine("Succesvol een tijdschrift aangemaakt: " + nieuwTijdschrift.ToString());
                        break;
                    case 3:
                        foreach (var boek in Boek.Boeken)
                        {
                            Console.WriteLine(boek.ToString());
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geen geldige optie");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine();
            } while (true);

        }
    }
}