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
        
        private bool light;
        private Texture2D original;
        Sprite lighty;

        public ScreenMouse(ContentManager pContent, Scene scene)
            : base(pContent, "Cursor", scene)
        {
            Mouse.SetPosition((int)(scene.ScreenSize.X / 2),(int)( scene.ScreenSize.Y / 2));
            original = pContent.Load<Texture2D>("Cursor");
            lighty = new Sprite(pContent, "CursorLight", scene);

            this.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            this.lighty.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);

            angle = 0;
            lighty.angle = angle;

            Scale = 1f;
            lighty.Scale = Scale;

            light = false;
        }

        public override void Update(GameTime pGameTime)
        {
            Point mp = scene.Mstate.Position;
            this.Position = new Vector2(mp.X- Texture.Width/2+10 ,mp.Y - Texture.Height/2+30);
            this.lighty.Position = new Vector2(mp.X - lighty.Texture.Width / 2 + 10, mp.Y - lighty.Texture.Height / 2 + 30);

            float x = Position.X;
            float y = Position.Y;

            light = false;

            foreach(Sprite hud in scene.HUD)
            {
                if(( x > hud.Position.X && x < (hud.Position.X + hud.Texture.Width) && y > hud.Position.Y && y < (hud.Position.Y + hud.Texture.Height)) || scene.Cone.Lockin)
                {
                    light = true;
                }
            }
            lighty.Update(pGameTime);
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            Point mp = scene.Mstate.Position;
            if(scene.Graphics.Viewport.Bounds.Contains(mp))
            {
                base.Draw(pSpriteBatch);
                if (light)
                {
                    lighty.Draw(pSpriteBatch);
                }
            }
        }
    }
}