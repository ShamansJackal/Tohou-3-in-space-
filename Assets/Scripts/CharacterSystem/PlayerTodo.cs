using Assets.Scripts.CharacterSystem.StatusEffects;
using Assets.Scripts.CharacterSystem.StatusEffects.EffectsData;
using UnityEngine;

namespace Assets.Scripts.CharacterSystem
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerTodo : MonoBehaviour
    {
        [SerializeField]
        private InvincibilityEffect _invincibilityEffect;

        [SerializeField]
        private PlayerCharacter _playerCharacter;

        [SerializeField]
        private PushBackEffect _pushBackEffect;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & LayerMask.GetMask("Enemy")) > 0)
            {
                var direction = (gameObject.transform.position - collision.transform.position).normalized;
                _playerCharacter.health.TakeDamage(1);
                _pushBackEffect.StartEffect(_playerCharacter, new DirectionData() { Duration = 1f, Direction = direction });
            }
        }

        public void GiveInvincibility(int health, int maxHealth, bool lossHealth)
        {
            if(lossHealth)
                _invincibilityEffect.StartEffect(_playerCharacter, new DurationData() { Duration = 1f });
        }
    }
}
