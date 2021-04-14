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
    public partial class SürücüBelgesineYazılanCezaSorulama : Form
    {
        public SürücüBelgesineYazılanCezaSorulama()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from [SürücüyeYazılanCezaSorgulama$]", con);
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
                                    if (rd["SÜRÜCÜ TC NO"].ToString() == txttcno.Text.ToString())
                                    {

                                        if (rd["NUFUS CÜZDAN HARF SERİ"].ToString() == txtnufusHarfseriNo.Text.ToString())
                                        {

                                            if (Convert.ToInt32(rd["NUFUS CÜZDAN SERİ NO"].ToString()) == Convert.ToInt32(txtCuzdanseriNo.Text.ToString()))
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
                }
                if (durum == false)
                {

                    MessageBox.Show("ARANILAN KULLANICI MEVCUT DEĞİLDİR");

                }
            }
            else
            {
                MessageBox.Show("KULLANICI BİLGİLERİ BOŞ GEÇİLEMEZ");

            }

            con.Close();




        }

        private void Txtisim_TextChanged(object sender, EventArgs e)
        {
            txtisim.Text = txtisim.Text.ToUpper();
            txtisim.SelectionStart = txtisim.Text.Length;
        }

        private void Txtsoyisim_TextChanged(object sender, EventArgs e)
        {
            txtsoyisim.Text = txtsoyisim.Text.ToUpper();
            txtsoyisim.SelectionStart = txtsoyisim.Text.Length;
        }

        private void Txttcno_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void TxtCuzdanseriNo_TextChanged(object sender, EventArgs e)
        {
            txtCuzdanseriNo.Text = txtCuzdanseriNo.Text.ToUpper();
            txtCuzdanseriNo.SelectionStart = txtCuzdanseriNo.Text.Length;
        }

        private void TxtnufusHarfseriNo_TextChanged(object sender, EventArgs e)
        {
            txtnufusHarfseriNo.Text = txtnufusHarfseriNo.Text.ToUpper();
            txtnufusHarfseriNo.SelectionStart = txtnufusHarfseriNo.Text.Length;
        }

        private void Txtdgmtarihi_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anaform frm = new Anaform();
            frm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anaform frm = new Anaform();
            frm.ShowDialog();
        }
    }
}
