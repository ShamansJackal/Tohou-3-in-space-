using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace Assets.Scripts.DialogSystem
{
    public class CharacterAvatar : MonoBehaviour
    {
        [SerializeField]
        private SpriteDatabase _spriteDatabase;

        [SerializeField]
        private Image _spriteRenderer;

        [YarnCommand("set_sprite")]
        public void SetSprite(string spriteName)
        {
            _spriteRenderer.sprite = _spriteDatabase.Sprites[spriteName];
        }
    }
}