using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : BaseInteract
{
    [SerializeField] private int objectCode;
    public int ObjectCode { get { return objectCode; } }

    protected override void Interact()
    {
        UIManager.instance.Action(this.gameObject);
    }
}
