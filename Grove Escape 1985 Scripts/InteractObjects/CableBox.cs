using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableBox : InteractObject
{
    public GameObject openSound;

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        SoundManager.Instance.PlaySound(this.transform, openSound);
        canvas.EnterInteract("CableBox");
    }
}
