﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerMenu : MonoBehaviour {

    public Button btn_Home;
    public Button btn_Play;
    public Button btn_1;
    public Button btn_2;
    public Button btn_3;
    public Button btn_4;
    public Button btn_5;
    public Button btn_6;
    public Button btn_7;
    public Button btn_8;
    public Button btn_9;
    public Button btn_10;
    public Button btn_11;
    public Button btn_12;
    public Button btn_13;
    public Button btn_14;
    public Button btn_15;
    public Button btn_16;
    public Button btn_17;
    public Button btn_18;
    public Button btn_19;
    public Button btn_20;
    private Button[] btnPlayerAll;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;
    public GameObject player9;
    public GameObject player10;
    public GameObject player11;
    public GameObject player12;
    public GameObject player13;
    public GameObject player14;
    public GameObject player15;
    public GameObject player16;
    public GameObject player17;
    public GameObject player18;
    public GameObject player19;
    public GameObject player20;
    private GameObject[] playerAll;

    public Image playBtn;
    public Sprite playvideo;
    public Sprite play;
    public Transform kuang;
    public Transform playerFather;
    public Image guojia;
    public Sprite[] guojiaAll;
    private GameObject nowShowPlayer = null;
    public Text coinLabel;
    public GameObject jiage;
    public Image sudu;
    public Image liliang;
    public Text suduText;
    public Text liliangText;
    public GameObject tishi;
    private float tishiShowTime = 1f;
    private void OnEnable()
    {
        if (nowShowPlayer != null)
            Destroy(nowShowPlayer);
        GameObject go = Instantiate(player1, playerFather);
        nowShowPlayer = go;
        kuang.position = btn_1.transform.position;
        guojia.sprite = guojiaAll[0];
        guojia.SetNativeSize();
        sudu.fillAmount = 84f / 100f;
        suduText.text = "84";
        liliang.fillAmount =84f / 100f;
        liliangText.text = "84";
        playBtn.sprite = play;
        jiage.SetActive(false);

        tishi.transform.localScale = new Vector3(0,0,0); 
    }

    void Start()
    { 
        btn_Home.onClick.AddListener(HomeClick);
        btn_Play.onClick.AddListener(PlayClick);
        btn_1.onClick.AddListener(AClick);
        btn_2.onClick.AddListener(BClick);
        btn_3.onClick.AddListener(CClick);
        btn_4.onClick.AddListener(DClick);
        btn_5.onClick.AddListener(EClick);
        btn_6.onClick.AddListener(FClick);
        btn_7.onClick.AddListener(GClick);
        btn_8.onClick.AddListener(HClick);
        btn_9.onClick.AddListener(IClick);
        btn_10.onClick.AddListener(JClick);
        btn_11.onClick.AddListener(KClick);
        btn_12.onClick.AddListener(LClick);
        btn_13.onClick.AddListener(MClick);
        btn_14.onClick.AddListener(NClick);
        btn_15.onClick.AddListener(OClick);
        btn_16.onClick.AddListener(PClick);
        btn_17.onClick.AddListener(QClick);
        btn_18.onClick.AddListener(RClick);
        btn_19.onClick.AddListener(SClick);
        btn_20.onClick.AddListener(TClick);
        playerAll = new GameObject[] {player1, player2, player3, player4, player5, player6, player7, player8, player9, player10,
                                      player11,player12,player13,player14,player15,player16,player17,player18,player19,player20};
        btnPlayerAll = new Button[] { btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9, btn_10,
                                      btn_11,btn_12,btn_13,btn_14,btn_15,btn_16,btn_17,btn_18,btn_19,btn_20,};
        Init();
        InitData();
        InitValue();

        playBtn.sprite = play;
        jiage.SetActive(false);
    }

    void Update()
    {
        if (coinLabel.text != UIManager._instance.CoinNum.ToString())
        {
            coinLabel.text = UIManager._instance.CoinNum.ToString();
        }

    }
    IEnumerator ShowTishi()
    {
        LeanTween.scale(tishi, new Vector3(1, 1, 1), 0.5f);
        yield return new WaitForSeconds(tishiShowTime);
        LeanTween.scale(tishi, new Vector3(0, 0, 0), 0.5f);
    }

    void ChangePlayer(int id)
    {
        UIManager._instance.audioManager.PlayOne(6);
        GameObject go = Instantiate(playerAll[id], playerFather);
        Destroy(nowShowPlayer);
        nowShowPlayer = go;
        kuang.position = btnPlayerAll[id].transform.position;
        guojia.sprite = guojiaAll[id];
        guojia.SetNativeSize();
        GameController._instance.NowUsePlayerID = id;

        sudu.fillAmount = playerValue[id, 0] / 100f;
        suduText.text = playerValue[id, 0].ToString();
        liliang.fillAmount = playerValue[id, 1] / 100f;
        liliangText.text = playerValue[id, 1].ToString();

        if (GetPlayerData(id) == 1)
        {//有这个人物
            playBtn.sprite = play;
            jiage.SetActive(false);
        }
        else
        {//没有这个人物
            if (UIManager._instance.CoinNum >= 1000)
            {//金币够买人物
                playBtn.sprite = play;
                jiage.SetActive(true); 
            }
            else
            {//金币不够买
                if (GameController._instance.IsUseVideo == true)
                {//有广告
                    playBtn.sprite = playvideo;
                    jiage.SetActive(false);

                }
                else
                {
                    playBtn.sprite = play;
                    jiage.SetActive(true);
                }
            }
        }
    }

    void HomeClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        UIManager._instance.ShowOrHideSelectPlayer(false);
        UIManager._instance.ShowOrHideStart(true);
        UIManager._instance.uiStep = UIManager.UIStep.start;
        
    }
    void PlayClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        if (GetPlayerData(GameController._instance.NowUsePlayerID) == 1)
        {//有这个人物 直接开始
            GameStart();
            GameController._instance.hand.GetComponent<UISelect>().ShowBuy();
        }
        else
        {//没有这个人物
            if (UIManager._instance.CoinNum >= 1000)
            {//金币够买人物  减去金币 获得人物 开始游戏
                UIManager._instance.CoinNum -= 1000;
                 
                SetPlayerData(GameController._instance.NowUsePlayerID);
                GameStart();
                GameController._instance.hand.GetComponent<UISelect>().ShowBuy();
            }
            else
            {//金币不够买   播放广告
                if (GameController._instance.IsUseVideo == true)
                {//有广告


                    GameController._instance.hand.GetComponent<UISelect>().ShowBuy();
                }
                else
                {
                    StartCoroutine(ShowTishi());
                    GameController._instance.hand.GetComponent<UISelect>().ShowInNoCoin();
                }
            }
        }
    }
    //开始游戏
    void GameStart()
    {
        UIManager._instance.ShowOrHideSelectPlayer(false);
        UIManager._instance.ShowOrHideSelectLevel(true);
        UIManager._instance.uiStep = UIManager.UIStep.selectLevel;
    }

    void AClick()
    {
        ChangePlayer(0);
    }
    void BClick()
    {
        ChangePlayer(1);
    }
    void CClick()
    {
        ChangePlayer(2);
    }
    void DClick()
    {
        ChangePlayer(3);
    }
    void EClick()
    {
        ChangePlayer(4);
    }
    void FClick()
    {
        ChangePlayer(5);
    }
    void GClick()
    {
        ChangePlayer(6);
    }
    void HClick()
    {
        ChangePlayer(7);
    }
    void IClick()
    {
        ChangePlayer(8);
    }
    void JClick()
    {
        ChangePlayer(9);
    }
    void KClick()
    {
        ChangePlayer(10);
    }
    void LClick()
    {
        ChangePlayer(11);
    }
    void MClick()
    {
        ChangePlayer(12);
    }
    void NClick()
    {
        ChangePlayer(13);
    }
    void OClick()
    {
        ChangePlayer(14);
    }
    void PClick()
    {
        ChangePlayer(15);
    }
    void QClick()
    {
        ChangePlayer(16);
    }
    void RClick()
    {
        ChangePlayer(17);
    }
    void SClick()
    {
        ChangePlayer(18);
    }
    void TClick()
    {
        ChangePlayer(19);
    }

    string[] playerData;
    void Init()
    {
        playerData = new string[] { "playerData1", "playerData2", "playerData3", "playerData4", "playerData5",
        "playerData6","playerData7","playerData8","playerData9","playerData10",
        "playerData11","playerData12","playerData13","playerData14","playerData15",
        "playerData16","playerData17","playerData18","playerData19","playerData20",};
    } 
    void InitData()
    {
        for (int i = 0; i< playerData.Length;i++)
        {
            if (PlayerPrefs.HasKey(playerData[i]) == false)
            {
                if(i == 0)
                    PlayerPrefs.SetInt(playerData[i], 1);
                else
                    PlayerPrefs.SetInt(playerData[i], 0);
            }
        } 
    }
    int GetPlayerData(int id)
    {
        int a = 0;
        a = PlayerPrefs.GetInt(playerData[id]);
        return a;
    }
    void SetPlayerData(int id)
    {
        PlayerPrefs.SetInt(playerData[id], 1);
    }

    int[,] playerValue;
    void InitValue()
    {
        playerValue = new int[20, 2] { {84,84 }, { 91, 94 }, { 63, 69 }, { 84, 70 }, { 80, 90 }, { 70, 70 }, { 70, 73 }, { 84, 89 }, { 98, 91 }, { 77, 77 },
                                       {90,91 },{84,91 },{77,84 },{85,94 },{99,99 },{77,86 },{92,87 },{84,89 },{63,70 },{95,95 }};
    }

//    西班牙	84	84
//法国	91	94
//韩国	63	69
//尼日利亚	84	70
//摩洛哥	80	90
//巴拿马	70	70
//伊朗	70	73
//乌拉圭	84	89
//德国	98	91
//瑞典	77	77
//比利时	90	91
//英格兰	84	91
//秘鲁	77	84
//意大利	85	94
//阿根廷	99	99
//瑞士	77	86
//葡萄牙	92	87
//荷兰	84	89
//日本	63	70
//巴西	95	95

}
