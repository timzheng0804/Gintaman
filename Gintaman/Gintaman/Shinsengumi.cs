using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Shinsengumi: Character
    {
        public Rectangle sourceRec;
        private bool needToChange;
        private Direct nextDir;
        private int elpasedTime;

        public Shinsengumi(Vector2 pos, string textureName): base(pos)
        {
            this.textureName = textureName;
            animate = new Animation();
            Random rnd = new Random();
            dir = (Direct)rnd.Next(0, 4);
            needToChange = false;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            animate.Initilization(texture, Const.frameCount, Const.frameTime, 0, 0);
            sourceRec = new Rectangle((int)pos.X, (int)pos.Y,
                Const.characterWidth, Const.characterHeight);
        }
        public override void Update(GameTime gameTime)
        {
            if (needToChange)
            {
                elpasedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elpasedTime > 60)
                {
                    dir = nextDir;
                    needToChange = false;
                }
            }
            move();
            // update Rec
            sourceRec.X = (int)pos.X;
            sourceRec.Y = (int)pos.Y;
            animate.Update(gameTime, (int)dir);
        }

        public override void move()
        {
            base.move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animate.Draw(spriteBatch, pos);
        }

        protected override void reBorn()
        {
            pos = Const.shinsenBornPos;
        }

        public override void death()
        {
            reBorn();
        }

        public void randomMove(List<List<Tiles>> mapTiles)
        {
            Random rnd = new Random();
            List<Direct> direction = new List<Direct>();
            direction.Add(dir);
            if (Direct.Left != dir && !checkOpposite(Direct.Left) && 
                checkForNewPath(Direct.Left, mapTiles))
            {
                direction.Add(Direct.Left);
            }
            if (Direct.Right != dir && !checkOpposite(Direct.Right) &&
                checkForNewPath(Direct.Right, mapTiles))
            {
                direction.Add(Direct.Right);
            }
            if (Direct.Up != dir && !checkOpposite(Direct.Up) &&
                checkForNewPath(Direct.Up, mapTiles))
            {
                direction.Add(Direct.Up);
            }
            if (Direct.Down != dir && !checkOpposite(Direct.Down) &&
                checkForNewPath(Direct.Down, mapTiles))
            {
                direction.Add(Direct.Down);
            }
            int index = rnd.Next(0, direction.Count);
            if (index > 0)
            {
                elpasedTime = 0;
                needToChange = true;
                nextDir = direction[index];
            } 
        }

        public void changeDirection(List<List<Tiles>> mapTiles)
        {
            int pos_X = (int)pos.X / 32;
            int pos_Y = (int)pos.Y / 32;
            Random rnd = new Random();
            List<Direct> direction = new List<Direct>()
            {
                Direct.Left,
                Direct.Right,
                Direct.Up,
                Direct.Down
            };
            for (int i = 0; i < direction.Count; ++i)
            {
                if (direction[i] == dir || checkOpposite(direction[i]))
                {
                    direction.Remove(direction[i]);
                } else
                {
                    Tiles nextTile = Collision.findNextTile(pos_X, pos_Y, mapTiles, direction[i]);
                    if (nextTile == null || (nextTile.state == TileState.Wall && 
                        sourceRec.Intersects(nextTile.tileRec)))
                    {
                        direction.Remove(direction[i]);
                    }
                }
            }
            int index = rnd.Next(0, direction.Count);
            dir = direction[index];
        }

        private bool checkOpposite(Direct direct)
        {
            return ((dir == Direct.Left && direct == Direct.Right) ||
                (dir == Direct.Right && direct == Direct.Left) ||
                (dir == Direct.Up && direct == Direct.Down) ||
                (dir == Direct.Down && direct == Direct.Up));
        }

        private bool checkForNewPath(Direct direct, List<List<Tiles>> mapTiles)
        {
            int pos_X = (int)pos.X / 32;
            int pos_Y = (int)pos.Y / 32;
            Tiles nextTile = Collision.findNextTile(pos_X, pos_Y, mapTiles, direct);
            bool newPath = false;
            Rectangle rec = sourceRec;
            rec.Width += 10;
            rec.Height += 5;
            if (nextTile == null) return false;
            if (nextTile.state != TileState.Wall && 
                !(nextTile.state == TileState.Gate && direct == Direct.Down))
            {
                if (direct == Direct.Left)
                {
                    rec.X -= ((int)speed + 10);
                    Tiles up = Collision.findNextTile(pos_X - 1, pos_Y, mapTiles, Direct.Up);
                    Tiles down = Collision.findNextTile(pos_X - 1, pos_Y, mapTiles, Direct.Down);
                    if ((up != null && up.state == TileState.Wall && !rec.Intersects(up.tileRec)) ||
                        (down != null && down.state == TileState.Wall && !rec.Intersects(down.tileRec)))
                    {
                        newPath = true;
                    }
                }
                else if (direct == Direct.Right)
                {
                    rec.X += ((int)speed + 10);
                    Tiles up = Collision.findNextTile(pos_X + 1, pos_Y, mapTiles, Direct.Up);
                    Tiles down = Collision.findNextTile(pos_X + 1, pos_Y, mapTiles, Direct.Down);
                    if ((up != null && up.state == TileState.Wall && !rec.Intersects(up.tileRec)) ||
                        (down != null && down.state == TileState.Wall && !rec.Intersects(down.tileRec)))
                    {
                        newPath = true;
                    }
                } else if (direct == Direct.Up)
                {
                    rec.Y -= ((int)speed + 10);  
                    Tiles left = Collision.findNextTile(pos_X, pos_Y - 1, mapTiles, Direct.Left);
                    Tiles right = Collision.findNextTile(pos_X, pos_Y - 1, mapTiles, Direct.Right);
                    if ((left != null && left.state == TileState.Wall && !rec.Intersects(left.tileRec)) ||
                        (right != null && right.state == TileState.Wall && !rec.Intersects(right.tileRec)))
                    {
                        newPath = true;
                    }
                } else if (direct == Direct.Down)
                {
                    rec.Y += (int)speed + 10;
                    Tiles left = Collision.findNextTile(pos_X, pos_Y + 1, mapTiles, Direct.Left);
                    Tiles right = Collision.findNextTile(pos_X, pos_Y + 1, mapTiles, Direct.Right);
                    if ((left != null && left.state == TileState.Wall && !rec.Intersects(left.tileRec)) ||
                        (right != null && right.state == TileState.Wall & !rec.Intersects(right.tileRec)))
                    {
                        newPath = true;
                    }
                }
            }
            return newPath;
        }
    }
}
