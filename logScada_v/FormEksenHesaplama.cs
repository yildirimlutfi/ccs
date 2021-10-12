using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logScada
{
    public partial class FormEksenHesaplama : Form
    {
        Int64 hesaplananX, hesaplananFark;
        string listboxText;
        string[] arrayString = new string[3];

        public FormEksenHesaplama()
        {
            InitializeComponent();
        }

        private void FormEksenHesaplama_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Zaman       LazerX      CmdX");
            for (int i = 0; i < classTxt.adet; i++)
            {
                if ((Convert.ToInt64(classDegisken.veriler[i, 18]) & 2305843009213693952) == 2305843009213693952)
                {
                    listBox1.Items.Add(classDegisken.veriler[i, 0] + " ; " + classDegisken.veriler[i, 1] + " ; " + classDegisken.veriler[i, 6]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxText = listBox1.Items[listBox1.SelectedIndex].ToString();
            arrayString = listboxText.Split(';');
            for (int i = 0; i < arrayString.Length; i++)
            {
                arrayString[i] = arrayString[i].Trim(' ');
            }
                        
            if ((hesaplananFark = Convert.ToInt64(arrayString[1]) - Convert.ToInt64(arrayString[2] + 1250))<1250 & (hesaplananFark = Convert.ToInt64(arrayString[1]) - Convert.ToInt64(arrayString[2] + 1250)) > 0)
            {
                hesaplananFark = Convert.ToInt64(arrayString[1]) - Convert.ToInt64(arrayString[2]) - 1250;
                hesaplananX = Convert.ToInt64(arrayString[1]) - 1250;
            }

            else 
            {
                hesaplananFark = Convert.ToInt64(arrayString[1]) - Convert.ToInt64(arrayString[2]) + 1250;
                hesaplananX = Convert.ToInt64(arrayString[1]) + 1250;
            }

            labelSeciliLazer.Text = arrayString[1];
            labelSeciliCmd.Text = arrayString[2];
            labelSeciliHesaplanan.Text = hesaplananX.ToString();
            labelSeciliFark.Text = hesaplananFark.ToString();
            try
            {
                
                chart1.Series.Clear();
                chart1.Series.Add("SeriesLazerX");
                chart1.Series.Add("SeriesCmdX");
                chart1.Series.Add("SeriesHesaplananX");

                chart1.Series["SeriesLazerX"].Points.AddXY(1, Convert.ToDouble(arrayString[1]));
                chart1.Series["SeriesCmdX"].Points.AddXY(1, Convert.ToDouble(arrayString[2]));
                chart1.Series["SeriesHesaplananX"].Points.AddXY(1, hesaplananX);
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
