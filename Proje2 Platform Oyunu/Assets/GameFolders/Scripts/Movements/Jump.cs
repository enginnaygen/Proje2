using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    Rigidbody2D _playerRigidbody2d;
    [SerializeField] float JumpSpeed=15;
    public bool isJumpAction => _playerRigidbody2d.velocity != Vector2.zero;

    private void Awake()
    {
        _playerRigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void JumpAction(Rigidbody2D _playerRigidbody2d)
    {
        _playerRigidbody2d.velocity = Vector2.zero;
        _playerRigidbody2d.velocity = Vector2.up * JumpSpeed;


    }
}
