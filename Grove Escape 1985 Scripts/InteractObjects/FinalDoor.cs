using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : InteractObject
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        canvas.EnterInteract("FinalDoor");
    }
}
