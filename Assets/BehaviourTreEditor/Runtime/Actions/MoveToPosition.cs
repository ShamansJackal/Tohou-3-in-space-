using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

namespace TheKiwiCoder {

    [System.Serializable]
    public class MoveToPosition : ActionNode {

        [Tooltip("How fast to move")]
        public NodeProperty<float> speed = new NodeProperty<float> { defaultValue = 5.0f };

        [Tooltip("Stop within this distance of the target")]
        public NodeProperty<float> stoppingDistance = new NodeProperty<float> { defaultValue = 0.1f };
        
        [Tooltip("Target Position")] 
        public NodeProperty<Vector2> targetPosition = new NodeProperty<Vector2> { defaultValue = Vector2.zero };

        [Tooltip("Move by delta vector")]
        public NodeProperty<bool> deltaPosition = new NodeProperty<bool> { defaultValue = false };

        protected override void OnStart() {
            if(deltaPosition.Value)
                context.commandsFollower.Move(targetPosition.Value+(Vector2)context.transform.position, speed.Value, stoppingDistance.Value);
            else
                context.commandsFollower.Move(targetPosition.Value, speed.Value, stoppingDistance.Value);
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (context.commandsFollower.MovingToTarget) {
                return State.Running;
            }

            return State.Success;
        }
    }
}
