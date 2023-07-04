using Assets.Scripts.Settings;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationDropdown : MonoBehaviour
{
    private List<Locale> _locales;

    [SerializeField]
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown.ClearOptions();
        _locales = LocalizationSettings.AvailableLocales.Locales;

        _dropdown.AddOptions(_locales.Select(x => x.LocaleName).ToList());
        _dropdown.SetValueWithoutNotify(_locales.FindIndex(x => x.Identifier.Code == SettingsStorage.Language));
        _dropdown.onValueChanged.AddListener(ChangeLocale);
    }

    public void ChangeLocale(int index)
    {
        var locale = _locales[index];
        LocalizationSettings.SelectedLocale = locale;
        SettingsStorage.Language = locale.Identifier.Code;
    }
}
