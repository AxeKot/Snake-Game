using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetBufferSize(80, 25);
            //Console.SetBufferSize(120, 30);

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);

            // отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 0, 24, '+');
            VerticalLine rightLine = new VerticalLine(78, 0, 24, '+');

            upLine.DrawLine();
            downLine.DrawLine();
            leftLine.DrawLine();
            rightLine.DrawLine();


            //отрисовка точек
            Point p = new Point(4, 5, '#');
            p.Draw();

            Console.ReadLine();
        }
    }
}
