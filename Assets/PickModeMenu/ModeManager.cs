using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public void FloatMode()
    {

        SceneManager.LoadScene(2);

    }

    public void HoverMode()
    {

        SceneManager.LoadScene(3);

    }

    public void ExitToMenu()
    {

        SceneManager.LoadScene(0);

    }
}
