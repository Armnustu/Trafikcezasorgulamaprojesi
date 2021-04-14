using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafikCezaVeSorulma
{
    public partial class AraçplakasınaYazılanTrafikcezaSorgulama : Form
    {
        public AraçplakasınaYazılanTrafikcezaSorgulama()
        {
            InitializeComponent();
        }

        private void AraçplakasınaYazılanTrafikcezaSorgulama_Load(object sender, EventArgs e)
        {
          
        }
        private void Button2_Click(object sender, EventArgs e)
        {
           OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from [plakacezasorgulama$]", con);
            OleDbDataReader rd = komut.ExecuteReader();
            if (txtisim.Text != "" && txtsoyisim.Text != "" && txttcnumara.Text.ToString() != "" && txtdgmtarihi.Text != "")
            {
                bool durum = false;
                while (rd.Read()) 
                {

                    if (rd["ADI"].ToString() == txtisim.Text)
                    {

                        if (rd["SOYADI"].ToString() == txtsoyisim.Text)
                        {

                            if (rd["TCNO"].ToString() == txttcnumara.Text)
                            {

                                if (Convert.ToInt32(rd["DOĞUMYILI"].ToString()) == Convert.ToInt32(txtdgmtarihi.Text.ToString()))
                                {
                                    if (rd["PLAKA"].ToString() == textplaka.Text.ToString())
                                    {

                                        if (Convert.ToDateTime(rd["TESCİL TARİHİ"].ToString()) == Convert.ToDateTime(msktcezatarih.Text.ToString()))
                                        {
                                            MessageBox.Show("ARANILAN KULLANICI MEVCUTTUR");
                                            durum = true;
                                            break;
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
                if (durum == false)
                {

                    MessageBox.Show("ARANILAN KULLANICI MEVCUT DEĞİLDİR");

                }
            }
            else
            {
                MessageBox.Show("KULLANICI BİLGiLERİ BOŞ GEÇİLEMEZ");

            }

            con.Close();
        }

        private void Txtisim_TextChanged(object sender, EventArgs e)
        {
            txtisim.Text = txtisim.Text.ToUpper();
            txtisim.SelectionStart = txtisim.Text.Length;
        }
        private void txtsoyisim_TextChanged_1(object sender, EventArgs e)
        {
            txtsoyisim.Text = txtsoyisim.Text.ToUpper();
            txtsoyisim.SelectionStart = txtsoyisim.Text.Length;
        }

        private void textplaka_TextChanged(object sender, EventArgs e)
        {
            textplaka.Text = textplaka.Text.ToUpper();
            textplaka.SelectionStart = textplaka.Text.Length;
        }

        private void msktcezatarih_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anaform frm = new Anaform();
            frm.ShowDialog();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anaform F = new Anaform();
            F.ShowDialog();
        }
    }
}
