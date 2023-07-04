using Assets.Scripts.WeaponSystem.Attack;
using Assets.Scripts.WeaponSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Aim
{
    public class WeaponAimedAttack : MonoBehaviour, IWeaponAim
    {

        [SerializeField] private WeaponAttack _weaponAttack;

        private Vector3 _position;
        private Vector3 _direction;

        public void SetShootPositionAndDirection(Vector2 position, Vector2 direction)
        {
            _position = position;
            _direction = direction;
        }

        public void AimendAttack()
        {
            _weaponAttack.Attack(_position, _direction);
        }
    }
}
