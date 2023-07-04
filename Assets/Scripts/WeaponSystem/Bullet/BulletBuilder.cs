using Assets.Scripts.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.WeaponSystem.Bullet
{
    public class BulletBuilder : MonoBehaviour
    {
        [SerializeField]
        private BulletContext _context;

        private List<Func<BulletContext, BulletContext>> _pipeline = new List<Func<BulletContext, BulletContext>>();

        public BaseBullet Build(Vector2 position, Vector2 direction)
        {
            var ctx = _context;

            for (int i = 0; i < _pipeline.Count; i++)
            {
                ctx = _pipeline[i](ctx);
            }

            direction = Quaternion.AngleAxis(Random.Range(-_context.Spread, _context.Spread), Vector3.forward) * direction;

            var bullet = ctx.Bullet.Instantien(position, direction);

            bullet.Init(_context);
            bullet.gameObject.SetActive(true);

            return bullet;
        }

        public void AddPredicates(params Func<BulletContext, BulletContext>[] func)
        {
            _pipeline.AddRange(func);
        }

        public void RemovePredicate(Func<BulletContext, BulletContext> func)
        {
            _pipeline.Remove(func);
        }
    }
}
