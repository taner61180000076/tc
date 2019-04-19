using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        int adet;

        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean islem = true;
            UInt64[] dizi = new UInt64[12];
            Random sayi = new Random();
            //adet = Convert.ToInt32(textBox1.Text);

            for (int j = 0; j <= 50; j++)
            {
                islem = true;

                while (islem)
                {
                    string tc = "";
                    UInt64 tcNo, bol = 1, kontrol1 = 0,
                    kontrol2 = 0, sonuc = 0, b10 = 0, kontrol3 = 0, b11 = 0;
                    for (int i = 1; i <= 11; i++)
                    {
                        if (i <= 1)
                        {
                            dizi[i] = Convert.ToUInt64(sayi.Next(1, 10));
                            tc = tc + dizi[i].ToString();
                            i++;
                        }
                        dizi[i] = Convert.ToUInt64(sayi.Next(0, 10));
                        tc = tc + dizi[i].ToString();
                    }

                    tcNo = Convert.ToUInt64(tc);
                    for (int i = 11; i >= 1; i--)
                    {
                        dizi[i] = tcNo / bol % 10;
                        bol = bol * 10;
                        if (i < 10)
                        {
                            if (i % 2 == 0)
                            {
                                kontrol1 = kontrol1 + dizi[i];
                            }
                            else
                            {
                                kontrol2 = kontrol2 + dizi[i];
                            }
                        }
                        if (i < 11)
                        {
                            kontrol3 += dizi[i];
                        }
                        b10 = dizi[10];
                        b11 = dizi[11];
                    }
                    kontrol2 = kontrol2 * 7;
                    sonuc = kontrol2 - kontrol1;

                    if (sonuc % 10 == b10 && kontrol3 % 10 == b11)
                    {
                        listBox1.Items.Add(tc);
                        islem = false;
                    }
                    else
                    {

                    }
                }
            }
            MessageBox.Show("50 Adet TC Kimlik No Üretildi. Yasa Dışı Kullanımlardan Sorumlu Değilim");
        }
    }
}
