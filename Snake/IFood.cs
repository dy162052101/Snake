using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace progrem
{
    interface IFood
    {
        void eat_food(int left, int top);//蛇吃食物后增加一节身体
        void food_location();//判断食物是否与蛇重叠
        void food_location_change();//改变食物坐标
    }
}
