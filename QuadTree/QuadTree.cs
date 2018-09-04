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
                    return true;
                }
                else
                {
                    // Subdivide Node - Recursivly subdivide the current node to quadrants
                    node.Subdivide();
                }
            }

            // Recursivly reinsert the last point to the right quad.
            // As a result if needed will Subdivide again.
            if (node.FindQuad(point, out QTNode quad))
            {
                return Insert(point, quad);
            }

            return false;
        }

        public List<Rectangle> GetRectangles()
        {
            QTNode node;
            Queue<QTNode> Q = new Queue<QTNode>();
            List<Rectangle> recList = new List<Rectangle>();

            if (QTRoot == null)
            {
                Console.WriteLine("Error:: QuadTree.GetRectangles:: Empty Quad Tree");
                return null;
            }

            Q.Enqueue(QTRoot);

            while (Q.Count > 0)
            {
                node = Q.Dequeue();
                recList.Add(node.Bounds);

                if (!node.IsLeaf)
                {
                    Q.Enqueue(node.TopLeft);
                    Q.Enqueue(node.TopRight);
                    Q.Enqueue(node.BottomLeft);
                    Q.Enqueue(node.BottomRight);
                }
            }

            return recList;
        }
    }
}
