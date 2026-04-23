using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPR_Unit_Testing.Dobrodruh;

namespace RPR_Unit_Testing
{
    public class Dobrodruh : ClenCechu
    {
        private povolani p;
        public enum povolani
        {
            Válečník,
            Hraničář,
            Mág,
            Zloděj
        }

        public enum zbran
        {
            Mec,
            Luk,
            Hul,
            Dyky
        }

        public enum brneni
        {
            Latove,
            Kozene,
            Latkove,
        }

        public povolani Povolani
        {
            get => p;
            set
            {
                if (Enum.IsDefined(typeof(povolani), value))
                    p = value;
            }

        }

        private zbran Zbran;
        private brneni Brneni;

        public int uroven = 1;
        public int zkusenosti = 0;

        public Dobrodruh(string jmeno, povolani povolani, zbran zbran, brneni brneni) : base(jmeno)
        {
            this.Povolani = povolani;
            this.Zbran = zbran;
            this.Brneni = brneni;
        }

        public void PridejZkusenosti(int xp)
        {
            if (xp <= 0)
                return;

            zkusenosti += xp;
            int p = zkusenosti;

            while (p >= Uroven * 100)
            {
                p -= Uroven * 100;
                Uroven++;
            }

        }

        public bool PouzijSchopnost()
        {
            if (Energie >= 10)
            {
                Energie -= 10;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPovolání: {Povolani}" +
                $"\nVýbava: {Zbran}, {Brneni}";
        }
    }
}
