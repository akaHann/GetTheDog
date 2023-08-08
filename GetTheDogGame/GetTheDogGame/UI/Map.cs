using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI
{
	public class Map
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		public List<CollisionTiles> CollisionTiles { get; } = new List<CollisionTiles>();

		public void Generate(int[,] map, int size)
		{
			for (int x = 0; x < map.GetLength(1); x++)
			{
				for (int y = 0; y < map.GetLength(0); y++)
				{
					int nr = map[y, x];

					if(nr > 0)
					{
						CollisionTiles.Add(new CollisionTiles(nr, new Rectangle(x * size, y * size, size, size)));
					}

					Width = Math.Max(Width, (x + 1) * size);
					Height = Math.Max(Height, (y + 1) * size);
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

