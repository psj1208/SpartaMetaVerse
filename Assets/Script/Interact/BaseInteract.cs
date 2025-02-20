using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class BaseInteract : MonoBehaviour
{
    [SerializeField] private int id;
    public int Id {  get { return id; } set { id = value; } }
    [SerializeField] private bool isNpc;
    public bool IsNpc { get { return isNpc; } }

    private bool CanInter = false;

    public void ChangeId(int input)
    {
        id = input;
    }
    protected virtual void Start()
    {

    }

    protected virtual void CanInteract(bool input)
    {
        CanInter = input;
    }
    public virtual void Interact()
    {
        Debug.Log("상호작용!");
        //UIManager.instance.InteractMessage(true);
    }
    //주석 처리 된 것은 상호작용 범위를 Npc한테 할당했을 때 사용하던 것입니다. 머리 위에 E 표시 뜨게 해놨는데. 막판 와서 맘에 안 들어서 바꾸다보니 까먹었습니다.
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            CanInteract(true);
            UIManager.instance.InteractMessage(CanInter);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(CanInter == false && collision.tag.Equals("Player"))
        {
            CanInter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            CanInteract(false);
            UIManager.instance.InteractMessage(CanInter);
        }
    }
    */
}
