using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Missile : Enemy
    {
        public Missile(ContentManager pContent, Scene pScene, Point pID)
            : base(pContent, "Hunter", pScene)
        {
            IsUnknown = false;
            IsVisible = true;
            IsActive = false;

            ID = pID;
            Health = 10;

            MaxSpeed = 2f;
            Accelaration = 0.2f;
        }

        public void UpdateMovement(Vector2 pTarget)
        {
            SetDestination(pTarget);
            base.UpdateMovement(0);
        }

        public void Update(Vector2 pTarget)
        {
            UpdateMovement(pTarget);
        }

        public override void TakeDamage(int pDmgType)
        {
            switch (pDmgType)
            {
                case 0: // Laser
                    Health -= 10;
                    break;
                case 1: // Missil
                    Health -= 5;
                    break;
                case 2: // Slug
                    Health -= 2;
                    break;
                case 3: // Particle Cannon
                    Health -= 1;
                    break;
                case 4: // EMP
                    IsMoving = false;
                    break;
            }
        }
    }
}
