using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : BaseInteract
{
    //상호작용 가능하 물체 전용 스크립트
    [SerializeField] private int objectCode;
    public int ObjectCode { get { return objectCode; } }

    public override void Interact()
    {
        UIManager.instance.Action(this.gameObject);
    }
}
