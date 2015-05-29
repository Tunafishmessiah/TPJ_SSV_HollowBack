using System;
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
            : base(pContent, "Hunter", pScene)
        {
            IsUnknown = false;
            IsVisible = true;
            IsActive = false;

            MaxSpeed = 2f;
            Velocity = MaxSpeed;
            Accelaration = 0.2f;

            this.s_texture = pContent.Load<Texture2D>("HunterLight");
        }
    }
}
