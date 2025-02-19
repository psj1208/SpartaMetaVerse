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
    public TalkingType type;
    public string[] talk;
    public (string select, int selectid)[] selectTalk;

    public Talking(int id_, TalkingType type,string[] talk_, (string sel_, int selectid_)[] select_ = null)
    {
        id = id_;
        this.type = type;
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
        instance = this;
        talkData = new List<Talking>();
        GenerateData();
    }
    
    void GenerateData()
    {
        talkData.Add(new Talking(
            1000,
            TalkingType.Select,
            new string[] { "�ݰ����ϴ�.", "����� ���ĸ�Ÿ �����Դϴ�.", "�ݰ�����." },
            new (string, int)[]
            {
                ("�ݰ����ϴ�.", 1001),
                ("�ݰ��� �ʽ��ϴ�.", 1002)
            }
            ));
        talkData.Add(new Talking(
            1001,
            TalkingType.Talk,
            new string[] {"���ǰ� �ٸ��ñ���."}
            ));
        talkData.Add(new Talking(
            1002,
            TalkingType.Talk,
            new string[] { "���ǰ� �����ñ���." }
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
