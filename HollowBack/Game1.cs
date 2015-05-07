#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace HollowBack
{
    //Making the game Scenes and menus
    enum GameState { 
        Start,
        Gameplay,
        Gameover
    }
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Point ScreenSize;
        Scene game;
        Fighter Fig1;
        GameState State;
        GameState Previous;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ScreenSize = new Point(1280, 720);
            graphics.PreferredBackBufferWidth = ScreenSize.X;
            graphics.PreferredBackBufferHeight = ScreenSize.Y;
            IsMouseVisible = false;
            State = GameState.Gameplay;
            Previous = State;
            
        }

        protected override void Initialize()
        {
            Fig1 = new Fighter(Content, game);
            Fig1.SpawnAt(new Vector2(600,600));
            Fig1.SetDestination(Vector2.Zero);
            base.Initialize();
        }

        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            game = new Scene(spriteBatch, new Vector2(ScreenSize.X, ScreenSize.Y), GraphicsDevice);
            game.MakeHUD(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (State != Previous)
            {
                switch (Previous)
                {
                    //We are gonna unload objects here, when we are transitioning from one state to the other.
                    case(GameState.Gameplay):
                        break;
                    case(GameState.Gameover):
                        break;
                    case (GameState.Start):
                        break;
                }
            }
            else
            {
                if (State == GameState.Start)
                {
 
                }
                else if (State == GameState.Gameplay)
                {
                    game.Update(gameTime);
                    Fig1.Update();
                }
                else if (State == GameState.Gameover)
                { }
            }

            Previous = State;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (Fig1.IsVisible) Fig1.Draw(spriteBatch);
            game.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
