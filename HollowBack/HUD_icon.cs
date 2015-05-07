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

        public HUD_icon(ContentManager pContent, Scene scene, int func)
            : base(pContent, "SideBlocks",scene)
        {
            font = pContent.Load<SpriteFont>("RadioLand");

            HUD_Func(func);
        }
        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            scene.SpriteBatch.DrawString(font, function,
                new Vector2(this.Position.X + 10, this.Position.Y + (this.Texture.Height / 2) 
                    - (this.font.MeasureString(function).Y/2)),Color.Red);
        }
        private void HUD_Func(int function)
        {
            switch(function)
            {
                case(0):
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
    }

    //mouseState.LeftButton == ButtonState.Pressed
}
