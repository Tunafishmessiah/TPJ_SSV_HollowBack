using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Carrier : Enemy
    {
        public Carrier(ContentManager pContent, Scene scene, int pID)
            : base(pContent, "Hunter", scene)
        {
            IsUnknown = true;
            IsVisible = false;
            IsActive = false;

            ID = new Point(3, pID);
            WeaponSys = new Weapon(10, 10); // Set the weapon systems
            Health = 10;

            MaxSpeed = 0.3f;
            Accelaration = 0.3f;
        }

        public void Update()
        {
            UpdateMovement(200);
        }

        public override void TakeDamage(int pDmgType)
        {
            switch (pDmgType)
            {
                case 0: // Laser
                    Health -= 1;
                    break;
                case 1: // Missile
                    Health -= 2;
                    break;
                case 2: // Railgun
                    Health -= 5;
                    break;
                case 3: // Particle Cannon
                    Health -= 10;
                    break;
                case 4: // EMP
                    IsMoving = false;
                    break;
            }
        }
    }
}
