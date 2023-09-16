using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedLockPuzzle : MonoBehaviour
{
    UI ui;
    string correctCombo = "0532";
    [SerializeField] List<string> comboEnter;
    [SerializeField] List<TMP_InputField> inputFields;
    [SerializeField] GameObject cable;
    [SerializeField] DoorTrigger redDoor;

    public GameObject unlockSound;

    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    public void UpdateEntry(int numToChange)
    {
        numToChange--;
        comboEnter[numToChange] = inputFields[numToChange].text;
    }

    public void Enter()
    {
        string comboToCheck = string.Join("", comboEnter);
        if (correctCombo == comboToCheck)
        {
            Debug.Log("YOU WIN BRUV");
            ui.ExitInteract();
            cable.SetActive(true);
            redDoor.DoorOpen();
            Destroy(GameObject.Find("RedLock"));
            SoundManager.Instance.PlaySound(this.transform, unlockSound);
        } else {
            Debug.Log("Try Again Bruv");
        }
    }
}
