using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    InputInterface _pcinput;
    //PcInput _pcinput;
    Mover _mover;
    Jump _jump;
    float _horizontal;
    float _vertical;
    bool _jumpedButton = false;

    //public bool _yerde= false;
    PlayerAnimations _playerAnimation;
    //Animator _animator;
    [SerializeField] Transform _playerTransform;
    Rigidbody2D _playerRigidbody2d;
    OnGround _onGround;
    Climbing _climbing;
    Heath _health;
    [SerializeField] TextMeshProUGUI healthText,scoreText;
    [SerializeField] AudioSource gemSound, damageSound;
    AudioSourceController _soundController;


    public PlayerAnimations PlayerAnimation { get { return _playerAnimation; } set { _playerAnimation = value; } }
    public bool Jumped  { get { return _jumpedButton; } set { _jumpedButton = value; } }


    //[SerializeField] GameObject Feet;

    private void Awake()
    {
        _pcinput = new PcInput();   // instanceýný almak zorundayýz yoksa  null kalýr
        //_jump = new Jump();
        //_mover = new Mover();
        //_playerAnimation = new PlayerAnimations();
        _onGround = GetComponentInChildren<OnGround>();
        _mover = GetComponent<Mover>();
        _playerAnimation = GetComponent<PlayerAnimations>();
        _jump = GetComponent<Jump>();
        _playerRigidbody2d = GetComponent<Rigidbody2D>();
        _climbing = GetComponent<Climbing>();
        _health = GetComponent<Heath>();
        _soundController = FindObjectOfType<AudioSourceController>().GetComponent<AudioSourceController>();




    }
    void Update()
    {
        _horizontal = _pcinput.Horizontal;
        _vertical = _pcinput.Vertical;
        healthText.text = _health.CurrentHealth.ToString();
        scoreText.text = GameManager.Instance.Score.ToString();

        if (_pcinput.Jump)
        {
            _jumpedButton = true;
            if(_playerRigidbody2d.velocity.y !=0)
                
            {
                _jumpedButton = false;

            }
        }
        _playerAnimation.AnimationJump(_jump.isJumpAction && !_onGround.IsOnGround ); //&& !_climbing.IsClimbing
        _playerAnimation.AnimationMove(_horizontal);
        _playerAnimation.AnimationClimb(_climbing.IsClimbing);

        /*if(_playerRigidbody2d.velocity.y<=0)
        {
            _onGround.IsOnGround = false;
        }*/

        


    }

    private void FixedUpdate()
    {

        _climbing.ClimbAction(_vertical);
        _mover.MoveAction(_horizontal, _playerTransform);
        /*if(horizontal < 0 ) 
        {
            _spriteRenderer.flipX = true;
        }
        else if(horizontal >0 )
        {
            _spriteRenderer.flipX = false;
        }*/
        _playerAnimation.AnimationMove(_horizontal);
        /*Debug.Log(Mathf.Sign(horizontal)+"Mathf.Sign");
 Debug.Log(horizontal+"horizontal deðer");*/

        if (_jumpedButton && _onGround.IsOnGround && !_climbing.IsClimbing)//_yerde) //
        {
            
            //_yerde = false;
            _jump.JumpAction(_playerRigidbody2d);
            //_yerde = false;
            _playerAnimation.AnimationJump(true);
            _onGround.IsOnGround = false;
            _jumpedButton = false;

        }
       /* if(_jump.isJumpAction)
        {
            _onGround.IsOnGround = false;

        }
        Debug.Log(_jump.isJumpAction);*/
        
        
        /*if(_playerRigidbody2d.velocity.y <-0.5f || _playerRigidbody2d.velocity.y >0.5)
        {
            _playerAnimation.AnimationJump(true,_animator);
        }
        Debug.Log(_playerRigidbody2d.velocity.y);*/

        /*if (_playerRigidbody2d.velocity.y > 0f )
        {
            _onGround.IsOnGround = false;
            //_yerde = false;
            _jumped = true;
            _playerAnimation.AnimationJump(true, _animator);
            //_animator.SetBool("Jump", true);
        }*/
        /*if (_playerRigidbody2d.velocity.y < 0)
        {
            _yerde = false;
            _jumped = true;
            _playerAnimation.AnimationJump(true, _animator);
            //_animator.SetBool("Jump", true);


        }*/

    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Zemin")
        {
            
        }
        _yerde = true;
        _jumped = false;
        _animator.SetBool("Jump", false);
    }*/
    /*private void OnCollisionEnter2D(Collision2D collision)
{

    if (collision.gameObject.tag=="Zemin")
    {
            _jumped = false;
            _yerde = true;
            _playerAnimation.AnimationJump(false, _animator);
        }
    

}*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage damage = collision.collider.GetComponent<Damage>();

        if (damage != null)
        {
            //_health.TakeHit(damage);
            damage.HitTarget(_health);
            _soundController.DamageSound(damageSound);
            //damageSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GemController gemController = collision.GetComponent<GemController>();
        if (gemController != null)
        {
            _soundController.GemSound(gemSound);
            //gemSound.Play();
        }

    }

}
