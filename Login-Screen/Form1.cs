using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source = DETHIAN\SQLEXPRESS; Initial Catalog = c#loginekrani;Integrated Security=True");
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text ==""|| textBox2.Text == "")
            {
                MessageBox.Show("Lutfen bos alan birakmayiniz");
            }
            else
            {
            
            baglanti.Open();
            string user;
            string password;
            user = textBox1.Text;
            password = textBox2.Text;

            SqlCommand komut = new SqlCommand("select * from users where kullanici='"+user+"' and sifre='"+password+"'",baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Hoşgeliniz "+user+"");
            }else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre...");
            }


            baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz...");
            }
            else
            {
            baglanti.Open();
            string user;
            string password;
            user = textBox1.Text;
            password = textBox2.Text;
            SqlCommand komut = new SqlCommand("select * from users where kullanici='" + user + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Bu kullanıcı adı kullanılıyor lütfen başka kullanıcı adı seçin");
            }else
            {
                oku.Close();
                SqlCommand ekle = new SqlCommand("insert into users(kullanici,sifre) values('"+user+"','"+password+"')",baglanti);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kayıt oldunuz ....");
            }

            baglanti.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl2.SelectedTab = tabPage2;
            textBox3.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text==""|| textBox4.Text=="")
            {
                MessageBox.Show("Lütfen boş alan bırakmayın ....");
            }
            else { 

            baglanti.Open();
            string user;
            string password;
            user = textBox3.Text;
            password = textBox4.Text;

            SqlCommand sorgu = new SqlCommand("select * from users where kullanici='"+user+"'",baglanti);
            SqlDataReader oku = sorgu.ExecuteReader();

            if (oku.Read())
            {
                oku.Close();
                SqlCommand guncelle = new SqlCommand("update users set sifre='"+password+"' where kullanici='"+user+"'",baglanti);
                guncelle.ExecuteNonQuery();
                MessageBox.Show("şifreniniz başarıyla güncellendi");
            }else
            {
                MessageBox.Show("Kullanıcı adınız hatalı....");
            }
            
            baglanti.Close();
            }
        }
    }
}
        
