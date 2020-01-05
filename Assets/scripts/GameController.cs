using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //是否有广告
    private bool isUseVideo = false;
    public bool IsUseVideo { get { return isUseVideo; } }

    //是否是TV
    private bool isUseHand = true;
    public bool IsUseHand { get { return isUseHand; } }

    //是否是测试版本，测试版本才可以相应确认键
    public static bool DEBUG = false;


    public static GameController _instance;
    public GameObject colliderObject;
    public GameObject npc;
    public GameObject player;
    public GameObject ball;
    public Transform ballFather;

    public GameObject scene;
    public GameObject touch;
    public GameObject touch2;
    public GameObject fire;
    public AudioManager audioManager;
    public ChangeGameManager changeGameManager;
    public GameObject hand;
    public GameObject daitianniu;
    public EasyJoystick easyJoystick;
    public bool SoundOpen { get; set; }

    private int ballNum = 0;
    public int BallNum { get { return ballNum; } set { ballNum = value; } }
    private void Awake()
    {
        _instance = this;

        hand.SetActive(IsUseHand);
        isStop = false;
    }
    private void OnEnable()
    {
        StartCoroutine(StartPlay());
    }
    //当前使用的角色ID
    public int NowUsePlayerID { get; set; }

    //当前管卡
    public int NowPlayLevel { get; set; }

    //当前球
    public GameObject Ball { get; set; }

    //Npc是否在小球运动路线上
    public bool isOnLine { get; set; }

    public Vector3 vel { get; set; }
     
    public bool isStop { get; set; }

    public bool isstart = false;
    private float jishiTime = 0;
    private float playTime = 60;
    private float showTime = 0;
    public int ShowTime
    {
        set { showTime = value; }
        get { return (int)showTime; }
    }
    public float JishiTime { get { return jishiTime; } set { jishiTime = value; } }
    bool boolDaojishi1 = false;
    bool boolDaojishi2 = false;
    bool boolDaojishi3 = false;
    bool boolDaojishi4 = false;
    bool boolDaojishi5 = false;
    bool boolDaojishi6 = false;
    bool boolDaojishi7 = false;
    bool boolDaojishi8 = false;
    bool boolDaojishi9 = false;
    bool boolDaojishi10 = false;
    void JiShi()
    {
        if (isstart == true)
        {
            if (jishiTime < playTime)
            {
                jishiTime += Time.deltaTime;
                PlayDaojishiSound();
            }
            else
            {
                isstart = false;
                jishiTime = 0;
                ResDaojishiBool();
                GameController._instance.ShowHideTouch(false);
                if (grade.redgrade >= text.bluegrade)
                {//胜利
                    if (IsUseHand == true)
                    {
                        hand.GetComponent<UISelect>().ShowInOverWin();
                    }
                    UIManager._instance.ShowOrHideGameOver(true);
                    UIManager._instance.uiStep = UIManager.UIStep.gameOver;
                    UIManager._instance.gameOver.ShowShengli();
                    UIManager._instance.playSprite.enabled = true;
                    UIManager._instance.audioManager.PlayOne(8);
                    //   player.transform.localPosition = new Vector3(_instance.player.transform.localPosition.x, player.transform.localPosition.y, 0);
                    //  npc.transform.localPosition = new Vector3( npc.transform.localPosition.x,  npc.transform.localPosition.y, 0);
                    changeGameManager.Des();
                    ball.SetActive(false);
                }
                else
                {
                    if (IsUseHand == true)
                    {
                        hand.GetComponent<UISelect>().ShowInOverLose();
                    }
                    UIManager._instance.ShowOrHideGameOver(true);
                    UIManager._instance.uiStep = UIManager.UIStep.gameOver;
                    UIManager._instance.gameOver.ShowShiBai();
                    //    player.transform.localPosition = new Vector3( player.transform.localPosition.x, player.transform.localPosition.y, 0);
                    //    npc.transform.localPosition = new Vector3( npc.transform.localPosition.x,  npc.transform.localPosition.y, 0);
                    changeGameManager.Des();
                    Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    ball.SetActive(false);
                }
            }
            showTime = playTime - jishiTime;
        }
    }

    void PlayDaojishiSound()
    {
        if (boolDaojishi1 == false)
        {
            if (jishiTime > 50)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi1 = true;
            }
        }
        if (boolDaojishi2 == false)
        {
            if (jishiTime > 51)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi2 = true;
            }
        }
        if (boolDaojishi3 == false)
        {
            if (jishiTime > 52)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi3 = true;
            }
        }
        if (boolDaojishi4 == false)
        {
            if (jishiTime > 53)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi4 = true;
            }
        }
        if (boolDaojishi5 == false)
        {
            if (jishiTime > 54)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi5 = true;
            }
        }
        if (boolDaojishi6 == false)
        {
            if (jishiTime > 55)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi6 = true;
            }
        }
        if (boolDaojishi7 == false)
        {
            if (jishiTime > 56)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi7 = true;
            }
        }
        if (boolDaojishi8 == false)
        {
            if (jishiTime > 57)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi8 = true;
            }
        }
        if (boolDaojishi9 == false)
        {
            if (jishiTime > 58)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi9 = true;
            }
        }
        if (boolDaojishi10 == false)
        {
            if (jishiTime > 59)
            {
                UIManager._instance.audioManager.PlayOne(5);
                boolDaojishi10 = true;
            }
        }
    }
    void ResDaojishiBool()
    {
        boolDaojishi1 = false;
        boolDaojishi2 = false;
        boolDaojishi3 = false;
        boolDaojishi4 = false;
        boolDaojishi5 = false;
        boolDaojishi6 = false;
        boolDaojishi7 = false;
        boolDaojishi8 = false;
        boolDaojishi9 = false;
        boolDaojishi10 = false;
    }


    IEnumerator StartPlay()
    {
        yield return new WaitForSeconds(1f);
        if (UIManager._instance.uiStep == UIManager.UIStep.game)
        {
            isstart = true;
            ResDaojishiBool();
        }
    }
    private void Update()
    {
        JiShi();
        if (UIManager._instance.uiStep == UIManager.UIStep.game)
        {
            if (ballFather.childCount > 1)
            {
                //  Destroy(ballFather.GetChild(0).gameObject);
            }
        }
        print(isStop);
    }

    public void ResetPos()
    {
        player.transform.localPosition = new Vector3(-2.75f, 0f, 5);
        player.GetComponent<player>().ResAnimator();
        npc.transform.localPosition = new Vector3(2.75f, 0f, 5);
        npc.GetComponent<Npc>().ResAnimator();
        
    }

    public void ShowOrHideGame(bool isShow)
    {
        scene.SetActive(isShow);
        ShowHideTouch(isShow);
    }

    public void ShowHideTouch(bool isShow)
    {
        if (IsUseHand == false)
        { 
                //touch.SetActive(isShow);
              //  touch2.SetActive(isShow);
                fire.SetActive(isShow);
                daitianniu.SetActive(!isShow);

            // easyJoystick.showTouch = isShow;
            // easyJoystick.showZone = isShow;
            // easyJoystick.showDeadZone = isShow;
            if (isShow == true)
            {
                easyJoystick.JoystickPositionOffset = new Vector2(0,0);
            }
            else
            {
                easyJoystick.JoystickPositionOffset = new Vector2(-500, 0);
            }

        }
    }




    public int[,] playerValue =  new int[20, 2] { {84,84 }, { 91, 94 }, { 63, 69 }, { 84, 70 }, { 80, 90 }, { 70, 70 }, { 70, 73 }, { 84, 89 }, { 98, 91 }, { 77, 77 },
                                                  {90,91 },{84,91 },{77,84 },{85,94 },{99,99 },{77,86 },{92,87 },{84,89 },{63,70 },{95,95 }};

    public int[,] levelValue = new int[30, 2] { {80,81 }, { 97, 82 }, { 90, 83 }, { 97, 84 }, { 99, 85 }, { 84, 84 }, { 98, 85 }, { 84, 86 }, { 80, 87 }, { 99, 88 },
                                                {94,87 },{94,88 },{85,89 },{92,90 },{95,91 },{96,90 },{92,91 },{89,92 },{81,93 },{97,94 },
                                                {89,93 },{99,94 },{97,95 },{84,96 },{98,97 },{97,96 },{92,97 },{81,98 },{85,99 },{100,100 }};
    //npc显示顺序
    private int[] npcUse = new int[30] {5,18,11,4,19,19,19,1,5,17,1,5,8,11,5,4,12,10,18,15,7,7,19,16,9,12,9,2,14,19};
    public int[] GetNpcUse { get { return npcUse; } }

    /// <summary>
    /// 0.待机
    /// 1.跑
    /// 2.踢球
    /// 3.头球
    /// 4.胜利
    /// </summary>
    public string[] animName = new string[] { "daiji","pao","tiqiu","touqiu","shengli"};
    //动画播放速度
    private int animSpeed = 3;
    public int AnimSpeed { get { return animSpeed; } }

    //    1	80	81
    //2	97	82
    //3	90	83
    //4	97	84
    //5	99	85
    //6	84	84
    //7	98	85
    //8	84	86
    //9	80	87
    //10	99	88

    //11	94	87
    //12	94	88
    //13	85	89
    //14	92	90
    //15	95	91
    //16	96	90
    //17	92	91
    //18	89	92
    //19	81	93
    //20	97	94

    //21	89	93
    //22	99	94
    //23	97	95
    //24	84	96
    //25	98	97
    //26	97	96
    //27	92	97
    //28	81	98
    //29	85	99
    //30	100	100

}
