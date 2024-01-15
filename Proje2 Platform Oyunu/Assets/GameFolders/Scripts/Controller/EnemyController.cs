using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Heath _health;
    Mover _mover;
    Transform _enemyTransform;
    float _yon = 1f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _enemyTransform = GetComponent<Transform>();
        _health = GetComponent<Heath>();

    }

    private void FixedUpdate()
    {
        if (!_health.IsDead)
        {
            _mover.MoveAction(_yon, _enemyTransform);
        }
        if (_health.IsDead)
        {
            _mover.MoveAction(0f, _enemyTransform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _yon *= -1;

    }
}


