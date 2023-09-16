using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueLockPuzzle : MonoBehaviour
{
    UI ui;
    [SerializeField] List<string> correctCombo;
    [SerializeField] List<string> currentCombo;
    [SerializeField] DoorTrigger blueDoor;
    [SerializeField] GameObject cable;
    TextMeshProUGUI progressText;

    public GameObject soundPrefab;

    void Start()
    {
        currentCombo = new List<string>(7);
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        progressText = transform.Find("ProgressText").GetComponent<TextMeshProUGUI>();
    }
    public void AddInput(string input)
    {
        if (currentCombo.Count < 6)
        {
            currentCombo.Add(input);
            progressText.text = string.Join(",",currentCombo);
        } else {
            currentCombo.Add(input);
            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        int correctAnswers = 0;
        for (int i = 0; i < correctCombo.Count; i++)
        {
            if (correctCombo[i] == currentCombo[i])
            {
                correctAnswers++;
            }
        }

        if (correctAnswers == 7)
        {
            Debug.Log("YOU WIN BRUV");
            ui.ExitInteract();
            blueDoor.DoorOpen();
            cable.SetActive(true);
            Destroy(GameObject.Find("BlueLock"));
            SoundManager.Instance.PlaySound(this.transform, soundPrefab);
        } else {
            Debug.Log("Try Again Bruv");
            progressText.text = ("Try Again!");
        }

        currentCombo = new List<string>(7);
    }
}
