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
    public partial class TrafiktenSorumluKayıtekle : Form
    {
        public TrafiktenSorumluKayıtekle()
        {
            InitializeComponent();
        }

        private void Exceligetir_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
                con.Open();
                System.Data.OleDb.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter("Select * from [Anasayfa$]", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Sheet1");
                dataGridView1.DataSource = ds.Tables[0];                
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void Listele()
        {
            OleDbConnection baglanti = new OleDbConnection("provider = Microsoft.Jet.OLEDB.4.0; Data Source =TRAFİK1.xls; Extended Properties = 'Excel 8.0;HDR=YES;IMEX=1'");
            baglanti.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from [Anasayfa$]", baglanti);
            adtr.Fill(ds, "Anasayfa");
            dataGridView1.DataSource = ds.Tables["Anasayfa"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void Kaydet_Click(object sender, EventArgs e)
        {

            OleDbConnection baglanti = new OleDbConnection("provider = Microsoft.Jet.OLEDB.4.0; Data Source =TRAFİK1.xls; Extended Properties = 'Excel 8.0;HDR=YES;IMEX=1'");
            baglanti.Open();
            string sorgu = "Insert into [Anasayfa$](ADI,SOYADI,TCNO,DOĞUMYILI) values (@ad,@soyad,@tcno,@dog)";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", txtad.Text);
            komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            komut.Parameters.AddWithValue("@tcno", txttcno.Text);
            komut.Parameters.AddWithValue("@dog", Convert.ToInt32(txtdgmyılı.Text.ToString()));        
            komut.ExecuteNonQuery();         
            Listele();
            baglanti.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TRAFİK1.xls;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';");
            con.Open();
            OleDbCommand komut = new OleDbCommand("Select * from [Anasayfa$]", con);
            OleDbDataReader rd = komut.ExecuteReader();
            if (txtad.Text != "" && txtsoyad.Text != "" && txttcno.Text.ToString()!="" && txtdgmyılı.Text !="")
            {


                if (rd.Read())
                {
                    if (rd["ADI"].ToString() == txtad.Text && rd["SOYADI"].ToString() ==txtsoyad.Text && rd["TCNO"].ToString() == txttcno.Text && Convert.ToInt32(rd["DOĞUMYILI"].ToString()) == Convert.ToInt32(txtdgmyılı.Text.ToString()))
                    {
                        MessageBox.Show("ARANILAN KULLANICI EXCELDE MEVCUTTUR");


                    }
                    else
                    {

                        MessageBox.Show("ARANILAN KULLANICI EXCELDE MEVCUT DEĞİLDİR");

                    }
                }
                else
                {
                    MessageBox.Show("EXCELDE KAYIT YOKTUR");

                }

            }
            else
            {
                MessageBox.Show("KULLANICI GİRİŞ BİLGİLERİ BOŞ GEÇİLEMEZ");


            }
            con.Close();
        }
        public string ad;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            txtkisiara.Text = txtkisiara.Text.ToUpper();
            txtkisiara.SelectionStart = txtkisiara.Text.Length;


            OleDbConnection baglanti = new OleDbConnection("provider = Microsoft.Jet.OLEDB.4.0; Data Source =TRAFİK.xls; Extended Properties = 'Excel 8.0;HDR=YES;IMEX=1'");
            baglanti.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adp = new OleDbDataAdapter("Select * from [Anasayfa$] WHERE ADI LIKE '"+txtkisiara.Text.ToUpper()+"'   " , baglanti);
            adp.Fill(ds,"Anasayfa");
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TrafiktenSorumluKayıtekle_Load(object sender, EventArgs e)
        {

        }

        private void Txtad_TextChanged(object sender, EventArgs e)
        {
            txtad.Text = txtad.Text.ToUpper();
            txtad.SelectionStart = txtad.Text.Length;
        }

        private void Txtsoyad_TextChanged(object sender, EventArgs e)
        {
            txtsoyad.Text = txtsoyad.Text.ToUpper();
            txtsoyad.SelectionStart = txtsoyad.Text.Length;
        }

        private void Txttcno_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Mskdgmyılı_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
