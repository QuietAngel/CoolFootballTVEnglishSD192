using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlView : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("JumpScene",2.0f);
	}

    void JumpScene()
    {
        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        KeyCode MIOkKeyCode =GameController.DEBUG?KeyCode.Return:(KeyCode)10;//小米遥控器确认键
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(MIOkKeyCode))
        {
            JumpScene();
        }
    }
}
