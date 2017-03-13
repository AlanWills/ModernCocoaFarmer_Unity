using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RandomEventScript
{
    public abstract string Description { get; }
    public abstract void Yes();
    public abstract void No();
}
