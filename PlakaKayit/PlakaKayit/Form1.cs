using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakaKayit
{
    public partial class Form1 : Form
    {

        string dosyaYolu = @"C:\Users\Arslanlar\Desktop\Plakalar.txt"; //dosya yolunu kendi bilgisayarınıza göre ayarlamalısınız
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(dosyaYolu))
            {
                File.Create(dosyaYolu);
            }
            else
            {
                listBox1.Items.AddRange(File.ReadAllLines(dosyaYolu)); //dosyadaki plaka kayıtları listbox'ta görüntülendi
            }
            
        }

     
        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            string eklenecek = textBox1.Text.ToUpper(); //textbox değeri eklenecek değişkenine atandı ve karakterler büyütüldü
            if (eklenecek != "") 
            {
                listBox1.Items.Add(eklenecek); 
                textBox1.Clear(); 

                string[] plakalar = listBox1.Items.OfType<string>().ToArray();
                File.WriteAllLines(dosyaYolu, plakalar);
            }
      
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Plaka kaydını silmek istediğinize emin misiniz?", "Plaka Silinecek", MessageBoxButtons.OKCancel);
            
            if(secim == DialogResult.OK)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                string[] plakalar = listBox1.Items.OfType<string>().ToArray();
                File.WriteAllLines(dosyaYolu, plakalar);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
