using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance;
    Dictionary<int, string[]> talkData;
    private void Awake()
    {
        instance = this;
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ݰ����ϴ�.", "����� ���ĸ�Ÿ �����Դϴ�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
