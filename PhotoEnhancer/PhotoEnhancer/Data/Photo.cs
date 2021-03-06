﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class Photo
    {
        public int Width
        {
            get { return data.GetLength(0); }
        }

        public int Height
        {
            get { return data.GetLength(1); }
        }

        private Pixel[,] data;

        public Photo(int width, int height)
        {
            data = new Pixel[
                CheckSize(width, "ширина"),
                CheckSize(height, "высота")
                ];
        }

        public Pixel this[int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }

        private int CheckSize(int val, string name)
        {
            if (val <= 0)
                throw new Exception($"Неверная {name} {val}. Размер должен быть положительный");

            return val;
        }


    }
}
