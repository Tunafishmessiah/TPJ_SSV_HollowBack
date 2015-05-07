using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace HollowBack
{
    class Fighter : Enemy
    {
        public Fighter(ContentManager pContent, Scene scene)
            : base(pContent, "Hunter", scene)
        {
            IsUnknown = true;
            IsVisible = false;
            IsActive = false;

            MaxSpeed = 1;
            Accelaration = 0.1f;
        }

        public void Update()
        {
            UpdateMovement();
        }
    }
}