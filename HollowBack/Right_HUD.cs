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
    class Right_HUD : Sprite
    {
        private SpriteFont font;
        private Texture2D original;
        private HUD_icon hud_Funcs;
        private int Function;

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        public Texture2D Original
        {
            get { return original; }
            set { original = value; }
        }

        public Right_HUD(ContentManager pContent, Scene cene, int func): base(pContent,"SideRight",cene)
        {
            this.scene = cene;
            Function = func;
            this.Scale = 1.2f;
            //Loading stuff that is gonna be needed further ahead

            Font = pContent.Load<SpriteFont>("RadioLand");

            if (func == 2)
            {Original = pContent.Load<Texture2D>("SideRight2");}

            else
            {Original = pContent.Load<Texture2D>("SideRight");}

            this.Texture = original;
            HUD_Func(func);
        }

        public override void Update(GameTime pGameTime)
        {

        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture, Position, Tangle, Color.White,
    angle, Origin, Scale, this.Effects, 1f); 
        }

        public void HUD_Func(int function)
        {
            switch (function)
            {
                case 0:
                    this.Position = new Vector2(this.scene.ScreenSize.X - (this.Texture.Width + 10)*Scale,(this.scene.ScreenSize.Y/8) - this.Texture.Height /2);
                    break;
                case 1:
                    this.Position = new Vector2(this.scene.ScreenSize.X - (this.Texture.Width + 10) * Scale, ((this.scene.ScreenSize.Y / 8) * 3) - (this.Texture.Height / 2));
                    break;
                case 2:
                    this.Position = new Vector2(this.scene.ScreenSize.X - this.Texture.Width * Scale, (this.scene.ScreenSize.Y / 2) + this.Texture.Height / 2);
                    break;
                default:
                    break;
            }
        }
    }
}
