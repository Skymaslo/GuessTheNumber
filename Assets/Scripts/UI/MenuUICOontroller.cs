using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    


public class MenuUICOontroller : MonoBehaviour
{
    public GameObject mainBackGround;
    public GameObject playerNameBackGround;
    public Text PlayerName;
    public InputField nickInput;
    public RecordDataBase recordDB;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentPlayer"))
        {
            mainBackGround.SetActive(true);
            RenderNick();
        }
        else
        {
            playerNameBackGround.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterNick()
    {
        string nick = nickInput.text;
        //PlayerPrefs.SetString("CurrentPlayer", nick);
        recordDB.SetCurrentPlayer(nick);

        playerNameBackGround.SetActive(false );
        mainBackGround.SetActive(true);
        RenderNick();
    }

    public void RenderNick()
    {
        string PlayerNick = PlayerPrefs.GetString("CurrentPlayer");

        PlayerName.text = $"Превет {PlayerNick}";
    }

}
