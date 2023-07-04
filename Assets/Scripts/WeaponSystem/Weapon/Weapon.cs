using Assets.Scripts.WeaponSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public virtual ITrigger MainFire => null;
        public virtual IWeaponAim Aim => null;
    }
}
