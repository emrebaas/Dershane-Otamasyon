using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershane_otomasyon
{
    public partial class giris_form : Form
    {
        public giris_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void giris_giris_buton_Click(object sender, EventArgs e)
        {
            if (giris_kuladi_textbox.Text == "admin" && giris_sifre_textbox.Text == "admin")
            {
                Form2 forum2 = new Form2();
                forum2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı !!");
                giris_kuladi_textbox.Clear();
                giris_sifre_textbox.Clear();
                giris_kuladi_textbox.Focus();
                label6.BackColor = Color.Yellow;
                label5.BackColor = Color.Yellow;
                label7.BackColor = Color.Yellow;

            }
        }

        private void giris_iptal_buton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  
    }
}
