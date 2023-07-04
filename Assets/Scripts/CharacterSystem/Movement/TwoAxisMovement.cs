using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CharacterSystem.Movement
{
    public class TwoAxisMovement : BaseMovementStrategy
    {
        public override void Move(Vector2 deltaV)
        {
            Vector2 newPosition = (Vector2)transform.position + deltaV * speed;
            newPosition.x = Mathf.Clamp(newPosition.x, -6, 6);
            newPosition.y = Mathf.Clamp(newPosition.y, -4, 4);

            transform.position = newPosition;
        }

        public override void Rotate(float deltaAng)
        {

        }
    }
}