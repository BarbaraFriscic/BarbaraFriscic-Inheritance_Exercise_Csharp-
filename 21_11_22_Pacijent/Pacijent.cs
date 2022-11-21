using _21_11_22_Pacijent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_11_22_Pacijent
{
    internal class Pacijent 
    {
        public int BrojPacijenta { get; set; }
        public string ImePacijenta { get; set; }
        public int GodinePacijenta { get; set; }
        public double Racun { get; set; }

        public Pacijent (int brPac, string imePac, int godPac, double racun)
        {
            this.BrojPacijenta = brPac;
            this.ImePacijenta = imePac;
            this.GodinePacijenta= godPac;
            this.Racun = racun;
        }
        public override string ToString()
        {
            return $"{BrojPacijenta} - {ImePacijenta} - {GodinePacijenta} godina -> Račun: {Racun}";
        }
        
    }
    class OsiguraniPacijent : Pacijent, IComparable
    {
        public OsiguraniPacijent(int brPac, string imePac, int godPac, double racun, string tipOsig) : base(brPac, imePac, godPac, racun)
        {
            this.TipOsiguranja = tipOsig;
        }

        protected string tipOsiguranja;
        protected double postotakOsiguranja;

        public string TipOsiguranja
        {
            get { return tipOsiguranja; }
            set 
            { 
                tipOsiguranja = value;
                if (tipOsiguranja == "osnovno" || tipOsiguranja == "Osnovno" || tipOsiguranja == "osn" || tipOsiguranja == "OSN")
                {
                    postotakOsiguranja = 0.25;
                    tipOsiguranja = "osnovno";
                }
                else if (tipOsiguranja == "dopunsko" || tipOsiguranja == "Dopunsko" || tipOsiguranja == "dop" || tipOsiguranja == "DOP")
                {
                    postotakOsiguranja = 0.6;
                    tipOsiguranja = "dopunsko";
                }
                else if (tipOsiguranja == "VIP" || tipOsiguranja == "vip" || tipOsiguranja == "Vip")
                {
                    postotakOsiguranja = 0.8;
                    tipOsiguranja = "VIP";
                }
                else
                    postotakOsiguranja = 0;
            }
        }
        public double PostotakOsiguranja
        {
            get { return postotakOsiguranja; }
        }
        public double PreostaliIznosNaplate()
        {
            return Racun - (Racun * PostotakOsiguranja);
        }
        public override string ToString()
        {
            return $"{BrojPacijenta} - {ImePacijenta} - {GodinePacijenta} godina -> Račun: {Racun:C} \n     Tip osiguranja: {TipOsiguranja} - Postotak koji osiguranje pokriva: {PostotakOsiguranja:P2} - Preostali iznos za platiti: {PreostaliIznosNaplate():C} \n";
        }

        int IComparable.CompareTo(object obj)
        {
            OsiguraniPacijent temp = (OsiguraniPacijent)obj;
            if (this.BrojPacijenta > temp.BrojPacijenta)
                return 1;
            else if (this.BrojPacijenta < temp.BrojPacijenta)
                return -1;
            else
                return 0;
        }
    }
} 
