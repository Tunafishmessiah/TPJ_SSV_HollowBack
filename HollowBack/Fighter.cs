﻿using System;
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

            MaxSpeed = 1;
            Accelaration = 0.1f;
        }

        public void Update()
        {
            UpdateMovement(70);
        }
    }
}