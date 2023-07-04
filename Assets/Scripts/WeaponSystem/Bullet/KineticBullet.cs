using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Bullet
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class KineticBullet : BaseBullet
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private BulletContext _context;
        public override void Init(BulletContext context)
        {
            _context = context;
        }

        private void Start()
        {
            _rigidbody.AddForce(transform.up * _context.Speed, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(((1 << collision.gameObject.layer) & _context.Target) > 0)
            {
                if(collision.TryGetComponent<IDamageble>(out var damageble))
                {
                    damageble.TakeDamage(_context.Damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
