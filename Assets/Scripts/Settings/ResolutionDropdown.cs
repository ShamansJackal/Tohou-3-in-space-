using Assets.Scripts.Settings;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResolutionDropdown : MonoBehaviour
{
    private List<Resolution> _resolutins;

    [SerializeField]
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown.ClearOptions();
        _resolutins = Screen.resolutions.ToList();

        _dropdown.AddOptions(_resolutins.Select(x => x.ToString()).ToList());
        var index = _resolutins.FindIndex(x => x.width == SettingsStorage.Width && x.height == SettingsStorage.Height);
        _dropdown.SetValueWithoutNotify(index > -1 ? index : 0);
        _dropdown.onValueChanged.AddListener(ChangeLocale);
    }

    public void ChangeLocale(int index)
    {
        var resolution = _resolutins[index];
        SettingsStorage.Width = resolution.width;
        SettingsStorage.Height = resolution.height;

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
