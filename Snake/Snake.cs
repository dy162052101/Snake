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
    class Snake:ISnake
    {
        public int m;
        public bool IsDeath = false;
        public PictureBox[] snake_init = new PictureBox[20];//创建初始化的蛇，有三节身体
        public PictureBox[] snake_body = new PictureBox[20000];//创建蛇吃到食物后长出的身体

        public void creat_snake_init()
        {
            for (int i = 0; i < 3; i++)
            {
                snake_init[i] = new PictureBox();
                snake_init[i].BorderStyle = BorderStyle.None;
                snake_init[i].Width = 20;
                snake_init[i].Height = 20;
                snake_init[i].Left = 100;
                snake_init[i].Top = 200;
                snake_init[i].BackColor = Color.Transparent;
                if (i > 0)
                {
                    Image image = Properties.Resources.snake_body;
                    snake_init[i].Image = image;
                    snake_init[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    
                }
            }
        }
        public void creat_snake_body()
        {
            snake_body[m] = new PictureBox();
            snake_body[m].BorderStyle = BorderStyle.None;
            snake_body[m].Left = snake_init[2].Left;
            snake_body[m].Top = snake_init[2].Top;
            snake_body[m].Width = 20;
            snake_body[m].Height = 20;
            Image image = Properties.Resources.snake_body;
            snake_body[m].Image = image;
            snake_body[m].SizeMode = PictureBoxSizeMode.StretchImage;
            snake_body[m].BackColor = Color.Transparent;
        }

        /// <summary>
        /// 初始蛇（三个长度）的移动
        /// </summary>
        /// <param name="x">蛇的X轴位移的变量</param>
        /// <param name="y">蛇的Y轴位移的变量</param>
        public void snake_init_move(int x,int y)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Width">游戏界面（panel）的宽</param>
        /// <param name="Height">游戏界面（panel）的高</param>
        public void snake_die(int Width,int Height)
        {
            //碰墙死
            if (snake_init[0].Left < 10 || snake_init[0].Right > Width - 10
                || snake_init[0].Top < 10 || snake_init[0].Bottom > Height - 20)
            { IsDeath = true; }
            ///自残死
            for (int i = 0; i < m; i++)
            {
                if (snake_init[0].Left == snake_body[i].Left &&
                    snake_init[0].Top == snake_body[i].Top)
                { IsDeath = true; }
            }
        }


    }
}
