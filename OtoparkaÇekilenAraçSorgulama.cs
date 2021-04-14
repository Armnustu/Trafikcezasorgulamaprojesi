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
    public partial class OtoparkaÇekilenAraçSorgulama : Form
    {
        public OtoparkaÇekilenAraçSorgulama()
        {
            InitializeComponent();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void OtoparkaÇekilenAraçSorgulama_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from [OtoparkaÇekilenAraçSorgulama$]", con);
            OleDbDataReader rd = komut.ExecuteReader();//exceli oku diyo ve okunduysa rd.Read() olarak tara

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
                                    if (rd["PLAKA"].ToString() == txtplaka.Text.ToString())
                                    {
                                        MessageBox.Show("ARANILAN KULLANICI MEVCUT");                                   
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

                    MessageBox.Show("ARANILAN KULLANICI MEVCUT DEĞİLDİR");

                }
            }
            else
            {
                MessageBox.Show("Textler boş gecilemez");

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

        private void Txtplaka_TextChanged(object sender, EventArgs e)
        {
            txtplaka.Text = txtplaka.Text.ToUpper();
            txtplaka.SelectionStart = txtplaka.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anaform f = new Anaform();
            f.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
