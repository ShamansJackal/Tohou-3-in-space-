using Assets.Scripts.Character.Health;
using Assets.Scripts.CharacterSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _segment;

    private List<Image> _segments = new List<Image>();

    [Inject]
    private void Init(PlayerCharacter player)
    {
        player.GetComponentInChildren<Health>().OnHealthChange.AddListener(SetAmount);
    }

    public void SetAmount(int currentHealth, int maxHealth, bool damage)
    {
        if (_segments.Count != maxHealth) InitSegments(maxHealth);

        for (int i = 0; i < _segments.Count; i++)
        {
            if(i<currentHealth)
                _segments[i].color = Color.red;
            else
                _segments[i].color = Color.black;
        }
    }

    private void InitSegments(int size)
    {
        while (_segments.Count < size)
        {
            var newSegment = Instantiate(_segment, transform);
            _segments.Add(newSegment);
        }

        while (_segments.Count > size)
        {
            Destroy(_segments[^1]);
            _segments.RemoveAt(_segments.Count-1);
        }
    }
}
