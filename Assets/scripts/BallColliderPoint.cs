using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColliderPoint : MonoBehaviour {

    Ray2D ray;
    void Update()
    {

        //计算出当前鼠标和Dian原点之间的向量  其中data.position为一个游戏物体的坐标  Dian_position另一个游戏物体的坐标
        Vector3 MoveNormalized = transform.position - GameController._instance.Ball.transform.position;
        //两点之间的向量
        Vector3 V3 = MoveNormalized.normalized;
        //角度
        float z;
        if ((V3).x > 0)
        {
            //以Z轴为坐标 使用向量计算出来角度  
            z = -Vector3.Angle(Vector3.up, V3);
        }
        else
        {
            z = Vector3.Angle(Vector3.up, V3);
        }
        //在使用上这句话  游戏物体就会转动了
        this.transform.eulerAngles = new Vector3(0, 0, (z)-180);


        Ray2D ray = new Ray2D(transform.position, Vector2.up *1000);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        // ray = new Ray2D(transform.position, Vector2.up);
        // RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction,1000);
        //Debug.DrawRay(ray.origin,ray.direction,Color.blue,1000);
        //Debug.DrawLine(ray.origin, ray.direction, Color.blue,1000);
        // RaycastHit2D hit = Physics2D.Linecast(transform.position, GameController._instance.Ball.transform.position);//射线检测(起始位置,和目标位置)
        // print(hit.collider.gameObject.name);




    }

}
