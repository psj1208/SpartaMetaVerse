using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : BaseInteract
{
    //��ȣ�ۿ� ������ ��ü ���� ��ũ��Ʈ
    [SerializeField] private int objectCode;
    public int ObjectCode { get { return objectCode; } }

    public override void Interact()
    {
        UIManager.instance.Action(this.gameObject);
    }
}
