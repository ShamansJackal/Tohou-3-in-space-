using Assets.Scripts.Extensions;
using Assets.Scripts.WeaponSystem.Bullet;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Attack
{
    public class RawAttack : WeaponAttack
    {
        [SerializeField] private BulletContext _context;

        public override void Attack(Vector2 position, Vector2 direction)
        {
            var bullet = _context.Bullet.Instantien(position, direction);

            bullet.Init(_context);
            bullet.gameObject.SetActive(true);
        }
    }
}
