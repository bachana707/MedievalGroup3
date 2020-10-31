﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody PlayerRb;

    public float PlayerSpeed = 5f;

    [HideInInspector]
    public Animator PlayerAnim;


    private void Start() {
        InitValuesAndComponenets();
    }


    //Function to Init Values and components
    private void InitValuesAndComponenets() {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
    }


    void Update()
    {
        
        if(Input.GetKey(KeyCode.A))
        {
            PlayerRb.velocity = new Vector3(-PlayerSpeed, 0f, 0f);
            PlayerAnim.SetTrigger(Constants.MoveAnimTrig);
            PlayerAnim.ResetTrigger(Constants.IdleAnimTrig);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,90, transform.eulerAngles.z);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            PlayerRb.velocity = new Vector3(PlayerSpeed, 0f, 0f);
            PlayerAnim.SetTrigger(Constants.MoveAnimTrig);
            PlayerAnim.ResetTrigger(Constants.IdleAnimTrig);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
        }      
        else
        {
            PlayerRb.velocity = Vector3.zero;
            PlayerAnim.SetTrigger(Constants.IdleAnimTrig);
            PlayerAnim.ResetTrigger(Constants.MoveAnimTrig);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAnim.SetTrigger(Constants.AttackAnimTrig);
            PlayerAnim.ResetTrigger(Constants.IdleAnimTrig);
            PlayerAnim.ResetTrigger(Constants.MoveAnimTrig);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnim.SetTrigger(Constants.JumpAnimTrig);
            PlayerAnim.ResetTrigger(Constants.IdleAnimTrig);
            PlayerAnim.ResetTrigger(Constants.MoveAnimTrig);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Reset"))
        {
          
        }
    }

    public void ResetPlayerPosition(Transform PlayerStartPos)
    {
        transform.position = PlayerStartPos.position;
    }

}
