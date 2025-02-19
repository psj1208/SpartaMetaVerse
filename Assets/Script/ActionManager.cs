using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    List<(int id, Action)> actionlist;

    private void Awake()
    {
        actionlist = new List<(int id, Action)>();
        GenerateList();
    }

    void GenerateList()
    {
        actionlist.Add(() => { SceneManager.LoadScene("MiniGame"); });
    }
}
