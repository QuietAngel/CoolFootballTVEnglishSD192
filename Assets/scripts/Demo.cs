using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBone;

public class Demo : MonoBehaviour {

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
      
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("pao");
        }


        
    }
}
