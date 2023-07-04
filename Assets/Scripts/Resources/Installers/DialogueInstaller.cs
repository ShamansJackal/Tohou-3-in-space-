using UnityEngine;
using UnityEngine.Localization.Settings;
using Yarn.Unity;
using Zenject;

namespace Assets.Scripts.Resources.Installers
{
    public class DialogueInstaller : MonoInstaller
    {
        [SerializeField]
        private DialogueRunner _dialogueRunner;

        [SerializeField]
        private TextLineProvider _textLineProvider;

        public override void InstallBindings()
        {
            Container.Bind<DialogueRunner>().FromComponentOn(_dialogueRunner.gameObject).AsSingle();
            _textLineProvider.textLanguageCode = LocalizationSettings.SelectedLocale.Identifier.Code;
        }
    }
}
