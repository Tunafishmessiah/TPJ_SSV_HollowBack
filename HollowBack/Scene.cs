using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HollowBack
{
    class Scene
    {
        #region Fields

        private SpriteBatch spriteBatch;
        private List<Enemy> enemies;
        private List<HUD_icon> hud;
        private SSV_HollowBack SSV;
        private Targeting cone;
        private Vector2 screenSize;
        private GraphicsDevice graphics;
        private ScreenMouse little; 
        #endregion

        #region Properties

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }

        public List<Enemy> Enemies
        {
            get { return enemies; }
            private set { enemies = value; }
        }

        public List<HUD_icon> HUD
        {
            get { return hud; }
            set { hud = value; }
        }
        public Vector2 ScreenSize
        {
            get { return screenSize;}
            set { screenSize = value;}
        }
        public GraphicsDevice Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }
        public ScreenMouse Little
        {
            get { return little; }
            set { little = value; }
        }
        #endregion

        public Scene(SpriteBatch pSpriteBatch, Vector2 screenDimensions, GraphicsDevice Graph)
        {
            this.spriteBatch = pSpriteBatch;
            Enemies = new List<Enemy>();
            this.screenSize = screenDimensions;
            Graphics = Graph;
        }

        public void AddSprite(ContentManager pContent, String pAssetName)
        {
            Sprite var = new Sprite(pContent, pAssetName,this);
        }

        public void AddEnemy(ContentManager pContent, Vector2 pPosition)
        {
            //Enemy var = new Enemy(pContent, pPosition, this);
            //enemies.Add(var);
        }

        public void MakeHUD( ContentManager pContent)
        {
            SSV = new SSV_HollowBack(pContent, this);
            cone = new Targeting(pContent, this);
            Little = new ScreenMouse(pContent, this);

            hud = new List<HUD_icon>();

            HUD_icon BellowHud = new HUD_icon(pContent,this,0);
            float yHeight = screenSize.Y / BellowHud.Texture.Height;
            int intYHeight = (int)yHeight;
            Vector2 position = Vector2.Zero;

            float Per = yHeight-intYHeight;

            for (int i = 0; i < 6; i++)
            {
                BellowHud = new HUD_icon(pContent,this,i);
                BellowHud.Position =new Vector2(0,((i+1)*(Per * BellowHud.Texture.Height) + (i*BellowHud.Texture.Height)));
                hud.Add(BellowHud);
            }
        }

        public void Update(GameTime pGameTime)
        {
            foreach (Enemy var1 in enemies) var1.Update(pGameTime);
            foreach (Sprite HUD in hud) HUD.Update(pGameTime);
            
            SSV.Update(pGameTime);
            cone.Update(pGameTime);
            Little.Update(pGameTime);

        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            cone.Draw(spriteBatch);
            this.SpriteBatch = pSpriteBatch;
            foreach (Enemy var1 in enemies) if (var1.IsActive) var1.Draw(SpriteBatch);
            SSV.Draw(SpriteBatch);
            foreach(Sprite HUD in hud) HUD.Draw(SpriteBatch);
            Little.Draw(pSpriteBatch);
        }
    }
}
