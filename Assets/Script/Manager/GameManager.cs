using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //플레이어 참고용 게임매니저, TransitionManager에서 이동했을 때의 포지션을 가져와서 플레이어를 강제 이동시킵니다.
    public static GameManager Instance;
    [SerializeField] private GameObject player;
    public GameObject Player { get { return player; } }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = TransitionManager.Instance.LastCharacterPos;
    }
}
