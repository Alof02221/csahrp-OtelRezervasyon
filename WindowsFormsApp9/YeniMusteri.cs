using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using Guna.UI2.WinForms;

namespace WindowsFormsApp9
{
    public partial class YeniMusteri : Form
    {
        private string connectionString = "Server=localhost;Database=otelsistem;User Id=otelsistem;Password=1230789Asd!";
        private Guna2Button btn207;
        private Guna2Button btn208;
        private Guna2Button btn209;
        private Guna2Button btn310;
        private Guna2Button btn311;
        private Guna2Button btn312;
        private Guna2Button btn413;
        private Guna2Button btn414;
        private Guna2Button btn415;
        double Ucret = 0;
        
        void musteri()
        {
           
            

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Gelen Verileri Tanımlama
                    string ad = tbad.Text;
                    string soyad = tbsoyad.Text;
                    string tckimlikno = tbtckimlik.Text;
                    string telno = tbtelno.Text;
                    string odano = tbodano.Text;
                    int ucret = Convert.ToInt32(tbucret.Text);
                    DateTime dogumtarihi = dtpdogum.Value;
                    DateTime dogumTarihi = dtpdogum.Value;
                    int yas = DateTime.Today.Year - dogumTarihi.Year;
                    if (DateTime.Today < dogumTarihi.AddYears(yas))
                    {
                        yas--;
                    }

                        if (yas < 18)
                        {
                        MessageBox.Show("18 yaşından küçükler Oda Kiralayamaz");
                        return;
                        
                        }
                    else
                    {
                        DateTime bugun = DateTime.Now.Date;
                        if (dtpcıkıstarihi.Value <= bugun)
                        {
                            MessageBox.Show("Çıkış tarihi bugünden önce veya bugüne eşit olamaz!");
                            return; // Hata durumunda fonksiyondan çık
                        }

                        DateTime gtarih = dtpgiristarihi.Value;
                        DateTime ctarih = dtpcıkıstarihi.Value;

                        string query = "INSERT INTO musteribilgi (ad, soyad, tckimlikno, telno, odano, ucret, dogumtarihi, gtarih, ctarih) " +
                                       "VALUES (@ad, @soyad, @tckimlikno, @telno, @odano, @ucret, @dogumtarihi, @gtarih, @ctarih)";
                        //Tanımlanan Verileri Veritabanına Ekleme
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ad", ad);
                            command.Parameters.AddWithValue("@soyad", soyad);
                            command.Parameters.AddWithValue("@tckimlikno", tckimlikno);
                            command.Parameters.AddWithValue("@telno", telno);
                            command.Parameters.AddWithValue("@odano", odano);
                            command.Parameters.AddWithValue("@ucret", ucret);
                            command.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
                            command.Parameters.AddWithValue("@gtarih", gtarih);
                            command.Parameters.AddWithValue("@ctarih", ctarih);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Müşteri Başarıyla Veritabnına Kaydedildi.");
                        MessageBox.Show("Oda Ücreti:" + tbucret.Text);
                    }
                }

                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }   
        private void yüklendiginde()
        {
            try
            {
                MySqlConnection baglanti = new MySqlConnection(connectionString);
                // Veritabanından veri çekecek olan sql sorgusu
                string kayit = "SELECT * FROM musteribilgi";
                // MySqlCommand nesnesi
                MySqlCommand komut = new MySqlCommand(kayit, baglanti);
                // MySqlDataAdapter nesnesi
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                // DataTable nesnesi
                DataTable dt = new DataTable();
                // Verileri DataTable'a aktarma
                da.Fill(dt);
                // DataGridView'in DataSource özelliğini DataTable'a atama
                guna2DataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        public YeniMusteri()
        {
            InitializeComponent();
            
        }
        public void zaman()
        {
            DateTime bilgisayarTarihi = DateTime.Now;
            dtpdogum.Value = bilgisayarTarihi;
            dtpgiristarihi.Value = bilgisayarTarihi;
            dtpcıkıstarihi.Value = bilgisayarTarihi;
            
            
        }
        private void YeniMusteri_Load(object sender, EventArgs e)
        {
            KontrolEtVeRenklendir();
            yüklendiginde();
            zaman();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;

            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {
                
                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "101";
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "102";
            }
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "103";
            }
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "204";
            }
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "205";
            }
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "206";
            }
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "307";
            }
            
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "308";
            }
            ;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "309";
            }
            
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "410";
            }
            
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "411";
            }
            
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
             Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "412";
            }
            
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
             Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "513";
            }
           
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
             Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "514";
            }
            
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
             Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton != null && clickedButton.FillColor == System.Drawing.Color.Red)
            {

                MessageBox.Show("Bu oda dolu! Başka bir oda seçiniz.");
            }
            else
            {
                tbodano.Text = "515";
            }
            
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            Ucret += 150;
        }

        

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
           
            DateTime kucuktarih = Convert.ToDateTime(dtpgiristarihi.Text);
            DateTime buyuktarih = Convert.ToDateTime(dtpcıkıstarihi.Text);
            // timespan aradaki farkı bulur.
            TimeSpan sonuc = buyuktarih - kucuktarih;
            label10.Text = sonuc.TotalDays.ToString();
            if (ch1sınıf.Checked)
            {
                Ucret = Convert.ToInt32(label10.Text) * 150;
                tbucret.Text = Ucret.ToString();
            }
            if (chsınıf2.Checked)
            {
                Ucret = Convert.ToInt32(label10.Text) * 250;
                tbucret.Text = Ucret.ToString();
            }
            if (chsınıf3.Checked)
            {
                Ucret = Convert.ToInt32(label10.Text) * 350;
                tbucret.Text = Ucret.ToString();
            }
        }

        

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
           KontrolEtVeRenklendir();
        }

        private void tbdogumtarihi_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            musteri();
            KontrolEtVeRenklendir();
            yüklendiginde();
            tbad.Text = "";
            tbsoyad.Text = "";
            tbtckimlik.Text = "";
            tbtelno.Text = "";
            tbodano.Text = "";
            tbucret.Text = "";


        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void KontrolEtVeRenklendir()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanındaki odaların numaralarını çek
                    string query = "SELECT odano FROM musteribilgi";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Veritabanındaki odaları bir liste içinde tut
                            var odalarVeritabani = reader.Cast<IDataRecord>()
                                .Select(r => r["odano"].ToString())
                                .ToList();

                            // Belirtilen odaları kontrol et ve duruma göre renklendir
                            KontrolVeRenklendir("101", btn101, odalarVeritabani);
                            KontrolVeRenklendir("102", btn102, odalarVeritabani);
                            KontrolVeRenklendir("103", btn103, odalarVeritabani);
                            KontrolVeRenklendir("204", btn204, odalarVeritabani);
                            KontrolVeRenklendir("205", btn205, odalarVeritabani);
                            KontrolVeRenklendir("206", btn206, odalarVeritabani);
                            KontrolVeRenklendir("307", btn307, odalarVeritabani);
                            KontrolVeRenklendir("308", btn308, odalarVeritabani);
                            KontrolVeRenklendir("309", btn309, odalarVeritabani);
                            KontrolVeRenklendir("410", btn410, odalarVeritabani);
                            KontrolVeRenklendir("411", btn411, odalarVeritabani);
                            KontrolVeRenklendir("412", btn412, odalarVeritabani);
                            KontrolVeRenklendir("513", btn513, odalarVeritabani);
                            KontrolVeRenklendir("514", btn514, odalarVeritabani);
                            KontrolVeRenklendir("515", btn515, odalarVeritabani);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            Guna2Button[] buttons = gbodalar.Controls.OfType<Guna2Button>().ToArray();

            // Yeşil ve kırmızı renk sayılarını tutacak değişkenleri tanımlayalım
            int greenCount = 0;
            int redCount = 0;

            // Dizideki her button için renk kontrolü yapalım
            foreach (Guna2Button button in buttons)
            {
                // Button'un rengi yeşilse, yeşil sayısını bir arttıralım
                if (button.FillColor == Color.Green)
                {
                    greenCount++;
                }
                // Button'un rengi kırmızıysa, kırmızı sayısını bir arttıralım
                else if (button.FillColor == Color.Red)
                {
                    redCount++;
                }
            }


            // Yeşil ve kırmızı sayılarını labelere yazdıralım
            lbbosoda.Text = greenCount.ToString();
            lbdoluoda.Text = redCount.ToString();

        }
            private void KontrolVeRenklendir(string odaNumarasi, Guna.UI2.WinForms.Guna2Button button,
                                         List<string> odalarVeritabani)
        {
            // Eğer odanın numarası veritabanında bulunuyorsa, butonun rengini değiştir
            if (odalarVeritabani.Contains(odaNumarasi))
            {
                button.FillColor = System.Drawing.Color.Red;
            }
            else
            {
                button.FillColor = System.Drawing.Color.Green;  // Eğer odanın numarası veritabanında yoksa, yeşil olarak kalır
            }
        }
        private void guna2Button19_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    double arananId = Convert.ToDouble(tbmusteriid.Text);

                    string query = "SELECT * FROM musteribilgi WHERE tckimlikno = @tckimlikno";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tckimlikno", arananId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string ad = reader["ad"].ToString();
                                string soyad = reader["soyad"].ToString();
                                string telno = reader["telno"].ToString();
                                string odano = reader["odano"].ToString();
                                int ucret = Convert.ToInt32(reader["ucret"]);
                                DateTime dogumtarihi = Convert.ToDateTime(reader["dogumtarihi"]);
                                DateTime gtarih = Convert.ToDateTime(reader["gtarih"]);
                                DateTime ctarih = Convert.ToDateTime(reader["ctarih"]);


                                MessageBox.Show($"Ad: {ad}, Soyad: {soyad}, TelNo: {telno}, OdaNo: {odano}, Ucret: {ucret}, DogumTarihi: {dogumtarihi}, GirisTarihi: {gtarih}, CikisTarihi: {ctarih}");
                            }
                            else
                            {
                                MessageBox.Show("Belirtilen T.C'ye sahip bir kayıt bulunamadı.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            KontrolEtVeRenklendir();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {

            DialogResult cevap = MessageBox.Show("Müşteriyi Silmek İstediğinizden emin misiniz? Dikatt Bu İşlem Geri Alınamaz", "Müşteriyi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {


                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        int silinecekId = (int)Convert.ToInt64(tbmusteriid.Text);

                        string query = "DELETE FROM musteribilgi WHERE tckimlikno = @tckimlikno";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@tckimlikno", silinecekId);

                            int affectedRows = command.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Müşteri başarıyla silindi.");
                            }
                            else
                            {
                                MessageBox.Show("Belirtilen T.C'ye sahip bir müşteri bulunamadı.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                KontrolEtVeRenklendir();

            }
            else
            {
                MessageBox.Show("Müşteri Silme İşlemi Başarıyla İptal Edildi", "Müşteriyi Sil");
            }
            yüklendiginde();
        }

        private void gbodalar_Click(object sender, EventArgs e)
        {

        }

        private void dtpdogum_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void CheckSelectedDate()
        {
           
        }
    }
}
