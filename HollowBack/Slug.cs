using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

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
        }
    }
}
