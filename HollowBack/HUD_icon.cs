﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace HollowBack
{
    class HUD_icon : Sprite
    {
        private SpriteFont font;
        private string function;
        private Keys FuncKey;
        private Texture2D original,Lighty;
        private bool lighty;
        private bool Click;

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        public string Function
        {
            get { return function; }
            set { function= value; }
        }
        public Keys funcKey
        {
            get { return FuncKey; }
            set { FuncKey = value; }
        }
        public Texture2D Original
        {
            get { return original; }
            set { original = value; }
        }
        public Texture2D M_Lighty
        {
            get { return Lighty; }
            set { Lighty = value; }
        }
        public bool Light
        {
            get { return lighty; }
            set { lighty = value; }
        }
        public bool click
        {
            get { return Click; }
            set { Click = value; }
        }


        public HUD_icon(ContentManager pContent, Scene scene, int func)
            : base(pContent, "SideBlocks",scene)
        {
            //Loading stuff that is gonna be needed further ahead
            font = pContent.Load<SpriteFont>("RadioLand");
            original = pContent.Load<Texture2D>("SideBlocks");
            Lighty = pContent.Load<Texture2D>("SideLight");//This one is to make it bright when the mouse hovers
            HUD_Func(func);
            lighty = false;
            Click = false;
        }

        public override void Update(GameTime pGameTime)
        {
            Vector2 mouse = scene.Little.Position;

            //Checking mouse buttons to make the block bright (or not)
            if ((scene.Mstate.LeftButton == ButtonState.Pressed && scene.PreviousMstate.LeftButton == ButtonState.Released && OnTop(mouse)) || KeyPress())
            {
                Click = !Click;
                if (Click)
                {
                    foreach (HUD_icon HUD in scene.HUD)
                    {
                        if (HUD != this)
                        HUD.Click = false;
                    }
                }
            }

            if (OnTop(mouse) || Click)
            {
                lighty = true;
            }
            else lighty = false;



            if (lighty) this.Texture = Lighty;
            else this.Texture = original;

            base.Update(pGameTime);

        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            //Drawing the text above the block. If these two draws positions are changed text will not apear!
            scene.SpriteBatch.DrawString(font, function,
                new Vector2(this.Position.X + 10, this.Position.Y + (this.Texture.Height / 2)
                    - (this.font.MeasureString(function).Y / 2)), Color.Red);
        }

        public virtual void HUD_Func(int function)
        {
            //this function will determine what's written in the block and what key
            //needs to be pressed in order to activate it
            switch (function)
            {
                case (0):
                    this.function = "Missil";
                    FuncKey = Keys.D1;
                    break;
                case (1):
                    this.function = "Laser";
                    FuncKey = Keys.D2;
                    break;
                case (2):
                    this.function = "Railgun";
                    FuncKey = Keys.D3;
                    break;
                case (3):
                    this.function = "Particle\nCannon";
                    FuncKey = Keys.D4;
                    break;
                case (4):
                    this.function = "EMP";
                    FuncKey = Keys.D5;
                    break;
                case (5):
                    this.function = "Torpedos";
                    FuncKey = Keys.D6;
                    break;
                case (6):
                    break;
                case (7):
                    break;
            }
        }
        
        private bool OnTop(Vector2 Position)
        {
            //Avaluating if the mouse is on top of this icon
            if (this.Position.X < Position.X && this.Position.X + this.Texture.Width> Position.X && this.Position.Y < Position.Y && this.Position.Y + this.Texture.Height > Position.Y)
            {
                return true;
            }
            return false;
        }

        private bool KeyPress()
        {
            //testing if the user pressed the designed key to activate this weapon
            if (scene.M_Keyboard != scene.M_PreviousKeyboard)
            {
                if (scene.M_Keyboard.IsKeyDown(FuncKey))
                    return true;

                else return false;
            }
            else return false;
        }
    }
}
