using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    abstract class GeometricFigure
    {
        public int Hoogte { get; set; }
        public int Breedte { get; set; }
        public int Oppervlakte { get; private set; }

        public abstract int BerekenOppervlakte();
        public GeometricFigure(int hoogte, int breedte)
        {
            Hoogte = hoogte;
            Breedte = breedte;
        }

    }
    class Rechthoek : GeometricFigure
    {
        public override int BerekenOppervlakte()
        {
            return Hoogte * Breedte;
        }
        public Rechthoek(int hoogte, int breedte) : base(breedte,hoogte)
        {
            Hoogte = hoogte;
            Breedte = breedte;
        }
    }

    class Vierkant : Rechthoek
    {

        public Vierkant(int hoogte, int breedte = 0) : base(breedte,hoogte)
        {
            Hoogte = hoogte;
            Breedte = hoogte;
        }
    }

    class Driehoek : GeometricFigure
    {
        public override int BerekenOppervlakte()
        {
            return base.Oppervlakte / 2;
        }
        public Driehoek(int hoogte, int breedte) : base(hoogte, breedte)
        {
            Hoogte = hoogte;
            Breedte = breedte;
        }
    }
}
