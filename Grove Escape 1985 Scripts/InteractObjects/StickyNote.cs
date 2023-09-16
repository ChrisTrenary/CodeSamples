using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNote : InteractObject
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        canvas.EnterInteract("StickyNote");
    }
}
