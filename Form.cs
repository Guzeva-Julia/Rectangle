/*Copyright (C) 2022 Huzieva Iyliia*/
/* Розробити клас, який повинен містити три конструктори, властивості, 
 * по можливості передбачити статичні елементи класу та перевантаження методів. 
 * Розробити Windows Form додаток, яка демонструє роботу класу.  
 * 6. Скласти опис класу прямокутників зі сторонами, паралельними осям координат. 
 * Передбачити можливість переміщення прямокутників на площині, зміни розмірів, 
 * побудови найменшого прямокутника, що містить два задані прямокутники, і прямокутники,
 * що є спільною частиною (перетинанням) двох прямокутників.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using static System.Drawing.Rectangle;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace Huzeva_Lab16
{
    public partial class Form : System.Windows.Forms.Form
    {
        private MyRectangle rect1;
        private MyRectangle rect2;
        public Form()
        {
            InitializeComponent();
            rect1 = new MyRectangle(10, 10, 100, 50);
            rect2 = new MyRectangle(70, 30, 50, 100);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(rect1.X, rect1.Y, rect1.Width, rect1.Height));
            e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(rect2.X, rect2.Y, rect2.Width, rect2.Height));

          }
        //Метод moveRect1 та moveRect2 дозволяє перемістити перший та другий прямокутник на 10 пікселів вправо.
        private void moveRect1Button_Click_1(object sender, EventArgs e)
        {
            rect1 = new MyRectangle(rect1.X + 10, rect1.Y, rect1.Width, rect1.Height);
            Console.WriteLine($"Rect1: X = {rect1.X}, Y = {rect1.Y}, Width = {rect1.Width}, Height = {rect1.Height}");
            panel1.Invalidate();
        }        
        private void moveRect2Button_Click(object sender, EventArgs e)
        {
            rect2 = new MyRectangle(rect2.X + 10, rect2.Y, rect2.Width, rect2.Height);
            panel1.Invalidate();
        }
        //Метод дозволяє збільшити перший та другий прямокутники на 20 пікселів по ширині та висоті.
        
        private void resizeRect1Button_Click(object sender, EventArgs e)
        {
            MyRectangle newRect1 = new MyRectangle(rect1.X, rect1.Y, rect1.Width + 20, rect1.Height + 20);
            rect1 = newRect1;
            panel1.Invalidate();
        }
        private void resizeRect2Button_Click(object sender, EventArgs e)
        {
            MyRectangle newRect2 = new MyRectangle(rect2.X, rect2.Y, rect2.Width + 20, rect2.Height + 20);
            rect2 = newRect2;
            panel1.Invalidate();
        }
        /*Метод знаходить найменший прямокутник, що містить обидва задані прямокутники rect1 
         * та rect2, та виводить його в діалоговому вікні MessageBox.*/
        private void butBounding_Click(object sender, EventArgs e)
        {
            MyRectangle boundingBox = MyRectangle.Union(rect1, rect2);
            MessageBox.Show($"Bounding box: X={boundingBox.X}, Y={boundingBox.Y}, Width={boundingBox.Width}, Height={boundingBox.Height}");
        }

        /*Метод знаходить перетинання двох прямокутників rect1 та rect2, 
         * та виводить його в діалоговому вікні MessageBox.
         * Якщо прямокутники не перетинаються, виводиться повідомлення про це.*/
        private void butIntersection_Click(object sender, EventArgs e)
        {
            System.Drawing.Rectangle rectangle1 = new System.Drawing.Rectangle(rect1.X, rect1.Y, rect1.Width, rect1.Height);
            System.Drawing.Rectangle rectangle2 = new System.Drawing.Rectangle(rect2.X, rect2.Y, rect2.Width, rect2.Height);

            System.Drawing.Rectangle intersection = System.Drawing.Rectangle.Intersect(rectangle1, rectangle2);

            if (intersection.IsEmpty)
            {
                MessageBox.Show("The rectangles do not intersect.");
            }
            else
            {
                MessageBox.Show($"Intersection: {intersection}");
            }
        }

    }
}
