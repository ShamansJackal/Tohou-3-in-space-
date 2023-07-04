using Assets.Scripts.WeaponSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Trigger
{
    public abstract class TriggerPull : MonoBehaviour, ITrigger
    {
        public abstract void Press();

        public abstract void Release();
    }
}
