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
        private float repair;
        private float cooldownTime;
        private float repairTime;
        private bool canFire;

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

        public float Repair
        {
            get { return repair; }
            protected set { repair = value; }
        }

        public float CooldownTime
        {
            get { return cooldownTime; }
            protected set { cooldownTime = value; }
        }

        public float RepairTime
        {
            get { return repairTime; }
            protected set { repairTime = value; }
        }

        public bool CanFire
        {
            get { return canFire; }
            protected set { canFire = value; }
        }

        #endregion

        public Weapon(float pCooldownTime, float pRepairTime, float pRange)
        {
            CooldownTime = pCooldownTime;
            RepairTime = pRepairTime;
            Range = pRange;
        }

        public void FireWeapon()
        {
            Cooldown = CooldownTime;
            CanFire = false;
        }

        public void RepairWeapon()
        {
            Repair = RepairTime;
        }

        public void Update(Vector2 pPosition, Vector2 pTarget)
        {
            if (Repair <= 0f)
            {
                if (Cooldown <= 0f)
                {
                    if (Vector2.Distance(pPosition, pTarget) < Range) CanFire = true;
                }
                else Cooldown -= 0.1f;
            }
            else RepairTime -= 0.1f;
        }
    }
}
