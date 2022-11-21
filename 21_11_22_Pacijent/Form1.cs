using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_11_22_Pacijent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            txtNumPacijent.Focus();
        }
        OsiguraniPacijent[] pacijenti = new OsiguraniPacijent[3];
        int counter = 0;

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtNumPacijent.Text == "")
            {
                MessageBox.Show("Unesite broj pacijenta");
                txtNumPacijent.Focus();
            }
            else if (txtNamePacijent.Text == "")
            {
                MessageBox.Show("Unesite ime pacijenta");
                txtNamePacijent.Focus();
            }
            else if (txtYearPacijent.Text == "")
            {
                MessageBox.Show("Unesite godine pacijenta");
                txtYearPacijent.Focus();
            }
            else if (txtChargePacijent.Text == "")
            {
                MessageBox.Show("Unesite iznos računa pacijenta");
                txtChargePacijent.Focus();
            }
            else if (txtInsuranceType.Text == "")
            {
                MessageBox.Show("Unesite tip osiguranja pacijenta");
                txtInsuranceType.Focus();
            }
            else
            {   
                pacijenti[counter] = new OsiguraniPacijent(Convert.ToInt32(txtNumPacijent.Text), txtNamePacijent.Text, Convert.ToInt32(txtYearPacijent.Text), Convert.ToDouble(txtChargePacijent.Text), txtInsuranceType.Text);
                txtNumPacijent.Clear();
                txtNumPacijent.Focus();
                txtNamePacijent.Clear();
                txtYearPacijent.Clear();
                txtChargePacijent.Clear();
                txtInsuranceType.Clear();

                counter++;

                if(counter == pacijenti.Length)
                {
                    txtNumPacijent.Enabled = false;
                    txtNamePacijent.Enabled = false;
                    txtYearPacijent.Enabled = false;
                    txtInsuranceType.Enabled = false;
                    txtChargePacijent.Enabled = false;

                    Array.Sort(pacijenti);

                    for (int i = 0; i < pacijenti.Length; i++)
                    {
                        lblShowReturn.Text += pacijenti[i].ToString();
                    }
                    lblShowReturn.Text += $"\nSvi osigurani pacijenti ukupno moraju platiti: {UkupniIznosNaplata(pacijenti):C}";
                }
            }
        }
        double UkupniIznosNaplata(params OsiguraniPacijent[] pacijenti)
        {
            double ukupniIznosNaplata = 0;
            for(int i = 0; i < pacijenti.Length; i++)
            {
                ukupniIznosNaplata += pacijenti[i].PreostaliIznosNaplate();
            }
            return ukupniIznosNaplata;
        }
    }
}
