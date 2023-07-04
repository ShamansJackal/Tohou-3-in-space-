using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class AimDecorator : DecoratorNode
{
    protected override void OnStart() {
        context.commandsFollower.Weapon.Aim.SetShootPositionAndDirection(context.transform.position, context.transform.up);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (child == null)
        {
            return State.Failure;
        }

        var state = child.Update();
        context.commandsFollower.Weapon.Aim.SetShootPositionAndDirection(context.transform.position, context.transform.up);
        return state;
    }
}
