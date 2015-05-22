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
        private Point id;

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

        #endregion

        public Enemy(ContentManager pContent, string pAsset, Scene scene) : base(pContent, pAsset, scene)
        {
            IsUnknown = true;
            IsVisible = false;
            IsActive = false;
        }


        public void SpawnAt(Vector2 pPosition)
        {
            this.Position = pPosition;
            IsActive = true;
        }


        public void UpdatePositionAngle(Targeting cone)
        {
           float PA = (float)(Math.Atan2(this.Position.X - 640, this.Position.Y - 360));
           //Console.WriteLine(this.Position.ToString());
           Console.WriteLine(PA + ":" + cone.angle);

           if ((PA + 0.42) > cone.angle + Math.PI / 32 && (PA - 0.42) < cone.angle - Math.PI / 32)
           {
               IsVisible = true;
           }
           else
           {
               IsVisible = false;
           }
        }

        public void UpdateMovement()
        {

            if (IsActive)
            {
                if (IsMoving)
                {
                    if (Velocity < MaxSpeed) Velocity += Accelaration;
                    Position += Direction * Velocity;
                    if (Vector2.Distance(Position, Destination) <= 100) IsMoving = false;
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
        }

        public void Update(Targeting cone)
        {
            UpdatePositionAngle(cone);
        }

        public void SetDestination(Vector2 pDestination)
        {
            Direction = Vector2.Normalize(pDestination - Position);
            IsMoving = true;
        }


        public void SetTarget(Vector2 pTarget)
        {
            this.Target = pTarget;
        }


        public void Engage()
        {
            //if (Vector2.Distance(this.Position, this.Target) < Weapon.Range)
            // && Weapon.Cooldown == 0
            // Weapon.Fire(Target)
        }

    }
}
