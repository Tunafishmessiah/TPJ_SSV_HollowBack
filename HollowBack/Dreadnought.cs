using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Dreadnought : Enemy
    {
        public Dreadnought(ContentManager pContent, Scene scene, int pID)
            : base(pContent, "Hunter", scene)
        {
            IsUnknown = true;
            IsVisible = false;
            IsActive = false;

            ID = new Point(4, pID);
            WeaponSys = new Weapon(10, 10); // Set the weapon systems

            MaxSpeed = 0.4f;
            Accelaration = 0.1f;
                
        }

        public void Update()
        {
            UpdateMovement();
        }
    }
}
