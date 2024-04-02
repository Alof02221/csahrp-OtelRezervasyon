using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp9
{
    public partial class Odalar : Form
    {
        private string connectionString = "Server=localhost;Database=otelsistem;User Id=otelsistem;Password=1230789Asd!";
        public Odalar()
        {
            InitializeComponent();
        }

        private void Odalar_Load(object sender, EventArgs e)
        {
            KontrolEtVeRenklendir();
            VerileriYukle();
        }
        private void VerileriYukle()
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
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
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
                            KontrolVeRenklendir("101", oda101, odalarVeritabani);
                            KontrolVeRenklendir("102", oda102, odalarVeritabani);
                            KontrolVeRenklendir("103", oda103, odalarVeritabani);
                            KontrolVeRenklendir("204", oda204, odalarVeritabani);
                            KontrolVeRenklendir("205", oda205, odalarVeritabani);
                            KontrolVeRenklendir("206", oda206, odalarVeritabani);
                            KontrolVeRenklendir("307", oda307, odalarVeritabani);
                            KontrolVeRenklendir("308", oda308, odalarVeritabani);
                            KontrolVeRenklendir("309", oda309, odalarVeritabani);
                            KontrolVeRenklendir("410", oda410, odalarVeritabani);
                            KontrolVeRenklendir("411", oda411, odalarVeritabani);
                            KontrolVeRenklendir("412", oda412, odalarVeritabani);
                            KontrolVeRenklendir("513", oda513, odalarVeritabani);
                            KontrolVeRenklendir("514", oda514, odalarVeritabani);
                            KontrolVeRenklendir("515", oda515, odalarVeritabani);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private Guna.UI2.WinForms.Guna2Button GetButtonByName(string buttonName)
        {
            return Controls.Find(buttonName, true).FirstOrDefault() as Guna.UI2.WinForms.Guna2Button;
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
            if (odalarVeritabani.Contains(odaNumarasi))
            {
                button.FillColor = System.Drawing.Color.Red;
                // Eğer butonun rengi kırmızı ise, Click olayına bir event ekleyin
                button.Click += (sender, e) => { Button_Click(odaNumarasi); };
            }
            else
            {
                button.FillColor = System.Drawing.Color.Green;  // Eğer odanın numarası veritabanında yoksa, yeşil olarak kalır
            }
        }
        private void Button_Click(string odaNumarasi)
        {
            

        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KontrolEtVeRenklendir();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eğer Button Yeşil İse Oda Boştur.");
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eğer Button Kırmızı İse Oda Doludur.");
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }
    }
}
