using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace Personel
{
    public partial class Form1 : Form
    {
        BusinessLogicLayer bl;
        public Form1()
        {
            InitializeComponent();
            bl = new BusinessLogicLayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maas = 0;

            if (EmailKontrol(txtemail.Text))
            {
                

                if (!Int32.TryParse(txtMaas.Text, out maas))
                {
                    MessageBox.Show("maas bilgisi bos olamaz");

                }
                else
                {

                   
                    int k = bl.PersonelKaydet(txtAd.Text, txtSoyad.Text, maskedTextBox1.Text, txtemail.Text, maas, txtSehir.Text, txtDepartman.Text);
                    if (k > 0)
                    {
                        MessageBox.Show("Kayit Başarili Şekilde Eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Girilen Değerlerde eksiklik var. Kontrol ediniz..");

                    }
                }
            }
            else
            {
                MessageBox.Show("geçersiz email");
            }





        }

        private void txtMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool EmailKontrol(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        }
    }
}
