using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GetTheDogGame.Levels
{
	public class Map
	{
            public List<CollisionTiles> CollisionTiles { get; } = new List<CollisionTiles>();
            public int Width { get; private set; }
            public int Height { get; private set; }

            public void Generate(int[,] map, int size)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    for (int y = 0; y < map.GetLength(0); y++)
                    {
                        int nr = map[y, x];

                        if (nr > 0)
                        {
                            CollisionTiles.Add(new CollisionTiles(nr, new Rectangle(x * size, y * size, size, size)));
                        }

                        Width = (x + 1) * size;
                        Height = (y + 1) * size;
                    }
                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                foreach (CollisionTiles tile in CollisionTiles)
                {
                    tile.Draw(spriteBatch);
                }
            }
    }

}

