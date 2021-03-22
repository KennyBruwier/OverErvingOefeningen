using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    enum DierSoort
    {
        Kat,
        Hond,
        Vis,
        Koe
    }
    abstract class Dier
    {
        public int Gewicht { get; set; }
        public virtual string Naam { get; set; }

        public virtual DierSoort Soort { get; set; }

        abstract public void Zegt();

        public void OverZicht()
        {
            Console.WriteLine(string.Format("\t{0,-6}:{1,-30}\t{2,4}kg", Soort, Naam, Gewicht));
        }

    }
    class Kat : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = value; }
        public override void Zegt()
        {
            Console.WriteLine("Who's the boss? You wish!");
        }
        public Kat(int gewicht, string naam = "Kat")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Kat;
        }
        public Kat()
        {
            Soort = DierSoort.Kat;
        }
    }
    class Hond : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = value; }

        public override void Zegt()
        {
            Console.WriteLine("Eten! eten! eten! ... waar is mijn eten!!!");
        }
        public Hond(int gewicht, string naam = "Hond")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Hond;
        }
        public Hond()
        {
            Soort = DierSoort.Hond;
        }
    }
    class Vis : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = value; }
        public override void Zegt()
        {
            Console.WriteLine(" ....  ....  .... !#?! .... ");
        }
        public Vis(int gewicht, string naam = "Vis")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Vis;
        }
        public Vis()
        {
            Soort = DierSoort.Vis;
        }
    }
    class Koe : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = DierSoort.Koe; }
        public override void Zegt()
        {
            Console.WriteLine("LEEEEEEEEOOOOOO!");
        }
        public Koe(int gewicht, string naam = "Koe")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Koe;
        }
        public Koe()
        {
            Soort = DierSoort.Koe;
        }
    }
}
