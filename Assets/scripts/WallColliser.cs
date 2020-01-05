using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColliser : MonoBehaviour {

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")//指定撞击对象
        {
            GameController._instance.Ball.GetComponent<Rigidbody2D>().velocity = Vector2.left * 300f;
        }
    }
}
