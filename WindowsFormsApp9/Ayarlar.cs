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
using System.Security.Cryptography;

namespace WindowsFormsApp9
{
    public partial class Ayarlar : Form
    {
        private string connectionString = "Server=localhost;Database=otelsistem;User Id=otelsistem;Password=1230789Asd!";
        // Veritabanı bağlantı nesnesini oluştur
        MySqlConnection conn;

        // Veri tablosu nesnesini oluştur
        DataTable dt;

        public Ayarlar()
        {
            InitializeComponent();
        }
        
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int admin = 0 ;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            try
            {
                    if (chadmin.Checked)
                    {
                        admin += 1;
                    }
                    else
                    {
                        admin += 0;
                    }
                string kadi = tbkadi.Text;
                string sifre = tbsifre.Text;

                string plainTextPassword = sifre;

                string hashedPassword = HashPassword(plainTextPassword);


                    connection.Open();
                string query = "INSERT INTO personel (kullaniciadi,sifre,admin) " +
                               "VALUES (@kullaniciadi, @sifre, @admin)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullaniciadi", kadi);
                        command.Parameters.AddWithValue("@sifre", hashedPassword);
                        command.Parameters.AddWithValue("@admin", admin);
                        

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Veritabanına ekleme başarılı!");
                }
            catch (Exception ex)
            {
                    MessageBox.Show("Hatta :" + ex.Message);
                
            }
            data();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sifreyigöster.Checked)
            {
                tbsifre.PasswordChar = '\0';
            }
            else
            {
                tbsifre.PasswordChar = '*';
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Anasayfa form1 = new Anasayfa();
            form1.Show();
            this.Hide();
            
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            data();
            // Veritabanı bağlantısını aç
            conn = new MySqlConnection(connectionString);
            conn.Open();

            // Veri tablosunu doldur
            VeriGetir();
        }
        private void VeriGetir()
        {
            string sql = "SELECT * FROM personel";

            // SQL komutunu çalıştırmak için komut nesnesi oluştur
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Veri tablosu nesnesini yeniden oluştur
            dt = new DataTable();

            // Veri tablosunu doldurmak için veri adaptörü nesnesi oluştur
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            // Veri tablosunu veri adaptörü ile doldur
            da.Fill(dt);

            // Datagridview denetiminin veri kaynağını veri tablosu olarak ayarla
            dataGridView1.DataSource = dt;
        }
        private void data()
        {
            try
            {
                MySqlConnection baglanti = new MySqlConnection(connectionString);
                // Veritabanından veri çekecek olan sql sorgusu
                string kayit = "SELECT kullaniciadi FROM personel";
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string kullaniciadi = tbkadisil.Text;
            
            string sql = "DELETE FROM personel WHERE kullaniciadi=@kullaniciadi";

            // SQL komutunu çalıştırmak için komut nesnesi oluştur
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // SQL komutuna parametre ekle
            cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);

            // SQL komutunu çalıştır
            cmd.ExecuteNonQuery();

            // Veri tablosunu güncelle
            VeriGetir();
        }
    }
}
