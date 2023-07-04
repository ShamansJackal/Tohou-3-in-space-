using Assets.Scripts.WeaponSystem.Bullet;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Attack
{
    public class PhysicAttack : WeaponAttack
    {
        [SerializeField] private BaseBullet _bullet;
        [SerializeField] private BulletBuilder _builder;

        public override void Attack(Vector2 position, Vector2 direction)
        {
            _builder.Build(position, direction);
        }
    }
}