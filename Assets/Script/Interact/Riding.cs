using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riding : BaseInteract
{
    // 탑승물의 상태를 건내주기 위함.
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
