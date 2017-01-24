using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Camera
    {
        public Vector2 position;
        public Matrix viewMatrix { get; private set; }


        public void Update(Vector2 ginsanPos)
        {
            position.X = ginsanPos.X - (Const.screenWidth / 2);
            position.Y = ginsanPos.Y - (Const.screenHeight / 2);

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X > Const.mapWidth)
            {
                position.X = Const.mapWidth;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.Y > Const.mapHeight)
            {
                position.Y = Const.mapHeight;
            }

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
