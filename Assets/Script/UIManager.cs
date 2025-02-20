using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("패널 등록")]
    [SerializeField] private GameObject talkPanel;
    [SerializeField] private GameObject AcPanel;
    [SerializeField] private GameObject headTextPanel;
    [SerializeField] private GameObject LeaderBoardPanel;
    [Header("그 외")]
    [SerializeField] private Text text;
    [SerializeField] private GameObject selectPrefab;
    [SerializeField] private GameObject selectLayer;

    private bool isAction = false;
    public bool IsAction { get { return isAction; } }
    [SerializeField] public int talkIndex;

    private bool isSelecting = false;
    public bool IsSelecting { get { return isSelecting; } }

    [SerializeField] int id_ = 0;
    public int Id { get { return id_; } set { id_ = Id; } }

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        talkPanel.SetActive(false);
        headTextPanel.SetActive(false);
        AcPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region 대화 제외 패널 조작 관련
    public void ChangeAcPanelState(bool state)
    {
        AcPanel.SetActive(state);
        if (state)
        {
            isSelecting = true;
            ClearTextPanel();
        }
        else
        {
            isSelecting = false;
        }
    }

    public void ChangeLeaderBoardState(bool state)
    {
        LeaderBoardPanel.SetActive(state);
        if (state)
        {
            LeaderBoardPanel.GetComponentInChildren<LeaderBoard>().Init();
            isSelecting = true;
            ClearTextPanel();
        }
        else
        {
            isSelecting = false;
        }
    }
    #endregion
    #region 대화 관련
    /// <summary>
    /// 대화창 열기
    /// </summary>
    public void Action(GameObject input)
    {
        BaseInteract inter = input.GetComponent<BaseInteract>();
        if (id_ == 0)
            id_ = inter.Id;
        if (inter != null)
        {
            Talk(id_, inter.IsNpc, inter);
            talkPanel.SetActive(isAction);
        }
        else
        { 
            return; 
        }
    }

    /// <summary>
    /// Action에서 연계되는 메서드
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isNpc"></param>
    void Talk(int id, bool isNpc, BaseInteract input)
    {
        Talking? talkData = TalkManager.instance.GetTalk(id);

        if (talkIndex == talkData.Value.talk.Length)
        {
            isAction = false;
            id_ = 0;
            talkIndex = 0;
            return;
        }
        if(isNpc)
        {
            text.text = talkData.Value.talk[talkIndex];
        }
        else
        {
            text.text = talkData.Value.talk[talkIndex];
        }
        isAction = true;
        talkIndex++;
        if (talkIndex == talkData.Value.talk.Length && talkData.Value.selectTalk != null) 
        {
            isSelecting = true;
            foreach (var select in talkData.Value.selectTalk)
            {
                if (select.type == TalkingType.Talk)
                {
                    Debug.Log(select.selectid);
                    input.Id = select.selectid;
                    isSelecting = false;
                    break;
                }
                else
                {
                    GameObject obj = Instantiate(selectPrefab, selectLayer.transform);
                    Button but = obj.GetComponent<Button>();
                    TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();

                    text.text = select.select;

                    switch (select.type)
                    {
                        case TalkingType.Select:
                            but.onClick.AddListener(() =>
                            {
                                id_ = select.selectid;
                                talkIndex = 0;
                                ClearButton();
                                isSelecting = false;
                                Talk(id_, isNpc, input);
                            });
                            break;
                        case TalkingType.Action:
                            but.onClick.AddListener(() =>
                            {
                                id_ = select.selectid;
                                talkIndex = 0;
                                ClearButton();
                                isSelecting = false;
                                Action action = ActionManager.instance.GetActionList(id_);
                                if (action != null)
                                {
                                    action.Invoke();
                                }
                                else
                                {
                                    Debug.LogError($"ActionManager에서 ID {id_}에 대한 액션을 찾을 수 없습니다!");
                                }
                            });
                            break;
                        case TalkingType.Quest:
                            break;
                        default:
                            ClearButton();
                            isSelecting = false;
                            break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 플레이어 머리 위에 상호작용 가능 띄우기.
    /// </summary>
    /// <param name="inter_mess"></param>
    public void InteractMessage(bool inter_mess)
    {
        bool isBool = (isAction == false) && (inter_mess == true) ? true : false;
        headTextPanel.SetActive(isBool);
    }

    public void ClearButton()
    {
        foreach(Transform obj in selectLayer.transform)
        {
            Destroy(obj.gameObject);
        }
    }
    
    public void ClearTextPanel()
    {
        id_ = 0;
        isSelecting = false;
        isAction = false;
        talkPanel.SetActive(false);
    }
    #endregion
}
