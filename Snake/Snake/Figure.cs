using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure//базовый класс для наследников
    {
        protected List<Point> pList;//чтоб pList была видна у наследников

        public void DrawLine()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
