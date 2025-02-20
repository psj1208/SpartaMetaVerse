using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryPanel : MonoBehaviour
{
    // Start is called before the first frame update.
    [SerializeField] private GameObject[] gameObjects;
    private PlayerController player;
    void Start()
    {
        player = GameManager.Instance.Player.GetComponent<PlayerController>();
        gameObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObjects[i] = transform.GetChild(i).gameObject;
        }
        InsertButton();
    }

    void InsertButton()
    {
        foreach(GameObject obj in gameObjects)
        {
            Button but = obj.GetComponent<Button>();
            but.onClick.AddListener(() => player.ChangeAccessory(obj.transform.Find("Sprite").GetComponent<Image>().sprite));
        }
    }
}
