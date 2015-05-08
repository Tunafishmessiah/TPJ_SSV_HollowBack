using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace HollowBack
{
    class Ladar:Sprite
    {
        
        public Ladar(ContentManager pContent, Scene Cene)
            : base(pContent, "Ladar", Cene)
        {
            this.Origin = new Vector2(this.Texture.Width/2-5, this.Texture.Height/2+5);
            this.Position = new Vector2(this.scene.ScreenSize.X / 2, this.scene.ScreenSize.Y / 2);         
        }

        public  void Update(GameTime pGameTime, bool lockin, float stopAngle)
        {
            Point mouse = scene.Mstate.Position;

           // if (Math.Atan((-mouse.X / mouse.Y)) < (Math.Atan((-stop.X / stop.Y)) + Math.PI / 16) && Math.Atan((-mouse.X / mouse.Y)) > (Math.Atan((-stop.X / stop.Y)) - Math.PI / 16))
            if (lockin == true)
            {
                if ((this.angle + 0.4) >= stopAngle + Math.PI / 32 && (this.angle - 0.4) <= stopAngle - Math.PI / 32)
                {
                    float a = (float)(mouse.X - this.scene.ScreenSize.X / 2);
                    float l = (float)(mouse.Y - this.scene.ScreenSize.Y / 2);
                    this.angle = (float)(Math.Atan2(l, a));
                    //Console.WriteLine(this.angle);
                    base.Update(pGameTime);
                }
                else
                {

                }
            }
            else
            {
                float a = (float)(mouse.X - this.scene.ScreenSize.X / 2);
                float l = (float)(mouse.Y - this.scene.ScreenSize.Y / 2);
                this.angle = (float)(Math.Atan2(l, a));
                //Console.WriteLine(this.angle);
                base.Update(pGameTime);
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture, Position, Tangle, Color.White,angle, Origin, 1, this.Effects, 1f);
        }
    }
}

