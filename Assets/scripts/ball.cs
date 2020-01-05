using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
    float speed = 700f;
    // Use this for initialization
    public ball Ball;
    bool isHaveCreat = false;//是否已经生成小球
    void OnEnable()
    {
        if (GameController._instance.isStop) return;
        transform.localPosition = Vector2.zero;
        StartCoroutine(run());
        GameController._instance.Ball = gameObject;
    }
     

    IEnumerator run()
    {
        yield return new WaitForSeconds(1f);
        isHaveCreat = false;
        UIManager._instance.audioManager.PlayOne(0);
        GameController._instance.isstart = true;
        GetComponent<Rigidbody2D>().velocity =  (GameController._instance.BallNum % 2 == 0 ? Vector2.left : Vector2.right) * speed;
        v2 = (GameController._instance.BallNum % 2 == 0 ? Vector2.left : Vector2.right) * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {//col指撞击的对象
        UIManager._instance.audioManager.PlayOne(1);
        if (col.gameObject.name == "playerplayerFather")//指定撞击对象
        {
            //speed += 100f;
            float y = hitVector(transform.position, col.transform.position,
              col.collider.bounds.size.y);//从撞向的对象的碰撞体的size获得其宽度

            Vector2 dir = new Vector2(1, y).normalized;//单位化向量方向
            if (GameController._instance.player.transform.position.x < transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = dir * (speed + GameController._instance.playerValue[GameController._instance.NowUsePlayerID ,1] );//改变方向
            }
        }
        else if(col.gameObject.name.Equals("npcNpcFather"))
        {
           // speed += 100f;
            float y = hitVector(transform.position, col.transform.position,
              col.collider.bounds.size.y); 
            Vector2 dir = new Vector2(-1, y).normalized;//设为-1反方向
            if (GameController._instance.npc.transform.position.x > transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = dir * (speed + GameController._instance.levelValue[GameController._instance.NowPlayLevel , 1] );
            }
        }
        else if (col.gameObject.name.Equals("right"))
        {
            UIManager._instance.audioManager.PlayOne(4);
            grade.redgrade += 1;
            GameController._instance.BallNum += 1;
            if(isHaveCreat == false)
            {
                isHaveCreat = true;
                GameController._instance.isStop = false;
                GameObject go = Instantiate(Ball, new Vector3(0, 0, -5), Quaternion.identity).gameObject;
                go.transform.parent = GameController._instance.ballFather;
                go.name = "ball" + GameController._instance.BallNum;
                go.transform.position = new Vector3(0, 0, 1);
                go.transform.localScale = new Vector3(1, 1, 1);
                go.tag = "ball";
                Destroy(gameObject);
                GameController._instance.Ball = go;
            }

            GameController._instance.Ball.transform.localPosition = Vector2.zero;
             GameController._instance.isstart = false;
            GameController._instance.ResetPos();
        }
        else if (col.gameObject.name.Equals("left"))
        {
            UIManager._instance.audioManager.PlayOne(7);
            text.bluegrade += 1;
            GameController._instance.BallNum += 1;
            if (isHaveCreat == false)
            {
                isHaveCreat = true;

                GameController._instance.isStop = false;
                GameObject go = Instantiate(Ball, new Vector3(0, 0, -5), Quaternion.identity).gameObject;
                go.transform.parent = GameController._instance.ballFather;
                go.name = "ball" + GameController._instance.BallNum;
                go.transform.position = new Vector3(0, 0,1);
                go.transform.localScale = new Vector3(1, 1, 1);
                go.tag = "ball";
                Destroy(gameObject);
                GameController._instance.Ball = go;
            }
         
            GameController._instance.Ball.transform.localPosition = Vector2.zero;
           GameController._instance.isstart = false;
            GameController._instance.ResetPos(); 
        }
        if (col.gameObject.name.Equals("wall")|| col.gameObject.name.Equals("player"))
        {
            ContactPoint2D contact = col.contacts[0];
            //碰撞点坐标
            Vector3 pos = contact.point;
            GameController._instance.colliderObject.transform.position = pos;
        }
    }
    float hitVector(Vector2 ballpos, Vector2 batpos, float batwidth)
    {//返回球撞击处占bat宽度的比例,注意要是float 
        return (ballpos.y - batpos.y) / batwidth;
    }
     
    Vector2 v2;
    void Update ()
    {
        if (transform.localPosition.z != 1)
        {
            transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,1);
        }

        if (GameController._instance.isstart == false)
        {
            v2 = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            transform.Rotate(Vector3.forward * 10,Space.Self);
            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                if(v2 == Vector2.zero)
                    v2 = (GameController._instance.BallNum % 2 == 0 ? Vector2.left : Vector2.right) * speed;

                GetComponent<Rigidbody2D>().velocity = v2;
            }
        }
    }

    public void DesAndCreat()
    {
 
    }
}
