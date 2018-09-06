# QuadTree
Visual Representation of the QuadTree algoritm

Quadtrees are trees used to efficiently store data of points on a two-dimensional space. In this tree, each node has at most four children.
We can construct a quadtree from a two-dimensional area using the following steps:

Divide the current two dimensional space into four boxes.
If a box contains one or more points in it, create a child object, storing in it the two dimensional space of the box
If a box does not contain any points, do not create a child for it
Recurse for each of the children.
Quadtrees are used in image compression, where each node contains the average colour of each of its children. The deeper you traverse in the tree, the more the detail of the image.
Quadtrees are also used in searching for nodes in a two-dimensional area. For instance, if you wanted to find the closest point to given coordinates, you can do it using quadtrees.
