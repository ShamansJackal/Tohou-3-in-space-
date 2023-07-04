using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Character.Health
{
    public class Health : BaseHealth
    {
        [SerializeField]
        private int _maxHealth;

        private int _health;

        public UnityEvent<int, int, bool> OnHealthChange;

        public UnityEvent<DeathContext> OnDeath;

        public override int CurrentHealth => _health;

        public override int MaxHealth => _maxHealth;

        public override int Heal(int heal)
        {
            var actualHealing = _health + heal > _maxHealth ? _maxHealth - _health : heal;
            _health += actualHealing;
            OnHealthChange.Invoke(_health, _maxHealth, false);
            return actualHealing;
        }

        public override int TakeDamage(int damage)
        {
            var actualDamage = _health - damage > 0 ? damage : _health;
            _health -= actualDamage;
            OnHealthChange.Invoke(_health, _maxHealth, true);
            if (_health <= 0) OnDeath.Invoke(new DeathContext());
            return actualDamage;
        }

        private void Start()
        {
            _health = _maxHealth;
            OnHealthChange.Invoke(_health, _maxHealth, false);
        }
    }
}
