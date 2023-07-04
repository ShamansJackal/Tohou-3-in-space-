using Assets.Scripts.CharacterSystem.Movement;
using Assets.Scripts.CharacterSystem.StatusEffects.EffectsData;
using UnityEngine;

namespace Assets.Scripts.CharacterSystem.StatusEffects
{
    public class PushBackEffect : BaseStatusEffect<DirectionData>
    {
        [SerializeField]
        private float _speed = 10f;

        public override bool Dispel => true;

        public override bool Stackable => false;

        private float _prevSpeed;
        private BaseMovementStrategy _movementStrategy;
        private Vector2 _direction;

        protected override void EndEffect()
        {
            _movementStrategy.speed = _prevSpeed; 
        }

        protected override void StartEffect(DirectionData data)
        {
            _movementStrategy = Character.GetComponent<BaseMovementStrategy>();
            _prevSpeed = _movementStrategy.speed;
            _movementStrategy.speed = 0;
            _direction = data.Direction;

            Destroy(gameObject, data.Duration);
        }

        private void OnDestroy()
        {
            EndEffect();
        }

        private void Update()
        {
            Vector2 newPosition = (Vector2)Character.transform.position + _speed * Time.deltaTime * _direction;
            newPosition.x = Mathf.Clamp(newPosition.x, -6, 6);
            newPosition.y = Mathf.Clamp(newPosition.y, -4, 4);

            Character.transform.position = newPosition;
        }
    }
}
