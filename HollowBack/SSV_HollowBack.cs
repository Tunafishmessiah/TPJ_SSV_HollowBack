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
    class SSV_HollowBack : Sprite
    {
        private Radar radar;
        //640x360 ->hb position

        public SSV_HollowBack(ContentManager pContent, Scene scene) : base(pContent ,"SSV_HollowBack", scene)
        {
            this.Origin = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);
            this.Position = new Vector2(this.scene.ScreenSize.X/2 , this.scene.ScreenSize.Y/2);
            radar = new Radar(pContent, scene);         
            radar.Position = new Vector2(this.scene.ScreenSize.X / 2 - radar.Texture.Width / 2, this.scene.ScreenSize.Y / 2 - radar.Texture.Height / 2);

        }

        public override void Update(GameTime pGameTime)
        {
            Point mouse = scene.Mstate.Position;

            float a = (float)(mouse.X-this.scene.ScreenSize.X/2);
            float l = (float)(mouse.Y-this.scene.ScreenSize.Y/2);
            this.angle = (float)(Math.Atan2(l, a) + Math.PI /2);
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            radar.Draw(pSpriteBatch);
            base.Draw(pSpriteBatch);
        }
    }
}