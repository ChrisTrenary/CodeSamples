using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static bool interactIsOpen;
    GameObject interactMenu;
    GameObject reticle;
    public GameObject interactIndicator;
    PlayerController player;
    string currentInteractName;
    TextMeshProUGUI powerText;
    TextMeshProUGUI notificationText;
    [SerializeField] List<GameObject> puzzles;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        interactMenu = transform.Find("InteractMenu").gameObject;
        reticle = transform.Find("Reticle").gameObject;
        interactIndicator = transform.Find("InteractIndicator").gameObject;
        powerText = transform.Find("PowerRestoredText").GetComponent<TextMeshProUGUI>();
        notificationText = transform.Find("NotifyText").GetComponent<TextMeshProUGUI>();

        interactIsOpen = false;
        reticle.SetActive(true);
        interactIndicator.SetActive(false);
        interactMenu.SetActive(false);
        powerText.gameObject.SetActive(false);
        notificationText.gameObject.SetActive(false);
    }

    public void EnterInteract(string openName)
    {
        Time.timeScale = 0f;
        Debug.Log("Enter Interact called");
        interactIsOpen = true;
        currentInteractName = openName;
        interactMenu.transform.Find(currentInteractName).gameObject.SetActive(true);
        interactMenu.SetActive(true);
        interactIndicator.SetActive(false);
        reticle.SetActive(false);
        player.StopLooking();
    }

    public void ExitInteract()
    {
        Time.timeScale = 1f;

        interactMenu.SetActive(false);
        reticle.SetActive(true);

        foreach (GameObject currentPuzzle in puzzles)
        {
            currentPuzzle.SetActive(false);
        }

        Debug.Log("Exit Interact");

        interactIsOpen = false;
        player.StartLooking();
        
    }

    public IEnumerator NotifyText(string notifyText)
    {
        notificationText.text = notifyText;
        notificationText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        notificationText.gameObject.SetActive(false);
    }

    public IEnumerator PowerRestored(int numRestored)
    {
        powerText.text = ("Power Restored! " + numRestored + "/3");
        powerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);

        if (numRestored == 3)
        {
            powerText.text = ("Password Revealed!");
            yield return new WaitForSeconds(3f);
        }

        powerText.gameObject.SetActive(false);
    }

    public void ReturnToTitle()
    {
        ExitInteract();
        SceneManager.LoadScene("TitleScreen");
    }
}
