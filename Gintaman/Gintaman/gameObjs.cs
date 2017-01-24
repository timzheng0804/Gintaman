using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class gameObjs
    {
        private static Gintoki ginsan;
        private static List<Shinsengumi> shinsengumi;

        public static void Initialize ()
        {
            ginsan = Factory.createGintoki();
            shinsengumi = Factory.createShinengumi();
        }

        public static void LoadContent(ContentManager content)
        {
            ginsan.LoadContent(content);
            foreach(Shinsengumi s in shinsengumi)
            {
                s.LoadContent(content);
            }
        }

        public static void Update(GameTime gameTime)
        {
            ginsan.Update(gameTime);
            foreach(Shinsengumi s in shinsengumi)
            {
                s.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        { 
            foreach(Shinsengumi s in shinsengumi)
            {
                s.Draw(spriteBatch);
            }

            ginsan.Draw(spriteBatch);
        }

        public static void changeDir(Direct dir)
        {
            ginsan.changeDir(dir);
        }

        public static Vector2 getGinsanPos()
        {
            return ginsan.pos;
        }

        public static void checkCollision(List<List<Tiles>> mapTiles)
        {
        //    Collision.checkEnemyCollision(ginsan, shinsengumi);
            Collision.checkMapCollision(ginsan, mapTiles);
            foreach(Shinsengumi s in shinsengumi)
            {
                Collision.checkShinCollision(s, mapTiles);
            }
        }

        public static void changeDirForShinsen(List<List<Tiles>> mapTiles)
        {
            foreach (Shinsengumi s in shinsengumi)
            {
                s.randomMove(mapTiles);
            }
        }
    }
}
