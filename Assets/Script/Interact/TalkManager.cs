using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using static Record;

public enum TalkingType
{
    Talk,
    Select,
    Quest,
    Action
}
public struct Talking
{
    public int id;
    public string[] talk;
    public (string select, int selectid, TalkingType type)[] selectTalk;

    public Talking(int id_, string[] talk_, (string sel_, int selectid_, TalkingType type_)[] select_ = null)
    {
        id = id_;
        talk = talk_;
        selectTalk = select_;
    }
}

public class TalkManager : MonoBehaviour
{
    //TalkManager�� ���� ����ü.(��ȭ id,��ȭ��,������(������ ������ �ش��ϴ� �۵� �Լ� ����)
    public static TalkManager instance;
    List<Talking> talkData;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        talkData = new List<Talking>();
        GenerateData();
    }
    
    void GenerateData()
    {
        talkData.Add(new Talking(
            1000,
            new string[] { "�ݰ����ϴ�.", "����� ���ĸ�Ÿ �����Դϴ�.", "�ݰ�����." },
            new (string, int, TalkingType)[]
            {
                ("�ݰ����ϴ�.", 1001, TalkingType.Select),
                ("�ݰ��� �ʽ��ϴ�.", 1002, TalkingType.Select)
            }
            ));
        talkData.Add(new Talking(
            1001,
            new string[] { "���ǰ� �ٸ��ñ���." },
            new (string, int, TalkingType)[]
            {
                ("",1005,TalkingType.Talk)
            }
            ));
        talkData.Add(new Talking(
            1002,
            new string[] { "���ǰ� �����ñ���." },
            new (string, int, TalkingType)[]
            {
                ("�ο���!", 1000,TalkingType.Action)
            }
            ));
        talkData.Add(new Talking(
            1005,
            new string[] { "���� �� �ѷ����ñ� �ٶ��ϴ�." }
            ));
        talkData.Add(new Talking(
            5000,
            new string[] {"Stack�� �����Ͻðڽ��ϱ�?"},
            new (string, int, TalkingType)[]
            {
                ("�����ϰڽ��ϴ�.", 1001,TalkingType.Action),
                ("�����Դϴ�.", 5002,TalkingType.Select)
            }
            ));
        talkData.Add(new Talking(
            5002,
            new string[] { "�˰ڽ��ϴ�." }
            ));
    }
    

    /// <summary>
    /// Talking ���� ��������. ?���� �� �ؾ���.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Talking? GetTalk(int id)
    {
        foreach(Talking talk in talkData)
        {
            if(talk.id == id)
            {
                return talk;
            }
        }    
        return null;
    }
}
