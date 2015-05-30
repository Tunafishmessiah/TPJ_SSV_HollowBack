using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace HollowBack
{
    class Missile : Enemy
    {
        public Missile(ContentManager pContent, Scene pScene, int pID, Point pTargetID)
            : base(pContent, "Missile", pScene)
        {
            IsUnknown = false;
            IsVisible = true;
            IsActive = false;

            ID = new Point(5, pID);
            TargetID = pTargetID;
            Health = 10;

            this.Scale = new Vector2(0.3f, 0.3f);

            MaxSpeed = 2f;
            Accelaration = 0.2f;
            this.s_texture = pContent.Load<Texture2D>("MissileSelected");
        }

        public void UpdateMovement(Vector2 pTarget)
        {
            SetDestination(pTarget);
            base.UpdateMovement(0);
        }

        public void Update(Vector2 pTarget)
        {
            UpdateMovement(pTarget);
            base.Update();
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
