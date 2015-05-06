using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace HollowBack
{
    class Targeting : Sprite
    {
        private bool Lockin = false;
        

        public Targeting(ContentManager pContent, Scene Cene)
            : base(pContent, "Cone", Cene)
        {
            this.Origin = new Vector2(this.Texture.Width/2-5, this.Texture.Height/2+5);
            this.Position = new Vector2(this.scene.ScreenSize.X / 2, this.scene.ScreenSize.Y / 2);         
        }

        public override void Update(GameTime pGameTime)
        {
            Point mouse = Mouse.GetState().Position;
            MouseState Mstate = Mouse.GetState();

            if (Mstate.LeftButton == ButtonState.Pressed && Lockin == false)
            {
                Lockin = true;
            } 
            else if (Mstate.LeftButton == ButtonState.Pressed && Lockin == true)
            {
                Lockin = false;
            }

            if (Lockin == false)
            {
                float a = (float)(mouse.X - this.scene.ScreenSize.X / 2);
                float l = (float)(mouse.Y - this.scene.ScreenSize.Y / 2);
                this.angle = (float)(Math.Atan2(l, a));
                Console.WriteLine(this.angle);
                base.Update(pGameTime);
            } 

        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture, Position, Tangle, Color.White,angle, Origin, 1, this.Effects, 1f);
        }
    }
}
