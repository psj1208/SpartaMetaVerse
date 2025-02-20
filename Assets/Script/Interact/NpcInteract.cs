using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NpcInteract : BaseInteract
{
    //npc용 스크립트.
    [SerializeField] private int npcCode = 0;
    public int NpcCode { get { return npcCode; } }
    public override void Interact()
    {
        UIManager.instance.Action(this.gameObject);
    }
}
