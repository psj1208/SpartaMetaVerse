using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NpcInteract : BaseInteract
{
    [SerializeField] private int npcCode = 0;
    public int NpcCode { get { return npcCode; } }
    protected override void Interact()
    {
        UIManager.instance.Action(this.gameObject);
    }
}
