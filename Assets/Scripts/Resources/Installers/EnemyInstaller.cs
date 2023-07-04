using Assets.Scripts.CharacterSystem.Enemy;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Resources.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyDatabase _enemyDatabase;

        public override void InstallBindings()
        {
            Container.Bind<EnemyDatabase>().FromScriptableObject(_enemyDatabase).AsSingle();
        }
    }
}