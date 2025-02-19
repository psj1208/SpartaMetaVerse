using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackStart : BaseInteract
{
    protected override void Interact()
    {
        TransitionManager.Instance.SceneTrans("Stack");
    }
}
