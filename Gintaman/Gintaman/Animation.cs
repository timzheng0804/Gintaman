using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Animation
    {
        private int elapsedTime;
        private int frameTime;
        private Rectangle sourceRec;
        private Texture2D sprite;
        private int currentFrameX;
        private int currentFrameY;
        private int frameCount;
        private int frameWidth;
        private int frameHeight;

        public void Initilization (Texture2D texture, int frameCount, int frameTime, 
            int startFrameX, int startFrameY)
        {
            this.sprite = texture;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            currentFrameX = startFrameX;
            currentFrameY = startFrameY;
            frameWidth = sprite.Width / 4;
            frameHeight = sprite.Height / 4;
            elapsedTime = 0;
        }

        public void Update(GameTime gameTime, int frameY)
        {
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (currentFrameY != frameY)
            {
                currentFrameY = frameY;
                currentFrameX = 0;
            }
            // change frame of sprite
            if (elapsedTime > frameTime)
            {
                ++currentFrameX;
                if (currentFrameX == frameCount)
                {
                    // reset current frame
                    currentFrameX = 0;
                }
                elapsedTime = 0;
            }
            // reset elapsedTime

            // create rec of the sprite
            sourceRec = new Rectangle(currentFrameX * frameWidth, 
                currentFrameY * frameHeight, frameWidth, frameHeight);
        }

        public void Draw (SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(sprite, pos, sourceRec, Color.White);
        }
    }
}
