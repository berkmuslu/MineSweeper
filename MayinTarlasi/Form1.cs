using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;

            int yukseklik = Convert.ToInt32(txtHeight.Text);
            int genislik = Convert.ToInt32(txtWidth.Text);
            int mayin = Convert.ToInt32(txtMines.Text);
            int id = 0;
            if (genislik > 21)
            {
                this.Size= new Size(genislik *35+20,this.Height);
            }
            if (yukseklik > 11)
            {
                this.Height = yukseklik * 48;
            }
            totalBayrak.Text = mayin.ToString();
            Blok[ , ] bloklar = new Blok[yukseklik , genislik];
            alan.Size = new Size(genislik * 30, yukseklik * 30);
            panel1.Size = new Size(genislik * 30, panel1.Height);
            label4.Text = "0";
            label4.Location = new Point(panel1.Width-40, (panel1.Height - pictureBox3.Height) / 2 +5);
            pictureBox1.Location = new Point((panel1.Width - pictureBox1.Width) / 2, (panel1.Height - pictureBox1.Height) / 2);
            pictureBox2.Location = new Point((panel1.Width - pictureBox1.Width) / 2, (panel1.Height - pictureBox1.Height) / 2);
            pictureBox3.Location = new Point((panel1.Width - pictureBox1.Width) / 2, (panel1.Height - pictureBox1.Height) / 2);
            int[] mayinId = new int[mayin];
            if (mayin >= yukseklik * genislik)
            {
                MessageBox.Show("Mayın sayısı blok sayısına eşit veya fazla olamaz!","Hata");
            }
            else
            {
                Random rnd = new Random();
                Array.Fill(mayinId, -1);
                int adet = 0;
                while(adet < mayin)
                {

                    int sayi=rnd.Next(0, yukseklik * genislik);
                    if (mayinId.Contains(sayi))
                    {
                        continue;
                    }
                    else
                    {
                        mayinId[adet] = sayi;
                    }
                    adet++;
                }



                alan.Controls.Clear();
                for (int i = 0; i < genislik; i++)
                {
                    for (int a = 0; a < yukseklik; a++)
                    {
                        if (mayinId.Contains(id))
                        {

                            bloklar[a, i] = new Blok(id, i, a, true);
                            bloklar[a, i].MouseDown += new MouseEventHandler(Blok_Bayrak);
                            bloklar[a, i].Click += new EventHandler(Blok_Click);
                            

                            bloklar[a, i].Size = new Size(30, 30);
                            bloklar[a, i].Location = new Point(i * 30, a * 30);
                            alan.Controls.Add(bloklar[a, i]);
                            id++;


                        }
                        else
                        {
                            bloklar[a, i] = new Blok(id, i, a, false);
                            bloklar[a, i].MouseDown += new MouseEventHandler(Blok_Bayrak);
                            bloklar[a, i].Click += new EventHandler(Blok_Click);
                            bloklar[a, i].Size = new Size(30, 30);
                            bloklar[a, i].Location = new Point(i * 30, a * 30);
                            alan.Controls.Add(bloklar[a, i]);
                            id++;

                        }

                    }

                }

            }

            void Blok_Click(object sender,EventArgs e)
            {
                Blok blok = sender as Blok;
                int mayinsiz_alan = yukseklik * genislik - mayin;
                timer1.Start();
                if (blok.is_mayin==false && blok.is_bayrak==false)
                {
                   
                    blok.kutuAc(bloklar, blok.y, blok.x, genislik, yukseklik);
                    blok.Enabled = false;
                    label1.Focus();
                    int cnt = 0;
                    foreach(var a in bloklar)
                    {
                        if (a.is_bayrak)
                        {
                            cnt++;
                        }
                    }
                    int yeni_bayrak = mayin - cnt;
                    totalBayrak.Text = yeni_bayrak.ToString();

                    int cnt1 = 0;
                    foreach(var a in bloklar)
                    {
                        if(a.Enabled==false)
                        cnt1++;
                    }
                    if (cnt1 == mayinsiz_alan)
                    {
                        pictureBox3.Visible = true; //Kazanma
                        timer1.Stop();
                        foreach (var item in bloklar)
                        {
                            item.Enabled = false;
                            if (item.is_mayin)
                            {
                                item.Image = Image.FromFile(".\\mine.png");
                            }
                        }

                    }
                }

                else
                {
                    if (blok.is_mayin == true && blok.is_bayrak == false)
                    {
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = true;
                        timer1.Stop();
                        foreach (var item in bloklar)
                        {
                            item.Enabled = false;
                            if (item.is_mayin)
                            {
                                if (item.is_bayrak)
                                {
                                    item.BackColor = Color.Green;
                                }
                                blok.BackColor = Color.Red;
                                item.Image = Image.FromFile(".\\mine.png");
                            }
                        }

                    }
                }
            }

            void Blok_Bayrak(object sender, MouseEventArgs e)
            {
                Blok blok = sender as Blok;
                int total = Convert.ToInt32(totalBayrak.Text);
                int mayin = Convert.ToInt32(totalBayrak.Text);
                total++;
                if (e.Button == MouseButtons.Right)
                {

                    if (mayin == 0 && blok.is_bayrak == true)
                    {
                        blok.is_bayrak = false;
                        mayin++;
                        totalBayrak.Text = Convert.ToString(mayin);
                        blok.Image = null;

                    }
                    else if (mayin > 0)
                    {
                        if (blok.is_bayrak == true)
                        {
                            blok.is_bayrak = false;
                            mayin++;
                            totalBayrak.Text = Convert.ToString(mayin);
                            blok.Image = null;

                        }
                        else if (blok.is_bayrak == false)
                        {
                            blok.is_bayrak = true;
                            mayin--;
                            totalBayrak.Text = Convert.ToString(mayin);
                            blok.Image = Image.FromFile(".\\flag.png");
                            blok.ImageAlign = ContentAlignment.MiddleCenter;


                        }

                    }
                }
            }




            

         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(label4.Text);
            x++;
            label4.Text = x.ToString();
        }
    }
}
