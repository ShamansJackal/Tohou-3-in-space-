using Assets.Scripts.Character.Health;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CharacterSystem
{
    public abstract class Character : MonoBehaviour, IDamageble
    {
        public BaseHealth health;
        public UnityEvent<DeathContext> onDeath;
        public int TakeDamage(int damage) => health.TakeDamage(damage);

        public abstract void Die(DeathContext deathContext);
    }
}
