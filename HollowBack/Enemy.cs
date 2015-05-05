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

        private bool isVisible; // Is ship within visible range.
        private float maxSpeed; // Maximum flight speed.
        private float accelaration; // Rate at which the ship accelarates.
        private Vector2 target; // Position of the target.

        #endregion

        #region Properties

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public float MaxSpeed
        {
            get { return maxSpeed; }
            private set { maxSpeed = value; }
        }

        public float Accelaration
        {
            get { return accelaration; }
            private set { accelaration = value; }
        }

        public Vector2 Target
        {
            get { return target; }
            set { target = value; }
        }

        #endregion

        public Enemy(ContentManager pContent, Vector2 pPosition, Scene scene) : base(pContent, "Hunter", scene)
        { 

        }

        /// <summary>
        /// Spawns the ship at the specified location.
        /// </summary>
        public void SpawnAt(Vector2 pPosition)
        {
            this.Position = pPosition;
        }

        /// <summary>
        /// If the ship is active accelarates it to max speed and moves it towards the destination.
        /// Else it decelarates the ship.
        /// </summary>
        public void UpdateMovement()
        {
            if (IsActive)
            {
                if (Velocity < MaxSpeed) Velocity += Accelaration;
                Position += Direction * Velocity;
            }
            else
            {
                if (Velocity > 0) Velocity -= Accelaration;
            }
        }

        /// <summary>
        /// Sets the ship's destination.
        /// </summary>
        public void SetDestination(Vector2 pDestination)
        {
            Direction = Vector2.Normalize(pDestination - Position);
        }

        /// <summary>
        /// Sets the ships target.
        /// </summary>
        public void SetTarget(Vector2 pTarget)
        {
            this.Target = pTarget;
        }

        /// <summary>
        /// Fires the main weapon if the ship is within range of its target and the weapon
        /// is off cooldown.
        /// </summary>
        public void Engage()
        {
            //if (Vector2.Distance(this.Position, this.Target) < Weapon.Range)
            // && Weapon.Cooldown == 0
            // Weapon.Fire(Target)
        }

        public void Update()
        {

        }

    }
}
