using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HollowBack
{
    class Radar : Sprite
    {
        public Radar(ContentManager pContent, Scene Cene)
            : base(pContent, "Radar", Cene)
        {
        }
        public override void Draw(SpriteBatch pSpriteBatch, Vector2 pOffset)
        {
            pSpriteBatch.Draw(Texture, Position, Tangle, Color.White,
                             angle, scene.ScreenSize, 1, this.Effects, 1f);
        }
    }
}
