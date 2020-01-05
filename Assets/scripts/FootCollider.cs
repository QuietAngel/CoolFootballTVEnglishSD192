using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {
     
    void OnCollisionEnter2D(Collision2D col)
    {//col指撞击的对象 
        if (col.gameObject.tag == "ball")//指定撞击对象
        {
            transform.parent.transform.Find("Armature").GetComponent<Animator>().Play("tiqiu");
           // StartCoroutine(BackPlay());
        } 
    }

    IEnumerator BackPlay()
    {
        yield return new WaitForSeconds(1f);
        transform.parent.transform.Find("Armature").GetComponent<Animator>().Play("daiji");
    }
}
