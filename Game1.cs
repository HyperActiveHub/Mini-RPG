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

namespace Mini_RPG
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Debug;
        static public Game1 instance = null;
        static public int screenWidth, screenHeight;
        public enum GameState { menu, inGame, gameOver};
        public GameState currentGameState = GameState.menu;

        
        Player player;
        Menu startButton;
        Menu quitButton;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            screenWidth = 1920;
            screenHeight = 1080;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.IsFullScreen = false;

            instance = this;
        }


        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Debug = Content.Load<SpriteFont>("Debug");
            startButton = new Menu("Play");
            player = new Player();
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            player.Update(gameTime);

            
            switch(currentGameState)
            {
                case GameState.menu:
                    IsMouseVisible = true;

                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        if(player.mouseClick().Intersects(startButton.Collider()))
                        {
                           currentGameState = GameState.inGame;
                           IsMouseVisible = false;

                        }
                    }
                    
                    //if(mouse.LeftButton == ButtonState.Pressed)
                    //{
                    //    if(player.mouseClick().Intersects(quitButton.Collider()))
                    //    {
                    //        this.Exit();
                    //    }
                    //}
                    break;

                case GameState.inGame:


                    

                    break;
            }    




            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.DrawString(Debug, "Player Direction" + player.Direction, new Vector2(10, 600), Color.White);


            if(currentGameState == GameState.menu)
            {
                startButton.Draw(spriteBatch);
                //quitButton.Draw(spriteBatch);

            }

            if(currentGameState == GameState.inGame)
            {
                player.Draw(spriteBatch);

            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
