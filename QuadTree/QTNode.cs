using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace QuadTree
{
    /// <summary>
    /// Quad Tree node class
    /// </summary>
    class QTNode
    {
        private List<Point> Points;

        public Rectangle Bounds { get; private set; }

        public QTNode TopLeft { get; private set; }
        public QTNode TopRight { get; private set; }
        public QTNode BottomLeft { get; private set; }
        public QTNode BottomRight { get; private set; }

        public int Capacity { get; private set; }
        public bool IsMaxCapacity { get { return (Points.Count == Capacity); } }
        public bool IsLeaf { get; private set; }

        public QTNode(Rectangle bounds, int capacity)
        {
            this.Capacity = capacity;
            this.Bounds = bounds;
            this.Points = new List<Point>(Capacity);
            this.IsLeaf = true;

            // Initialize child nodes
            this.TopLeft = null;
            this.TopRight = null;
            this.BottomLeft = null;
            this.BottomRight = null;
        }

        public bool Insert(Point point, QTNode node)
        {
            if (!this.Bounds.Contains(point))
            {
                Console.WriteLine("Error:: QTNode.Insert:: Point {0} is out of bounds {1}", point.ToString(), Bounds.ToString());
                return false;
            }

            Points.Add(point);

            return true;
        }

        public bool FindQuadrant(Point point, out QTNode node)
        {
            // Set initial return value
            node = null;

            if (!this.Bounds.Contains(point))
            {
                Console.WriteLine("Error:: QTNode.FindQuadrant:: Point not in Node boundaries");
                return false;
            }

            //if (IsLeaf)
            //{
            //    node = this;    // return self reference
            //    return true;
            //}

            if (TopLeft.Bounds.Contains(point))
                node = TopLeft;
            else if (TopRight.Bounds.Contains(point))
                node = TopRight;
            else if (BottomLeft.Bounds.Contains(point))
                node = BottomLeft;
            else if (BottomRight.Bounds.Contains(point))
                node = BottomRight;
            else
                return false;

            return true;
        }
    }
}
