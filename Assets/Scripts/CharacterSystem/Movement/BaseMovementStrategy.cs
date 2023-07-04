using UnityEngine;

namespace Assets.Scripts.CharacterSystem.Movement
{
    public abstract class BaseMovementStrategy : MonoBehaviour
    {
        public float speed = 10;

        public abstract void Move(Vector2 deltaV);

        public abstract void Rotate(float deltaAng);
    }
}