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
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Visible = true;
          
        }   
        //Not:Exceli kapatip proğramı çalıştır hata alırsın
        private void ANASAYFA_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            progressBar1.Visible = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            timer1.Interval = 100;
        }      
        private void Button5_Click(object sender, EventArgs e)
        {
            AraçplakasınaYazılanTrafikcezaSorgulama frm = new AraçplakasınaYazılanTrafikcezaSorgulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;           
            frm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            AraçplakasınaYazılanTrafikcezaSorgulama frm = new AraçplakasınaYazılanTrafikcezaSorgulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;
            frm.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SürücüBelgesineYazılanCezaSorulama frm = new SürücüBelgesineYazılanCezaSorulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;
            frm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OtoparkaÇekilenAraçSorgulama frm = new OtoparkaÇekilenAraçSorgulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;
            frm.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            SürücüBelgesineYazılanCezaSorulama frm = new SürücüBelgesineYazılanCezaSorulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;            
            frm.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TüzelkişiVeCezaSorulama frm = new TüzelkişiVeCezaSorulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;
            frm.ShowDialog();
           
        }     
        private void Button8_Click(object sender, EventArgs e)
        {
            OtoparkaÇekilenAraçSorgulama frm = new OtoparkaÇekilenAraçSorgulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;
            frm.ShowDialog();

        }
        private void Txtisim_TextChanged(object sender, EventArgs e)
        {
            txtisim.Text = txtisim.Text.ToUpper();
            txtisim.SelectionStart =txtisim.Text.Length;
        }

        private void Txtsoyisim_TextChanged(object sender, EventArgs e)
        {
            txtsoyisim.Text = txtsoyisim.Text.ToUpper();
            txtsoyisim.SelectionStart = txtsoyisim.Text.Length;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TüzelkişiVeCezaSorulama frm = new TüzelkişiVeCezaSorulama();
            frm.txtisim.Text = txtisim.Text;
            frm.txtsoyisim.Text = txtsoyisim.Text;
            frm.txtdgmtarihi.Text = txtdgmtarihi.Text;
            frm.txttcnumara.Text = txttcnumara.Text;
            frm.ShowDialog();
        }
        int time = 0;       
        private void timer1_Tick(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from [Anasayfa$]", con);
            OleDbDataReader rd = komut.ExecuteReader();
            bool durum = false;
            time++;
            progressBar1.Value = time;
            label6.Text = "%" + time + " Tamamlandı.Lütfen Bekleyin";
            if (time == 100)
            {
                timer1.Stop();                
                time = 0;
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


                                        MessageBox.Show("ARANILAN KULLANICI MEVCUTTUR");
                                        button1.Visible = true;
                                        button2.Visible = true;
                                        button3.Visible = true;
                                        button4.Visible = true;
                                        button5.Visible = true;
                                        button6.Visible = true;
                                        button7.Visible = true;
                                        button8.Visible = true;
                                        durum = true;
                                        AraçplakasınaYazılanTrafikcezaSorgulama frm = new AraçplakasınaYazılanTrafikcezaSorgulama();
                                        break;


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

                //con.Close();
            }
            con.Close();
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
