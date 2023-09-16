using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLock : InteractObject
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        canvas.EnterInteract("BlueLock");
    }
}
