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
    public partial class TüzelkişiVeCezaSorulama : Form
    {
        public TüzelkişiVeCezaSorulama()
        {
            InitializeComponent();
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from [TüzelkişiVeCezaSorulama$]", con);
            OleDbDataReader rd = komut.ExecuteReader();

            bool durum = false;

            if (txtisim.Text != "" && txtsoyisim.Text != "" && txttcnumara.Text.ToString() != "" && txtdgmtarihi.Text != "")
            {
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
                                    if (rd["TÜZEL KİŞİ VERGİ NO"].ToString() == txtKisiVergiNo.Text.ToString())
                                    {
                                        MessageBox.Show("KULLANICI MEVCUTTUR");
                                        durum = true;
                                        break;
                                    }

                                }
                            }
                        }
                    }

                }
                if (durum == false)
                {

                    MessageBox.Show("KULLANICI MEVCUT DEĞİLDİR");

                }
            }
            else
            {
                MessageBox.Show("KULLANICI BİLGİLERİ BOŞ GEÇİLEMEZ");

            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anaform frm = new Anaform();
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anaform f = new Anaform();
            f.ShowDialog();
        }

        private void TüzelkişiVeCezaSorulama_Load(object sender, EventArgs e)
        {

        }
    }
}
