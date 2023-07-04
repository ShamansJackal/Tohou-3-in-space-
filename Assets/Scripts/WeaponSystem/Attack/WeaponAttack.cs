using System.Collections;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Attack
{
    public abstract class WeaponAttack : MonoBehaviour
    {
        public abstract void Attack(Vector2 position, Vector2 direction);
    }
}