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
using System.IO;

namespace dershane_otomasyon
{
    public partial class Form2 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-LSFJ4N5\\SQLEXPRESS;Initial Catalog=dershane_otomasyon;Integrated Security=True");
        
        public Form2()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bilgiadres_ogrgor_buton_Click(object sender, EventArgs e)
        {
            bilgiadres_ogrgor_butongor();
        }
       


        private void bilgiadres_ogrgor_butongor()
        {
            adres_bilgileri_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From adres Where ogr_adres_tc='" + textBox71.Text + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adres_ev"].ToString();
                ekle.SubItems.Add(oku["adres_okul"].ToString());

                adres_bilgileri_listview.Items.Add(ekle);
            }
            baglan.Close();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bilgitelefon_ogrgor_buton_Click(object sender, EventArgs e)
        {
            bilgitelefon_ogrgor__butongor();
        }




        private void bilgitelefon_ogrgor__butongor()
        {
            telefon_bilgileri_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From telefon Where ogr_telefon_tc='" + textBox71.Text + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["telefon_ogr_ev"].ToString();
                ekle.SubItems.Add(oku["telefon_ogr_cep"].ToString());

                telefon_bilgileri_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void bilgikimlik_ogrgor_buton_Click(object sender, EventArgs e)
        {
            bilgikimlik_ogrgor__butongor();
          //  resimgor_picturebox.Image = resimkaydet_picturebox.Image;


            resimgor_picturebox.Image = Image.FromFile(Application.StartupPath + @"\resim\" + textBox71.Text + ".jpg");


        }


        private void bilgikimlik_ogrgor__butongor()
        {
            kimlik_bilgileri_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From ogrenci O, kimlik_bilgileri K Where O.tc_no='" + (textBox71.Text) + "' And K.ogr_kimlik_tc='" + (textBox71.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["tc_no"].ToString();
                ekle.SubItems.Add(oku["ogr_adi"].ToString());
                ekle.SubItems.Add(oku["ogr_soyadi"].ToString());
                ekle.SubItems.Add(oku["baba_adi"].ToString());
                ekle.SubItems.Add(oku["anne_adi"].ToString());
                ekle.SubItems.Add(oku["dogum_tarih"].ToString());
                ekle.SubItems.Add(oku["dogum_yeri"].ToString());
                ekle.SubItems.Add(oku["il"].ToString());
                ekle.SubItems.Add(oku["ilce"].ToString());
                ekle.SubItems.Add(oku["kan_grubu"].ToString());
                ekle.SubItems.Add(oku["medeni_hali"].ToString());
                ekle.SubItems.Add(oku["cilt_no"].ToString());
                ekle.SubItems.Add(oku["sira_no"].ToString());
                ekle.SubItems.Add(oku["aile_sira_no"].ToString());

                kimlik_bilgileri_listview.Items.Add(ekle);
                
                
            }



            baglan.Close();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void bilgivelibil_ogrgor_buton_Click(object sender, EventArgs e)
        {
            veli_bilgileri_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From veli_bilgileri Where ogr_tc='" + (textBox71.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["veli_adi"].ToString();
                ekle.SubItems.Add(oku["veli_soyadi"].ToString());
                ekle.SubItems.Add(oku["veli_email"].ToString());
                ekle.SubItems.Add(oku["veli_telefon_cep"].ToString());
                ekle.SubItems.Add(oku["veli_telefon_is"].ToString());
                ekle.SubItems.Add(oku["veli_adres_ev"].ToString());
                ekle.SubItems.Add(oku["veli_adres_is"].ToString());


                veli_bilgileri_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

        public void resimyukle()
        {
            
        }

        private void yeni_kayit_resim_buton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                resimkaydet_picturebox.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        
        /////////////////////////////////////////////////////////////////////////////////////////////

        private void ygs_ogrgor_buton_Click(object sender, EventArgs e)
        {
            ygs_ogrgor_butongor();
        }


        private void ygs_ogrgor_butongor()
        {
            ygs_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From ygs Where ygs_tc='" + (textBox72.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ygs_id"].ToString();
                ekle.SubItems.Add(oku["ygs_tc"].ToString());
                ekle.SubItems.Add(oku["kacinci_sinav"].ToString());
                ekle.SubItems.Add(oku["ygs1"].ToString());
                ekle.SubItems.Add(oku["ygs2"].ToString());
                ekle.SubItems.Add(oku["ygs3"].ToString());
                ekle.SubItems.Add(oku["ygs4"].ToString());
                ekle.SubItems.Add(oku["ygs5"].ToString());
                ekle.SubItems.Add(oku["ygs6"].ToString());
                ekle.SubItems.Add(oku["siralama"].ToString());


                ygs_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void lys_ogrgor_buton_Click(object sender, EventArgs e)
        {
            lys_ogrgor_butongor(); 
        }

        private void lys_ogrgor_butongor()
        {
            lys_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From lys Where lys_tc='" + (textBox72.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["lys_id"].ToString();
                ekle.SubItems.Add(oku["lys_tc"].ToString());
                ekle.SubItems.Add(oku["kacinci_sinav"].ToString());
                ekle.SubItems.Add(oku["lys1"].ToString());
                ekle.SubItems.Add(oku["lys2"].ToString());
                ekle.SubItems.Add(oku["lys3"].ToString());
                ekle.SubItems.Add(oku["lys4"].ToString());
                ekle.SubItems.Add(oku["siralama"].ToString());


                lys_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void kasa_ogrgorkredi_buton_Click(object sender, EventArgs e)
        {
            kasa_ogrgorkredi_butongor();
        }


        private void kasa_ogrgorkredi_butongor()
        {
            kredikarti_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From Taksit Where taksit_tc='" + (textBox53.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["taksit_tc"].ToString();
                ekle.SubItems.Add(oku["odeme_yapan_ad"].ToString());
                ekle.SubItems.Add(oku["odeme_yapan_soyad"].ToString());
                ekle.SubItems.Add(oku["odeme_alan_ad"].ToString());
                ekle.SubItems.Add(oku["odeme_alan_soyad"].ToString());
                ekle.SubItems.Add(oku["taksit_sayisi"].ToString());
                ekle.SubItems.Add(oku["miktar"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());

                kredikarti_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

        /// <summary>
        /////////////////////////////////////////////////////// ////////////////
 
        private void dersprogram_ogrgor_buton_Click(object sender, EventArgs e)
        {
            dersprogram_ogrgor_butongor();
        }

        private void dersprogram_ogrgor_butongor()
        {
            dersprogrami_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From ders_programı Where tc='" + textBox2.Text + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["dersprogram_id"].ToString();
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["saat"].ToString());
                ekle.SubItems.Add(oku["pazartesi_ders"].ToString());
                ekle.SubItems.Add(oku["pazartesi_sinif"].ToString());
                ekle.SubItems.Add(oku["salı_ders"].ToString());
                ekle.SubItems.Add(oku["salı_sinif"].ToString());
                ekle.SubItems.Add(oku["carsamba_ders"].ToString());
                ekle.SubItems.Add(oku["carsamba_sinif"].ToString());
                ekle.SubItems.Add(oku["persembe_ders"].ToString());
                ekle.SubItems.Add(oku["persembe_sinif"].ToString());
                ekle.SubItems.Add(oku["cuma_ders"].ToString());
                ekle.SubItems.Add(oku["cuma_sinif"].ToString());
                ekle.SubItems.Add(oku["cumartesi_ders"].ToString());
                ekle.SubItems.Add(oku["cumartesi_sinif"].ToString());
                ekle.SubItems.Add(oku["pazar_ders"].ToString());
                ekle.SubItems.Add(oku["pazar_sinif"].ToString());

                dersprogrami_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

       ////////////////////////////////////////////////////////////////////////////////////////
    
        private void ogretmen_ogrgor_buton_Click(object sender, EventArgs e)
        {
            ogretmen_ogrgor_butongor();
        }


        private void ogretmen_ogrgor_butongor()
        {
            ogretmen_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From ogretmen Where ogretmen_tc='" + textBox3.Text + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogretmen_tc"].ToString();
                ekle.SubItems.Add(oku["ogretmen_adi"].ToString());
                ekle.SubItems.Add(oku["ogretmen_soyadi"].ToString());
                ekle.SubItems.Add(oku["ders_adi"].ToString());

                ogretmen_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        private void devamzislik_ogrgor_buton_Click(object sender, EventArgs e)
        {
            devamzislik_ogrgor_butongor();
            
        }


        private void devamzislik_ogrgor_butongor()
        {
            devamzislik_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From devamsizlik Where ogr_devamsizlik_tc='" + textBox1.Text + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["devamsizlik_id"].ToString();
                ekle.SubItems.Add(oku["ogr_devamsizlik_tc"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());
                ekle.SubItems.Add(oku["mazaret"].ToString());

                devamzislik_listview.Items.Add(ekle);
            }
            baglan.Close();
        }
      
        /// ///////////////////////////////////////////////////////////////////////////////////////////////
    
        private void kasa_ogrgorpesin_buton_Click(object sender, EventArgs e)
        {
            kasa_ogrgorpesin_butongor();
        }

         private void kasa_ogrgorpesin_butongor()
        {
            pesin_listview.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From Pesin Where pesin_tc='" + (textBox53.Text) + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["pesin_tc"].ToString();
                ekle.SubItems.Add(oku["odeme_yapan_ad"].ToString());
                ekle.SubItems.Add(oku["odeme_yapan_soyad"].ToString());
                ekle.SubItems.Add(oku["odeme_alan_ad"].ToString());
                ekle.SubItems.Add(oku["odeme_alan_soyad"].ToString());
                ekle.SubItems.Add(oku["miktar"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());

                pesin_listview.Items.Add(ekle);
            }
            baglan.Close();
        }

         private void ygs_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into ygs(ygs_tc,kacinci_sinav,ygs1,ygs2,ygs3,ygs4,ygs5,ygs6,siralama) Values('" + ygs_tc_textBox.Text.ToString() + "','" + ygs_kacinci_textBox.Text.ToString() + "','" + ygs1_textBox.Text.ToString() + "','" + ygs2_textBox.Text.ToString() + "','" + ygs3_textBox.Text.ToString() + "','" + ygs4_textBox.Text.ToString() + "','" + ygs5_textBox.Text.ToString() + "','" + ygs6_textBox.Text.ToString() + "','" + ygs_siralama_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         
         
         }

         private void lys_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into lys(lys_tc,kacinci_sinav,lys1,lys2,lys3,lys4,siralama) Values('" + lys_tc_textBox.Text.ToString() + "','" + lys_kacinci_textBox.Text.ToString() + "','" + lys1_textBox.Text.ToString() + "','" + lys2_textBox.Text.ToString() + "','" + lys3_textBox.Text.ToString() + "','" + lys4_textBox.Text.ToString() + "','" + ygs_siralama_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         }

         private void taksit_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into Taksit(taksit_tc,odeme_yapan_ad,odeme_yapan_soyad,odeme_alan_ad,odeme_alan_soyad,taksit_sayisi,miktar,tarih) Values('" + kredi_tc_textBox.Text.ToString() + "','" + kredi_öyadi_textBox.Text.ToString() + "','" + kredi_öysoyadi_textBox.Text.ToString() + "','" + kredi_öaadi_textBox.Text.ToString() + "','" + kredi_öasoyadi_textBox.Text.ToString() + "','" + kredi_taksit_textBox.Text.ToString() + "','" + kredi_miktar_textBox.Text.ToString() + "','" + kredi_tarih_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         }

         private void pesin_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into Pesin(pesin_tc,odeme_yapan_ad,odeme_yapan_soyad,odeme_alan_ad,odeme_alan_soyad,miktar,tarih) Values('" + pesin_tc_textBox.Text.ToString() + "','" + pesin_öyadi_textBox.Text.ToString() + "','" + pesin_öysoyadi_textBox.Text.ToString() + "','" + pesin_öaadi_textBox.Text.ToString() + "','" + pesin_öasoyadi_textBox.Text.ToString() + "','" + pesin_miktar_textBox.Text.ToString() + "','" + pesin_tarih_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         }

         private void devamsizlik_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into devamsizlik(ogr_devamsizlik_tc,tarih,mazaret) Values('" + devam_tc_textBox.Text.ToString() + "','" + devam_tarih_textBox.Text.ToString() + "','" + devam_mazaret_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         }

         private void ogretmen_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into ogretmen(ogretmen_tc,ogretmen_adi,ogretmen_soyadi,ders_adi) Values('" + ogretmen_tc_textBox.Text.ToString() + "','" + ogretmen_adi_textBox.Text.ToString() + "','" + ogretmen_soyadi_textBox.Text.ToString() + "','" + ogretmen_dersadi_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         }

         private void yeni_ogrenci_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into ogrenci(tc_no,ogr_adi,ogr_soyadi) Values('" + tc_textBox.Text.ToString() + "','" + adi_textBox.Text.ToString() + "','" + soyad_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();


             SqlCommand komut1 = new SqlCommand("Insert into kimlik_bilgileri(ogr_kimlik_tc,baba_adi,anne_adi,dogum_tarih,dogum_yeri,il,ilce,kan_grubu,medeni_hali,cilt_no,sira_no,aile_sira_no) Values('" + tc_textBox.Text.ToString() + "','" + babaadi_textBox.Text.ToString() + "','" + anaadi_textBox.Text.ToString() + "','" + dogtar_textBox.Text.ToString() + "','" + dogyer_textBox.Text.ToString() + "','" + il_textBox.Text.ToString() + "','" + ilce_textBox.Text.ToString() + "','" + kangrub_textBox.Text.ToString() + "','" + medenihal_textBox.Text.ToString() + "','" + cilt_textBox.Text.ToString() + "','" + sira_textBox.Text.ToString() + "','" + ailesira_textBox.Text.ToString() + "')", baglan);
             komut1.ExecuteNonQuery();

             SqlCommand komut2 = new SqlCommand("Insert into veli_bilgileri(ogr_tc,veli_adi,veli_soyadi,veli_email,veli_telefon_cep,veli_telefon_is,veli_adres_ev,veli_adres_is) Values('" + tc_textBox.Text.ToString() + "','" + veli_adi_textBox.Text.ToString() + "','" + veli_soyadi_textBox.Text.ToString() + "','" + veli_email_textBox.Text.ToString() + "','" + veli_ceptelefon_textBox.Text.ToString() + "','" + veli_istelefon_textBox.Text.ToString() + "','" + veli_evadres_textBox.Text.ToString() + "','" + veli_isadres_textBox.Text.ToString() + "')", baglan);
             komut2.ExecuteNonQuery();

             SqlCommand komut3 = new SqlCommand("Insert into adres(ogr_adres_tc,adres_ev,adres_okul) Values('" + tc_textBox.Text.ToString() + "','" + evadres_textBox.Text.ToString() + "','" + okuladres_textBox.Text.ToString() + "')", baglan);
             komut3.ExecuteNonQuery();


             SqlCommand komut4 = new SqlCommand("Insert into telefon(ogr_telefon_tc,telefon_ogr_ev,telefon_ogr_cep) Values('" + tc_textBox.Text.ToString() + "','" + evtelefon_textBox.Text.ToString() + "','" + ceptelefon_textBox.Text.ToString() + "')", baglan);
             komut4.ExecuteNonQuery();


             baglan.Close();
         }

         private void bilgi_ogrsil_buton_Click(object sender, EventArgs e)
         {
            
         
         }

         private void Ogrenci_sil_button_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand sil = new SqlCommand("Delete from ogrenci where tc_no='" + textBox16.Text.ToString() + "'", baglan);
             sil.ExecuteNonQuery();



             baglan.Close();
         }

         private void dersprogram_kaydet_Click(object sender, EventArgs e)
         {
             baglan.Open();

             SqlCommand komut = new SqlCommand("Insert into derprogramı(dersprogram_id,tc,saat,pazartesi_ders,pazartesi_sinif,salı_ders,salı_sinif,carsamba_ders,carsamba_sinif,persembe_ders,persembe_sinif,cuma_ders,cuma_sinif,cumartesi_ders,cumartesi_sinif,pazar_ders,pazar_sinif) Values('" + pesin_tc_textBox.Text.ToString() + "','" + pesin_öyadi_textBox.Text.ToString() + "','" + pesin_öysoyadi_textBox.Text.ToString() + "','" + pesin_öaadi_textBox.Text.ToString() + "','" + pesin_öasoyadi_textBox.Text.ToString() + "','" + pesin_miktar_textBox.Text.ToString() + "','" + pesin_tarih_textBox.Text.ToString() + "')", baglan);
             komut.ExecuteNonQuery();

             baglan.Close();
         }

         private void button1_Click(object sender, EventArgs e)
         {
             this.Close();
             giris_form forum1 = new giris_form();
             forum1.Show();
         }

    }
}
