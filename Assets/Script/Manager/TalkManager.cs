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
//Npc와 상호작용해서 대화로 가기 위해 식별용 id, 대화 정보를 담은 talk,그리고 선택지 혹은 행동이 되도록 TalkingType을 포함한 변수형을 선언
//어렵네요. JSON변환같은 것을 사용해서 기획자가 편하게 바꾸게 할려면 구조를 좀 바꿔야겟네요.
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
    //TalkManager를 위한 구조체.(대화 id,대화문,선택지(선택지 갯수와 해당하는 작동 함수 포함)
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
            new string[] { "반갑습니다.", "여기는 스파르타 공간입니다.", "반가워요." },
            new (string, int, TalkingType)[]
            {
                ("반갑습니다.", 1001, TalkingType.Select),
                ("반갑지 않습니다.", 1002, TalkingType.Select)
            }
            ));
        talkData.Add(new Talking(
            1001,
            new string[] { "예의가 바르시군요." },
            new (string, int, TalkingType)[]
            {
                ("",1005,TalkingType.Talk)
            }
            ));
        talkData.Add(new Talking(
            1002,
            new string[] { "예의가 없으시군요." },
            new (string, int, TalkingType)[]
            {
                ("싸우자!", 1000,TalkingType.Action)
            }
            ));
        talkData.Add(new Talking(
            1005,
            new string[] { "마음 껏 둘러보시기 바랍니다." }
            ));
        talkData.Add(new Talking(
            1050,
            new string[] { "액세서리를 변경하시겠어요?" },
            new (string, int, TalkingType)[]
            {
                ("변경하겠습니다.", 1002,TalkingType.Action),
                ("아직입니다.", 5002,TalkingType.Select)
            }
            ));
        talkData.Add(new Talking(
            5000,
            new string[] {"Stack에 입장하시겠습니까?"},
            new (string, int, TalkingType)[]
            {
                ("입장하겠습니다.", 1001,TalkingType.Action),
                ("아직입니다.", 5002,TalkingType.Select)
            }
            ));
        talkData.Add(new Talking(
            5002,
            new string[] { "알겠습니다." }
            ));
        talkData.Add(new Talking(
            5050,
            new string[] { "리더보드를 확인하시겠습니까?" },
            new (string, int, TalkingType)[]
            {
                ("확인하겠습니다.", 1003,TalkingType.Action),
                ("아직입니다.", 5002,TalkingType.Select)
            }
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
