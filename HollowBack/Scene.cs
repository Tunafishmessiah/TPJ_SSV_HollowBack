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
        private ContentManager content;
        //Gameplay
        private int GAMESTATE;
        private SpriteBatch spriteBatch;
        private List<Fighter> enemyFighter;
        private List<Fighter> enemyFighterDump;
        private List<Frigate> enemyFrigate;
        private List<Frigate> enemyFrigateDump;
        private List<Carrier> enemyCarrier;
        private List<Carrier> enemyCarrierDump;
        private List<Dreadnought> enemyDreadnought;
        private List<Dreadnought> enemyDreadnoughtDump;
        private List<Laser> lasers;
        private List<Laser> lasersDump;
        private List<Missile> enemyMissile;
        private List<Missile> enemyMissileDump;
        private List<Slug> enemySlug;
        private List<Slug> enemySlugDump;
        private List<Cannon> enemyCannon;
        private List<Cannon> enemyCannonDump;
        private List<WeaponPlayer> playerWpn;
        private Point targetID;
        private int HB_hp;
        //private List<PtCannon> enemyCannon;
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

        public ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }

        public List<Fighter> EnemyFighter
        {
            get { return enemyFighter; }
            private set { enemyFighter = value; }
        }

        public List<Fighter> EnemyFighterDump
        {
            get { return enemyFighterDump; }
            private set { enemyFighterDump = value; }
        }

        public List<Frigate> EnemyFrigate
        {
            get { return enemyFrigate; }
            private set { enemyFrigate = value; }
        }

        public List<Frigate> EnemyFrigateDump
        {
            get { return enemyFrigateDump; }
            private set { enemyFrigateDump = value; }
        }

        public List<Carrier> EnemyCarrier
        {
            get { return enemyCarrier; }
            private set { enemyCarrier = value; }
        }

        public List<Carrier> EnemyCarrierDump
        {
            get { return enemyCarrierDump; }
            private set { enemyCarrierDump = value; }
        }

        public List<Dreadnought> EnemyDreadnought
        {
            get { return enemyDreadnought; }
            private set { enemyDreadnought = value; }
        }

        public List<Dreadnought> EnemyDreadnoughtDump
        {
            get { return enemyDreadnoughtDump; }
            private set { enemyDreadnoughtDump = value; }
        }


        public List<Missile> EnemyMissile
        {
            get { return enemyMissile; }
            private set { enemyMissile = value; }
        }

        public List<Missile> EnemyMissileDump
        {
            get { return enemyMissileDump; }
            private set { enemyMissileDump = value; }
        }

        public List<Laser> Lasers
        {
            get { return lasers; }
            private set { lasers = value; }
        }

        public List<Laser> LaserDump
        {
            get { return lasersDump; }
            private set { lasersDump = value; }
        }

        public List<Slug> EnemySlug
        {
            get { return enemySlug; }
            private set { enemySlug = value; }
        }

        public List<Slug> EnemySlugDump
        {
            get { return enemySlugDump; }
            private set { enemySlugDump = value; }
        }

        public List<Cannon> EnemyCannon
        {
            get { return enemyCannon; }
            private set { enemyCannon = value; }
        }

        public List<Cannon> EnemyCannonDump
        {
            get { return enemyCannonDump; }
            private set { enemyCannonDump = value; }
        }

        public List<WeaponPlayer> PlayerWpn
        {
            get { return playerWpn; }
            private set { playerWpn = value; }
        }

        public int HB_HP
        {
            get { return HB_hp; }
            private set { HB_hp = value; }
        }

        public Point TargetID
        {
            get { return targetID; }
            set { targetID = value; }
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

        public Scene(int GameState,SpriteBatch pSpriteBatch, Vector2 screenDimensions, GraphicsDevice Graph, ContentManager pContent)
        {
            GAMESTATE = GameState;

            Graphics = Graph;
            //Loading "master" variables
            this.spriteBatch = pSpriteBatch;
            this.screenSize = screenDimensions;
            this.Content = pContent;
 

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
            EnemyFighter[i].SetTarget(new Vector2(640, 360));
        }

        public void AddFrigate(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyFrigate.Count != 0) while (i < EnemyFrigate.Count && EnemyFrigate[i] != null) i++;
            Frigate var = new Frigate(pContent, this, i);
            EnemyFrigate.Insert(i, var);
            EnemyFrigate[i].SpawnAt(pPosition);
            EnemyFrigate[i].SetDestination(pDestination);
            EnemyFrigate[i].SetTarget(new Vector2(640, 360));
        }

        public void AddCarrier(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyCarrier.Count != 0) while (i < EnemyCarrier.Count && EnemyCarrier[i] != null) i++;
            Carrier var = new Carrier(pContent, this, i);
            EnemyCarrier.Insert(i, var);
            EnemyCarrier[i].SpawnAt(pPosition);
            EnemyCarrier[i].SetDestination(pDestination);
            EnemyCarrier[i].SetTarget(new Vector2(640, 360));
        }

        public void AddDreadnought(ContentManager pContent, Vector2 pPosition, Vector2 pDestination)
        {
            int i = 0;
            if (EnemyDreadnought.Count != 0) while (i < EnemyDreadnought.Count && EnemyDreadnought[i] != null) i++;
            Dreadnought var = new Dreadnought(pContent, this, i);
            EnemyDreadnought.Insert(i, var);
            EnemyDreadnought[i].SpawnAt(pPosition);
            EnemyDreadnought[i].SetDestination(pDestination);
            EnemyDreadnought[i].SetTarget(new Vector2(640, 360));
        }

        public void SpawnEnemy(ContentManager Content)
        {
            Random rnd = new Random();
            int SelShip = rnd.Next(1, 4);
            
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
                case 1: AddFrigate(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
                case 2: AddCarrier(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
                case 3: AddDreadnought(Content, new Vector2(SpawnX, SpawnY), new Vector2(DestX, DestY)); break;
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
            EnemyFighterDump = new List<Fighter>();
            EnemyFrigate = new List<Frigate>();
            EnemyFrigateDump = new List<Frigate>();
            EnemyCarrier = new List<Carrier>();
            EnemyCarrierDump = new List<Carrier>();
            EnemyDreadnought = new List<Dreadnought>();
            EnemyDreadnoughtDump = new List<Dreadnought>();
            EnemyMissile = new List<Missile>();
            enemyMissileDump = new List<Missile>();
            Lasers = new List<Laser>();
            LaserDump = new List<Laser>();
            EnemySlug = new List<Slug>();
            enemySlugDump = new List<Slug>();
            EnemyCannon = new List<Cannon>();
            EnemyCannonDump = new List<Cannon>();
            PlayerWpn = new List<WeaponPlayer>();
            PlayerWpn.Add(new WeaponPlayer(10, 10, 300)); // Missile
            PlayerWpn.Add(new WeaponPlayer(10, 10, 200)); // Laser
            PlayerWpn.Add(new WeaponPlayer(10, 10, 400)); // Railgun
            PlayerWpn.Add(new WeaponPlayer(10, 10, 500)); // Particle Cannon
            PlayerWpn.Add(new WeaponPlayer(10, 10, 800)); // EMP
            HB_hp = 100;
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
                    Point ID = Enemies.Update(pGameTime);
                    if (ID != Point.Zero) TargetID = ID;
                    Enemies.UpdatePositionAngle(cone);
                    if (Enemies.FireWeapon)
                    {
                        int i = 0;
                        if (EnemyMissile.Count != 0) while (i < EnemyMissile.Count && EnemyMissile[i] != null) i++;
                        Missile var = new Missile(content, this, i, new Point(0,0));
                        EnemyMissile.Insert(i, var);
                        EnemyMissile[i].SpawnAt(Enemies.Position);
                        EnemyMissile[i].SetDestination(new Vector2(640, 360));
                        Enemies.FireWeapon = false;
                    }
                    if (!Enemies.IsActive) EnemyFighterDump.Add(Enemies);
                }
                EnemyFighter = EnemyFighter.Except(EnemyFighterDump).ToList();

                foreach (Frigate Enemies in EnemyFrigate)
                {
                    Point ID = Enemies.Update(pGameTime);
                    if (ID != Point.Zero) TargetID = ID;
                    Enemies.UpdatePositionAngle(cone);
                    if (Enemies.FireWeapon)
                    {
                        int i = 0;
                        if (EnemySlug.Count != 0) while (i < EnemySlug.Count && EnemySlug[i] != null) i++;
                        Slug var = new Slug(content, this);
                        EnemySlug.Insert(i, var);
                        EnemySlug[i].SpawnAt(Enemies.Position);
                        EnemySlug[i].SetDestination(new Vector2(640, 360));
                        Enemies.FireWeapon = false;
                    }
                    if (!Enemies.IsActive) EnemyFrigateDump.Add(Enemies);
                }
                EnemyFrigate = EnemyFrigate.Except(EnemyFrigateDump).ToList();

                foreach (Carrier Enemies in EnemyCarrier)
                {
                    Point ID = Enemies.Update(pGameTime);
                    if (ID != Point.Zero) 
                        TargetID = ID;
                    Enemies.UpdatePositionAngle(cone);
                    if (Enemies.FireWeapon)
                    {
                        AddFigther(content, Enemies.Position, new Vector2(640, 360));
                        Enemies.FireWeapon = false;
                    }
                    if (!Enemies.IsActive) EnemyCarrierDump.Add(Enemies);
                }
                EnemyCarrier = EnemyCarrier.Except(EnemyCarrierDump).ToList();

                foreach (Dreadnought Enemies in EnemyDreadnought)
                {
                    Point ID = Enemies.Update(pGameTime);
                    if (ID != Point.Zero) 
                        TargetID = ID;
                    Enemies.UpdatePositionAngle(cone);
                    if (Enemies.FireWeapon)
                    {
                        int i = 0;
                        if (EnemyCannon.Count != 0) while (i < EnemyCannon.Count && EnemyCannon[i] != null) i++;
                        Cannon var = new Cannon(content, this, new Point(0,0), 10);
                        EnemyCannon.Insert(i, var);
                        EnemyCannon[i].SpawnAt(Enemies.Position);
                        Enemies.FireWeapon = false;
                    }
                    if (!Enemies.IsActive) EnemyDreadnoughtDump.Add(Enemies);
                }
                EnemyDreadnought = EnemyDreadnought.Except(EnemyDreadnoughtDump).ToList();

                //endEnemies Update

                //Weapons Update

                foreach (Missile Missile in EnemyMissile)
                {
                    Point ID = Missile.Update(GetPositionByID(Missile.TargetID));
                    if (ID != Point.Zero) TargetID = ID;

                    if (Missile.Friendly == false && Missile.IsMoving == false)
                    {
                        Missile.Destroy = true;
                        enemyMissileDump.Add(Missile);
                        HB_hp -= 1;
                    }
                    else if (Missile.Friendly && !Missile.IsMoving)
                    {
                        DamageTarget(Missile.TargetID, 1);
                    }
                }

                enemyMissile = enemyMissile.Except(enemyMissileDump).ToList();

                foreach (Laser Lsr in Lasers)
                {
                    Lsr.Update();
                }

                foreach (Slug Slug in EnemySlug)
                {
                    Slug.Update();

                    if (Slug.Friendly == false && Slug.IsMoving == false)
                    {
                        Slug.Destroy = true;
                        enemySlugDump.Add(Slug);
                        HB_hp -= 5;
                    }
                    else if (Slug.Friendly && !Slug.IsMoving)
                    {
                        DamageTarget(Slug.TargetID, 2);
                    }
                }

                enemySlug = enemySlug.Except(enemySlugDump).ToList();

                foreach (Cannon Cannon in EnemyCannon)
                {
                    Cannon.Update();

                    //Add destroy here.
                }

                enemySlug = enemySlug.Except(enemySlugDump).ToList();

                //endWeapons Update

                ladar.Update(pGameTime, cone.Lockin, cone.stopAngle_M);

                if (SpawnBlock == 200)
                {
                    SpawnEnemy(Content);
                    SpawnBlock = 0;
                }
                else SpawnBlock += 1;

                //PlayerWeapons

                PlayerWpn[0].Update();
                PlayerWpn[1].Update();
                PlayerWpn[2].Update();
                PlayerWpn[3].Update();
                PlayerWpn[4].Update();

                if (keyboard.IsKeyDown(Keys.D1))
                {
                    if (PlayerWpn[0].CanFire)
                    {
                        int i = 0;
                        if (EnemyMissile.Count != 0) while (i < EnemyMissile.Count && EnemyMissile[i] != null) i++;
                        Missile var = new Missile(content, this, i, TargetID);
                        EnemyMissile.Insert(i, var);
                        EnemyMissile[i].SpawnAt(new Vector2(640, 360));
                        EnemyMissile[i].SetDestination(GetPositionByID(TargetID));
                        EnemyMissile[i].Friendly = true;
                        PlayerWpn[0].FireWeapon();
                    }
                }
                else if (keyboard.IsKeyDown(Keys.D2))
                {
                    if (PlayerWpn[1].CanFire)
                    {
                        int i = 0;
                        if (Lasers.Count != 0) while (i < Lasers.Count && Lasers[i] != null) i++;
                        Laser var = new Laser(content, this, TargetID, 10);
                        Lasers.Insert(i, var);
                        Lasers[i].SpawnAt(new Vector2(640, 360));
                        PlayerWpn[1].FireWeapon();
                    }
                }
                else if (keyboard.IsKeyDown(Keys.D3))
                {
                    if (PlayerWpn[2].CanFire)
                    {
                        int i = 0;
                        if (EnemySlug.Count != 0) while (i < EnemySlug.Count && EnemySlug[i] != null) i++;
                        Slug var = new Slug(content, this);
                        EnemySlug.Insert(i, var);
                        EnemySlug[i].SpawnAt(new Vector2(640, 360));
                        EnemySlug[i].SetDestination(GetPositionByID(TargetID));
                        PlayerWpn[2].FireWeapon();
                    }
                }
                else if (keyboard.IsKeyDown(Keys.D4))
                {
                    if (PlayerWpn[3].CanFire)
                    {
                        int i = 0;
                        if (EnemyCannon.Count != 0) while (i < EnemyCannon.Count && EnemyCannon[i] != null) i++;
                        Cannon var = new Cannon(content, this, TargetID, 10);
                        EnemyCannon.Insert(i, var);
                        EnemyCannon[i].SpawnAt(new Vector2(640, 360));
                        PlayerWpn[3].FireWeapon();
                        DamageTarget(TargetID, 3);
                    }
                }
                else if (keyboard.IsKeyDown(Keys.D5))
                {
                    if (PlayerWpn[4].CanFire)
                    {
                        foreach (Fighter var1 in EnemyFighter) DamageTarget(var1.ID, 4);
                        foreach (Frigate var1 in EnemyFrigate) DamageTarget(var1.ID, 4);
                        foreach (Carrier var1 in EnemyCarrier) DamageTarget(var1.ID, 4);
                        foreach (Dreadnought var1 in EnemyDreadnought) DamageTarget(var1.ID, 4);
                    }
                }

                //End Player Weapons

                //Dreadnought Countdown
                foreach (Dreadnought Dreadnought in EnemyDreadnought)
                {
                    if (Dreadnought.IsMoving == false)
                    {
                        Dreadnought.cannonCountdown -= 1;
                        //Console.WriteLine(Dreadnought.cannonCountdown);
                    }

                    if (Dreadnought.cannonCountdown == 0)
                    {
                        Dreadnought.cannonCountdown = 100;
                    }
                    
                }
                //end Dreadnought Countdown
            }
        }

        private void Gameplay_Draw(SpriteBatch pSpriteBatch)
        {
            foreach (Fighter var1 in EnemyFighter) var1.Draw(SpriteBatch);
            foreach (Frigate var1 in EnemyFrigate) var1.Draw(SpriteBatch);
            foreach (Carrier var1 in EnemyCarrier) var1.Draw(SpriteBatch);
            foreach (Dreadnought var1 in EnemyDreadnought) { var1.Draw(SpriteBatch); var1.DrawCountDown(SpriteBatch); }
            foreach (Missile var1 in EnemyMissile) var1.Draw(SpriteBatch);
            foreach (Slug var1 in EnemySlug) var1.Draw(SpriteBatch);
            foreach (Cannon var1 in EnemyCannon) if(var1.IsActive) var1.Draw(SpriteBatch);
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
            foreach (Missile Enemies in enemyMissile)
            {
                Enemies.isSelected = false;
            }
            foreach (Slug Enemies in enemySlug)
            {
                Enemies.isSelected = false;
            }
        //    }
        //private List<Missile> enemyMissile;
        //private List<Slug> enemySlug;
        }

        public Vector2 GetPositionByID(Point pID)
        {
            switch (pID.X)
            {
                case 0:
                    return new Vector2(640, 360);
                case 1:
                    return EnemyFighter[pID.Y].Position;
                case 2:
                    return EnemyFrigate[pID.Y].Position;
                case 3:
                    return EnemyCarrier[pID.Y].Position;
                case 4:
                    return EnemyDreadnought[pID.Y].Position;
                case 5:
                    return EnemyMissile[pID.Y].Position;
                default:
                    return Vector2.Zero;
            }
        }

        public void DamageTarget(Point pID, int pDmgType)
        {
            switch (pID.X)
            {
                case 1:
                    if (EnemyFighter.Count != 0) 
                        EnemyFighter[pID.Y].TakeDamage(pDmgType);
                    break;
                case 2:
                    if (EnemyFrigate.Count != 0) 
                        EnemyFrigate[pID.Y].TakeDamage(pDmgType);
                    break;
                case 3:
                    if (EnemyCarrier.Count != 0) 
                        EnemyCarrier[pID.Y].TakeDamage(pDmgType);
                    break;
                case 4:
                    if (EnemyDreadnought.Count != 0) 
                        EnemyDreadnought[pID.Y].TakeDamage(pDmgType);
                    break;
                case 5:
                    if (EnemyMissile.Count != 0) 
                        EnemyMissile[pID.Y].TakeDamage(pDmgType);
                    break;
                default:
                    break;
            }
        }
    }
}
