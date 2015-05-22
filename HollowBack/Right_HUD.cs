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
        private bool st;
        private List <string> Moves;

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
            Moves = new List<string>();
            //Loading stuff that is gonna be needed further ahead

            Font = pContent.Load<SpriteFont>("RadioLand");

            if (func == 2)
            {
                Original = pContent.Load<Texture2D>("SideRight2");
                Scale = new Vector2(1.18f, 1.5f);
            }

            else
            {
                Original = pContent.Load<Texture2D>("SideRight");
                Scale = new Vector2(1.3f, 1f);
            }

            this.Texture = original;
            HUD_Func(func);

        }

        public override void Update(GameTime pGameTime)
        {
            if (!st)
            {
                this.Texture = original;
                this.TangleUpdate();
                st = true;
            }

            switch (Function)
            {
                case 0:
                    //Enemy Image
                    break;
                case 1:
                    //Enemy Data
                    break;
                case 2:
                    //Move History
                    Update_History();
                    break;
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);

            switch (Function)
            {
                case 0:
                    //Enemy Image
                    break;
                case 1:
                    //Enemy Data
                    break;
                case 2:
                    //Move History
                    Draw_History(pSpriteBatch);
                    break;
            }
        }

        public void HUD_Func(int function)
        {
            switch (function)
            {
                case 0:
                    this.Position = new Vector2(this.scene.ScreenSize.X - (this.Texture.Width + 10)*(Scale.X),-10 + 
                        (this.scene.ScreenSize.Y/8) - this.Texture.Height /2 );
                    break;
                case 1:
                    this.Position = new Vector2(this.scene.ScreenSize.X - (this.Texture.Width + 10) * (Scale.X), -50 + 
                        ((this.scene.ScreenSize.Y / 8) * 3) - (this.Texture.Height / 2));
                    break;
                case 2:
                    this.Position = new Vector2(this.scene.ScreenSize.X - this.Texture.Width * (Scale.X), -50 + (this.scene.ScreenSize.Y / 2));
                    break;
                default:
                    //Mueheheheh, you have no power here  \m/(ò.ó)\m/
                    break;
            }
        }

        public void Update_History()
        {
            bool press = false;
            foreach (HUD_icon icon in scene.HUD)
            {
                if (icon.click && !icon.PreClick)
                {
                    if (font.MeasureString("->Selected " + icon.Function).X + this.Position.X + 10 < this.scene.ScreenSize.X )
                    {
                         Moves.Add("->Selected " + icon.Function);
                    }
                    else
                    {
                        Moves.Add("->Selected \n " + icon.Function);
                    }
                    press = true;
                }
            }

            int length = 6;

            if (Moves.Count > length )
            {
                int i = 0;
                for (; i < length && Moves[i+1] != null; i++)
                {
                    Moves[i] = Moves[i + 1];
                }

                Moves.RemoveAt(i);
            }


        }

        public void Draw_History(SpriteBatch pSpriteBatch)
        {
            Vector2 InitialPosition = this.Position + new Vector2(7,3);
            float distance = (this.scene.ScreenSize.Y - this.Position.Y) / 8;
            foreach (string Move in Moves)
            {
                if (Move != null)
                {

                    if (this.font.MeasureString(Move).Y < distance)
                        pSpriteBatch.DrawString(this.font, Move, InitialPosition, Color.Green);
                    else
                    {
                        pSpriteBatch.DrawString(this.font, Move, new Vector2(InitialPosition.X, InitialPosition.Y), Color.Green);
                        InitialPosition = new Vector2(InitialPosition.X, InitialPosition.Y - distance + this.font.MeasureString(Move).Y);
                    }

                    InitialPosition = new Vector2(InitialPosition.X , InitialPosition.Y+ distance);

                }
            }

        }

        public void Update_Image()
        { }

        public void Draw_Image() { }

        public void Update_Descript()
        { }

        public void Draw_Descript() { }
    }
}
