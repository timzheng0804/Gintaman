using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Map
    {
        private List<List<Tiles>> tiles;
        private Texture2D gameMap;
        private Vector2 mapPos;

        public Map()
        {
            tiles = new List<List<Tiles>>();
        }

        public void Initialize()
        {
            // initialize tiles
            for (int i = 0; i < Const.map_y_tiles; ++i)
            {
                List<Tiles>row = new List<Tiles>();
                for (int j = 0; j < Const.map_x_tiles; ++j)
                {
                    Tiles newTile = new Tiles(j, i);
                    row.Add(newTile);
                }
                tiles.Add(row);
            }

            // initialize Items
            for (int i = 0; i < Const.itemPos.Count; ++i)
            {
                for (int j = 0; j < Const.itemPos[i].Count; ++j)
                {
                    if (Const.itemPos[i][j] == (int)itemType.Pudding)
                    {
                        tiles[i][j].state = TileState.Item;
                    } else if (Const.itemPos[i][j] == (int)itemType.Touyako)
                    {
                        tiles[i][j].state = TileState.Weapon;
                    }
                }
            } 

            // initialize walls
            for (int i = 0; i < Const.wallPos.Count; ++i)
            {
                for (int j = 0; j < Const.wallPos[i].Count; ++j)
                {
                    tiles[i][Const.wallPos[i][j]].state = TileState.Wall;
                }
            }

            // initialize teleport
            tiles[13][0].state = TileState.Teleport;
            tiles[14][0].state = TileState.Teleport;
            tiles[16][0].state = TileState.Teleport;
            tiles[17][0].state = TileState.Teleport;
            tiles[13][29].state = TileState.Teleport;
            tiles[14][29].state = TileState.Teleport;
            tiles[16][29].state = TileState.Teleport;
            tiles[17][29].state = TileState.Teleport;

            tiles[13][13].gate();
            tiles[13][14].gate();
            tiles[13][15].gate();
            tiles[13][16].gate();

            // initialize monster birth place
            tiles[13][11].birthWall(birthTile.Both);
            tiles[14][11].birthWall(birthTile.Both);
            tiles[15][11].birthWall(birthTile.Both);
            tiles[16][11].birthWall(birthTile.Both);
            tiles[13][13].birthWall(birthTile.Both);
            tiles[13][12].birthWall(birthTile.Both);
            tiles[13][17].birthWall(birthTile.Both);
            tiles[13][18].birthWall(birthTile.Both);
            tiles[14][18].birthWall(birthTile.Both);
            tiles[15][18].birthWall(birthTile.Both);
            tiles[16][18].birthWall(birthTile.Both);
            tiles[16][17].birthWall(birthTile.Both);
            tiles[16][16].birthWall(birthTile.Both);
            tiles[16][15].birthWall(birthTile.Both);
            tiles[16][14].birthWall(birthTile.Both);
            tiles[16][13].birthWall(birthTile.Both);
            tiles[16][12].birthWall(birthTile.Both);
            tiles[16][11].birthWall(birthTile.Both);
        }

        public void LoadContent(ContentManager content)
        {
            gameMap = content.Load<Texture2D>("Sprites//gameMap");
            mapPos = new Vector2(0, 0);
            gameObjs.LoadContent(content);
            foreach(List<Tiles> ts in tiles)
            {
                foreach(Tiles t in ts)
                {
                    t.LoadContent(content);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            checkCollision();
            gameObjs.Update(gameTime);
            gameObjs.changeDirForShinsen(tiles);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gameMap, mapPos, Color.White);
            foreach (List<Tiles> ts in tiles)
            {
                foreach (Tiles t in ts)
                {
                    t.draw(spriteBatch);
                }
            }
            gameObjs.Draw(spriteBatch);
        }

        public void checkCollision()
        {
            gameObjs.checkCollision(tiles);
        }
    }
}
