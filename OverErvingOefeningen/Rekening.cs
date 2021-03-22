using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    enum TypeRekening
    {
        Debitrekening,
        Creditrekening,
        Spaarrekening
    }
    class Rekening
    {
        public string Naam { get; set; }
        private string rekeningNr;

        public virtual string RekeningNr
        {
            get { return rekeningNr; }
            set { rekeningNr = "BE" + value; }
        }

        public virtual TypeRekening Type { get; set; } = TypeRekening.Debitrekening;
        public double Saldo { get; set; }
        public virtual bool onderNul { get; set; } = false;

        public Rekening(int bedrag, string naam = "Geen", string rekenNr = "")
        {
            Saldo = bedrag;
            Naam = naam;
            RekeningNr = rekenNr;
        }
        public Rekening()
        {
        }

        public void OpenRekening(bool clear = false, double bedrag = 0)
        {
            if (clear) Console.Clear();
            Naam = InputStr("Naam: ");
            RekeningNr = InputStr("Rekening nummer: ");
            this.Saldo = bedrag;
            if (Type == TypeRekening.Creditrekening) onderNul = true;
        }

        private string RekeningNrInput()
        {
            return "";
        }
        public double Afhalen(double bedrag)
        {
            double bedragAfgehaald = 0;
            if (Saldo - bedrag < 0)
                if (onderNul) Saldo -= bedragAfgehaald = bedrag;
                else Msg($"{Saldo} - {bedrag} = {Saldo - bedrag} (niet toegelaten)");
            else Saldo -= bedragAfgehaald = bedrag;
            return bedragAfgehaald;
        }

        public double Storten(double bedrag)
        {
            double bedragGestort = 0;
            if (Saldo + bedrag < 0)
                if (onderNul) Saldo += bedragGestort = +bedrag;
                else Msg($"{Saldo} + {bedrag} = {Saldo + bedrag} (niet toegelaten)");
            else Saldo += bedragGestort = bedrag;
            return bedragGestort;
        }

        public void Overzicht()
        {
            Console.Write(String.Format("{0,20} - {1,-20}:{2,-30}\tSaldo: ", Naam,Type,RekeningNr,Saldo));
            if (Saldo < 0)
            {
                ConsoleColor front = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0,-20}",Saldo));
                Console.ForegroundColor = front;
            }
            else
                Console.WriteLine(Saldo);

        }
        string InputStr(params string[] tekst)
        {
            for (int i = 0; i < tekst.GetLength(0); i++)
                if (tekst.GetLength(0) == 1) Console.Write(tekst[i]);
                else Console.WriteLine(tekst[i]);
            return Console.ReadLine();
        }
        bool InputBool(string tekst = "j/n", bool Cyes = true, bool Cno = false)
        {
            Console.WriteLine(tekst);
            switch (Char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case 'y':
                case 'j': return Cyes;
                case 'n': return Cno;
            }
            return false;
        }
        double InputDbl(string tekst = "Getal: ")
        {
            Console.Write(tekst);
            return double.Parse(Console.ReadLine());
        }
        private void Msg(string bericht)
        {
            Console.WriteLine(bericht);
            Console.ReadKey(true);
        }
    }

    class DebitRekening : Rekening
    {
        public override TypeRekening Type { get => base.Type; set => base.Type = value; } // default waarde werkt niet
        public DebitRekening(int bedrag, string naam = "geen", string rekenNr = "")
        {
            Saldo = bedrag;
            Naam = naam;
            RekeningNr = rekenNr;
            Type = TypeRekening.Debitrekening;
        }
        public DebitRekening()
        {
            Type = TypeRekening.Debitrekening;
        }
    }
    class CreditRekening : Rekening
    {
        public override TypeRekening Type { get => base.Type; set => base.Type = value; }
        public string extraNr;
        public override string RekeningNr { get => base.RekeningNr; set => base.RekeningNr = value + extraNr; }
        public CreditRekening(int bedrag, string extraNr, string naam = "geen", string rekenNr = "")
        {
            Saldo = bedrag;
            Naam = naam;
            RekeningNr = rekenNr;
            Type = TypeRekening.Creditrekening;
            onderNul = true;
        }
        public CreditRekening()
        {
            Type = TypeRekening.Creditrekening;
        }
    }
    class SpaarRekening : Rekening
    {
        public override TypeRekening Type { get => base.Type; set => base.Type = value; }

        public SpaarRekening(int bedrag, string naam = "geen", string rekenNr = "")
        {
            Saldo = bedrag;
            Naam = naam;
            Type = TypeRekening.Spaarrekening;
        }
        public SpaarRekening()
        {
            Type = TypeRekening.Spaarrekening;
        }
    }
}
