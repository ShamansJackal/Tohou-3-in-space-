using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Settings
{
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField]
        private string _chanel;

        [SerializeField]
        private AudioMixer _mixer;

        [SerializeField]
        private Slider _slider;

        public void SetVolume(float value)
        {
            _mixer.SetFloat(_chanel, SettingsStorage.ConvertToMixerValue(value));
            SettingsStorage.SetVolume(_chanel, Convert.ToByte(value));
        }

        private void Awake()
        {
            _slider.maxValue = 100;
            _slider.minValue = 0;
            _slider.wholeNumbers = true;

            _slider.SetValueWithoutNotify(SettingsStorage.GetVolume(_chanel));
            _slider.onValueChanged.AddListener(SetVolume);
        }
    }
}
