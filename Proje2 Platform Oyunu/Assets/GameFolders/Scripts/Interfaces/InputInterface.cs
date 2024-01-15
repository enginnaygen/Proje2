using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InputInterface
{
    bool Jump { get; }
    float Horizontal { get; }
    float Vertical { get; }
    bool Pause { get; }
}
