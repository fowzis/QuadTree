using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace QuadTree
{
    static class Art
    {
        public static Texture2D Pixel { get; private set; }		// a single white pixel
        public static Texture2D Dot16 { get; private set; }		// a single white pixel
        public static Texture2D Dot32 { get; private set; }		// a single white pixel

        public static void Load(ContentManager content)
        {
            // TODO
            Pixel = content.Load<Texture2D>(@"Pixel");
            Dot16 = content.Load<Texture2D>(@"Dot16x16");
            Dot32 = content.Load<Texture2D>(@"Dot32x32");
        }
    }
}
