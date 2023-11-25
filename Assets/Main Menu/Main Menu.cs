using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PickModeMenu()
    {

        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {

        Application.Quit();

    }

    public void OptionsGame()
    {

        SceneManager.LoadScene(4);

    }

    public void ExitGame()
    {

        SceneManager.LoadScene(0);

    }

}
