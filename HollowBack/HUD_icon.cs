using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace HollowBack
{
    class HUD_icon : Sprite
    {
        private SpriteFont font;
        private int function;
        //0-Missils
        //1-Lasers
        //2-Railgun
        //3-Particle Cannon
        //4-EMP
        //5-Torpedos
        public HUD_icon(ContentManager pContent, Scene scene, int func)
            : base(pContent, "SideBlocks",scene)
        {
            this.function = func;
        }
    }

    //mouseState.LeftButton == ButtonState.Pressed
}
