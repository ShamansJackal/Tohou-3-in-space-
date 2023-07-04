using Assets.Scripts.InputLayout;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.WeaponSystem.Attack
{
    public class RumbelAttack : WeaponAttack
    {
        [SerializeField] private WeaponAttack _weaponAttack;

        [Inject] private RumbleManager _rumbleManager;
        [SerializeField] private float _duration;
        [SerializeField] private float _lowFreq;
        [SerializeField] private float _highFreq;

        public override void Attack(Vector2 position, Vector2 direction)
        {
            _weaponAttack.Attack(position, direction);
            _rumbleManager.RumblePulse(_lowFreq, _highFreq, _duration);
        }
    }
}
