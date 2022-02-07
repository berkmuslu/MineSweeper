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
    class Blok: Button
    {
        public int id;
        public int x;
        public int y;
        public bool is_bayrak;
        public bool is_mayin;
        public int komsuMayin;

        public Blok(int id, int x, int y, bool mayin)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            is_mayin = mayin;
        }

        public int komsuBul(Blok[ , ]  bloklar, int genislik, int uzunluk)
        {

            if (y == 0 && x == 0)
            {
                Blok sag = bloklar[y, x + 1];
                Blok sag_alt_capraz = bloklar[y + 1, x + 1];
                Blok alt = bloklar[y + 1, x];

                if (sag.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (alt.is_mayin)
                {
                    komsuMayin++;
                }
            }
            else if (y == 0 && x != genislik - 1 && x != 0)
            {
                Blok sol = bloklar[y, x - 1];
                Blok sag = bloklar[y, x + 1];
                Blok sag_alt_capraz = bloklar[y + 1, x + 1];
                Blok sol_alt_capraz = bloklar[y + 1, x - 1];
                Blok alt = bloklar[y + 1, x];


                if (sag.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (alt.is_mayin)
                {
                    komsuMayin++;
                }

                if (sol.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }

            }
            else if (y == 0 && x == genislik - 1)
            {
                Blok sol = bloklar[y, x - 1];
                Blok alt = bloklar[y + 1, x];
                Blok sol_alt_capraz = bloklar[y + 1, x - 1];

                if (alt.is_mayin)
                {
                    komsuMayin++;
                }

                if (sol.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }
            }
            else if (y == uzunluk - 1 && x == genislik - 1)
            {
                Blok sol = bloklar[y, x - 1];
                Blok ust = bloklar[y - 1 , x];
                Blok sol_ust_capraz = bloklar[y - 1, x - 1];

                if (sol.is_mayin)
                {
                    komsuMayin++;
                }

                if (ust.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }

            }
            else if (x == genislik - 1 && y != 0 && y != uzunluk - 1)
            {
                Blok sol = bloklar[y, x - 1];
                Blok alt = bloklar[y + 1, x];
                Blok ust = bloklar[y - 1, x];
                Blok sol_ust_capraz = bloklar[y - 1, x - 1];
                Blok sol_alt_capraz = bloklar[y + 1, x - 1];

                if (sol.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (alt.is_mayin)
                {
                    komsuMayin++;
                }

                if (ust.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }
            }
            else if (y == uzunluk - 1 && x == 0)
            {
                Blok sag = bloklar[y, x + 1];
                Blok sag_ust_capraz = bloklar[y - 1, x + 1];
                Blok ust = bloklar[y - 1, x];

                if (sag.is_mayin)
                {
                    komsuMayin++;
                }

                if (sag_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (ust.is_mayin)
                {
                    komsuMayin++;
                }
            }
            else if (y == uzunluk - 1 && x != 0 && x != genislik - 1)
            {
                Blok sol = bloklar[y, x - 1];
                Blok sol_ust_capraz = bloklar[y - 1, x - 1];
                Blok ust = bloklar[y -1, x];
                Blok sag_ust_capraz = bloklar[y - 1, x + 1];
                Blok sag = bloklar[y, x + 1];

                if (sol.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }

                if (ust.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag.is_mayin)
                {
                    komsuMayin++;
                }
            }

            else if (x == 0 && y != uzunluk - 1 && y != 0)
            {
                Blok ust = bloklar[y - 1, x];
                Blok sag_ust_capraz = bloklar[y - 1, x + 1];
                Blok sag = bloklar[y, x + 1];
                Blok alt = bloklar[y + 1, x];
                Blok sag_alt_capraz = bloklar[y + 1, x + 1];

                if (alt.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }

                if (ust.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag.is_mayin)
                {
                    komsuMayin++;
                }
            }
            else
            {
                Blok sag = bloklar[y, x + 1];
                Blok sol = bloklar[y, x - 1];
                Blok alt = bloklar[y + 1, x];
                Blok ust = bloklar[y - 1, x];
                Blok sag_ust_capraz = bloklar[y - 1, x + 1];
                Blok sol_ust_capraz = bloklar[y - 1, x - 1];
                Blok sag_alt_capraz = bloklar[y + 1, x + 1];
                Blok sol_alt_capraz = bloklar[y + 1, x - 1];

                if (alt.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }

                if (ust.is_mayin)
                {
                    komsuMayin++;
                }
                if (sag.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_ust_capraz.is_mayin)
                {
                    komsuMayin++;
                }
                if (sol_alt_capraz.is_mayin)
                {
                    komsuMayin++;
                }

               
            }

            if (komsuMayin != 0)
            {
                bloklar[y, x].Text = komsuMayin.ToString();
                bloklar[y, x].Enabled = false;
            }
            bloklar[y, x].Enabled = false;

            return komsuMayin;
        }

        public void kutuAc(Blok[ , ] bloklar,int kor_x, int kor_y,int genislik,int yukseklik)
        {
            int sut = bloklar[kor_x, kor_y].y;
            int sat = bloklar[kor_x, kor_y].x;

            for(int i=sat-1; i<=sat+1; i++)
            {
                for(int j=sut-1; j<=sut+1; j++)
                {
                    if((i!=sut || j!=sat) && i>=0 && j>=0 && i<genislik && j < yukseklik)
                    {
                        if(bloklar[j,i].is_mayin==false && bloklar[j, i].Enabled == true)
                        {
                            Goster(bloklar, j, i, genislik, yukseklik);
                        }
                    }
                }
            }



        }
        public void Goster(Blok[,] bloklar,int j,int i,int genislik,int yukseklik)
        {
            if (bloklar[j, i].is_bayrak == true)
            {
                bloklar[j, i].Image = null;
                bloklar[j, i].is_bayrak = false;
            }

            bloklar[j, i].Enabled = false;
            if (bloklar[j, i].komsuBul(bloklar, genislik, yukseklik) == 0 && bloklar[j, i].is_mayin == false) 
            {
                kutuAc(bloklar, j, i, genislik, yukseklik);
            }

        }

    }
}
