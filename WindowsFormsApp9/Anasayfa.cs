using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace WindowsFormsApp9
{
    public partial class Anasayfa : Form
    {
        private string connectionString = "Server=localhost;Database=otelsistem;User Id=otelsistem;Password=1230789Asd!";
        public Anasayfa()
        {
            InitializeComponent();
        }
        
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap=MessageBox.Show("Çıkmak İstedğinizden Emin Misiniz","Çıkış",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (cevap==DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (cevap==DialogResult.No)
            {
                MessageBox.Show("Çıkış İptal Edildi.","Çıkış");
            }
            else
            {
                MessageBox.Show("Çıkış İptal Edildi","Çıkış");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            YeniMusteri form1 = new YeniMusteri();
            form1.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Odalar form2 = new Odalar();
            form2.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetButtonVisibility(bool isVisible)
        {
            button1.Visible = isVisible;
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            
            FormYuklendiginde();
        }
        private void FormYuklendiginde()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Bilgisayarın tarihini al
                    DateTime bilgisayarTarihi = DateTime.Now;

                    // Çıkış tarihi bilgisayarın tarihine eşit olan müşteriyi sorgula
                    string query = "SELECT * FROM musteribilgi WHERE ctarih = @ctarih";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ctarih", bilgisayarTarihi.Date);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Müşteriyi sormak için MessageBox göster
                                DialogResult result = MessageBox.Show("Çıkış tarihi bugüne denk gelen bir müşteri bulundu. Silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    // Kullanıcı 'Evet' dediğinde müşteriyi sil
                                    SilMusteriyi(Convert.ToInt32(reader["id"]));
                                    MessageBox.Show("Müşteri başarıyla silindi!");
                                }
                                else if (result==DialogResult.No) 
                                {
                                    // Kullanıcı 'Hayır' dediğinde bir işlem yapma
                                    MessageBox.Show("Müşteri silinmedi.");
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen Tekrar Deneyinizç");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void SilMusteriyi(int musteriId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Müşteriyi sil
                    string query = "DELETE FROM musteribilgi WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", musteriId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Ayarlar form3 = new Ayarlar();
            form3.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Hide();
        }
    }
}
