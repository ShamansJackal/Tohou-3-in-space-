using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Database", menuName = "DialogSystem/Database")]
public class SpriteDatabase : ScriptableObject
{
    [Serializable]
    public struct SpriteInfo : IHasId<string>
    {
        public string name;
        public Sprite sprite;

        public string Id => name;
    }

    [SerializeField]
    private List<SpriteInfo> _sprites;

    private Dictionary<string, Sprite> _cache;

    public IReadOnlyDictionary<string, Sprite> Sprites => _cache ??= BuildDictionary();

    private Dictionary<string, Sprite> BuildDictionary()
    {
        var temp = new Dictionary<string, Sprite>();
        foreach (var spriteInfo in _sprites)
        {
            if (temp.ContainsKey(spriteInfo.name)) throw new Exception($"Enemy with id {spriteInfo.name} all ready exists");
            temp[spriteInfo.name] = spriteInfo.sprite;
        }
        return temp;
    }
}
