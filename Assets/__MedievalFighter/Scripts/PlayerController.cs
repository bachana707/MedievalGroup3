using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody PlayerRb;

    public float PlayerSpeed = 10f;
    public float JumpForce = 5f;
    public bool OnGround;

    [HideInInspector]
    public Animator PlayerAnim;


    private void Start() {
        InitParameters();
    }


    public void InitParameters() {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();
    }



    void Update() {
        
        if (Input.GetKey(KeyCode.A)) {
            PlayerRb.velocity = new Vector3(-PlayerSpeed, 0f, 0f);
            PlayerAnim.SetTrigger("Run");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.D)) {
            PlayerRb.velocity = new Vector3(PlayerSpeed, 0f, 0f);
            PlayerAnim.SetTrigger("Run");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (OnGround == true)
            {
                PlayerRb.velocity = new Vector2(0f, JumpForce);
                
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
           // PlayerAnim.SetTrigger("Attack");
        }
        else {
            PlayerRb.velocity = Vector3.zero;
            PlayerAnim.SetTrigger("Idle");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }



    }
   

    private void OnCollisionStay(Collision coll) {
        if(coll.gameObject.tag == "ground")
        {
            OnGround = true;
        }
       
    }
    private void OnCollisionExit(Collision collE)
    {
        if (collE.gameObject.tag == "ground")
        {
            OnGround = false;
        }
    }

    public void ResetPlayerPosition(Transform PlayerStartPos) {
        transform.position = PlayerStartPos.position;
    }

}
