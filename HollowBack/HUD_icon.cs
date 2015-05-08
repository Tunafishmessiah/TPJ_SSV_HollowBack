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
        private Keys FuncKey;
        private Texture2D original,Lighty;
        private bool lighty;
        private bool Click;


        public HUD_icon(ContentManager pContent, Scene scene, int func)
            : base(pContent, "SideBlocks",scene)
        {
            font = pContent.Load<SpriteFont>("RadioLand");
            original = pContent.Load<Texture2D>("SideBlocks");
            Lighty = pContent.Load<Texture2D>("SideLight");
            HUD_Func(func);
            lighty = false;
            Click = false;
        }

        public override void Update(GameTime pGameTime)
        {
            Vector2 mouse = scene.Little.Position;

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

        private bool KeyPress()
        {
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
