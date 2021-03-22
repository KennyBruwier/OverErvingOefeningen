using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    public abstract class mRekening
    {
        private double saldo;
        public double Saldo
        {
            get { return saldo; }
            private set { saldo = value; }
        }

        public double HaalGeldAf(double bedrag)
        {
            Saldo -= bedrag;
            return bedrag;
        }

        public double VoegGeldToe(double bedrag)
        {
            Saldo += bedrag;
            return bedrag;
        }
        public abstract double BerekenRente();

        public mRekening(double bedrag)
        {
            Console.WriteLine(VoegGeldToe(bedrag) + " gestort");
        }
        public mRekening()
        {

        }

    }
    public class mBankRekening : mRekening
    {
        public override double BerekenRente()
        {
            if (Saldo > 100) return Saldo * 0.05;
            return 0;
        }
        public mBankRekening(double bedrag)
        {
            Console.WriteLine(VoegGeldToe(bedrag) + " gestort");
        }
        public mBankRekening()
        {

        }
    }
    public class mSpaarRekening : mRekening
    {
        public override double BerekenRente()
        {
            return Saldo * 0.02;
        }
        public mSpaarRekening(double bedrag)
        {
            Console.WriteLine(VoegGeldToe(bedrag) + " gestort");
        }
        public mSpaarRekening()
        {

        }
    }
    public class mProRekening : mSpaarRekening
    {
        public override double BerekenRente()
        {
            if (Saldo > 999)
            {
                int duizendTal = (int)(Saldo / 1000);
                if (duizendTal > 0)
                {
                    return base.BerekenRente() + 10 * duizendTal;
                }
            }
            return base.BerekenRente();
        }
        public mProRekening(double bedrag)
        {
            Console.WriteLine(VoegGeldToe(bedrag) + " gestort");
        }
        public mProRekening()
        {

        }
    }
}
