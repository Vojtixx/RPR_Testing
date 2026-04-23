using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR_Unit_Testing
{
    public class ClenCechu
    {
        public string jmeno;
        public int energie;
        public int zdravi;
        public bool jeAktivni;

        public string Jmeno
        {
            get => jmeno;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("Neplatné jméno!");
                else if (value.Length > 12)
                    Console.WriteLine("Jméno je příliš dlouhé!");
                else
                    jmeno = value;
            }
        }

        public int Zdravi { get; protected set; } = 100;
        public int Energie { get; protected set; } = 50;
        public int Uroven { get; protected set; } = 1;
        public bool JeAktivni { get; protected set; } = true;

        public ClenCechu(string jmeno)
        {
            Jmeno = jmeno;
        }

        public void Trenuj(int pocet)
        {
            if (pocet <= 0)
                return;

            Energie = Math.Min(100, Energie + pocet);
        }

        public void UtrzZraneni(int dmg)
        {
            if (dmg <= 0)
                return;

            Zdravi -= dmg;

            if (Zdravi < 0)
            {
                Zdravi = 0;
                JeAktivni = false;
            }
        }

        public virtual void Odpocivej()
        {
            Zdravi = Math.Min(100, Zdravi + 10);
            Energie = Math.Min(100, Energie + 5);
        }

        public override string ToString()
        {
            return $"Jméno: {Jmeno}" +
                $"\nZdraví: {Zdravi}" +
                $"\nEnergie: {Energie}" +
                $"\nÚroveň: {Uroven}" +
                $"\nJe Aktivní: {JeAktivni}";
        }
    }
}
