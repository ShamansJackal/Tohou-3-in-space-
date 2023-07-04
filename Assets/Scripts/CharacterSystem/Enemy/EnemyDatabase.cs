using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.CharacterSystem.Enemy
{
    [CreateAssetMenu(fileName ="Database", menuName = "Enemy/Database")]
    public class EnemyDatabase: ScriptableObject
    {
        [SerializeField]
        private List<EnemyCharacter> _enemies;

        private DiContainer _container;
        private Dictionary<string, EnemyCharacter> _cache = new Dictionary<string, EnemyCharacter>();

        [Inject]
        private void Init(DiContainer container)
        {
            _container = container;
            foreach (var enemy in _enemies)
            {
                if (_cache.ContainsKey(enemy.Id))
                {
                    throw new Exception($"Enemy with id {enemy.Id} all ready exists");
                }
                _cache[enemy.Id] = enemy;
            }
        }

        public TCharacter Instantiate<TCharacter>(string characterId) where TCharacter: EnemyCharacter
        {
            var character = _cache[characterId];
            return _container.InstantiatePrefab(character.gameObject).GetComponent<TCharacter>();
        }

        public TCharacter Instantiate<TCharacter>(string characterId, Transform transform) where TCharacter : EnemyCharacter
        {
            var character = _cache[characterId];
            return _container.InstantiatePrefab(character, transform).GetComponent<TCharacter>();
        }

        public TCharacter Instantiate<TCharacter>(string characterId, Vector3 position, Quaternion rotation, Transform transform = null) where TCharacter : EnemyCharacter
        {
            var character = _cache[characterId];
            return _container.InstantiatePrefab(character, position, rotation, transform).GetComponent<TCharacter>();
        }
    }
}
