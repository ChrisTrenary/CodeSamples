using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CableBoxInteract : MonoBehaviour
{
    UI ui;
    [SerializeField] List<GameObject> buttons;
    [SerializeField] List<GameObject> powerObjects;
    [SerializeField] TextMeshProUGUI cableCountText;
    [SerializeField] List<GameObject> pluggedIn;

    public GameObject openGarageSound;

    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        //cableCountText = transform.Find("CableCount").GetComponent<TextMeshProUGUI>();
    }
    void OnEnable()
    {
        cableCountText.text = ("Cables Found: " + Inventory.cableCount);
    }
    public void OutletSelected(int selectNum)
    {
        if (Inventory.cableCount > 0)
        {
            if (selectNum == 1)
            {
                Destroy(buttons[0]);
                powerObjects[0].GetComponent<KeypadManager>().poweredOn = true;
                ui.StartCoroutine(ui.NotifyText("KeyPad Power Restored!"));
                pluggedIn[0].SetActive(true);
            } else {
                Destroy(buttons[1]);
                powerObjects[1].GetComponent<DoorTrigger>().DoorOpen();
                ui.StartCoroutine(ui.NotifyText("Garage Door Opened!"));
                pluggedIn[1].SetActive(true);
                SoundManager.Instance.PlaySound(this.transform, openGarageSound);
            }

            ui.ExitInteract();
            Inventory.cableCount--;
        }
    }
}
