using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [SerializeField] float climbSpeed = 5f;
    Rigidbody2D rb;
    public Rigidbody2D Rigidbody => rb;
    public bool IsClimbing { get; set; }
    //Jump _jump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //_jump = GetComponent<Jump>();
    }

    public void ClimbAction(float direction)
    {

        if (IsClimbing)
        {
            transform.Translate(climbSpeed * direction * Time.deltaTime * Vector2.up);
        }

    }
}
