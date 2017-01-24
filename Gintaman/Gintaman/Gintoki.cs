using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Gintoki : Character
    {
        private Texture2D dead;
        private Texture2D stay;
        public Rectangle sourceRec;
        public bool collide = false;
        

        public Gintoki (Vector2 pos, string textureName) : base(pos)
        {
            this.textureName = textureName;
            dir = Direct.Stay;
            animate = new Animation();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            dead = content.Load<Texture2D>("Sprites//Death");
            stay = content.Load<Texture2D>("Sprites//Stay");
            animate.Initilization(texture, Const.frameCount, Const.frameTime, 0, 0);
            sourceRec = new Rectangle((int)pos.X, (int)pos.Y, 
                Const.characterWidth, Const.characterHeight);
        }
        public override void Update(GameTime gameTime)
        {
            move();

            // update Rec
            sourceRec.X = (int)pos.X;
            sourceRec.Y = (int)pos.Y;

            animate.Update(gameTime, (int)dir);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!alive)
            {
                spriteBatch.Draw(dead, pos, Color.White);
            }
            else if (dir == Direct.Stay)
            {
                spriteBatch.Draw(stay, pos, Color.White);
            }
            else
            {
                animate.Draw(spriteBatch, pos);
            }
        }

        public void changeDir(Direct dir)
        {
            if (this.dir != dir && collide) { collide = false; this.dir = dir; }
            if(this.dir != dir) this.dir = dir;
        }

        public void death()
        {
            alive = false;
        }

        public override void move ()
        {
            if (!alive) return;
            if (collide ) return;
            base.move();
        }

        public void teleport()
        {
            if (dir == Direct.Left)
            {
                pos = new Vector2(900, pos.Y);
            } else if(dir == Direct.Right)
            {
                pos = new Vector2(50, pos.Y);
            }
        }
    }
}
