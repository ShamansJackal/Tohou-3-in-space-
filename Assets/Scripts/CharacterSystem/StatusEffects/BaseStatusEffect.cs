using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using Assets.Scripts.CharacterSystem.StatusEffects.EffectsData;

namespace Assets.Scripts.CharacterSystem.StatusEffects
{
    public abstract class BaseStatusEffect<TData> : MonoBehaviour where TData: DurationData
    {
        [NonSerialized]
        public Character Character;

        public abstract bool Dispel { get; }

        public abstract bool Stackable { get; }

        public void StartEffect(Character character, TData data)
        {
            if (!Stackable)
            {
                var buff = character.gameObject.GetComponentInChildren(GetType());
                if (buff != null)
                {
                    Destroy(buff.gameObject);
                }
            }

            var a = Instantiate(this, character.gameObject.transform);
            a.Character = character;
            a.StartEffect(data);
        }

        protected abstract void StartEffect(TData data);

        protected abstract void EndEffect();
    }
}
