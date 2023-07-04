using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Assets.Scripts.Settings
{
    public static class SettingsStorage
    {
        private const string WIDTH_KEY = "Width";
        private const string HEIGHT_KEY = "Height";
        private const string FULLSCREEN_KEY = "Fullscreen";
        private const string LANGUEGE_KEY = "Lang";

        public static int Width
        {
            get
            {
                if (!PlayerPrefs.HasKey(WIDTH_KEY))
                    Width = Screen.width;
                return PlayerPrefs.GetInt(WIDTH_KEY);
            }
            set
            {
                PlayerPrefs.SetInt(WIDTH_KEY, value);
            }
        }

        public static int Height
        {
            get
            {
                if (!PlayerPrefs.HasKey(HEIGHT_KEY))
                    Height = Screen.height;
                return PlayerPrefs.GetInt(HEIGHT_KEY);
            }
            set
            {
                PlayerPrefs.SetInt(HEIGHT_KEY, value);
            }
        }

        public static bool Fullscreen
        {
            get
            {
                if (!PlayerPrefs.HasKey(FULLSCREEN_KEY))
                    Fullscreen = Screen.fullScreen;
                return PlayerPrefs.GetInt(FULLSCREEN_KEY) != 0;
            }
            set
            {
                PlayerPrefs.SetInt(FULLSCREEN_KEY, value ? 1 : 0);
            }
        }

        public static string Language
        {
            get
            {
                if (!PlayerPrefs.HasKey(LANGUEGE_KEY))
                    Language = LocalizationSettings.SelectedLocale.Identifier.Code;
                return PlayerPrefs.GetString(LANGUEGE_KEY);
            }
            set
            {
                PlayerPrefs.SetString(LANGUEGE_KEY, value);
            }
        }

        public static void SetVolume(string chanelName, byte value)
        {
            PlayerPrefs.SetInt(chanelName, value);
        }

        public static byte GetVolume(string chanelName)
        {
            if (!PlayerPrefs.HasKey(chanelName))
                SetVolume(chanelName, 100);
            return (byte)PlayerPrefs.GetInt(chanelName);
        }

        public static float ConvertToMixerValue(byte value) => value * 0.8f - 80f;
        public static float ConvertToMixerValue(float value) => value * 0.8f - 80f;
    }
}
