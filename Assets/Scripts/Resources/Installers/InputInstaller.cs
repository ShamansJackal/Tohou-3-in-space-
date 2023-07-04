using Assets.Scripts.InputLayout;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Resources.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField]
        private RumbleManager _rumbleManager;

        [SerializeField]
        private PlayerInput _playerInput;

        [SerializeField]
        private Canvas _loadingScreen;

        public override void InstallBindings()
        {
            Container.Bind<StandartInputActions>().AsSingle();
            Container.Bind<PlayerInput>().FromComponentInNewPrefab(_playerInput).AsSingle();
            Container.Bind<RumbleManager>().FromComponentInNewPrefab(_rumbleManager).AsSingle();
            Container.Bind<Canvas>()
                .WithId("LoadingScreen")
                .FromComponentInNewPrefab(_loadingScreen)
                .AsSingle()
                .OnInstantiated<Canvas>((ctx, obj) => obj.gameObject.SetActive(false));
        }
    }
}