using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Fighter : Enemy
    {
        public Fighter(ContentManager pContent, Scene scene, int pID)
            : base(pContent, "Hunter", scene)
        {
            IsUnknown = true;
            IsVisible = false;
            IsActive = false;

            ID = new Point(1, pID);
            WeaponSys = new Weapon(10, 10); // Set the weapon systems
            Health = 10;

            MaxSpeed = 1;
            Accelaration = 0.1f;
        }

        public void Update()
        {
            UpdateMovement(70);
        }

        public override void TakeDamage(int pDmgType)
        {
            switch (pDmgType)
            {
                case 0: // Laser
                    Health -= 5;
                    break;
                case 1: // Missil
                    Health -= 10;
                    break;
                case 2: // Railgun
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