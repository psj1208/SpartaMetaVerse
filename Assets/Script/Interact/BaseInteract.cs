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
        Debug.Log("��ȣ�ۿ�!");
        //UIManager.instance.InteractMessage(true);
    }
    //�ּ� ó�� �� ���� ��ȣ�ۿ� ������ Npc���� �Ҵ����� �� ����ϴ� ���Դϴ�. �Ӹ� ���� E ǥ�� �߰� �س��µ�. ���� �ͼ� ���� �� �� �ٲٴٺ��� ��Ծ����ϴ�.
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
