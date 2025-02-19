using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject talkPanel;
    [SerializeField] private Text text;
    [SerializeField] private GameObject headTextPanel;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ��ȭâ ����
    /// </summary>
    public void Action(GameObject input)
    {
        BaseInteract inter = input.GetComponent<BaseInteract>();
        if (id_ == 0)
            id_ = inter.Id;
        Talk(id_, inter.IsNpc);
        talkPanel.SetActive(isAction);
    }

    void Talk(int id,bool isNpc)
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
        if (talkIndex == talkData.Value.talk.Length) 
        {
            if (talkData.Value.type == TalkingType.Select && talkData.Value.selectTalk != null)
            {
                isSelecting = true;
                foreach (var select in talkData.Value.selectTalk)
                {
                    GameObject obj = Instantiate(selectPrefab, selectLayer.transform);
                    Button but = obj.GetComponent<Button>();
                    TextMeshProUGUI text = obj.GetComponentInChildren<TextMeshProUGUI>();

                    text.text = select.select;

                    but.onClick.AddListener(() =>
                    {
                        id_ = select.selectid;
                        talkIndex = 0;
                        ClearButton();
                        isSelecting = false;
                        Talk(id_, isNpc);
                    });
                }
            }
        }
    }


    /// <summary>
    /// �÷��̾� �Ӹ� ���� ��ȣ�ۿ� ���� ����.
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
}
