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

        #region Fields

        private float aux = 0;

        #endregion

        public Ladar(ContentManager pContent, Scene Cene)
            : base(pContent, "Ladar", Cene)
        {
            this.Origin = new Vector2(this.Texture.Width/2, this.Texture.Height/2-2);
            this.Position = new Vector2(this.scene.ScreenSize.X / 2 +3, this.scene.ScreenSize.Y / 2+3);

        }

        public  void Update(GameTime pGameTime, bool lockin, float stopAngle)
        {
            Point mouse = scene.Mstate.Position;
            float a = (float)(mouse.X - this.scene.ScreenSize.X / 2);
            float l = (float)(mouse.Y - this.scene.ScreenSize.Y / 2);
            aux = (float)(Math.Atan2(l, a));

            if (lockin == true)
            {
                if ((aux + 0.42) > stopAngle + Math.PI / 32 && (aux - 0.42) < stopAngle - Math.PI / 32)
                {
                    this.angle = aux;
                    base.Update(pGameTime);
                   //Console.WriteLine(this.angle);
                }
            }
            else
            {
                this.angle = aux;
                base.Update(pGameTime);
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            if (scene.Cone.Lockin == true)
                pSpriteBatch.Draw(Texture, Position, Tangle, Color.White, angle, Origin, 1, this.Effects, 1f);
        }
    }
}

