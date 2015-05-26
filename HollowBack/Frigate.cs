using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Frigate : Enemy
    {
        public Frigate(ContentManager pContent, Scene scene, int pID)
            : base(pContent, "Hunter", scene)
        {
            IsUnknown = true;
            IsVisible = false;
            IsActive = false;

            ID = new Point(2, pID);

            MaxSpeed = 0.7f;
            Accelaration = 0.1f;
        }

        public void Update()
        {
            UpdateMovement(100);
        }
    }
}
