using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    CheckpointController[] _checkpointController;
    Heath _health;

    private void Awake()
    {
        _checkpointController = GetComponentsInChildren<CheckpointController>();
        _health = FindObjectOfType<PlayerController>().GetComponent<Heath>();
    }

    private void Start()
    {
        _health.OnHealtChanged += HandleHealtChanged;
    }

    private void HandleHealtChanged()
    {
        _health.transform.position = _checkpointController.LastOrDefault(x => x.IsPassed).transform.position;
    }
}
