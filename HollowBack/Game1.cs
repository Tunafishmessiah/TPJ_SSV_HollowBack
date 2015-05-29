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
        GameState State;
        GameState Previous;
        int sendState;
        int C_State;
     

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ScreenSize = new Point(1280, 720);
            graphics.PreferredBackBufferWidth = ScreenSize.X;
            graphics.PreferredBackBufferHeight = ScreenSize.Y;
            IsMouseVisible = false;
            State = GameState.Start;
            Previous = State;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SwitchState();

            game = new Scene(sendState,spriteBatch, new Vector2(ScreenSize.X, ScreenSize.Y), GraphicsDevice, Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            this.C_State = game.Update(sendState, gameTime, Content);

            Update_States(gameTime);

            Previous = State;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            game.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }


        private void SwitchState()
        {
            switch (State)
            {
                case GameState.Start:
                    sendState = 1;
                    break;
                case GameState.Gameplay:
                    sendState = 2;
                    break;
                case GameState.Gameover:
                    sendState = 3;
                    break;
                default:
                    sendState = 0;
                    break;
            }
        }
        private void SwitchIntState()
        {
            switch (this.sendState)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    this.State = GameState.Start;
                    break;
                case 2:
                    this.State = GameState.Gameplay;
                    break;
                case 3:
                    this.State = GameState.Gameover;
                    break;
                default:
                    Exit();
                    break;
            }
        }
        private void Update_States(GameTime gameTime)
        {

            if (this.sendState != C_State)
            {
                this.sendState = C_State;
                SwitchIntState();
            }

            if (State != Previous)
            {
                //cleaning the previous
                game.UnloadContent();
                //making the new one
                game = new Scene(sendState, spriteBatch, new Vector2(ScreenSize.X,ScreenSize.Y),GraphicsDevice, Content);
                game.Update(sendState, gameTime, Content);
            }

        }
    }
}
