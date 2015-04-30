using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HollowBack
{
    class SSV_HollowBack : Sprite
    {
        private Radar radar;

        public SSV_HollowBack(ContentManager pContent, Scene scene) : base(pContent ,"SSV_HollowBack", scene)
        {
            this.Position = new Vector2(this.scene.ScreenSize.X/2- this.Texture.Width/2, this.scene.ScreenSize.Y/2 - this.Texture.Height/2);
            radar = new Radar(pContent, scene);
        }

        public override void Draw(SpriteBatch pSpriteBatch,Vector2 pOffset)
        {
            radar.Draw(pSpriteBatch, pOffset);
            base.Draw(pSpriteBatch, pOffset); 
        }
    }
}