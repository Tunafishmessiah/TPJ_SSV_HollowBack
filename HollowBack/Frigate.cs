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
    class Frigate : Enemy
    {
        public Frigate(ContentManager pContent, Scene scene, int pID)
            : base(pContent, "Frigate", scene)
        {

            ID = new Point(2, pID);
            WeaponSys = new Weapon(10, 10, 300); // Set the weapon systems
            Health = 10;

            MaxSpeed = 0.5f;
            Accelaration = 0.3f;

            this.Scale = new Vector2(0.5f, 0.5f);

            this.s_texture = pContent.Load<Texture2D>("FrigateSelected");
        }

        public Point Update(GameTime pGameTime)
        {
            UpdateMovement(250);
            UpdateWeapons();
            return base.Update();
        }

        public override void TakeDamage(int pDmgType)
        {
            switch (pDmgType)
            {
                case 0: // Laser
                    Health -= 1;
                    break;
                case 1: // Missile
                    Health -= 5;
                    break;
                case 2: // Slug
                    Health -= 10;
                    break;
                case 3: // Particle Cannon
                    Health -= 2;
                    break;
                case 4: // EMP
                    IsMoving = false;
                    break;
            }
        }
    }
}
