using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekDay
{
    class MapV2
    {
        public class Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public int X;
            public int Y;
            public override string ToString()
            {
                return "("+X + ":" + Y+")";
            }
        }
        int width;
        int height;
        public Dictionary<int, Point> points=new Dictionary<int, Point>();
        public MapV2(int w, int h)
        {
            width = w;
            height = h;
            points = new Dictionary<int, Point>();
            for (int i = 0; i < w*h; i++)
            {
                points.Add(i, new Point(i % width, i / width));
            }
            
        }
        public List<int> Others(int id)
        {
            Point p = points[id];
            List<int> keys = new List<int>();
            if (FirstType(p))
            {
                keys.Add(PointId(p.X - 1, p.Y));
                keys.Add(PointId(p.X, p.Y - 1));
                keys.Add(PointId(p.X + 1, p.Y - 1));
                keys.Add(PointId(p.X + 1, p.Y));
                keys.Add(PointId(p.X + 1, p.Y + 1));
                keys.Add(PointId(p.X, p.Y + 1));
            }
            else
            {
                keys.Add(PointId(p.X + 1, p.Y));
                keys.Add(PointId(p.X, p.Y + 1));
                keys.Add(PointId(p.X - 1, p.Y + 1));
                keys.Add(PointId(p.X - 1, p.Y));
                keys.Add(PointId(p.X - 1, p.Y - 1));
                keys.Add(PointId(p.X, p.Y - 1));
            }
            return keys.Where(x => IsValid(x)).Select(x => x).ToList();

        }
        private bool IsValid(int id)
        {
            return id > -1 && id < height * width;
        }
        bool FirstType(Point p)
        {
            return p.Y % 2 == 0;
        }
        public int PointId(int x,int y)
        {
            return y * width + x;
        }
        public Dictionary<int, int> Fields(int point, int distance)
        {
            Dictionary<int, int> distacnes = new Dictionary<int, int>();
            distacnes.Add(point, 0);
            Queue<int> vs = new Queue<int>();
            vs.Enqueue(point);
            while (vs.Count != 0)
            {
                int index = vs.Dequeue();
                int d = distacnes[index];
                if ( d< distance)
                {
                    foreach (var item in Others(index))
                    {
                        if (!distacnes.Keys.Contains(item))
                        {
                            vs.Enqueue(item);
                            distacnes.Add(item, d + 1);
                        }
                    }
                }
            }
            return distacnes;
        }
    }
}
