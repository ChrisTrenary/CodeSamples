using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLock : InteractObject
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        canvas.EnterInteract("RedLock");
    }
}
