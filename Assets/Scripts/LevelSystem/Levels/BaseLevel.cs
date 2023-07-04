using Assets.Scripts.CharacterSystem.Enemy;
using System.Collections;
using UnityEngine;
using Yarn.Unity;
using Zenject;

namespace Assets.Scripts.LevelSystem.Levels
{
    public abstract class BaseLevel : MonoBehaviour, IEnumerable
    {
        [Inject]
        protected EnemyDatabase EnemyDatabase;

        [Inject]
        protected DialogueRunner DialogueRunner;

        protected Coroutine ExecutingLevelCoroutine;

        public abstract IEnumerator GetEnumerator();
    }
}
