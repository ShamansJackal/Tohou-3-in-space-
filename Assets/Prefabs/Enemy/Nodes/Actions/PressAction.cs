using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class PressAction : ActionNode
{
    protected override void OnStart()
    {
        context.commandsFollower.Weapon.MainFire.Press();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
