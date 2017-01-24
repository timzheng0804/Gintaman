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
                if(s.sourceRec.Intersects(ginsan.sourceRec))
                {
                    ginsan.death();
                }
            }
        }

        // chekc Collision on the Map for Ginsan
        public static void checkMapCollision(Gintoki ginsan, List<List<Tiles>> mapTiles)
        {
            int ginsan_X = (int)(ginsan.pos.X / 32);
            int ginsan_Y = (int)(ginsan.pos.Y / 32);
            Tiles currentTile = mapTiles[ginsan_Y][ginsan_X];
            Tiles nextTile = currentTile;
            Direct direction = ginsan.dir;
            int next_X = ginsan_X;
            int next_Y = ginsan_Y;

            if (currentTile.state == TileState.Teleport)
            {
                ginsan.teleport();
                return;
            }

            if (checkBound(ginsan.sourceRec, ginsan.dir))
            {
                ginsan.collide = true;
                return;
            }
            // check border

            #region get Next Tile
            switch (direction)
            {
                case Direct.Left:
                    next_X = ginsan_X - 1;
                    if (next_X < 0) nextTile = null;
                    else nextTile = mapTiles[ginsan_Y][next_X];
                    break;
                case Direct.Right:
                    next_X = ginsan_X + 1;
                    if (next_X > 30) nextTile = null;
                    else nextTile = mapTiles[ginsan_Y][next_X];
                    break;
                case Direct.Down:
                    next_Y = ginsan_Y + 1;
                    if (next_Y > 33) nextTile = null;
                    else nextTile = mapTiles[next_Y][ginsan_X];
                    break;
                case Direct.Up:
                    next_Y = ginsan_Y - 1;
                    if (next_Y < 0) nextTile = null;
                    else nextTile = mapTiles[next_Y][ginsan_X];
                    break;
                default:
                    break;
            }
            #endregion

            if (nextTile == null) return;

            #region check Tile state
            switch (nextTile.state)
            {
                case TileState.Wall:
                    if(ginsan.sourceRec.Intersects(nextTile.tileRec)) ginsan.collide = true;
                    break;
                case TileState.Gate:
                    ginsan.collide = true;
                    break;
                case TileState.Item:
                    break;
                case TileState.Empty:
                    if (next_Y + 1 < Const.map_y_tiles)
                    {
                        // check upper tile bound
                        Tiles above = mapTiles[next_Y + 1][next_X];
                        Rectangle halfRec = above.tileRec;
                        halfRec.Y += 18;
                        if (above.state == TileState.Wall &&
                            ginsan.sourceRec.Intersects(halfRec))
                        {
                            ginsan.collide = true;
                        }
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
    }
}
