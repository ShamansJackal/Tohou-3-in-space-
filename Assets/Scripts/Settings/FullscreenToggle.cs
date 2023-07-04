using Assets.Scripts.Settings;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public const string FULLSCREEN_KEY = "Fullscreen";

    [SerializeField]
    private Toggle _toggle;

    public void SetFullscreen(bool value)
    {
        Screen.fullScreen = value;
        SettingsStorage.Fullscreen = value;
    }

    private void Awake()
    {
        _toggle.SetIsOnWithoutNotify(SettingsStorage.Fullscreen);
        _toggle.onValueChanged.AddListener(SetFullscreen);
    }
}
