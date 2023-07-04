using System;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Bullet
{
    [Serializable]
    public struct BulletContext
    {
        public int Damage;
        public LayerMask Target;
        public int Speed;
        public BaseBullet Bullet;

        [Range(0, 180)]
        public int Spread;
    }
}
