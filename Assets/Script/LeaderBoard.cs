using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Record;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stackScore;
    int stackSc;

    public void Init()
    {
        Debug.Log("�������� init!");
        stackSc = PlayerPrefs.GetInt(StackBest, 0);
        stackScore.text = stackSc.ToString();
    }
}
