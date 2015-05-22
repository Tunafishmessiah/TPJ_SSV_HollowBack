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

        public void Update()
        {
            
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture, Position, Tangle, Color.White,
                             angle,Vector2.Zero, Vector2.One, this.Effects, 1f);
        }
    }
}
