using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class dugumTek
        {
            public string ad;
            public string soyad;
            public int no;
            public dugumTek sonraki;
        }
        dugumTek ilk = null;
        dugumTek son = null;

        private void btnSonaEkle_Click(object sender, EventArgs e)
        {
            dugumTek yeni = new dugumTek();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox3.Text;
            yeni.no = Convert.ToInt32(textBox2.Text);
            if (ilk == null)
            {
                ilk = yeni;
                son = ilk;
                son.sonraki = null;
            }
            else
            {
                son.sonraki = yeni;
                son = yeni;
                son.sonraki = null;
            }
        }
        private void listeyiYazdir(dugumTek ilk)
        {
            richTextBox1.Text = null;

            while (ilk != null)
            {
                richTextBox1.Text += ilk.ad + " :" + ilk.soyad + " : " + ilk.no.ToString();
                richTextBox1.Text += "==> ";
                ilk = ilk.sonraki;
            }
            richTextBox1.Text += "null";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listeyiYazdir(ilk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dugumTek yeni = new dugumTek();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox3.Text;
            yeni.no = Convert.ToInt32(textBox2.Text);
            dugumTek gecici = new dugumTek();
            gecici = ilk;
            if (ilk != null)
            {

                while (gecici.no < yeni.no)
                {
                    if (gecici.sonraki.no > yeni.no)
                    {
                        break;
                    }
                    gecici = gecici.sonraki;

                }
                yeni.sonraki = gecici.sonraki;
                gecici.sonraki = yeni;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox2.Text);
            dugumTek silinecek = new dugumTek();
            dugumTek gecici = new dugumTek();
            silinecek = ilk;

            silinecek = ilk;

            if (ilk.no == no)//ilk düğüm silinecek
            {
                ilk = ilk.sonraki;

            }
            else
            {
                while (silinecek.no != no)
                {
                    gecici = silinecek;
                    silinecek = silinecek.sonraki;

                }
                gecici.sonraki = silinecek.sonraki;

            }
        }
    }
}
