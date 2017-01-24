using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Character
    {
        public Texture2D texture;
        public string textureName;
        public Vector2 pos { get; protected set; }
        protected float speed;
        public bool alive { get; protected set; }
        protected Animation animate;
        public Direct dir { get; protected set; }

        public Character (Vector2 pos)
        {
            speed = Const.characterSpeed;
            this.pos = pos;
            alive = true;
        } 

        public virtual void LoadContent (ContentManager content)
        {
            texture = content.Load<Texture2D>("Sprites/" + this.textureName);
          //  center = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Update(GameTime time) { }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            if (!alive) return;
            spriteBatch.Draw(texture, pos, Color.White);
        }

        public virtual void move ()
        {
            switch (dir)
            {
                case Direct.Left:
                    pos -= new Vector2(speed, 0);
                    break;
                case Direct.Right:
                    pos += new Vector2(speed, 0);
                    break;
                case Direct.Up:
                    pos -= new Vector2(0, speed);
                    break;
                case Direct.Down:
                    pos += new Vector2(0, speed);
                    break;
                default:
                    break;
            }
        }
    }
}
