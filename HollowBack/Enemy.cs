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
    class Enemy : Sprite
    {
        #region Fields

        private bool isVisible; // Is the ship within visible range.
        private bool isMoving; // Is the ship moving.
        private bool isUnknown; // As the ship been identified.
        private bool fireWeapon;
        private Vector2 destination; // Where the ship is heading.
        private float maxSpeed; // Maximum flight speed.
        private float accelaration; // Rate at which the ship accelarates.
        private Vector2 target; // Position of the target.
        private Point id; // The ships ID.
        private Point targetID; // The target's ID.
        private Weapon weaponSys; // Weapon Systems
        private int range; // Firing range
        private int health; // Ships health.
        private int lastHealth;//To show the damage the ship has taken
        private Texture2D original,lighted;//trades between selected and not selected
        private bool selected;//see if the ship has been selected
        #endregion

        #region Properties

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; }
        }

        public bool IsUnknown
        {
            get { return isUnknown; }
            set { isUnknown = value; }
        }

        public bool FireWeapon
        {
            get { return fireWeapon; }
            set { fireWeapon = value; }
        }

        public Vector2 Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public float MaxSpeed
        {
            get { return maxSpeed; }
            protected set { maxSpeed = value; }
        }

        public float Accelaration
        {
            get { return accelaration; }
            protected set { accelaration = value; }
        }

        public Vector2 Target
        {
            get { return target; }
            set { target = value; }
        }

        public Point ID
        {
            get { return id; }
            protected set { id = value; }
        }

        public Point TargetID
        {
            get { return targetID; }
            protected set { targetID = value; }
        }

        public Weapon WeaponSys
        {
            get { return weaponSys; }
            protected set { weaponSys = value; }
        }

        public int FiringRange
        {
            get { return range; }
            set { range = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Texture2D Original
        {
            get { return original; }
            set { original = value; }
        }

        public Texture2D s_texture
        {
            get { return lighted; }
            set { lighted = value; }
        }

        public bool isSelected
        { 
            get { return selected; }
            set { selected = value; }
        }
        #endregion

        public Enemy(ContentManager pContent, string pAsset, Scene scene) : base(pContent, pAsset, scene)
        {
            original = pContent.Load<Texture2D>(pAsset);
            IsUnknown = true;
            IsVisible = true;
            IsActive = false;
            selected = false;
        }

        public virtual Point Update()
        {
            if (Health <= 0) IsActive = false;
            Update_Texture();
            return Update_Selection();
        }
        public void SpawnAt(Vector2 pPosition)
        {
            this.Position = pPosition;
            IsActive = true;
        }

        public void UpdatePositionAngle(Targeting cone)
        {
            float PA = (float)(Math.Atan2(this.Position.Y, this.Position.X));
            // Console.WriteLine(PA);

            if ((PA + 0.2 > cone.angle + Math.PI / 32 && (PA - 0.2) < cone.angle - Math.PI / 32))
            {
                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
        }

        public void UpdateMovement(int range)
        {

            if (IsActive)
            {
                if (IsMoving)
                {
                    if (Velocity < MaxSpeed) Velocity += Accelaration;
                    Position += Direction * Velocity;
                    
                }
                else
                {
                    if (Velocity > 0) Velocity -= Accelaration;
                }
            }
            else
            {
                if (Velocity > 0) Velocity -= Accelaration;
            }

            if (Vector2.Distance(Position, Destination) <= range) IsMoving = false;
        }

        public void UpdateWeapons()
        {
            WeaponSys.Update(Position, Target);
            if (WeaponSys.CanFire)
            {
                FireWeapon = true;
                WeaponSys.FireWeapon();
            }
        }

        public void Update_Texture()
        {
            //This is were the texture will be changed
            //when the ship is selected
            if (isSelected)
            {
                if (s_texture != null)
                {
                    this.Texture = s_texture;
                }
            }
            else
            {
                this.Texture = original;
            }
        }

        public Point Update_Selection()
        {
            Point mPosition = this.scene.Mstate.Position;
            //Avaluating if the mouse is on top of this icon
            if(this.Position.X< mPosition.X &&
                this.Position.X + this.Texture.Width > mPosition.X &&
                this.Position.Y < mPosition.Y &&
                this.Position.Y + this.Texture.Height > mPosition.Y)
            {
                if (this.scene.Mstate.LeftButton == ButtonState.Pressed &&
                    !this.isSelected)
                {
                    this.scene.Deselect();
                    foreach (Right_HUD hud in this.scene.R_HUD)
                    {
                        hud.add_selected(this);
                    }
                    isSelected = true;
                    return this.ID;
                }
                return Point.Zero;
            }
            return Point.Zero;
        }

        public void SetDestination(Vector2 pDestination)
        {
            Destination = pDestination;
            Direction = Vector2.Normalize(pDestination - Position);
            IsMoving = true;
        }

        public void SetTarget(Vector2 pTarget)
        {
            this.Target = pTarget;
        }

        public virtual void TakeDamage(int pDmgType)
        {

        }

        public void Engage()
        {
            //if (Vector2.Distance(this.Position, this.Target) < Weapon.Range)
            // && Weapon.Cooldown == 0
            // Weapon.Fire(Target)
        }

    }
}
