using Assets.Scripts.Character.Health;
using Assets.Scripts.CharacterSystem.StatusEffects.EffectsData;
using UnityEngine;

namespace Assets.Scripts.CharacterSystem.StatusEffects
{
    public class InvincibilityEffect : BaseStatusEffect<DurationData>
    {
        [SerializeField]
        private Immortality _immortality;

        private BaseHealth _previuseHelth;

        public override bool Dispel => false;

        public override bool Stackable => false;

        protected override void EndEffect()
        {
            if(Character.gameObject != null)
            {
                Character.health = _previuseHelth;
            }
        }

        protected override void StartEffect(DurationData data)
        {
            _previuseHelth = Character.health;
            _immortality.baseHealth = _previuseHelth;
            Character.health = _immortality;

            Destroy(gameObject, data.Duration);
        }

        private void OnDestroy()
        {
            EndEffect();
        }
    }
}
