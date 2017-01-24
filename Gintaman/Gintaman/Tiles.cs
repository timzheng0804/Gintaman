using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Tiles
    {
        public TileState state { get; set; }
        public Rectangle tileRec;
        public Texture2D item;
        public Vector2 itemPos;

        public Tiles(int x, int y)
        {
            state = TileState.Empty;
            tileRec = new Rectangle(x * Const.tile_size + 1, y * Const.tile_size,
                Const.tile_size + 10, Const.tile_size + 10);
            itemPos = new Vector2(x * Const.tile_size, y * Const.tile_size);
        }

        public void LoadContent(ContentManager content)
        {
            item = content.Load<Texture2D>("Sprites//pudding");
            itemPos.X += 10;
            itemPos.Y += 10;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (state == TileState.Item)
            {
                spriteBatch.Draw(item, itemPos, Color.White);
            }
        }

        public void birthWall(birthTile birthTile)
        {
            state = TileState.Wall;
            if (birthTile == birthTile.Horizontal)
            {
                tileRec.Height /= 2;
            }
        }

        public void gate()
        {
            state = TileState.Gate;
            tileRec.Height /= 4;
        }
    }
}
