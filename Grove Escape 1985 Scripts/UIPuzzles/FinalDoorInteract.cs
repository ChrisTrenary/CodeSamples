using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDoorInteract : MonoBehaviour
{
    string pwInput;
    string correctPW = "Unpaid2023";
    UI ui;
    TMP_InputField input;
    [SerializeField] DoorTrigger doorToOpen;

    void Start()
    {
        input = transform.Find("FinalPWInput").GetComponent<TMP_InputField>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    public void EnterPassword()
    {
        pwInput = input.text;
    }

    public void EnterButton()
    {
        if (pwInput == correctPW)
        {
            doorToOpen.DoorOpen();
            ui.ExitInteract();
        }
    }
}
