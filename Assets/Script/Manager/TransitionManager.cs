using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    //씬 이동 시에 포지션을 저장합니다. 씬 이동시에 파괴되지 않고 중복 생성을 막기 위해 코드를 추가했습니다..
    public static TransitionManager Instance;
    private bool isHome = true;
    public bool IsHome { get { return isHome; } }
    [SerializeField] private Vector2 lastCharacterPos = Vector2.zero;
    public Vector2 LastCharacterPos { get { return lastCharacterPos; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SceneTrans(string name)
    {
        if (name.Equals("MainScene"))
        {
            isHome = true;
        }
        else
        {
            isHome = false;
            lastCharacterPos = GameManager.Instance.Player.transform.position;
        }
        SceneManager.LoadScene(name);
    }
}
