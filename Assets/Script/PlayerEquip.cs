using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    [SerializeField] private GameObject accessory;
    [SerializeField] private GameObject vehicle;
    public Sprite Accessory { set{ accessory.GetComponent<SpriteRenderer>().sprite = value; } }

    public void Start()
    {
        accessory = GameObject.Find("Head").transform.Find("Ac").gameObject;
    }

    public void flipAcc(bool isLeft)
    {
        accessory.GetComponent<SpriteRenderer>().flipX = isLeft;
    }
}
