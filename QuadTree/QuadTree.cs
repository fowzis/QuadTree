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
            QTNode tmpNode = null;

            if (!FindNode(point, out tmpNode))
            {
                Console.WriteLine("Error:: QuadTree.Insert:: Error inserting point to tree");
                return false;
            }

            if (tmpNode.IsMaxCapacity)
            {
                // Split Node
            }
            return true;
        }

        public bool FindNode(Point point, out QTNode node)
        {
            QTNode tmpNode;

            // Set initial return value
            node = null;

            if (QTRoot == null)
                return false;

            tmpNode = QTRoot;

            while (!tmpNode.IsLeaf)
            {
                tmpNode.FindQuadrant(point, out tmpNode);
            }

            return true;
        }
    }
}
