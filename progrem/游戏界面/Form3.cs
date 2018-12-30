using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace progrem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }



        Label[] snake_init = new Label[20];//创建初始化的蛇，有三节身体
        Label[] snake_body = new Label[20];//创建蛇吃到食物后长出的身体
        PictureBox snake_food = new PictureBox();//创建蛇的食物
        private int x = 10, y = 0, m=0;
        private int p = 1;//标记暂停的变量
        Random r = new Random();//创建随机数




        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {




            snake_body_move();
            snake_init_move();
            eat_food();
            snake_die();
        }

        public void creat_snake_init()
        {
            for (int i = 0; i < 3; i++)
            {
                snake_init[i] = new Label();
                snake_init[i].BorderStyle = BorderStyle.FixedSingle;
                snake_init[i].Width = 10;
                snake_init[i].Height = 10;
                snake_init[i].Left = x *10 ;
                snake_init[i].Top = y * 10+150 ;
                snake_init[i].BackColor = Color.Orange;
                panel1.Controls.Add(snake_init[i]);
            }
        }
        public void creat_snake_body()
        {
            snake_body[m] = new Label();
            snake_body[m].BorderStyle = BorderStyle.FixedSingle;
            snake_body[m].Width = 10;
            snake_body[m].Height = 10;
            snake_body[m].BackColor = Color.Orange;
            snake_body[m].Text = m.ToString();
            panel1.Controls.Add(snake_body[m]);
        }
        public void snake_init_move()
        {
            for (int i = 2; i > 0; i--)
            {
                snake_init[i].Left = snake_init[i - 1].Left;
                snake_init[i].Top = snake_init[i - 1].Top;
            }
            snake_init[0].Left += x;
            snake_init[0].Top += y;
        }
        public void snake_body_move()
        {
            if (m > 0)
            {
                for (int i = m - 1; i > 0; i--)
                {

                    snake_body[i].Left = snake_body[i - 1].Left;
                    snake_body[i].Top = snake_body[i - 1].Top;

                }
                snake_body[0].Left = snake_init[2].Left;
                snake_body[0].Top = snake_init[2].Top;
            }
        }


        public void food()
        {
            snake_food = new PictureBox();
            snake_food.BorderStyle = BorderStyle.Fixed3D;
            snake_food.Width = 10;
            snake_food.Height = 10;
            snake_food.Left = r.Next(2, 38) * 10;
            snake_food.Top = r.Next(2, 28) * 10;
            snake_food.BackColor = Color.Brown;
            panel1.Controls.Add(snake_food);
        }
        public void eat_food()
        {
            if (snake_init[0].Left >= snake_food.Left - 5 && snake_init[0].Left <= snake_food.Left + 5
                && snake_init[0].Top >= snake_food.Top - 5 && snake_init[0].Top <= snake_food.Top + 5)
            {
                snake_food.Dispose();
                food();
                creat_snake_body();
                m++;
            }
        }


        public void snake_die()
        {
            ///碰墙死
            if (snake_init[0].Left < 10 || snake_init[0].Right > panel1.Width
                || snake_init[0].Top < 10 || snake_init[0].Bottom >= panel1.Bottom-10 )
            {
                timer1.Enabled = false;
                KeyPreview = false;
            }
            ///自残死
            for (int i = 0; i < m; i++)
            {
                if (snake_init[0].Left == snake_body[i].Left &&
                    snake_init[0].Top == snake_body[i].Top)
                {
                    timer1.Enabled = false;
                    KeyPreview = false;
                }
            }
            
        }



        /// <summary>
        /// 开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            creat_snake_init();
            food();

        }
        /// <summary>
        /// 暂停按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            p++;
            if (p % 2 == 0)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    {
                        if (x > 0)
                        { x = 10; y = 0; }
                        else
                        { x = -10; y = 0; }

                    } break;
                case Keys.D:
                    {
                        if (x < 0)
                        { x = -10; y = 0; }
                        else
                        { x = 10; y = 0; }
                    } break;
                case Keys.W:
                    {
                        if (y > 0)
                        { x = 0; y = 10; }
                        else
                        { x = 0; y = -10; }

                    } break;
                case Keys.S:
                    {
                        if (y < 0)
                        { x = 0; y = -10; }
                        else
                        { x = 0; y = 10; }
                    } break;
             }
        }


    }
}
