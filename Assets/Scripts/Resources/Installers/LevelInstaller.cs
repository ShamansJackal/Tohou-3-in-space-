using Assets.Scripts.CharacterSystem;
using Assets.Scripts.LevelSystem.Levels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Resources.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private BaseLevel _level;

        [SerializeField]
        private PlayerCharacter _player;

        public override void InstallBindings()
        {
            Container.Bind<BaseLevel>().FromComponentInNewPrefab(_level.gameObject).WithGameObjectName("Level").AsSingle().Lazy();
            Container.Bind<PlayerCharacter>().FromComponentOn(_player.gameObject).AsSingle();
        }
    }
}
