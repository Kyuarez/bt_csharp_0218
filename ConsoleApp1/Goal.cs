﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Goal : GameObject
    {
        public Goal(Vector2 position, char shape)
        {
            this.name = GetType().Name;
            this.position = position;
            this.shape = shape;
            orderLayer = 3;
            isTrigger = true;

            color.r = 0;
            color.g = 255;
            color.b = 0;
            color.a = 255;
        }
    }
}
