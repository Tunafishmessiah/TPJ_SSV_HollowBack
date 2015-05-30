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
        //Global
        private ScreenMouse little;
        private MouseState mstate, previousMstate;
        private KeyboardState keyboard, previousKeyboard;
        //Gameplay
        private int GAMESTATE;
        private SpriteBatch spriteBatch;
        private List<Fighter> enemyFighter;
        private List<Frigate> enemyFrigate;
        private List<Carrier> enemyCarrier;
        private List<Dreadnought> enemyDreadnought;
        private List<HUD_icon> hud;
        private List<Right_HUD> R_hud;
        private SSV_HollowBack SSV;
        private Targeting cone;
        private Ladar ladar;
        private Vector2 screenSize;
        private GraphicsDevice graphics;
        private int SpawnBlock = 0;
        private bool pause = false;
        private Point Pause;
        //Start
        private HUD_icon Start, End;

        //Game Over;
        #endregion

        #region Properties
        public int Game_State
        {
            get { return GAMESTATE; }
            set { this.GAMESTATE = value; }
        }
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }

        public List<Fighter> EnemyFighter
        {
            get { return enemyFighter; }
            private set { enemyFighter = value; }
        }

        public List<Frigate> EnemyFrigate
        {
            get { return enemyFrigate; }
            private set { enemyFrigate = value; }
        }

        public List<Carrier> EnemyCarrier
        {
            get { return enemyCarrier; }
            private set { enemyCarrier = value; }
        }

        public List<Dreadnought> EnemyDreadnought
        {
            get { return enemyDreadnought; }
            private set { enemyDreadnought = value; }
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

        public Scene(int GameState,SpriteBatch pSpriteBatch, Vector2 screenDimensions, GraphicsDevice Graph, ContentManager Content)
        {
            GAMESTATE = GameState;

            Graphics = Graph;
            //Loading "master" variables
            this.spriteBatch = pSpriteBatch;
            this.screenSize = screenDimensions;

            //This variable were made so that we can save some processing time, we can acess it
            //from any variable that's called here, so we don't need to call them in almost every single thing we have on screen
            mstate = Mouse.GetState();
            previousMstate = mstate;

            keyboard = Keyboard.GetState();
            previousKeyboard = keyboard;

            Little = new ScreenMouse(Content, this);

            MakeHUD(Content);

            switch (GAMESTATE)
            {
                    //Main Menu
                case 1:
                    Start_Load(GameState, pSpriteBatch, Content);
                    break;
                    //Gameplay
                case 2:
                    Gameplay_Load(GameState,pSpriteBatch,Content);
                    break;
                    //GameOver
                case 3:
                    End_Load(GameState, pSpriteBatch, Content);
                    break;
            }
        }

        public void UnloadContent()
        {

        }

        public int Update(int GameState,GameTime pGameTime, ContentManager Content)
        {
            GAMESTATE = GameState;


            keyboard = Keyboard.GetState();
            mstate = Mouse.GetState();

            Little.Update(pGameTime);

            switch (GAMESTATE)
            {
                case 1:
                    Start_Update(GAMESTATE, pGameTime, Content);
                    break;

                case 2:
                    Gameplay_Update(GAMESTATE,pGameTime,Content);
                    break;

                case 3:
                    End_Update(GAMESTATE, pGameTime, Content);
                    break;
            }

            previousKeyboard = keyboard;
            previousMstate = mstate;
            return GAMESTATE;
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            this.SpriteBatch = pSpriteBatch;

            switch (GAMESTATE)
            {
                case 1:
                    Start_Draw(pSpriteBatch);
                    break;

                case 2:
                    Gameplay_Draw(pSpriteBatch);
                    break;

                case 3:
                    End_Draw(pSpriteBatch);
                    break;

            }

            Little.Draw(pSpriteBatch);
        }

        public void AddSprite(ContentManager pContent, String pAssetName)
        {
            Sprite var = new Sprite(pContent, pAssetName,this);
        }


        #region Add Enemy

        public void AddFigther(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyFighter.Count != 0) while (i < EnemyFighter.Count && EnemyFighter[i] != null) i++;
            Fighter var = new Fighter(pContent, this, i);
            EnemyFighter.Insert(i, var);
            EnemyFighter[i].SpawnAt(pPosition);
            EnemyFighter[i].SetDestination(pDestination);
        }

        public void AddFrigate(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyFrigate.Count != 0) while (i < EnemyFrigate.Count && EnemyFrigate[i] != null) i++;
            Frigate var = new Frigate(pContent, this, i);
            EnemyFrigate.Insert(i, var);
            EnemyFrigate[i].SpawnAt(pPosition);
            EnemyFrigate[i].SetDestination(pDestination);
        }

        public void AddCarrier(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyCarrier.Count != 0) while (i < EnemyCarrier.Count && EnemyCarrier[i] != null) i++;
            Carrier var = new Carrier(pContent, this, i);
            EnemyCarrier.Insert(i, var);
            EnemyCarrier[i].SpawnAt(pPosition);
            EnemyCarrier[i].SetDestination(pDestination);
        }

        public void AddDreadnought(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyDreadnought.Count != 0) while (i < EnemyDreadnought.Count && EnemyDreadnought[i] != null) i++;
            Dreadnought var = new Dreadnought(pContent, this, i);
            EnemyDreadnought.Insert(i, var);
            EnemyDreadnought[i].SpawnAt(pPosition);
            EnemyDreadnought[i].SetDestination(pDestination);
        }

        public void SpawnEnemy(ContentManager Content)
        {
            Random rnd = new Random();
            int SelShip = rnd.Next(1, 5);
            
            #region SpawnSelection
            int SpawnX = rnd.Next(-(int)(screenSize.X / 2), (int)screenSize.X + (int)(screenSize.X/2));
            int SpawnY = 0;
            //Coordenadas onde a nave vai dar spawn

            if (SpawnX > 0 && SpawnX < screenSize.X) //Se a coordenada X estiver dentro do ecrã
            {
                int SelectY = rnd.Next(1, 3); //Seleção: Se a coordenada Y vai ser por cima ou por baixo do ecrã

                if (SelectY == 1)
                {
                    SpawnY = rnd.Next(0 - (int)(screenSize.Y / 2), 0);
                }
                else //Então a coordenada Y vai ser por cima ou por baixo do ecrã, estando fora dos limites do mesmo
                {
                    SpawnY = rnd.Next((int)(screenSize.Y), (int)screenSize.Y + (int)(screenSize.Y / 2));
                }
            }
            else //Caso contrário, então a coordenada  Y pode ser qualquer uma dentro dos limites estipulados
            {
                SpawnY = rnd.Next(0 - (int)(screenSize.Y / 2), (int)screenSize.Y + (int)(screenSize.Y / 2));
            }
            #endregion

            #region DestinationSelection

            int DestX = 640;
            int DestY = 360;


            #endregion

            switch (SelShip)
            {
                case 1: AddFigther(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
                case 2: AddFrigate(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
                case 3: AddCarrier(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
                case 4: AddDreadnought(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
            }
        }



        #endregion



#region Start_Code
        private void Start_Load(int GameState, SpriteBatch pSpriteBatch, ContentManager Content)
        {
            MakeHUD(Content);
        }
        private void Start_Update(int GameState, GameTime pGameTime, ContentManager Content)
        {
            foreach (Sprite HUD in hud) HUD.Update(pGameTime);
        }
        private void Start_Draw(SpriteBatch pSpriteBatch)
        {
            foreach (Sprite HUD in hud) HUD.Draw(SpriteBatch);
        }
#endregion

#region Gameplay_Code
        private void Gameplay_Load(int GameState, SpriteBatch pSpriteBatch,  ContentManager Content)
        {                    //Loading stuff and starting up some needed variables
            EnemyFighter = new List<Fighter>();
            EnemyFrigate = new List<Frigate>();
            EnemyCarrier = new List<Carrier>();
            EnemyDreadnought = new List<Dreadnought>();
        }

        private void Gameplay_Update(int GameState, GameTime pGameTime, ContentManager Content)
        {
            if (keyboard != previousKeyboard && keyboard.IsKeyDown(Keys.Escape) && pause)
            { this.Game_State = 0; }

            if (keyboard.IsKeyDown(Keys.Escape))
            { 
                pause = true;
                this.Pause = mstate.Position;
            }
            

            if (keyboard != previousKeyboard && keyboard.IsKeyDown(Keys.Enter) && pause)
            { 
                pause = false;
                Mouse.SetPosition(Pause.X,Pause.Y);
            }

            if (!pause)
            {
                foreach (Enemy var1 in enemyFighter) var1.Update(pGameTime);
                foreach (Sprite HUD in hud) HUD.Update(pGameTime);
                foreach (Right_HUD R_H in R_hud) R_H.Update(pGameTime);

                SSV.Update(pGameTime);
                cone.Update(pGameTime);

                //Enemies Update
                foreach (Fighter Enemies in EnemyFighter)
                {
                    Enemies.Update(pGameTime);
                    Enemies.UpdatePositionAngle(cone);
                }
                foreach (Frigate Enemies in EnemyFrigate)
                {
                    Enemies.Update(pGameTime);
                    Enemies.UpdatePositionAngle(cone);
                }
                foreach (Carrier Enemies in EnemyCarrier)
                {
                    Enemies.Update(pGameTime);
                    Enemies.UpdatePositionAngle(cone);
                }
                foreach (Dreadnought Enemies in EnemyDreadnought)
                {
                    Enemies.Update(pGameTime);
                    Enemies.UpdatePositionAngle(cone);
                }
                //endEnemies Update

                ladar.Update(pGameTime, cone.Lockin, cone.stopAngle_M);

                if (SpawnBlock == 50)
                {
                    SpawnEnemy(Content);
                    SpawnBlock = 0;
                }
                else SpawnBlock += 1;
            }
        }

        private void Gameplay_Draw(SpriteBatch pSpriteBatch)
        {
            foreach (Enemy var1 in EnemyFighter) var1.Draw(SpriteBatch);
            cone.Draw(spriteBatch);
            SSV.Draw(SpriteBatch);
            ladar.Draw(spriteBatch);
            foreach (Sprite HUD in hud) HUD.Draw(SpriteBatch);
            foreach (Right_HUD R_H in R_hud) R_H.Draw(SpriteBatch);
            if (pause)
            {
                pSpriteBatch.DrawString(R_hud[2].Font,
                    "Press ESC again to quit\nPress Enter to continue",
                    new Vector2((this.screenSize.X/2)-(R_hud[2].Font.MeasureString("Press ESC again to quit\nPress Enter to continue").X / 2),
                        (this.screenSize.Y/2)-(R_hud[2].Font.MeasureString("Press ESC again to quit\nPress Enter to continue").Y * 2)),
                    Color.White);
            }
        }
#endregion

#region End_Code
        private void End_Load(int GameState, SpriteBatch pSpriteBatch, ContentManager Content)
        { }
        private void End_Update(int GameState, GameTime pGameTime, ContentManager Content)
        { }
        private void End_Draw(SpriteBatch pSpriteBatch)
        { }
        #endregion

        public void MakeHUD( ContentManager pContent)
        {
            switch(Game_State)
            {
                case 1:
                    hud = new List<HUD_icon>();
                    Start = new HUD_icon(pContent,this,6);
                    End = new HUD_icon(pContent, this, 7);
                    Start.Scale = new Vector2(2.4f, 1.5f);
                    End.Scale = new Vector2(2.4f, 1.5f);
                    Start.Position = new Vector2(0, 0 + Start.Texture.Height);
                    End.Position = new Vector2(0, screenSize.Y - (End.Texture.Height*2));

                    hud.Add(Start);
                    hud.Add(End);

                    break;
                case 2:
                    SSV = new SSV_HollowBack(pContent, this);
                    cone = new Targeting(pContent, this);

                    ladar = new Ladar(pContent, this);
            
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
            break;
        }

        }

        public void Deselect()
        {
            foreach (Fighter Enemies in EnemyFighter)
            {
                Enemies.isSelected = false;
            }
            foreach (Frigate Enemies in EnemyFrigate)
            {
                Enemies.isSelected = false;
            }
            foreach (Carrier Enemies in EnemyCarrier)
            {
                Enemies.isSelected = false;
            }
            foreach (Dreadnought Enemies in EnemyDreadnought)
            {
                Enemies.isSelected = false;
            }
        }
    }
}
