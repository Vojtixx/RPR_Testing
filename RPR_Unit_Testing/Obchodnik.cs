using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR_Unit_Testing
{
    public class Obchodnik : ClenCechu
    {
        public enum typObchodu
        {
            Lektvary,
            Zbrane,
            Brneni,
            Jidlo
        }

        public typObchodu TypObchodu { get; set; }
        public bool MaSlevu { get; set; }
        public int PocetPredmetu { get; set; } = 10;

        public bool maSlevu = true;
        public int pocetPredmetu = 10;

        public Obchodnik(string jmeno, typObchodu typObchodu, bool sleva) : base(jmeno)
        {
            TypObchodu = typObchodu;
            MaSlevu = sleva;
        }

        public Obchodnik(string jmeno, typObchodu typObchodu) : this(jmeno, typObchodu, false)
        {

        }

        public void Prodej(int pocet)
        {
            if (pocet > 0)
                PocetPredmetu = Math.Max(0, PocetPredmetu - pocet);
        }

        public void DoplnZbozi(int pocet)
        {
            if (pocet > 0)
                PocetPredmetu += pocet;
        }

        public override void Odpocivej()
        {
            Zdravi = Math.Min(100, Zdravi + 5);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nObchod: {TypObchodu}" +
                $"\nZboží: {PocetPredmetu}";
        }
    }
}
