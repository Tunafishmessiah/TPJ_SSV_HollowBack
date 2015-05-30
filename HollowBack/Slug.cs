﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HollowBack
{
    class Slug : Enemy
    {
        public Slug(ContentManager pContent, Scene pScene)
            : base(pContent, "Slug", pScene)
        {
            IsUnknown = false;
            IsVisible = true;
            IsActive = false;

            ID = new Point(6, 0);

            this.Scale = new Vector2(0.3f, 0.3f);

            MaxSpeed = 2f;
            Velocity = MaxSpeed;
            Accelaration = 0.2f;

            this.s_texture = pContent.Load<Texture2D>("SlugSelected");
        }

        public override void Update()
        {
            UpdateMovement(0);
            base.Update();
        }
    }
}
