using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;        
        SpriteBatch spriteBatch;

        private List<Dot> dotList = new List<Dot>();
        
        private void SpawnObjects()
        {
            for (int i = 0; i < 6000; i++)
            {
                dotList.Add(new Dot(1024, 768));
            }
        } 
        

        //textures
        Texture2D spaceshipTexture;
        Texture2D greenBlob;


        public Game1()
        {            
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768; 
            
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
            base.Initialize();
            
            
        }

        internal Texture2D LoadTextureFromStream(string pathToTexture)
        {
            using (FileStream fileStream = new FileStream(pathToTexture, FileMode.Open))
            {
                return Texture2D.FromStream(GraphicsDevice, fileStream);
            }
               
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            SpawnObjects();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here            
            spaceshipTexture = LoadTextureFromStream("Content/spaceShip.png");
            greenBlob = LoadTextureFromStream("Content/green.png");
           

            foreach (var dot in dotList)
            {
                dot.Texture = LoadTextureFromStream(dot.PathToSkin);
            }

            //dot.Texture = LoadTextureFromStream(dot.PathToSkin);
                       
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();
            
            // TODO: Add your update logic here
            foreach (var dot in dotList)
            {
                dot.Move(dot.PosX, dot.PosY + 1, mouseState);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            foreach(var dot in dotList)
            {
                spriteBatch.Draw(dot.Texture, dot.Position, Color.White);
            }

            //spriteBatch.Draw(dot.Texture, dot.Position, Color.White);
            
            

            spriteBatch.End();
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }



    }
}
