using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager instance;
    List<(int id, Action ac)> actionlist;

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
        actionlist = new List<(int id, Action)>();
        GenerateList();
    }

    void GenerateList()
    {
        actionlist.Add((1000, () => { TransitionManager.Instance.SceneTrans("MiniGame"); }));
        actionlist.Add((1001, () => { TransitionManager.Instance.SceneTrans("Stack"); }));
        actionlist.Add((1002, () => { UIManager.instance.ChangeAcPanelState(true); }));
        actionlist.Add((1003, () => { UIManager.instance.ChangeLeaderBoardState(true); }));
    }

    /// <summary>
    /// �׼Ǹ���Ʈ(��ȭ�� �ൿ������ �ۿ�)�� id�� �˻��ؼ� ����.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Action GetActionList(int id)
    {
        Debug.Log("Get!");
        foreach(var action in actionlist)
        {
            if (action.id == id)
            {
                Debug.Log("Find!");
                return action.ac;
            }
        }
        return null;
    }
}
