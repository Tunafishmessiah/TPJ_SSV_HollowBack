﻿using System;
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
        private List<Right_HUD> R_hud;
        private SSV_HollowBack SSV;
        private Targeting cone;
        private Ladar ladar;
        private Vector2 screenSize;
        private GraphicsDevice graphics;
        private ScreenMouse little;
        private MouseState mstate, previousMstate;
        private KeyboardState keyboard, previousKeyboard;
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

        public List<Right_HUD> R_HUD
        {
            get { return R_hud; }
            set { R_hud = value; }
        }
        public List<HUD_icon> HUD
        {
            get { return hud; }
            set { hud = value; }
        }

        public Targeting Cone
        {
            get { return cone; }
            private set { cone = value; }
        }

        public Ladar M_Ladar
        {
            get { return ladar; }
            private set { ladar = value; }
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
        public MouseState Mstate
        {
            get {return mstate;}
            set {mstate = value;}
        }
        public MouseState PreviousMstate
        {
            get { return previousMstate; }
            set { previousMstate = value; }
        }

        public KeyboardState M_Keyboard
        {
            get { return keyboard; }
            set { keyboard = value; }
        }
        public KeyboardState M_PreviousKeyboard
        {
            get { return previousKeyboard; }
            set { previousKeyboard = value; }
        }
        #endregion

        public Scene(SpriteBatch pSpriteBatch, Vector2 screenDimensions, GraphicsDevice Graph)
        {
            //Loading stuff and starting up some needed variables
            this.spriteBatch = pSpriteBatch;
            Enemies = new List<Enemy>();
            this.screenSize = screenDimensions;
            Graphics = Graph;

            //This variable were made so that we can save some processing time, we can acess it
            //from any variable that's called here, so we don't need to call them in almost every single thing we have on screen
            mstate = Mouse.GetState();
            previousMstate = mstate;

            keyboard = Keyboard.GetState();
            previousKeyboard = keyboard;

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

            ladar = new Ladar(pContent, this);

            Little = new ScreenMouse(pContent, this);


            hud = new List<HUD_icon>();

            //creating sidebars

            //Left ones
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

            //Right ones
            R_hud = new List<Right_HUD>();
            
            for (int i = 0; i < 3; i++)
            {
                Right_HUD argh = new Right_HUD(pContent, this, i);
                R_hud.Add(argh);
            }


        }

        public void Update(GameTime pGameTime)
        {
            keyboard = Keyboard.GetState();
            mstate = Mouse.GetState();

            foreach (Enemy var1 in enemies) var1.Update(pGameTime);
            foreach (Sprite HUD in hud) HUD.Update(pGameTime);
            foreach (Right_HUD R_H in R_hud) R_H.Update(pGameTime);
            
            SSV.Update(pGameTime);
            cone.Update(pGameTime);

            ladar.Update(pGameTime, cone.Lockin, cone.stopAngle_M);
            Little.Update(pGameTime);

            previousKeyboard = keyboard;
            previousMstate = mstate;
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {

            this.SpriteBatch = pSpriteBatch;
            foreach (Enemy var1 in enemies) if (var1.IsActive) var1.Draw(SpriteBatch);
            foreach(Sprite HUD in hud) HUD.Draw(SpriteBatch);
            foreach (Right_HUD R_H in R_hud) R_H.Draw(pSpriteBatch);
            Little.Draw(pSpriteBatch);
            cone.Draw(spriteBatch);
            SSV.Draw(SpriteBatch);
            ladar.Draw(spriteBatch);
        }
    }
}
