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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int x = 0;//蛇x轴移动的变量
        private int y = 0;//蛇y轴移动的变量
        PictureBox p;//用来创建食物
        Label[] snake = new Label[20000];//用来创建蛇的身体
        Random r = new Random();//创建随机数
        private int a1, b1, j = 0, i = 0, i1 = 1;
        private string mark;
        int u=1;//测试数据用的变量


        /// <summary>
        /// 蛇的移动的控制和加速的控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    {
                        mark = "a";
                        if (x > 0)
                        { x = 10; y = 0; }
                        else
                        { x = -10; y = 0; }

                    } break;
                case Keys.D:
                    {
                        mark = "d";
                        if (x < 0)
                        { x = -10; y = 0; }
                        else
                        { x = 10; y = 0; }

                    } break;
                case Keys.W:
                    {
                        mark = "w";
                        if (y > 0)
                        { x = 0; y = 10; }
                        else
                        { x = 0; y = -10; }


                    } break;
                case Keys.S:
                    {
                        mark = "s";
                        if (y < 0)
                        { x = 0; y = -10; }
                        else
                        { x = 0; y = 10; }

                    } break;
                case Keys.J:
                    {
                        timer1.Interval = 50;
                    }
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.J:
                    {
                        timer1.Interval = 200;
                    }
                    break;
            }
        }


        /// <summary>
        /// 简单来说timer就是每隔多少秒蛇运动一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox3.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y);
            pictureBox2.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
            pictureBox1.Left += x;
            pictureBox1.Top += y;//上边四行都是初始化的蛇，长度为三


            picture_change();
            picture_eat();
            eat_food();
            snake_eat();
            snake_die();
            progressBar1.Value = i/10;
            
        }

        /// <summary>
        /// 根据蛇头的方向改变蛇头的图片
        /// </summary>
        private void picture_change()
        {
            if (mark == "a")
            {
                    Image image = Properties.Resources.left;
                    pictureBox1.Image = image;
            }
            if (mark == "s")
            {
                    Image image = Properties.Resources.down;
                    pictureBox1.Image = image;
            }
            if (mark == "d")
            {
                    Image image = Properties.Resources.right;
                    pictureBox1.Image = image;
            }
            if (mark == "w")
            {
                    Image image = Properties.Resources.up;
                    pictureBox1.Image = image;
            }
        }

        private void picture_eat()
        {
            if (pictureBox1.Left <= a1 + 5 && pictureBox1.Left >= a1 - 5 &&
                pictureBox1.Top <= b1 + 5 && pictureBox1.Top >= b1 - 5 && mark == "a")
            {
                Image image = Properties.Resources.left_open;
                pictureBox1.Image = image;
            }
            if (pictureBox1.Left <= a1 + 5 && pictureBox1.Left >= a1 - 5 &&
               pictureBox1.Top <= b1 + 5 && pictureBox1.Top >= b1 - 5 && mark == "s")
            {
                Image image = Properties.Resources.down_open;
                pictureBox1.Image = image;
            }
            if (pictureBox1.Left <= a1 + 5 && pictureBox1.Left >= a1 - 5 &&
               pictureBox1.Top <= b1 + 5 && pictureBox1.Top >= b1 - 5 && mark == "d")
            {
                Image image = Properties.Resources.right_open;
                pictureBox1.Image = image;
            }
            if (pictureBox1.Left <= a1 + 5 && pictureBox1.Left >= a1 - 5 &&
               pictureBox1.Top <= b1 + 5 && pictureBox1.Top >= b1 - 5 && mark == "w")
            {
                Image image = Properties.Resources.up_open;
                pictureBox1.Image = image;
            }
        }


        /// <summary>
        /// 把初始的蛇的身体隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(100, 100);
            pictureBox1.Visible=false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }



        /// <summary>
        /// 给蛇一个初始运动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            x = 10;
            mark = "d";
            food();
            //button1.Hide();//点击按钮后，按钮将会隐藏
            button1.Enabled = false;
            timer1.Enabled = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }


        /// <summary>
        /// 生成食物，吃掉一个食物在随机位置在生成一个食物
        /// </summary>
        public void food()
        {
            
            p = new PictureBox();
            p = new System.Windows.Forms.PictureBox();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Left = r.Next(2, 38)*10;
            p.Top = r.Next(2,28)*10;
            p.Width = 10;
            p.Height = 10;
            p.BackColor = Color.Black;
            a1 = p.Left;
            b1 = p.Top;
            panel1.Controls.Add(p);
        }


        /// <summary>
        /// 蛇吃食物的代码，if中的条件是由于蛇头无法精确找到食物而设置的碰触食物的极小范围
        /// </summary>
        public void eat_food()
        {
            if (pictureBox1.Left <= a1 + 5 && pictureBox1.Left >= a1 - 5 && 
                pictureBox1.Top <= b1 + 5 && pictureBox1.Top >= b1 - 5)
            {
                p.Dispose();
                i1 = i1 + 1;
                j = j + 1;
                food();
            }
        }


        /// <summary>
        /// 生成蛇的身体
        /// </summary>
        public void snake_eat()
        {
            snake[i] = new Label();
            snake[i].BorderStyle = BorderStyle.FixedSingle;
            snake[i].Left = pictureBox3.Left;
            snake[i].Top = pictureBox3.Top;
            snake[i].Width = 10;
            snake[i].Height = 10;
            //snake[i].Text = snake.LongLength.ToString();
            snake[i].BackColor = Color.Black;
            panel1.Controls.Add(snake[i]);
            snake_move();
            i = i + 1;
        }


        /// <summary>
        /// 这个是蛇身体的移动，简单来说就是擦掉第i-1个显示第i个，自己可以在纸上写写看，条件是i>3；
        /// </summary>
        public void snake_move()
        {
            if (i > 3)
            {
               //snake[i].Visible = true;
                //snake[i - i1].Visible = false;
                snake[i-i1].Dispose();
            }
            else
            {
                snake[i].Dispose();
            }
        }



        /// <summary>
        /// 蛇死亡的两种判定
        /// </summary>
        public void snake_die()
        {
            if (pictureBox1.Left < 10 || pictureBox1.Right >= panel1.Width || pictureBox1.Top < 10 || pictureBox1.Bottom > panel1.Bottom - 10)
            {
                label1.Text = "GAME OVER";//游戏结束
                KeyPreview = false; //切断键盘的事件响应
                timer1.Enabled = false;//停止蛇的运动
            }
            for (int i2 = 0; i2 < i; i2++)
            {
                if (snake[i2].Visible == true && pictureBox1.Left == snake[i2].Left && pictureBox1.Top == snake[i2].Top)
                {

                    label1.Text = "GAME OVER";//游戏结束
                    KeyPreview = false; //切断键盘的事件响应
                    timer1.Enabled = false;//停止蛇的运动
                }
            }
        }



        /// <summary>
        /// 设置暂停的按钮
        /// </summary>
        private int time = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            time++;
            if (time % 2 == 0)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
        }




        /// <summary>
        /// 设置退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2 = new Form2();
            if (this.Visible == false)
            {
                f2.Show();
            }
        }
        
        


    }
  
}
