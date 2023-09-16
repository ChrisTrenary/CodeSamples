using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("EscapeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
