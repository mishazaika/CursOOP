using System;
using System.Collections.Generic;//для работы со списками 
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //размер окна
            Console.SetWindowSize(80, 25);

            //рисуем рамку
            Walls walls = new Walls(80, 25);
            walls.Draw();

            //отрисовка точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.DrawLine();

            //еда
            FoodCreator foodCreator = new FoodCreator(80, 25, '&');
            Point food = foodCreator.CreateFood();
            food.Draw();

            //управление стрелками и созданием еды
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    //если змея врезалась в стену или свой хвост, то останавливаем игру
                    break;
                }
                if (snake.Eat(food))
                {
                    //если змея кушает еду, то создаем новую
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    //постоянное движение змейки
                    snake.Move();
                }
                //задержка
                Thread.Sleep(100);

                //следит за нажатыми клавишами. для управления змеей
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

            }




        }


    }
}