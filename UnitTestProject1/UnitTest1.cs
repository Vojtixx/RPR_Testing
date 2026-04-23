using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RPR_Unit_Testing;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /*
        public Form1 form1 = new Form1();

        [TestMethod]
        public void PasswordLengthTest()
        {
            Assert.AreEqual(false, form1.CheckPassword("abcd"));
        }

        public void PasswordContainsRPRTest()
        {
            Assert.AreEqual(false, form1.CheckPassword("123456789"));
        }

        public void PasswordLength30Test()
        {
            Assert.AreEqual(false, form1.CheckPassword("0123456789012345678901234567890"));
        }

        public void PasswordEmptyTest()
        {
            Assert.AreEqual(false, form1.CheckPassword(""));
        }

        public void PasswordCorrectTest()
        {
            Assert.AreEqual(true, form1.CheckPassword("RPRjeNEJ123*"));
        }
        */

        // ---------- ČLEN CECHU ----------

        [TestMethod]
        public void JmenoTest()
        {
            // gut jméno
            ClenCechu c = new ClenCechu("Jouda");
            Assert.AreEqual("Jouda", c.Jmeno);

            // příliš dlouhé jméno
            c.Jmeno = "PřílišDlouhéJménoKteréMěNebavíVymýšlet";
            Assert.AreEqual("Jouda", c.Jmeno);
        }

        [TestMethod]
        public void JmenoNullMezeryTest()
        {
            ClenCechu c = new ClenCechu("Jouda");

            // null jméno
            c.Jmeno = "";
            Assert.AreEqual("Jouda", c.Jmeno);

            // mezery jméno
            c.Jmeno = "      ";
            Assert.AreEqual("Jouda", c.Jmeno);
        }

        [TestMethod]
        public void VychziHodnotyTest()
        {
            ClenCechu c = new ClenCechu("Jouda");
            Assert.AreEqual(100, c.Zdravi);
            Assert.AreEqual(50, c.Energie);
            Assert.AreEqual(1, c.Uroven);
            Assert.IsTrue(c.JeAktivni);
        }

        [TestMethod]
        public void TrenujTest()
        {
            ClenCechu clenCechu = new ClenCechu("Jouda");
            Assert.AreEqual(50, clenCechu.Energie);

            // pokud je zadaná hodnota záporná nebo 0, nic se nestane
            clenCechu.Trenuj(0);
            clenCechu.Trenuj(-50);
            Assert.AreEqual(50, clenCechu.Energie);

            // zvýší energii o zadanou hodnotu
            clenCechu.Trenuj(20);
            Assert.AreEqual(70, clenCechu.Energie);

            // maximální energie je 100
            clenCechu.Trenuj(500);
            Assert.AreEqual(100, clenCechu.Energie);
        }

        [TestMethod]
        public void ZraneniTest()
        {
            ClenCechu c = new ClenCechu("Jouda");
            // pokud je zadaná hodnota záporná nebo 0, nic se nestane
            c.UtrzZraneni(-50);
            c.UtrzZraneni(0);
            Assert.AreEqual(100, c.Zdravi);

            // sníží zdraví o zadanou hodnotu
            c.UtrzZraneni(50);
            Assert.AreEqual(50, c.Zdravi);

            // zdraví nesmí klesnout pod 0
            c.UtrzZraneni(500);
            Assert.AreEqual(0, c.Zdravi);

            // pokud zdraví klesne na 0, vlastnost JeAktivni se nastaví na false
            c.UtrzZraneni(500);
            Assert.AreEqual(false, c.jeAktivni);
        }

        [TestMethod]
        public void OdpocivejTest()
        {
            ClenCechu c = new ClenCechu("Jouda");
            c.UtrzZraneni(30); // 70 HP
            c.Odpocivej(); // +10 HP
            Assert.AreEqual(80, c.Zdravi);
            Assert.AreEqual(55, c.Energie);
        }

        [TestMethod]
        public void OdpocivejLimityTest()
        {
            ClenCechu c = new ClenCechu("Jouda");

            // nesmí překročit max hranici
            for (int i = 0; i < 20; i++)
                c.Odpocivej();

            Assert.AreEqual(100, c.Zdravi);
            Assert.AreEqual(100, c.Energie);

        }

        [TestMethod]
        public void TestToString()
        {
            ClenCechu c = new ClenCechu("Jouda");
            string s = c.ToString();
            Assert.IsTrue(s.Contains("Jouda"));
            Assert.IsTrue(s.Contains("100"));
        }

        // ---------- DOBRODRUH ----------

        [TestMethod]
        public void DobrodruhKonstruktorTest()
        {
            Dobrodruh d = new Dobrodruh("Blud", Dobrodruh.povolani.Válečník, Dobrodruh.zbran.Mec, Dobrodruh.brneni.Kozene);
            Assert.AreEqual(Dobrodruh.povolani.Válečník, d.Povolani);
            Assert.AreEqual(1, d.Uroven);
            Assert.AreEqual(0, d.zkusenosti);
        }

        [TestMethod]
        public void SpravnePovolaniTest()
        {
            Dobrodruh d = new Dobrodruh("Blud", Dobrodruh.povolani.Válečník, Dobrodruh.zbran.Mec, Dobrodruh.brneni.Kozene);
            Assert.AreEqual(Dobrodruh.povolani.Válečník, d.Povolani);
        }

        [TestMethod]
        public void NeplatnePovolaniTest()
        {
            Dobrodruh d = new Dobrodruh("Blud", Dobrodruh.povolani.Válečník, Dobrodruh.zbran.Mec, Dobrodruh.brneni.Kozene);
            d.Povolani = (Dobrodruh.povolani)99;
            Assert.AreEqual(Dobrodruh.povolani.Válečník, d.Povolani);
        }

        [TestMethod]
        public void VychoziZkusenostiTest()
        {
            Dobrodruh d = new Dobrodruh("Blud", Dobrodruh.povolani.Válečník, Dobrodruh.zbran.Mec, Dobrodruh.brneni.Kozene);
            Assert.AreEqual(0, d.zkusenosti);
        }

        [TestMethod]
        public void PridejZkusenostiTest()
        {
            Dobrodruh d = new Dobrodruh("Blud", Dobrodruh.povolani.Válečník, Dobrodruh.zbran.Mec, Dobrodruh.brneni.Kozene);

            // pokud je zadaná hodnota záporná nebo 0, nic se nestane
            d.PridejZkusenosti(-50);
            d.PridejZkusenosti(0);
            Assert.AreEqual(0, d.zkusenosti);

            // přičte zadanou hodnotu zkušeností (10 XP)
            d.PridejZkusenosti(10);
            Assert.AreEqual(10, d.zkusenosti);

            // při každých 100 * Uroven zkušenostech se zvýší úroveň o 1 (10 + 90 XP)
            d.PridejZkusenosti(90);
            Assert.AreEqual(2, d.Uroven);

            d.PridejZkusenosti(400);
            Assert.AreEqual(4, d.Uroven);

            // zkušenosti se po levelupu neanulují, pouze se dál sčítají
            Assert.AreEqual(500, d.zkusenosti);
        }

        [TestMethod]
        public void PouzijSchopnostTest()
        {
            Dobrodruh d = new Dobrodruh("Blud", Dobrodruh.povolani.Válečník, Dobrodruh.zbran.Mec, Dobrodruh.brneni.Kozene);

            // -10 energie
            bool uspech = d.PouzijSchopnost();
            Assert.IsTrue(uspech);
            Assert.AreEqual(40, d.Energie);

            // spotřeba energie na nulu
            for (int i = 0; i < 5; i++)
                d.PouzijSchopnost();

            Assert.AreEqual(0, d.Energie);

            // pokud má méně než 10 energie -> nic se nestane, vrátí false
            bool neuspech = d.PouzijSchopnost();
            Assert.IsFalse(neuspech);
            Assert.AreEqual(0, d.Energie);
        }

        // ---------- OBCHODNÍK ----------
        [TestMethod]
        public void ObchodnikKonstruktoryTest()
        {
            // První konstruktor
            Obchodnik o1 = new Obchodnik("Spytihněv", Obchodnik.typObchodu.Zbrane, true);
            Assert.AreEqual(true, o1.MaSlevu);

            // Druhý konstruktor
            Obchodnik o2 = new Obchodnik("Análie", Obchodnik.typObchodu.Jidlo);
            Assert.AreEqual(false, o2.MaSlevu);
            Assert.AreEqual(10, o2.PocetPredmetu);
        }

        [TestMethod]
        public void VychoziPocetPredmetuTest()
        {
            Obchodnik o = new Obchodnik("Honimír", Obchodnik.typObchodu.Zbrane, true);
            Assert.AreEqual(10, o.PocetPredmetu);
        }

        [TestMethod]
        public void ObchodnikSlevaTrueFalseTest()
        {
            Obchodnik o1 = new Obchodnik("Levnej", Obchodnik.typObchodu.Jidlo, true);
            Obchodnik o2 = new Obchodnik("Drahej", Obchodnik.typObchodu.Jidlo, false);

            Assert.IsTrue(o1.MaSlevu);
            Assert.IsFalse(o2.MaSlevu);
        }

        [TestMethod]
        public void ProdejTest()
        {
            Obchodnik o = new Obchodnik("Honimír", Obchodnik.typObchodu.Jidlo);

            o.Prodej(5);
            Assert.AreEqual(5, o.PocetPredmetu);

            // Záporná hodnota - nic se nestane
            o.Prodej(-10);
            Assert.AreEqual(5, o.PocetPredmetu);

            // Nesmí klesnout pod 0
            o.Prodej(100);
            Assert.AreEqual(0, o.PocetPredmetu);
        }

        [TestMethod]
        public void DoplnZboziTest()
        {
            Obchodnik o = new Obchodnik("Irmhild", Obchodnik.typObchodu.Zbrane);
            o.DoplnZbozi(20);
            Assert.AreEqual(30, o.PocetPredmetu);

            // Záporná hodnota -> beze změny
            o.DoplnZbozi(-5);
            Assert.AreEqual(30, o.PocetPredmetu);
        }

        [TestMethod]
        public void ObchodnikOdpocivejTest()
        {
            Obchodnik o = new Obchodnik("Židoslav", Obchodnik.typObchodu.Jidlo);
            o.UtrzZraneni(20);

            o.Odpocivej();

            Assert.AreEqual(85, o.Zdravi);
            Assert.AreEqual(50, o.Energie);
        }
    }
}
