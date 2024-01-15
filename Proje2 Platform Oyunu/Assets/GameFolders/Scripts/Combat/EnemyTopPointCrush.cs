using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopPointCrush : MonoBehaviour
{
    Heath _health;
    PlayerAnimations _enemyAnimations;
    Rigidbody2D _playerRigidbody;
    AudioSource puffSound;
    AudioSourceController _soundController;
    [SerializeField] GameObject _enemy;

    private void Awake()
    {
        _health = GetComponentInParent<Heath>();
        _enemyAnimations = GetComponentInParent<PlayerAnimations>();
        _soundController = FindObjectOfType<AudioSourceController>().GetComponent<AudioSourceController>();
        _playerRigidbody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();
        puffSound = GetComponentInParent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PolygonCollider2D footcollider = collision.GetComponent<PolygonCollider2D>();

        if (footcollider != null) //collision.gameObject.tag == "Player"
        {
            _playerRigidbody.velocity = Vector3.up * 10;
            _health.CurrentHealth = 0;
            _enemyAnimations.AnimationDeath(true);
            _soundController.PuffSound(puffSound);
            //puffSound.Play();
            Destroy(_enemy, 0.5f);


        }
    }
}
