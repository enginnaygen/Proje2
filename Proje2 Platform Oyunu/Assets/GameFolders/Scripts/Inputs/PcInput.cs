using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInput : InputInterface
{
    public bool Jump => Input.GetKeyDown(KeyCode.Space);
    public float Horizontal => Input.GetAxisRaw("Horizontal");

    public float Vertical => Input.GetAxisRaw("Vertical");

    public bool Pause => Input.GetKeyDown(KeyCode.Escape);
}
