using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuHandler : MonoBehaviour
{
    public GameObject buttons;
    public GameObject closeButton;
    public GameObject ControlsPanel;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(buttons.transform.GetChild(0).gameObject);
        ControlsPanel.SetActive(false);
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void OpenControls()
    {
        ControlsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(closeButton);
    }
    public void CloseControls()
    {
        ControlsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(buttons.transform.GetChild(1).gameObject);
    }
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        Debug.Log("ExitGame attempted.");
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}