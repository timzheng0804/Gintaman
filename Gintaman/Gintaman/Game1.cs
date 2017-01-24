using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Gintaman
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        Texture2D background;
        Vector2 backgroundPos;
        Camera camera;

        public Game1()
        {
            // set up screen
            graphics = new GraphicsDeviceManager(this);
            camera = new Camera();
            Content.RootDirectory = "Content";
            backgroundPos = new Vector2(0, 0);
            map = new Map();
            IsFixedTimeStep = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            map.Initialize();
            gameObjs.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load background
            background = Content.Load<Texture2D>("Sprites\\Background");

            // Load everything on the map
            map.LoadContent(this.Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            detectUserInput();
            // TODO: Add your update logic here

            // update everything on the map
            map.Update(gameTime);

            // update Camera
            camera.Update(gameObjs.getGinsanPos());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                null, null, null, null, camera.viewMatrix);

            // draw Background
            spriteBatch.Draw(background, Const.origin, Color.White);

            // draw everything on the Map
            map.Draw(spriteBatch);

            // draw all object on tile

            spriteBatch.End();

            base.Draw(gameTime);
        }


        // get User input
        private void detectUserInput()
        {
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            else if (input.IsKeyDown(Keys.Left))
            {
                gameObjs.changeDir(Direct.Left);
            }
            else if (input.IsKeyDown(Keys.Right))
            {
                gameObjs.changeDir(Direct.Right);
            }
            else if (input.IsKeyDown(Keys.Up))
            {
                gameObjs.changeDir(Direct.Up);
            }
            else if (input.IsKeyDown(Keys.Down))
            {
                gameObjs.changeDir(Direct.Down);
            }
        }
    }
}
