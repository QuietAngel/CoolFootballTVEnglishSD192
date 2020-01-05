using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Button btnHome;
    public Button btnRes;
    public Button btnPlay;
    public GameObject shengliBg;
    public GameObject shengli;
    public GameObject shibai;
    public GameObject scene;
    public Text coinAdd;
    public GameObject bg;

    private void OnEnable()
    {
      //  LeanTween.rotateZ(bg,361,1f).setLoopType(LeanTweenType.linear);
    }

    private void Update()
    {
        bg.transform.Rotate(new Vector3(0,0,360)*100000,Space.Self);
    }
    private void Start()
    {
        btnHome.onClick.AddListener(HomeClick);
        btnRes.onClick.AddListener(ResClick);
        btnPlay.onClick.AddListener(PlayClick);
    }

    void HomeClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        UIManager._instance.audioManager.PlayBG(Random.Range(0, 2));
        GameController._instance.ShowOrHideGame(false);
        UIManager._instance.ShowOrHideStart(true);
        UIManager._instance.ShowOrHideGame(false);
        UIManager._instance.ShowOrHideGameOver(false);
        UIManager._instance.uiStep = UIManager.UIStep.start;
        GameController._instance.player.transform.localPosition = new Vector3(GameController._instance.player.transform.localPosition.x, GameController._instance.player.transform.localPosition.y, 5);
        GameController._instance.npc.transform.localPosition = new Vector3(GameController._instance.npc.transform.localPosition.x, GameController._instance.npc.transform.localPosition.y, 5); GameController._instance.ball.SetActive(true);
    }
    void ResClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        UIManager._instance.audioManager.PlayBG(Random.Range(2, 4));
      
        grade.redgrade = 0;
        text.bluegrade = 0;
        UIManager._instance.ShowOrHideGameOver(false);
        UIManager._instance.uiStep = UIManager.UIStep.game; 
        // GameController._instance.player.transform.localPosition = new Vector3(GameController._instance.player.transform.localPosition.x, GameController._instance.player.transform.localPosition.y, 5);
        // GameController._instance.npc.transform.localPosition = new Vector3(GameController._instance.npc.transform.localPosition.x, GameController._instance.npc.transform.localPosition.y, 5);
        GameController._instance.changeGameManager.Init();
        GameController._instance.ResetPos();
        GameController._instance.Ball.transform.localPosition = Vector2.zero;
        GameController._instance.ball.SetActive(true);
        GameController._instance.Ball.GetComponent<ball>().DesAndCreat();
        GameController._instance.ShowHideTouch(true);
    }
    void PlayClick()
    {
        //进入选关界面
        UIManager._instance.audioManager.PlayOne(6);
        UIManager._instance.audioManager.PlayBG(Random.Range(0, 2));
        GameController._instance.ShowOrHideGame(false);
        UIManager._instance.ShowOrHideSelectLevel(true);
        UIManager._instance.ShowOrHideGame(false);
        UIManager._instance.ShowOrHideGameOver(false);
        UIManager._instance.uiStep = UIManager.UIStep.selectLevel;
        GameController._instance.player.transform.localPosition = new Vector3(GameController._instance.player.transform.localPosition.x, GameController._instance.player.transform.localPosition.y, 5);
        GameController._instance.npc.transform.localPosition = new Vector3(GameController._instance.npc.transform.localPosition.x, GameController._instance.npc.transform.localPosition.y, 5); GameController._instance.ball.SetActive(true);


        GameController._instance.hand.GetComponent<UISelect>().ShowGameToSelectLV();
    }
    int coinAddNum = 0;
    public void ShowShengli()
    {
        UIManager._instance.audioManager.PlayOne(2);
        shengliBg.SetActive(true);
        shengli.SetActive(true);
        shibai.SetActive(false);
        if (GameController._instance.NowPlayLevel == UIManager._instance.LevelData)
        {
            UIManager._instance.LevelData += 1;
        }
        coinAddNum = (grade.redgrade - text.bluegrade) * 100;
        UIManager._instance.CoinNum += coinAddNum;
        coinAdd.text = "+"+ coinAddNum;
    }

    public void ShowShiBai()
    {
        UIManager._instance.audioManager.PlayOne(3);
        shengliBg.SetActive(false );
        shengli.SetActive(false );
        shibai.SetActive(true);
    }
}
