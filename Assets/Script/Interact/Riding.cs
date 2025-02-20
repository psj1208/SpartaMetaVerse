using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riding : BaseInteract
{
    [SerializeField] private StatHandler stat;
    [SerializeField] private AnimationHandler anim;

    public void Start()
    {
        stat = GetComponent<StatHandler>();
        anim = GetComponent<AnimationHandler>();
    }
    public override void Interact()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().Ride(stat, anim);
    }
}
