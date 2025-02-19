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
    //TalkManager를 위한 구조체.(대화 id,대화문,선택지(선택지 갯수와 해당하는 작동 함수 포함)
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
            new string[] { "반갑습니다.", "여기는 스파르타 공간입니다.", "반가워요." },
            new (string, int)[]
            {
                ("반갑습니다.", 1001),
                ("반갑지 않습니다.", 1002)
            }
            ));
        talkData.Add(new Talking(
            1001,
            TalkingType.Talk,
            new string[] {"예의가 바르시군요."}
            ));
        talkData.Add(new Talking(
            1002,
            TalkingType.Talk,
            new string[] { "예의가 없으시군요." }
            ));
    }
    

    /// <summary>
    /// Talking 정보 가져오기. ?선언 꼭 해야함.
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
