using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HollowBack
{
    class Weapon
    {
        #region Fields

        private float cooldown;
        private float range;
        private float repairTime;

        #endregion

        #region Properties

        public float Cooldown
        {
            get { return cooldown; }
            protected set { cooldown = value; }
        }

        public float Range
        {
            get { return range; }
            protected set { range = value; }
        }

        public float RepairTime
        {
            get { return repairTime; }
            protected set { repairTime = value; }
        }

        #endregion

        public Weapon()
        {

        }

        //public void FireWeapon();

        //public void Repair();

        public void Update(Vector2 pPosition, Vector2 pTarget)
        {
            if (RepairTime <= 0f)
            {
                if (Cooldown <= 0f)
                {
                    if (Vector2.Distance(pPosition, pTarget) < Range) ;
                        //FireWeapon();
                }
                else Cooldown -= 0.1f;
            }
            else RepairTime -= 0.1f;
        }
    }
}
