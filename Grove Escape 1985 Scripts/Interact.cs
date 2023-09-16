using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool canInteract;
    UI ui;
    IInteractable objectToInteract;
    void Start()
    {
        canInteract = true;
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (canInteract && objectToInteract != null)
            {
                //Debug.Log("Input detected");
                objectToInteract.OnInteracted();
                canInteract = false;
                ui.interactIndicator.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ui.ExitInteract();
            ui.EnterInteract("PauseMenu");
        }
    }

    public void CheckForInteract()
    {
        if (UI.interactIsOpen == false)
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5))
            {
                if (hit.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactObject))
                {
                    if (!ui.interactIndicator.activeInHierarchy)
                    {
                        ui.interactIndicator.SetActive(true);
                        canInteract = true;
                        objectToInteract = interactObject;
                    }
                } else {
                    if (ui.interactIndicator.activeInHierarchy)
                    {
                        ui.interactIndicator.SetActive(false);
                        canInteract = false;
                        objectToInteract = null;
                    }
                }
            } else {
                if (ui.interactIndicator.activeInHierarchy)
                {
                    ui.interactIndicator.SetActive(false);
                    canInteract = false;
                    objectToInteract = null;
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("WinZone"))
        {
            ui.EnterInteract("YouEscapedScreen");
        }
    }
}
