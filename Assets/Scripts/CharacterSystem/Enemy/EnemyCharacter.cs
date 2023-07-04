using Assets.Scripts.Character.Health;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.CharacterSystem.Enemy
{
    public class EnemyCharacter : Character, IHasId<string>
    {
        [SerializeField]
        private CommandsFollower _commandsFollower;

        public CommandsFollower CommandsFollower => _commandsFollower;

        [SerializeField]
        private string _enemyId;

        public string Id => _enemyId;

        public override void Die(DeathContext deathContext)
        {
            onDeath.Invoke(deathContext);
            Destroy(gameObject);
        }
    }
}

