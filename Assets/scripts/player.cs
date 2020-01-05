using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
       EasyButton.On_ButtonPress += On_ButtonPress;
        EasyButton.On_ButtonUp += On_ButtonUp;
        //EasyButton.On_ButtonDown += On_ButtonDown;
    }
    // Use this for initialization
    void Start () {
	
	}

    public float speed = 50f; 
    private float moveX = 0;
    private float moveY = 0;

    float mid = -0.24f;
    void FixedUpdate()
    { //得到用户输入，用输入轴实现平滑输入 

        if (GameController._instance.isstart == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveY = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveY = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveX = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = -1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveX = 0;
        }
        if (Input.anyKey == false)
        {
            moveX = 0;
            moveY = 0;
        }
        GetComponent<Rigidbody2D>().velocity = (Vector2.up * moveY + Vector2.left * moveX) * (speed + GameController._instance.playerValue[GameController._instance.NowUsePlayerID, 0] * 2);
         
       

        if (moveX == 0 && moveY == 0)
        {//移动
            if (transform.Find("playerFather/Armature"). GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("daiji") == false
                && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tiqiu") == false
                && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("touqiu") == false)
            {
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play("daiji");
            }
        }
        if (moveX != 0 || moveY != 0)
        {//移动
             
            if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pao") == false
                && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tiqiu") == false
                && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("touqiu") == false)
            { 
              transform.Find("playerFather/Armature").GetComponent<Animator>().Play("pao");
            }
        }
        if (transform.localPosition.x >= mid)
        {
            transform.localPosition = new Vector3(mid, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x <= -4.4f)
        {
            transform.localPosition = new Vector3(-4.4f, transform.localPosition.y, transform.localPosition.z);
        }
    }


    void Fire()
    {
        //if (buttonName=="Fire"){
      //  Instantiate(bullet, gun.transform.position, gun.rotation);
        //}		
    }


    void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
        //		EasyButton.On_ButtonPress -= On_ButtonPress;
        EasyButton.On_ButtonUp -= On_ButtonUp;
    }

    void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
        //		EasyButton.On_ButtonPress -= On_ButtonPress;
        EasyButton.On_ButtonUp -= On_ButtonUp;
    }
    void On_JoystickMove(MovingJoystick move)
    {

        //  float angle = move.Axis2Angle(true);
        //  transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        //  transform.Translate(Vector3.forward * move.joystickValue.magnitude * Time.deltaTime);

        if (GameController._instance.isstart == false) return;
        if (move.joystickAxis.x > 0f)
        {
            moveX = -1;
        }
        else if (move.joystickAxis.x < 0f)
        {
            moveX = 1;
        }
        else
        {
            moveX = 0;
        }
        if (move.joystickAxis.y > 0f)
        {
            moveY = 1;
        }
        else if (move.joystickAxis.y < 0f)
        {
            moveY = -1;
        }
        else
        {
            moveY = 0;
        } 
            GetComponent<Rigidbody2D>().velocity = (Vector2.up * moveY + Vector2.left * moveX) * (speed + GameController._instance.playerValue[GameController._instance.NowUsePlayerID, 0] * 2); 
       
        if (moveX != 0 || moveY != 0)
        {//移动
            if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pao") == false
                && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tiqiu") == false
                && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("touqiu") == false)
            {
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play("pao");
            }
        }
        if (transform.localPosition.x >= mid)
        {
            transform.localPosition = new Vector3(mid, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x <= -4.4f)
        {
            transform.localPosition = new Vector3(-4.4f, transform.localPosition.y, transform.localPosition.z);
        }
    }

    public void ResAnimator()
    {
        transform.Find("playerFather/Armature").GetComponent<Animator>().Play("daiji");
    }

    //  daiji  pao  shengli  tiqiu  touqiu

    void On_JoystickMoveEnd(MovingJoystick move)
    {
         
    }
     
	void On_ButtonPress (string buttonName)
	{
		if (buttonName=="Fire")
        {
            speed = 100;
        }
	} 

    void On_ButtonUp(string buttonName)
    {
        if (buttonName == "Fire")
        {
            speed = 50;   
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {//col指撞击的对象 
        if (col.gameObject.tag == "ball")//指定撞击对象
        {
          //  transform.Find("playerFather/Armature").GetComponent<Animator>().Play("tiqiu"); 
        }
    }
}
