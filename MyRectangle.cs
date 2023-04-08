using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Huzeva_Lab16
{
    class MyRectangle
    {
        //координати верхнього лівого кута
        public int X { get; set; }
        public int Y { get; set; }
        //ширина та висота
        public int Width { get; set; }
        public int Height { get; set; }

        //Конструктор 1
        public MyRectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }


        //Конструктор 2, викликає Конструктор 1 та ініціалізує об'єкт нулями
        public MyRectangle() : this(0, 0, 0, 0)
        {
        }

        //Конструктор 3, викликає Конструктор 1 та ініціалізує об'єкт копією іншого прямокутника
        public MyRectangle(MyRectangle rect) : this(rect.X, rect.Y, rect.Width, rect.Height)
        {
        }

        //метод переміщення прямокутника на відстань (dx, dy)
        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        //метод зміни розміру прямокутника на коефіцієнти (kw, kh)
        public void Resize(double kw, double kh)
        {
            Width = (int)(Width * kw);
            Height = (int)(Height * kh);
        }

        //метод знаходження найменшого прямокутника, що містить два задані прямокутники
        public static MyRectangle GetBoundingBox(MyRectangle rect1, MyRectangle rect2)
        {
            int x = Math.Min(rect1.X, rect2.X);
            int y = Math.Min(rect1.Y, rect2.Y);
            int right = Math.Max(rect1.X + rect1.Width, rect2.X + rect2.Width);
            int bottom = Math.Max(rect1.Y + rect1.Height, rect2.Y + rect2.Height);
            int width = right - x;
            int height = bottom - y;
            return new MyRectangle(x, y, width, height);
        }

        //метод знаходження прямокутника, що є спільною частиною (перетинанням) двох прямокутників
        public static Rectangle GetIntersection(Rectangle rect1, Rectangle rect2)
        {
            int x = Math.Max(rect1.X, rect2.X);
            int y = Math.Max(rect1.Y, rect2.Y);
            int right = Math.Min(rect1.X + rect1.Width, rect2.X + rect2.Width);
            int bottom = Math.Min(rect1.Y + rect1.Height, rect2.Y + rect2.Height);
            int width = right - x;
            int height = bottom - y;
            if (width <= 0 || height <= 0) //якщо немає перетинання
            {
                return Rectangle.Empty;
            }
            return new Rectangle(x, y, width, height);
        }
        public class RectangleEx : MyRectangle
        {
            public RectangleEx(int x, int y, int width, int height) : base(x, y, width, height)
            {
            }

            public void Inflate(int x, int y)
            {
                X -= x;
                Y -= y;
                Width += 2 * x;
                Height += 2 * y;
            }
        }

        // Accessor methods for Location
        public Point Location
        {
            get { return new Point(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public static MyRectangle Union(MyRectangle rect1, MyRectangle rect2)
        {
            int x1 = Math.Min(rect1.X, rect2.X);
            int y1 = Math.Min(rect1.Y, rect2.Y);
            int x2 = Math.Max(rect1.X + rect1.Width, rect2.X + rect2.Width);
            int y2 = Math.Max(rect1.Y + rect1.Height, rect2.Y + rect2.Height);

            int width = x2 - x1;
            int height = y2 - y1;

            return new MyRectangle(x1, y1, width, height);
        }
    }
}
