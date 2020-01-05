using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    private Transform mTra;
    public float speed = 80f;
    //  Animator animator;
    // Use this for initialization
    void Start()
    {
        mTra = transform;
        //  animator = transform.Find("npcFather/Armature").GetComponent<Animator>();
        //  animator.Play("daiji");
         
    }

    float time = 0;
    void Update()
    {
        NpcMove();
        if (isKa == true)
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                isKa = false;
                time = 0;
            }
        }
        else
        {
            time = 0;
        }
    }
    int moveX = 0;
    bool isRun = false;
    void NpcMove()
    {
         
        if (GameController._instance.isstart == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;



        }
        if (GameController._instance.Ball.transform.localPosition.x < 0)
        {
            if (isRun == false)
            {
                if (Random.Range(0, 100) > 50)
                {
                    if (mTra.localPosition.x > 0.4f)
                    {
                        moveX = 1;
                    }
                    else
                    {
                        isRun = true;
                        moveX = -1;
                    }
                }
                else
                {
                    //  moveX = 0;
                }
            }
        }
        else
        {
            if (mTra.localPosition.x < 0.4f)
                moveX = -1;
        }

        if (mTra.localPosition.x < 0.4f)
            moveX = -1;
        if (GameController._instance.Ball.transform.localPosition.x > mTra.localPosition.x && isKa == false)
        {
            if (mTra.localPosition.x < 4)
            {
                moveX = -1;
            }
            else
            {
                moveX = 1;
            }
        }
        if (mTra.localPosition.x >= 4)
        {
            isRun = false;
            moveX = 1;
        }
        if (GameController._instance.Ball.transform.position.y > mTra.position.y + 20f)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.up + Vector2.left * moveX) * (speed + GameController._instance.levelValue[GameController._instance.NowPlayLevel, 0] * 2);
             PlayMove();
        }
        else if (GameController._instance.Ball.transform.position.y < mTra.position.y - 20f)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.down + Vector2.left * moveX) * (speed + GameController._instance.levelValue[GameController._instance.NowPlayLevel, 0] * 2);
            PlayMove();
        }
        else
        { 
            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
                PlayIdle();
        }
        if (mTra.localPosition.x < 0.4f)
        {
            GetComponent<Rigidbody2D>().velocity = ( Vector2.left * -1) * (speed + GameController._instance.levelValue[GameController._instance.NowPlayLevel, 0] * 2);
            PlayMove();
        }
    }
     

    void PlayMove()
    {
        if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pao") == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tiqiu") == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("touqiu") == false)
        {
            transform.Find("npcFather/Armature").GetComponent<Animator>().Play("pao");
        }
    }

    void PlayIdle()
    {
        if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tiqiu") == false
              && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("touqiu") == false)
        {
            transform.Find("npcFather/Armature").GetComponent<Animator>().Play("daiji");
        }
    }
    public void ResAnimator()
    {
        transform.Find("npcFather/Armature").GetComponent<Animator>().Play("daiji");
    }

    void OnCollisionEnter2D(Collision2D col)
    {//col指撞击的对象 
        if (col.gameObject.tag == "ball")//指定撞击对象
        {
            transform.Find("npcFather/Armature").GetComponent<Animator>().Play("tiqiu");
        }
    }
    bool isKa = false;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")//指定撞击对象
        {
            isKa = true;
        }
    }

}
