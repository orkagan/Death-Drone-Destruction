using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject playAgain;
    public GameObject mainMenu;

    private void OnEnable()
    {
        {
            EventSystem.current.SetSelectedGameObject(playAgain);
            

        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
