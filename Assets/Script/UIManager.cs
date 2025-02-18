using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject talkPanel;
    [SerializeField] private Text text;

    private bool isAction = false;
    public bool IsAction { get { return isAction; } }
    public int talkIndex;

    public TalkManager talkM;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        talkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 대화창 열기
    /// </summary>
    public void Action(GameObject input)
    {
        BaseInteract inter = input.GetComponent<BaseInteract>();
        Talk(inter.Id, inter.IsNpc);
        talkPanel.SetActive(isAction);
    }

    void Talk(int id,bool isNpc)
    {
        string talkData = TalkManager.instance.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if(isNpc)
        {
            text.text = talkData;
        }
        else
        {
            text.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }
}
