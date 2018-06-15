using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{

    public Text money;
    public Text id;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        money.text = GameManager.Instance.PlayerMoneyCount;
        id.text = GameManager.Instance.PlayerName;

    }
}
