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
        public List<Point> Points;

        public Rectangle Bounds { get; private set; }

        public QTNode TopLeft { get; set; }
        public QTNode TopRight { get; set; }
        public QTNode BottomLeft { get; set; }
        public QTNode BottomRight { get; set; }

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

        public bool Add(Point point)
        {
            if (!this.Bounds.Contains(point))
            {
                Console.WriteLine("Error:: QTNode.Insert:: Point {0} is out of bounds {1}", point.ToString(), Bounds.ToString());
                return false;
            }

            Points.Add(point);

            return true;
        }

        public bool FindQuad(Point point, out QTNode node)
        {
            // Set initial return value
            node = null;

            if (!this.Bounds.Contains(point))
            {
                Console.WriteLine("Error:: QTNode.FindQuadrant:: Point not in Node boundaries");
                return false;
            }

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

        public bool Subdivide()
        {
            int halfWidth = this.Bounds.Width / 2;
            int halfHeight = this.Bounds.Height / 2;

            // Subdivide current node
            TopLeft = new QTNode(new Rectangle(Bounds.X, Bounds.Y, halfWidth, halfHeight), Capacity);
            TopRight = new QTNode(new Rectangle(Bounds.X + halfWidth, Bounds.Y, halfWidth, halfHeight), Capacity);
            BottomLeft = new QTNode(new Rectangle(Bounds.X, Bounds.Y + halfHeight, halfWidth, halfHeight), Capacity);
            BottomRight = new QTNode(new Rectangle(Bounds.X + halfWidth, Bounds.Y + halfHeight, halfWidth, halfHeight), Capacity);

            // insert the current points to the right quadrant
            foreach (var point in Points)
            {
                if (!FindQuad(point, out QTNode tmpNode))
                {
                    Console.WriteLine("Error:: QuadTree.Insert:: Error inserting point to tree");
                    return false;
                }

                tmpNode.Add(point);
            }

            this.Points.Clear();
            this.IsLeaf = false;

            // Success
            return true;
        }
    }
}
