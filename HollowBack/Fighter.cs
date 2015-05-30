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
    class Fighter : Enemy
    {
        public Fighter(ContentManager pContent, Scene scene, int pID)
            : base(pContent, "Hunter", scene)
        {
            ID = new Point(1, pID);
            WeaponSys = new Weapon(10, 10, 200); // Set the weapon systems
            Health = 10;

            MaxSpeed = .7f;
            Accelaration = 0.3f;

            this.s_texture = pContent.Load<Texture2D>("HunterLight");
        }

        public override void Update(GameTime pGameTime)
        {
            UpdateMovement(100);
            UpdateWeapons();
            base.Update();
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