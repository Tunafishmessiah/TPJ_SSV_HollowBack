using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Laser : Sprite
    {
        #region Fields

        private Point targetID; // The target's ID

        #endregion

        #region Properties

        public Point TargetID
        {
            get { return targetID; }
            protected set { targetID = value; }
        }

        #endregion

        public Laser(ContentManager pContent, Scene pScene, Point pTarget)
            : base(pContent, "Hunter", pScene)
        {
            TargetID = pTarget;
        }
    }
}
