using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TwoOfTheKing
{
    public partial class Form1 : Form
    {
        int[] card = new int[18];
        PictureBox[] pic = new PictureBox[18];
        int t=0, f=0;   //計算正確和錯誤次數
        int click=0;  //計算第幾次翻牌
        int first, second, fc, sc;  //暫存第一張翻的和第二張翻的牌
        Stopwatch sw = new Stopwatch(); //手錶物件

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //指定
            pic[0] = pictureBox1;
            pic[1] = pictureBox2;
            pic[2] = pictureBox3;
            pic[3] = pictureBox4;
            pic[4] = pictureBox5;
            pic[5] = pictureBox6;
            pic[6] = pictureBox7;
            pic[7] = pictureBox8;
            pic[8] = pictureBox9;
            pic[9] = pictureBox10;
            pic[10] = pictureBox11;
            pic[11] = pictureBox12;
            pic[12] = pictureBox13;
            pic[13] = pictureBox14;
            pic[14] = pictureBox15;
            pic[15] = pictureBox16;
            pic[16] = pictureBox17;
            pic[17] = pictureBox18;
            //蓋牌
            for (int i = 0; i < pic.Length; i++)
            {
                close(i);
            }
            
        }

        //蓋牌，傳入要蓋牌的ID
        private void close(int id)
        {
            pic[id].Image = Image.FromFile("poker\\0.jpg");
        }
        //洗牌
        private void shuffle()
        {
            int p, q;
            Random rand = new Random();

            for (int i = 0; i < card.Length; i++)
            {
                if (i <= 8)
                    card[i] = i + 1;
                else
                    card[i] = (i + 1) - 9;
            }
            
            for (int i = 1; i <= 500; i++)
            {
                p = rand.Next(0, 9);
                q = rand.Next(9, 17);
                int tmp = card[p];
                card[p] = card[q];
                card[q] = tmp;
            }
        }
        //隱藏
        private void hide(Boolean b,int i) 
        {
            pic[i].Visible = b;
        }
        //分配
        private void assign()
        {
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Image = Image.FromFile("poker\\" + card[i] + ".jpg");
            }
        }
        //翻哪張牌
        private void show(int i)
        {
            pic[i].Image = Image.FromFile("poker\\" + card[i] + ".jpg");
        }
        //判斷第幾次翻牌並暫存所翻的牌的數值
        private void save(int i)
        {
            //第一次翻牌時
            if (click == 0)
            {
                show(i);
                first = card[i];
                fc = i;
                click++;
                interact(false, i);
            }
            else
            {
                show(i);
                second = card[i];
                sc = i;
                click = 0;  //歸0
                judge();
                interact(false, i);
            }
        }
        //判斷是否相同
        private void judge()
        {
            if (first == second)
            {
                t++;    //增加正確次數
                label1.Text = "Correct:" + t;
                decide();
                hide(false, fc);
                hide(false, sc);
            }
            else
            {
                f++;
                label2.Text = "Wrong:" + f;
                timer2.Enabled = true;
            }
        }
        //決定輸贏
        private void decide()
        {
            if (t == 9)
            {
                double time = Math.Round(sw.ElapsedMilliseconds / 1000.0,2);   //四捨五入至小數點二位
                String msg = "You win,wrong:" + f + "\nspend time:" + time + "+" + f + "\nps:The wrong increases one second";

                if (MessageBox.Show(msg,"Play again?", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                {
                    button1.Enabled = true;
                    t = 0;
                    f = 0;
                    label1.Text = "Correct:" + t;
                    label2.Text = "Wrong:" + f;
                    for (int i = 0; i < pic.Length; i++)
                        close(i);
                    
                }
                else
                    Application.Exit();
            }
        }
        //按鈕互動
        private void interact(Boolean b, int i)
        {
            pic[i].Enabled = b;
        }




        //各種UI各種事件
        private void button1_Click(object sender, EventArgs e)
        {
            shuffle();
            assign();
            for (int i = 0; i < pic.Length; i++)
            {
                hide(true, i);
                interact(true, i);
            }
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //蓋牌
            for (int i = 0; i < pic.Length; i++)
            {
                close(i);
            }
            timer1.Enabled = false;
            sw.Reset();   //手錶歸零
            sw.Start();    //手錶啟動

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            save(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            save(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            save(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            save(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            save(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            save(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            save(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            save(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            save(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            save(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            save(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            save(11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            save(12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            save(13);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            save(14);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            save(15);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            save(16);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            save(17);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            close(fc);
            close(sc);
            timer2.Enabled = false;
            interact(true, fc);
            interact(true, sc);
        }
    }
}
