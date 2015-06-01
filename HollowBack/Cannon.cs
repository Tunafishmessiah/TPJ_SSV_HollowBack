﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HollowBack
{
    class Cannon : Sprite
    {
                #region Fields

        private Point targetID; // The target's ID
        private float duration; // For how long does the effet stay visible;
        private float timer;

        #endregion

        #region Properties

        public Point TargetID
        {
            get { return targetID; }
            protected set { targetID = value; }
        }

        public float Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public float Timer
        {
            get { return timer; }
            private set { timer = value; }
        }

        #endregion

        public Cannon(ContentManager pContent, Scene pScene, Point pTarget, float pDuration)
            : base(pContent, "Hunter", pScene)
        {
            IsActive = true;

            TargetID = pTarget;
            Duration = pDuration;
            Timer = 0;
        }

        public void Update()
        {
            if (Timer < Duration) Timer++;
            else IsActive = false;
        }
    }
}
