using System.Collections;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Attack
{
    public class AnimatedAttack : WeaponAttack
    {
        [SerializeField] private WeaponAttack _weaponAttack;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _triggerName;

        public override void Attack(Vector2 position, Vector2 direction)
        {
            _weaponAttack.Attack(position, direction);
            _animator.SetTrigger(_triggerName);
        }
    }
}