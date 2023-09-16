using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVHighScore : InteractObject
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        canvas.EnterInteract("TVHighScore");
    }
}
