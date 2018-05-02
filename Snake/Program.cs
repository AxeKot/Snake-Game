using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Walls walls = new Walls(80, 25);
            walls.DrawLine();            
      
            //отрисовка точек
            Point p = new Point(4, 5, '#');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.DrawLine();


            FoodCreator foodCreator = new FoodCreator(80, 25, '$'); //габариты экрана и символ еды
            Point food = foodCreator.CreateFood();
            while (true) //проверка на генерацию еды внутри змеи
            {
                if (!snake.IsHit(food))
                    break;
                else
                    food = foodCreator.CreateFood();
            }
            food.Draw();

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food)) //встретится ли змейка с едой
                {
                    while (true) //проверка на генерацию еды внутри змеи
                    {
                        if (!snake.IsHit(food))
                            break;
                        else
                            food = foodCreator.CreateFood();
                    }
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }                    
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                   
                }
            }


            WriteGameOver();
            Console.ReadLine();

        }
        static void WriteGameOver()
            {
                int xOffset = 25;
                int yOffset = 8;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(xOffset, yOffset++);
                WriteText("============================", xOffset, yOffset++);
                WriteText("G A M E   O V E R", xOffset + 6, yOffset++);
                yOffset++;
                WriteText("AxeKot 2018", xOffset + 9, yOffset++);
                WriteText("============================", xOffset, yOffset++);
            }

            static void WriteText(String text, int xOffset, int yOffset)
            {
                Console.SetCursorPosition(xOffset, yOffset);
                Console.WriteLine(text);
            }
    }
}
