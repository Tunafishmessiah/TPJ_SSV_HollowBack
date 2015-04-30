﻿using System;
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

        public SSV_HollowBack(ContentManager pContent, Scene scene) : base(pContent ,"SSV_HollowBack", scene)
        {
            this.Origin = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);
            this.Position = new Vector2(this.scene.ScreenSize.X/2 , this.scene.ScreenSize.Y/2);
            radar = new Radar(pContent, scene);
            radar.Position = new Vector2(this.scene.ScreenSize.X/2 - radar.Texture.Width/2,this.scene.ScreenSize.Y/2 - radar.Texture.Height/2);
        }

        public override void Update(GameTime pGameTime)
        {
            Point mouse = Mouse.GetState().Position;

            float a = (float)(mouse.X-this.scene.ScreenSize.X/2);
            float l = (float)(mouse.Y-this.scene.ScreenSize.Y/2);
            this.angle = (float)(Math.Atan2(l, a) + Math.PI /2);
            Console.WriteLine(this.angle);
            base.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch,Vector2 pOffset)
        {
            radar.Draw(pSpriteBatch, pOffset);
            base.Draw(pSpriteBatch, pOffset);
        }
    }
}