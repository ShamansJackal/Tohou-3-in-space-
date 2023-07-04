using Assets.Scripts.WeaponSystem.Aim;
using Assets.Scripts.WeaponSystem.Interfaces;
using Assets.Scripts.WeaponSystem.Trigger;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Weapon
{
    public class ChainGun : Weapon
    {
        [SerializeField]
        private AutomaticTrigger _trigger;


        [SerializeField]
        private WeaponAimedAttack _aim;

        public override IWeaponAim Aim => _aim;
        public override ITrigger MainFire => _trigger;
    }
}
