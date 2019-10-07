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
    class Food:IFood
    {
        public PictureBox snake_food = new PictureBox();//创建蛇的食物
        Snake s = new Snake();
        public int s1 = 0;
        public bool IsEat = false;

        public void creat_food()
        {
            snake_food = new PictureBox();
            snake_food.BorderStyle = BorderStyle.None;
            snake_food.Width = 20;
            snake_food.Height = 20;
            Image image = Properties.Resources.form3_food;
            snake_food.Image = image;
            snake_food.SizeMode = PictureBoxSizeMode.StretchImage;
            snake_food.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 蛇吃食物
        /// </summary>
        /// <param name="left">蛇头X轴坐标</param>
        /// <param name="top">蛇头Y轴坐标</param>
        public void eat_food(int left,int top)
        {
            if (left >= snake_food.Left - 5 && left <= snake_food.Left + 5
                && top >= snake_food.Top - 5 && top <= snake_food.Top + 5)
            { food_location(); IsEat = true; }
            else
            { IsEat = false; }
        }
        public void food_location()
        {
            Random r = new Random();
            snake_food.Left = r.Next(1, 19) * 20;
            snake_food.Top = r.Next(1, 14) * 20;
        }
        public void food_location_change()
        {
            for (int i = 0; i < s.m; i++)
            {
                if (snake_food.Left == s.snake_body[i].Left && snake_food.Top == s.snake_body[i].Top
                    || snake_food.Left == s.snake_init[1].Left && snake_food.Top == s.snake_init[1].Top
                    || snake_food.Left == s.snake_init[2].Left && snake_food.Top == s.snake_init[2].Top)
                { s1++; food_location(); }
            }
        }




    }
}
