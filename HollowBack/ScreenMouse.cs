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
    class ScreenMouse : Sprite
    {
        public ScreenMouse(ContentManager pContent, Scene scene)
            : base(pContent, "Hunter", scene)
        {
            Mouse.SetPosition((int)(scene.ScreenSize.X / 2),(int)( scene.ScreenSize.Y / 2));
            this.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            angle =(float) (-(Math.PI / 4));
            Scale = .5f;
        }
        public override void Update(GameTime pGameTime)
        {
            Scale = .5f;
            Point mp = Mouse.GetState().Position;
            this.Position = new Vector2(mp.X- Texture.Width/2,mp.Y - Texture.Height/2);

            base.Update(pGameTime);
        }
        public override void Draw(SpriteBatch pSpriteBatch)
        {
            Point mp = Mouse.GetState().Position;
            if(scene.Graphics.Viewport.Bounds.Contains(mp))
            {base.Draw(pSpriteBatch);}
        }
    }
}