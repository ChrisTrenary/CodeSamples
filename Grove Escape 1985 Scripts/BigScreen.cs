using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigScreen : MonoBehaviour
{
    [SerializeField] Material[] phases;
    Renderer rend;
    int switchesOn = 0;
    UI ui;

    void Start()
    {
        rend = GetComponent<Renderer>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }
    public void CheckPower()
    {
        if (switchesOn < 3)
        {
            switchesOn++;
            ui.StartCoroutine(ui.PowerRestored(switchesOn));
            rend.material = phases[switchesOn];
            if (switchesOn == 3)
            {
                Debug.Log("The password is Unpaid2023. Now GOOO!!!");
            }
        }
    }
}
