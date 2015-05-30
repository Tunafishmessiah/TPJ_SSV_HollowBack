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
        private int Function;
        private bool st;
        //history
        private List <string> Moves;
        //description
        private string enemyDescript, enemyDescript2;
        private bool write1;
        private double change;
        //image
        private Texture2D s_enemy;

        #region properties
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
                Scale = new Vector2(1.35f, 1.5f);
            }

            else
            {
                Original = pContent.Load<Texture2D>("SideRight");
                Scale = new Vector2(1.45f, 1f);
            }

            this.Texture = original;
            HUD_Func(func);

        }
        #endregion

        public override void Update(GameTime pGameTime)
        {
            if (!st)
            {
                this.Position = new Vector2(this.Position.X +15, this.Position.Y);
                this.Texture = original;
                this.TangleUpdate();
                st = true;
                change = pGameTime.TotalGameTime.TotalSeconds;
                write1 = true;
            }

            switch (Function)
            {
                case 0:
                    //Enemy Image
                    break;
                case 1:
                    //Enemy Data  
                    if (change + 1 < pGameTime.TotalGameTime.TotalSeconds)
                    {
                        change = pGameTime.TotalGameTime.TotalSeconds;
                        if (write1) write1 = false;
                        else write1 = true;
                    }
                    //Update_Description(pGameTime);
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
                    Draw_Image(pSpriteBatch);
                    //Enemy Image
                    break;
                case 1:
                    Draw_Descript(pSpriteBatch);
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
                }
            }

            delete_history();
        }

        public void delete_history()
        {
            int length = 7;

            if (Moves.Count > length)
            {
                int i = 0;
                for (; i < length && Moves[i + 1] != null; i++)
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
            Color color = Color.Green;

            if (Moves.Count > 0)
            {
                for (int i = Moves.Count-1; i >= 0; i--)
                {
                    if (Moves[i] != null)
                    {
                        if (i == Moves.Count - 1)
                        { 
                            //color = Color.LimeGreen;
                            color = Color.Gold;
                        }

                        else color = Color.LimeGreen ;

                        if (this.font.MeasureString(Moves[i]).Y < distance)
                            pSpriteBatch.DrawString(this.font, Moves[i], InitialPosition, color);
                        else
                        {
                            pSpriteBatch.DrawString(this.font, Moves[i], new Vector2(InitialPosition.X, InitialPosition.Y), color);
                            InitialPosition = new Vector2(InitialPosition.X, InitialPosition.Y - distance + this.font.MeasureString(Moves[i]).Y);
                        }

                        InitialPosition = new Vector2(InitialPosition.X, InitialPosition.Y + distance);

                    }
                }
            }

        }

        public void Draw_Image(SpriteBatch pSpriteBatch) 
        {
           if(s_enemy!= null)
           {
               pSpriteBatch.Draw(s_enemy,
                   new Vector2((this.Position.X+ (this.Texture.Width*this.Scale.X)/2)-(s_enemy.Width/2),
                       (this.Position.Y + (this.Texture.Height * this.Scale.Y) / 2) - (s_enemy.Height / 2))
                   ,Color.White);
           }

        }

        public void Draw_Descript(SpriteBatch pSpriteBatch)
        {
            if(enemyDescript != null)
            {
                if (write1)
                {
                    pSpriteBatch.DrawString(this.Font, enemyDescript, new Vector2(this.Position.X + 7, this.Position.Y + 3), Color.GreenYellow);
                }
                else {



                    pSpriteBatch.DrawString(this.Font, enemyDescript2, new Vector2(this.Position.X + 7, this.Position.Y + 3), Color.GreenYellow);
                }
            }
        }

        public void Update_Description(GameTime pGameTime)
        { }

        public void Update_Descript(Enemy enemy) 
        {
            switch (enemy.ID.X)
            {
                case 1:
                    stringMesureAndInsertion("Fighter");
                    break;
                case 2:
                    stringMesureAndInsertion("Frigate");
                    break;
                case 3:
                    stringMesureAndInsertion("Carrier");
                    break;
                case 4:
                    stringMesureAndInsertion("Dreadnought");
                    break;
                case 5:
                    stringMesureAndInsertion("Missile");
                    break;
                case 6:
                    stringMesureAndInsertion("Slug");
                    break;
                default:
                    stringMesureAndInsertion("Badass");
                    break;
            }
        }

        public void stringMesureAndInsertion(string enemyName)
        {
            switch(Function)
            {
                case 1:
                    //Adding the description here
                    switch (enemyName)
                    {
                        case "Fighter":
                            enemyDescript = (enemyName + "\nBest weapon:\n-Missil");
                            enemyDescript2 = (enemyName + "\nWorst weapon:\n-Particle\nCannon");
                            break;
                        case "Frigate":
                            enemyDescript = (enemyName + "\nBest weapon:\n-Slug");
                            enemyDescript2 = (enemyName + "\nWorst weapon:\n-Laser");
                            break;
                        case "Carrier":
                            enemyDescript = (enemyName + "\nBest weapon:\n-Particle\nCannon");
                            enemyDescript2 = (enemyName + "\nWorst weapon:\n-Laser");
                            break;
                        case "Dreadnought":
                            enemyDescript = (enemyName + "\nBest weapon:\n-Particle\nCannon");
                            enemyDescript2 = (enemyName + "\nWorst weapon:\n-Laser");
                            break;
                        case "Missile":
                            enemyDescript = (enemyName + "\nBest weapon:\n-Laser");
                            enemyDescript2 = (enemyName + "\nWorst weapon:\n-Particle\nCannon");
                            break;
                        case "Slug":
                            enemyDescript = (enemyName + "\nBest weapon:\n-Laser");
                            enemyDescript2 = (enemyName + "\nWorst weapon:\n-Particle\nCannon");
                            break;
                        default:
                            break;
                    }
                    break;

                case 2://adding the 
                    if ((font.MeasureString("->Identified a " + enemyName + "").X + this.Position.X + 10) < this.scene.ScreenSize.X)
                    {
                        Moves.Add("->Identified a " + enemyName + "");
                    }
                    else
                    {
                        Moves.Add("->Identified a\n" + enemyName + "");
                    }

                    break;
        }
        }

        public void add_selected(Enemy enemy)
        {
            switch(this.Function)
            {
                case 0://If it's the 1st on top
                    this.s_enemy = enemy.Original;
                    break;
                case 1://the second
                    Update_Descript(enemy);
                    break;
                case 2://the last one
                    Update_Descript(enemy);
                    break;
            }
        }
    }
}
