using System;
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
        private Texture2D original,Lighty;
        private bool lighty;
        private bool Click;
        private MouseState previous;
        private MouseState actualMouse;


        public HUD_icon(ContentManager pContent, Scene scene, int func)
            : base(pContent, "SideBlocks",scene)
        {
            font = pContent.Load<SpriteFont>("RadioLand");
            original = pContent.Load<Texture2D>("SideBlocks");
            Lighty = pContent.Load<Texture2D>("SideLight");
            HUD_Func(func);
            lighty = false;
            Click = false;
            actualMouse = Mouse.GetState();
            previous = actualMouse;
        }

        public override void Update(GameTime pGameTime)
        {
            Vector2 mouse = scene.Little.Position;
            actualMouse = Mouse.GetState();

            if (actualMouse.LeftButton == ButtonState.Pressed && previous.LeftButton == ButtonState.Released && OnTop(mouse))
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

            previous = actualMouse;
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            scene.SpriteBatch.DrawString(font, function,
                new Vector2(this.Position.X + 10, this.Position.Y + (this.Texture.Height / 2)
                    - (this.font.MeasureString(function).Y / 2)), Color.Red);
        }

        private void HUD_Func(int function)
        {
            switch (function)
            {
                case (0):
                    this.function = "Missil";
                    break;
                case (1):
                    this.function = "Laser";
                    break;
                case (2):
                    this.function = "Railgun";
                    break;
                case (3):
                    this.function = "Particle\nCannon";
                    break;
                case (4):
                    this.function = "EMP";
                    break;
                case (5):
                    this.function = "Torpedos";
                    break;
            }
        }
        
        private bool OnTop(Vector2 Position)
        {
            if (this.Position.X < Position.X && this.Position.X + this.Texture.Width> Position.X && this.Position.Y < Position.Y && this.Position.Y + this.Texture.Height > Position.Y)
            {
                return true;
            }
            return false;
        }
    }
}
