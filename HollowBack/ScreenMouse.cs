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
        bool increase;

        public ScreenMouse(ContentManager pContent, Scene scene)
            : base(pContent, "Cursor", scene)
        {
            //Seting initial mouse position to be the center of our screen
            Mouse.SetPosition((int)(scene.ScreenSize.X / 2),(int)( scene.ScreenSize.Y / 2));

            //loading textures needed
            original = pContent.Load<Texture2D>("Cursor");
            lighty = new Sprite(pContent, "CursorLight", scene);

            //Giving our sprites the acurate first position
            this.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            this.lighty.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);

            //Modifing some values
            angle = 0;
            lighty.angle = angle;

            Scale = .9f;
            lighty.Scale = Scale;

            //variables that will help when overing something 
            light = false;
            increase = true;
        }

        public override void Update(GameTime pGameTime)
        {
            Point mp = scene.Mstate.Position;

            float x = Position.X;
            float y = Position.Y;

            light = false;

            //Testing if the mouse is worthy of bearing the mighty variable known as "light"
            foreach(Sprite hud in scene.HUD)
            {
                if(( x > hud.Position.X && x < (hud.Position.X + hud.Texture.Width) && y > hud.Position.Y && y < (hud.Position.Y + hud.Texture.Height)) || scene.Cone.Lockin)
                {
                    light = true;
                }
            }
            
            //Making that red circle flow
            if (light)
            {
                if (lighty.Scale > 1.2f)
                {
                    increase = false;
                }
                else if (lighty.Scale <= this.Scale-.2f)
                {
                    increase = true;
                }

                if (increase)
                {
                    lighty.Scale += .045f;
                }
                else
                {
                    lighty.Scale -= .045f;
                }
 
            }

            //updating as last the position so that it goes well with the scale, its kind of tricky even though it's fairly easy to acomplish
            this.Position = new Vector2(mp.X - Texture.Width / 2 + 2.3f, mp.Y - Texture.Height / 2 + 2);
            this.lighty.Position = new Vector2(mp.X - (lighty.Texture.Width * lighty.Scale) / 2 ,
                mp.Y - (lighty.Texture.Height * lighty.Scale) / 2 );


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