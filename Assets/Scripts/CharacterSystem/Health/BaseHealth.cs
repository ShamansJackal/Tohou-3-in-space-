using UnityEngine;

namespace Assets.Scripts.Character.Health
{
    public abstract class BaseHealth : MonoBehaviour
    {
        public abstract int CurrentHealth {get;}
        public abstract int MaxHealth {get;}

        public abstract int Heal(int health);

        public abstract int TakeDamage(int damage);
    }
}
