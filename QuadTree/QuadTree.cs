using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace QuadTree
{
    class QuadTree
    {
        public QTNode QTRoot { get; private set; }
        public Rectangle QTBounds { get; private set; }
        public int QTCapacity { get; private set; }

        public QuadTree(Rectangle bounds, int capacity)
        {
            if (bounds == null || capacity == 0)
            {
                Console.WriteLine("Error:: QuadTree Constructor:: Invalid input parameters");
                return;
            }

            this.QTBounds = bounds;
            this.QTCapacity = capacity;
            this.QTRoot = new QTNode(bounds, capacity);
        }

        public bool Insert(Point point)
        {
            return Insert(point, QTRoot);
        }

        public bool Insert(Point point, QTNode node)
        {
            if (!node.Bounds.Contains(point))
                return false;

            if (node.IsLeaf)
            {
                if (!node.IsMaxCapacity)
                {
                    node.Add(point);
                }
                else
                {
                    // Subdivide Node - Recursivly subdivide the current node to quadrants
                    node.Subdivide();
                }
                return true;
            }

            // Recursivly reinsert the last point to the right quad.
            // As a result if needed will Subdivide again.
            if (node.FindQuad(point, out QTNode quad))
            {
                return Insert(point, quad);
            }

            return true;
        }
    }
}
