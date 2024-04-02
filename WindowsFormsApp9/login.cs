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
using System.Security.Cryptography;
namespace WindowsFormsApp9
{
    public partial class login : Form
    {

        private string connectionString = "Server=localhost;Database=otelsistem;User Id=otelsistem;Password=1230789Asd!";
        public login()
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
            // Kullanıcı adı ve şifre al
            string username = tbadi.Text;
            string password = tbsifre.Text;

            
            string hashedPassword = HashPassword(password);

            // Veritabanı bağlantısı kur
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            // Veritabanından kullanıcı adı ve şifreye göre admin değerini çek
            string query = "SELECT admin FROM personel WHERE kullaniciadi=@username AND sifre=@password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            object result = cmd.ExecuteScalar();

            // Eğer sonuç null değilse, yani böyle bir kullanıcı varsa
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {

            
            if (result != null)
             {
                // Admin değerini int olarak al
                int admin = Convert.ToInt32(result);

                // Eğer admin 1 ise, yani kullanıcı yönetici ise
                if (admin == 1)
                {
                    MessageBox.Show("Admin Girişi Yapıldı");
                    // Anasayfa formunu aç ve bu formu gizle
                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.Show();
                    this.Hide();
                }
                // Eğer admin 0 ise, yani kullanıcı normal kullanıcı ise
                else if (admin == 0)
                {
                    MessageBox.Show("Personel Girişi Yapıldı");
                    // Anasayfa formunu aç, ama btnayarlar isimli ayarlar formundaki güncelle butonuna basmasına izin verme
                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.SetButtonVisibility(false);
                    anasayfa.Show();
                    this.Hide();
                }
             }
             // Eğer sonuç null ise, yani böyle bir kullanıcı yoksa
             else
             {
                // Hata mesajı göster
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
             }
            }
            else
            {
                // Hata mesajı göster
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
            // Veritabanı bağlantısını kapat
            conn.Close();

        }
       

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            // Programı Kapat
            Application.Exit();
        }
    }
}
