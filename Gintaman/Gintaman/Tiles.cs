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
        public Rectangle itemRec;
        public Texture2D item;
        public Vector2 itemPos;
        public Rectangle itemSize;

        public Tiles(int x, int y)
        {
            state = TileState.Empty;
            tileRec = new Rectangle(x * Const.tile_size + 1, y * Const.tile_size,
                Const.tile_size + 10, Const.tile_size + 10);
            itemPos = new Vector2(x * Const.tile_size, y * Const.tile_size);
        }

        public void LoadContent(ContentManager content)
        {
            if (state == TileState.Item)
            {
                item = content.Load<Texture2D>("Sprites//pudd");
                itemPos.X += 10;
                itemPos.Y += 10;
                itemRec = new Rectangle((int)itemPos.X, (int)itemPos.Y, 28, 25);
                itemSize = new Rectangle((int)itemPos.X, (int)itemPos.Y, 20, 18);
            } else if (state == TileState.Weapon)
            {
                item = content.Load<Texture2D>("Sprites//Touyako");
                itemPos.X += 10;
                itemPos.Y += 10;
                itemRec = new Rectangle((int)itemPos.X, (int)itemPos.Y, 28, 25);
                itemSize = new Rectangle((int)itemPos.X, (int)itemPos.Y, 25, 18);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (state == TileState.Item || state == TileState.Weapon)
            {
                spriteBatch.Draw(item, itemSize, Color.White);
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

        public void itemEaten(Gintoki ginsan)
        {
            if(state == TileState.Weapon)
            {
                ginsan.getWeapon();
            }
            state = TileState.Empty;
        }
    }
}
