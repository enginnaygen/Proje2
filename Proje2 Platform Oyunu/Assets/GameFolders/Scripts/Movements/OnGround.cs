using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OnGround : MonoBehaviour
{
    [SerializeField]bool isOnGround=false;
    //[SerializeField]Rigidbody2D rb;
   PlayerAnimations _playerAnimation;
    PlayerController _controller;
    [SerializeField] float maxDistance;
    //[SerializeField] LayerMask layer;
    public bool IsOnGround {  get {return isOnGround; }  set {isOnGround = value; } }

    private void Awake()
    {
        //_playerAnimation = new PlayerAnimations();
        _controller = GetComponentInParent<PlayerController>();
        _playerAnimation = GetComponentInParent<PlayerAnimations>();
        
    }
    private void FixedUpdate()
    {
        CheckFootOnGround();


    }
    private void CheckFootOnGround()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, maxDistance, LayerMask.GetMask("Foreground"));
        Debug.DrawRay(transform.position, Vector2.down * maxDistance, Color.red);
        if (hit2D.collider != null)
        {
            
                Debug.Log("Raycast Tilemape Çarptý");
                isOnGround = true;
            
            
        }
        else
        { isOnGround = false; }
        //Debug.Log("Raycast Polygon Collidere Çarptý");


    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 6)
        {
           isOnGround = true;
           _playerAnimation.AnimationJump(false);
           _controller.Jumped = false;
            //_controller.PlayerAnimation.AnimationJump(false)
            Debug.Log("YumuþakÇarpýþma");
            

        }   
        /*else
        {
            isOnGround = false;
            _playerAnimation.AnimationJump(true, _animator);
            _controller.Jumped = true;
        }*/

}
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isOnGround = false;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer==6)
        {
            isOnGround = true;
            _playerAnimation.AnimationJump(false);
           _controller.Jumped = false;

        }
    }*/
    

    /* public void IsOnGroundFalse()
     {
         if(rb.velocity.y>0)
         {
             isOnGround=false;
         }
     }*/
    /*[SerializeField] Transform[] translates;
    [SerializeField] bool isOnGround = false;
    [SerializeField] float maxDistance = 0.5f;
    [SerializeField] LayerMask layerMask;

    public bool IsOnGround => isOnGround;

    private void Update()
    {
        foreach (Transform footTransform in translates)
        {
            CheckFootOnGround(footTransform);

            if (isOnGround) break;

        }
    }
    

    private void CheckFootOnGround(Transform footTransform)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance);
        Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

        if(hit2D.collider != null)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }*/

