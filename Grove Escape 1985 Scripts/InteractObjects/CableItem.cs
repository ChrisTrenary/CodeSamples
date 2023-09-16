using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableItem : InteractObject
{
    public GameObject collectItemSound;

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteracted()
    {
        SoundManager.Instance.PlaySound(this.transform, collectItemSound);
        Inventory.cableCount++;
        Destroy(gameObject);
    }
}
