using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour, IInteractable
{
    [HideInInspector] public UI canvas;
    
    public virtual void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<UI>();
    }

    public virtual void OnInteracted()
    {
        //ui.EnterInteract();
    }
}
