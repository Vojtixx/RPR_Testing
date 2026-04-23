using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPR_Unit_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public bool CheckPassword(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Contains("RPR")) return false;
            if (password.Length > 30) return false;
            if (password == "") return false;

            // Ověření, jestli má heslo spec. znak a číslo pomocí ASCII
            foreach(char c in password)
            {
                if(((int)c >= 33 && (int) c <= 47))
                return false;
            }

            return true;
        }
    }
}
