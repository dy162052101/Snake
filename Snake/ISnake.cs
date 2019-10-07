using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace progrem
{
    interface ISnake
    {
        void snake_init_move(int x, int y);
        void snake_body_move();
        void snake_die(int Width, int Height);
    }
}
