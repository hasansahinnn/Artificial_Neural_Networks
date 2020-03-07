using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YapaySinir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double[] agirlik = new double[11] { -2.110000, 0.690000, 1.830000, 1.120000, 1.490000, 1.970000, -2.890000, -1.360000, -0.240000, -2.400000, -2.120000 };
        public double[,] ornek;
        public double[,] test;public double f3son;
        public double momentum2;
        string islem = "";public int kont = 0;
        public int testsayac = 0, orneksayac = 0;
      

        private void button43_Click(object sender, EventArgs e)
        {
            agirlik = new double[11] { -2.110000, 0.690000, 1.830000, 1.120000, 1.490000, 1.970000, -2.890000, -1.360000, -0.240000, -2.400000, -2.120000 };
            testsayac = 0; orneksayac = 0; kont = 0;

        }

        private void button42_Click(object sender, EventArgs e)
        {
            testsayac = 0; orneksayac = 0; kont = 0;
            if (checkBox1.Checked) { girisata(testsayac, 2, new double[4] { 0, 0, 0, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 0, 0, 0 }); orneksayac++; }
            if (checkBox2.Checked) { girisata(testsayac, 2, new double[4] { 0, 0, 1, 1 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 0, 1, 1 }); orneksayac++; }
            if (checkBox3.Checked) { girisata(testsayac, 2, new double[4] { 0, 1, 0, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 1, 0, 0 }); orneksayac++; }
            if (checkBox4.Checked) { girisata(testsayac, 2, new double[4] { 0, 1, 1, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 1, 1, 0 }); orneksayac++; }
            if (checkBox5.Checked) { girisata(testsayac, 2, new double[4] { 1, 0, 0, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 0, 0, 0 }); orneksayac++; }
            if (checkBox6.Checked) { girisata(testsayac, 2, new double[4] { 1, 0, 1, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 0, 1, 0 }); orneksayac++; }
            if (checkBox7.Checked) { girisata(testsayac, 2, new double[4] { 1, 1, 0, 1 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 1, 0, 1 }); orneksayac++; }
            if (checkBox8.Checked) { girisata(testsayac, 2, new double[4] { 1, 1, 1, 1 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 1, 1, 1 }); orneksayac++; }
            for (int i = 0; i < testsayac; i++)
            {
                islem = test[i, 0].ToString() + "       " + test[i, 1].ToString() + "        " + test[i, 2].ToString() + "    ";
                listBox2.Items.Add("");
                listBox2.Items.Add(" X1     X2      X3        W11          W12         W21          W22            W31           W32         W13            W23         WB1            WB2            WB3                  DEĞER               Y");
                for (int j = 0; j < 11; j++)
                    islem += agirlik[j].ToString("N6") + "   ";
                ileritest(i);
            }
        }



        private void button33_Click(object sender, EventArgs e)
        {
            testsayac = 0; orneksayac = 0; kont = 0; button41.Text = "0"; button40.Text = "0"; button39.Text = "0"; button38.Text = "0"; button37.Text = "0"; button36.Text = "0"; button35.Text = "0"; button22.Text = "0";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            momentum2 = Convert.ToDouble(textBox2.Text);
            if (checkBox1.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox2.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox3.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox4.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox5.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox6.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox7.Checked) { testsayac++; } else {; orneksayac++; }
            if (checkBox8.Checked) { testsayac++; } else {; orneksayac++; }
            test = new double[testsayac, 4];
            ornek = new double[orneksayac, 4];
            orneksayac = 0; testsayac = 0;
            int momentum = Convert.ToInt32(textBox2.Text);
            if (checkBox1.Checked) { girisata(testsayac, 2, new double[4] { 0, 0, 0, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 0, 0, 0 }); orneksayac++; }
            if (checkBox2.Checked) { girisata(testsayac, 2, new double[4] { 0, 0, 1, 1 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 0, 1, 1 }); orneksayac++; }
            if (checkBox3.Checked) { girisata(testsayac, 2, new double[4] { 0, 1, 0, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 1, 0, 0 }); orneksayac++; }
            if (checkBox4.Checked) { girisata(testsayac, 2, new double[4] { 0, 1, 1, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 0, 1, 1, 0 }); orneksayac++; }
            if (checkBox5.Checked) { girisata(testsayac, 2, new double[4] { 1, 0, 0, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 0, 0, 0 }); orneksayac++; }
            if (checkBox6.Checked) { girisata(testsayac, 2, new double[4] { 1, 0, 1, 0 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 0, 1, 0 }); orneksayac++; }
            if (checkBox7.Checked) { girisata(testsayac, 2, new double[4] { 1, 1, 0, 1 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 1, 0, 1 }); orneksayac++; }
            if (checkBox8.Checked) { girisata(testsayac, 2, new double[4] { 1, 1, 1, 1 }); testsayac++; } else { girisata(orneksayac, 1, new double[4] { 1, 1, 1, 1 }); orneksayac++; }
            int epoc = Convert.ToInt32(textBox1.Text);
            for (int t = 1; t <= epoc; t++)
            {
                if (t == epoc)
                {
                    listBox1.Items.Add("");
                    listBox1.Items.Add("------------------------------------------------------------------------------------------  " + t.ToString() + " EPOC  ------------------------------------------------------------------------------------------ ");
                    listBox1.Items.Add("                       X1     X2      X3        W11          W12         W21          W22            W31           W32         W13            W23         WB1            WB2            WB3            ÇIKIŞ HATASI           Y           HESAPLANAN  Y");
                }
                    for (int i = 0; i < orneksayac; i++)
                {
                    if (t == epoc) { 
                    islem = (i + 1) + ". İterasyon -    " + ornek[i, 0].ToString() + "       " + ornek[i, 1].ToString() + "        " + ornek[i, 2].ToString() + "    ";
                    for (int j = 0; j < 11; j++)
                        islem += agirlik[j].ToString("N6") + "   ";
                        kont = 1;
                    }
                    ileriornek(i);
                    if (t == epoc)
                    {
                       
                        if (checkBox1.Checked == false  && button41.Text=="0")
                        { button41.Text = f3son.ToString("N6"); }
                       else if (checkBox2.Checked == false && button40.Text == "0")
                        { button40.Text = f3son.ToString("N6"); }
                       else if (checkBox3.Checked == false && button39.Text == "0")
                        { button39.Text = f3son.ToString("N6"); }
                        else if (checkBox4.Checked == false && button38.Text == "0")
                        { button38.Text = f3son.ToString("N6"); }
                        else if (checkBox5.Checked == false && button37.Text == "0")
                        { button37.Text = f3son.ToString("N6"); }
                        else if (checkBox6.Checked == false && button36.Text == "0")
                        { button36.Text = f3son.ToString("N6"); }
                        else if (checkBox7.Checked == false && button35.Text == "0")
                        { button35.Text = f3son.ToString("N6"); }
                        else if (checkBox8.Checked == false && button22.Text == "0")
                        { button22.Text = f3son.ToString("N6"); }
                    }
                }
            }
       
     }
    


        public void ileriornek(int i)
        {
            double f1 = ornek[i, 0] * agirlik[0] + ornek[i, 1] * agirlik[2] + ornek[i, 2] * agirlik[4] + 1 * agirlik[8];
            f1 = 1 / (1 + Math.Exp(-1 * f1));
            double f2 = ornek[i, 0] * agirlik[1] + ornek[i, 1] * agirlik[3] + ornek[i, 2] * agirlik[5] + 1 * agirlik[9];
            f2 = 1 / (1 + Math.Exp(-1 * f2));
            double f3 = f1 * agirlik[6] + f2 * agirlik[7] + 1 * agirlik[10];
            f3 = 1 / (1 + Math.Exp(-1 * f3));
            double hata = 0.5 * (ornek[i, 3] - f3) * (ornek[i, 3] - f3);
            if (hata == 0)
                MessageBox.Show("Sonuç 0");
            if (kont==1)
            {
            islem += "          " + hata.ToString("N6");
            islem += "              " + ornek[i, 3];
            islem += "              " + f3.ToString("N6");
            listBox1.Items.Add(islem);f3son = f3;
            }

            //Geri Yön
            double noron = f3 * (1 - f3) * (0 - f3);

            agirlik[10] = agirlik[10] + momentum2 * noron * 1;
            agirlik[6] = agirlik[6] + momentum2 * noron * f1;
            agirlik[7] = agirlik[7] + momentum2 * noron * f2;

            double y1noron = f1 * (1 - f1) * agirlik[6] * noron;
            agirlik[8] = agirlik[8] + momentum2 * y1noron * 1;
            agirlik[0] = agirlik[0] + momentum2 * y1noron * 1;
            agirlik[2] = agirlik[2] + momentum2 * y1noron * 1;
            agirlik[4] = agirlik[4] + momentum2 * y1noron * 1;
            double y2noron = f2 * (1 - f2) * agirlik[7] * noron;
            agirlik[9] = agirlik[9] + momentum2 * y1noron * 1;
            agirlik[1] = agirlik[1] + momentum2 * y1noron * 1;
            agirlik[3] = agirlik[3] + momentum2 * y1noron * 1;
            agirlik[5] = agirlik[5] + momentum2 * y1noron * 1;

        }
        public void ileritest(int i)
        {
            double f1 = test[i, 0] * agirlik[0] + test[i, 1] * agirlik[2] + test[i, 2] * agirlik[4] + 1 * agirlik[8];
            f1 = 1 / (1 + Math.Exp(-1 * f1));
            double f2 = test[i, 0] * agirlik[1] + test[i, 1] * agirlik[3] + test[i, 2] * agirlik[5] + 1 * agirlik[9];
            f2 = 1 / (1 + Math.Exp(-1 * f2));
            double f3 = f1 * agirlik[6] + f2 * agirlik[7] + 1 * agirlik[10];
            f3 = 1 / (1 + Math.Exp(-1 * f3));
            islem += "          " + f3.ToString("N6");
            islem += "              " + test[i, 3];
            listBox2.Items.Add(islem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void girisata(int satir, int diziid, double[] veri)
        {
            if (diziid == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    ornek[satir, i] = veri[i];
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    test[satir, i] = veri[i];
                }
            }
        }


    }
}
