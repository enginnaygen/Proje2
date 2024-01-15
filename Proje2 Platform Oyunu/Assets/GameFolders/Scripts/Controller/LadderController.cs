using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{

   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {   
            ClimbingAction(collision, 0, true);
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        animations.AnimationJump(false);
        animations.AnimationClimb(true);
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        ClimbingAction(collision, 3, false);
       
    }

    private void ClimbingAction(Collider2D collision, float GravityScale,bool Climbing)
    {
        Climbing playerClimbing = collision.GetComponent<Climbing>();
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        PlayerAnimations animations = collision.GetComponent<PlayerAnimations>();

        if (playerClimbing != null)
        {
            Debug.Log("Laddere Çarptý");
            playerClimbing.Rigidbody.gravityScale = GravityScale;
            playerClimbing.IsClimbing = Climbing;
            rb.velocity = Vector2.zero;
            animations.AnimationClimb(Climbing);



        }
        
    }
}
