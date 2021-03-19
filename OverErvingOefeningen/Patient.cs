using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    class Patient
    {
        public string Naam { get; set; }
        public int AantalUren { get; set; }
        protected int vasteKostPerUur = 50 + 20;
        private int korting = 10;

        public virtual double BerekenKost()
        {
            return (double)AantalUren * vasteKostPerUur;
        }
        public void ToonInfo()
        {
            Console.WriteLine($"Naam patient:\t{Naam}");
            Console.WriteLine($"Aantal uren:\t{AantalUren}");
            Console.WriteLine($"Totaal:\t{Math.Round(BerekenKost(), 2)}");
        }
    }
    class VerzekerdePatient : Patient
    {
        private int korting = 10;
        public override double BerekenKost()
        {
            return (AantalUren * vasteKostPerUur) * (1 - korting / 100.0);
        }
    }
}
