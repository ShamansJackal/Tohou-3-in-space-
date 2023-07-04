using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

namespace Assets.Scripts.Settings
{
    public class SettingsInstaller : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer _mixer;

        [SerializeField]
        private string[] _channels;

        private IEnumerator Start()
        {
            foreach (var channel in _channels)
            {
                _mixer.SetFloat(
                    channel,
                    SettingsStorage.ConvertToMixerValue(SettingsStorage.GetVolume(channel))
                );
            }
            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales
                .GetLocale(new UnityEngine.Localization.LocaleIdentifier(SettingsStorage.Language));
        }
    }
}
