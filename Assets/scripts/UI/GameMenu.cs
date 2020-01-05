using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
    public Button btn_Home;
    public Text time;
    public GameObject panelStop;
    public Image playerName;
    public Image npcName;

   
    private void OnEnable()
    {
        playerName.sprite = UIManager._instance.allName[GameController._instance.NowUsePlayerID];
        playerName.SetNativeSize();
        // npcName.sprite = UIManager._instance.allName[GameController._instance.GetNpcUse[GameController._instance.NowPlayLevel]];
        // npcName.SetNativeSize();

        GameController._instance.isStop = false ;
        time.text = "59";
    }
    void Start()
    {
        btn_Home.onClick.AddListener(HomeClick);

    }
    private void Update()
    { 
        if (GameController._instance.ShowTime < 10)
        {
            time.text ="0"+ GameController._instance.ShowTime.ToString();
        }
        else if(GameController._instance.ShowTime == 60)
        {
            time.text = "59";
        }
        else
        {
            time.text = GameController._instance.ShowTime.ToString();
        }

        if (UIManager._instance.uiStep == UIManager.UIStep.game)
        {
            if(GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled == true)
               GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled = false;
        }
        else
        {
            if (GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled == false)
                GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled = true;
        }


    }
    void HomeClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        GameController._instance.isstart = false;
        UIManager._instance.ShowOrHideGameStop(true);
        UIManager._instance.uiStep = UIManager.UIStep.gameStop;
          GameController._instance.player.transform.localPosition = new Vector3(GameController._instance.player.transform.localPosition.x, GameController._instance.player.transform.localPosition.y,5);
           GameController._instance.npc.transform.localPosition = new Vector3(GameController._instance.npc.transform.localPosition.x, GameController._instance.npc.transform.localPosition.y, 5);

        GameController._instance.vel = GameController._instance.Ball.GetComponent<Rigidbody2D>().velocity;
         GameController._instance.ball.SetActive(false);
        GameController._instance.isStop = true;

        GameController._instance.ShowHideTouch(false);
    }
}
