using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Collision
    {
        // check collision of user and enemies
        public static void checkEnemyCollision(Gintoki ginsan, List<Shinsengumi> shinsen)
        {
            foreach(Shinsengumi s in shinsen)
            {
                if (s.sourceRec.Intersects(ginsan.sourceRec))
                {
                    if (ginsan.hype) {
                        s.death();
                    } else if (ginsan.alive)
                    {
                        ginsan.death();
                    }
                }
            }
        }

        // chekc Collision on the Map for Ginsan
        public static void checkMapCollision(Gintoki ginsan, List<List<Tiles>> mapTiles)
        {
            int ginsan_X = (int)(ginsan.pos.X / 32);
            int ginsan_Y = (int)(ginsan.pos.Y / 32);
            Direct direction = ginsan.dir;
            Tiles currentTile = mapTiles[ginsan_Y][ginsan_X];
            Tiles nextTile = findNextTile(ginsan_X, ginsan_Y, mapTiles, direction);
            int next_X = ginsan_X;
            int next_Y = ginsan_Y;

            if (currentTile.state == TileState.Teleport)
            {
                ginsan.teleport();
                return;
            }

            // checkBound
            if (checkBound(ginsan.sourceRec, ginsan.dir))
            {
                ginsan.collide = true;
                return;
            }

            if (nextTile == null) return;

            #region get NEXT x and Y
            switch (direction)
            {
                case Direct.Left:
                    next_X = ginsan_X - 1;
                    break;
                case Direct.Right:
                    next_X = ginsan_X + 1;
                    break;
                case Direct.Down:
                    next_Y = ginsan_Y + 1;
                    break;
                case Direct.Up:
                    next_Y = ginsan_Y - 1;
                    break;
                default:
                    break;
            }
            #endregion

            // check Items
            Tiles up = findNextTile(next_X, next_Y, mapTiles, Direct.Up);
            Tiles down = findNextTile(next_X, next_Y, mapTiles, Direct.Down);
            Tiles left = findNextTile(next_X, next_Y, mapTiles, Direct.Left);
            Tiles right = findNextTile(next_X, next_Y, mapTiles, Direct.Right);

            checkItem(currentTile, ginsan);
            checkItem(nextTile, ginsan);
            checkItem(up, ginsan);
            checkItem(down, ginsan);
            checkItem(left, ginsan);
            checkItem(right, ginsan);
            
            #region check Tile state
            switch (nextTile.state)
            {
                case TileState.Wall:
                    if (ginsan.sourceRec.Intersects(nextTile.tileRec)) ginsan.collide = true;
                    break;
                case TileState.Gate:
                    ginsan.collide = true;
                    break;
                case TileState.Empty:
                    Tiles below = findNextTile(next_X, next_Y, mapTiles, Direct.Down);
                    Rectangle rec = ginsan.sourceRec;
                    rec.Height -= 20;
                    if (below != null && below.state == TileState.Wall &&
                        rec.Intersects(below.tileRec))
                    {
                        ginsan.collide = true;
                        return;
                    }
                    break;
                default:
                    ginsan.collide = false;
                    break;
            }
            #endregion 
        }

        // check Collision for enemies
        public static void checkShinCollision(Shinsengumi shinsen, List<List<Tiles>> mapTiles)
        {
            int pos_X = (int)(shinsen.pos.X / 32);
            int pos_Y = (int)(shinsen.pos.Y / 32);
            Tiles nextTile = findNextTile(pos_X, pos_Y, mapTiles, shinsen.dir);

            if ( nextTile == null || (nextTile.state == TileState.Wall && shinsen.sourceRec.Intersects(nextTile.tileRec))|| 
                checkBound(shinsen.sourceRec, shinsen.dir))
            {
                shinsen.changeDirection(mapTiles);
            }
        }

        public static Tiles findNextTile(int pos_X, int pos_Y, List<List<Tiles>> mapTiles, 
            Direct direction)
        {
            Tiles currentTile = mapTiles[pos_Y][pos_X];
            Tiles nextTile = currentTile;
            int next_X = pos_X;
            int next_Y = pos_Y;

            switch (direction)
            {
                case Direct.Left:
                    next_X = pos_X - 1;
                    break;
                case Direct.Right:
                    next_X = pos_X + 1;
                    break;
                case Direct.Down:
                    next_Y = pos_Y + 1;
                    break;
                case Direct.Up:
                    next_Y = pos_Y - 1;
                    break;
                default:
                    break;
            }
            if (next_X < 0 || next_X > 30 || next_Y < 0 || next_Y > 33)
            {
                nextTile = null;
            }
            else
            {
                nextTile = mapTiles[next_Y][next_X];
            }
            return nextTile;
        }

        private static bool checkBound(Rectangle rec, Direct dir)
        {
            return ((dir == Direct.Left && rec.Intersects(Const.leftBound)) ||
                (dir == Direct.Up && rec.Intersects(Const.upperBound)) ||
                (dir == Direct.Right && rec.Intersects(Const.rightBound)) ||
                (dir == Direct.Down && rec.Intersects(Const.lowerBound)));
        }

        private static void checkItem(Tiles tile, Gintoki ginsan)
        {
            if (tile == null) return;
            if ((tile.state == TileState.Item || tile.state == TileState.Weapon) && 
                ginsan.sourceRec.Intersects(tile.itemRec))
            {
                tile.itemEaten(ginsan);
            }
        }
    }
}
