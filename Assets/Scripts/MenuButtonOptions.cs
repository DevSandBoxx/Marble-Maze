using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuButtonOptions : MonoBehaviour
{
    private Canvas canvas;
    private GameObject homeScreen;
    private GameObject levelSelect;
    private GameObject instructionsScreen;


    int desiredLevel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        canvas = FindObjectOfType<Canvas>();
        homeScreen = canvas.transform.GetChild(0).gameObject;
        levelSelect = canvas.transform.GetChild(1).gameObject;
        instructionsScreen = canvas.transform.GetChild(2).gameObject;
    }
    public void PlayButton()
    {
        homeScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        levelSelect.SetActive(true);
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
    public void selectLevelToPlayButtons()
    {
        GameObject buttonPressed = EventSystem.current.currentSelectedGameObject;
        desiredLevel = int.Parse(buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text);
        GameManager.instance.OpenLevel(desiredLevel);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void InstructionsButton()
    {
        homeScreen.SetActive(false);
        levelSelect.SetActive(false);
        instructionsScreen.SetActive(true);
    }
    public void BackButton()
    {
        homeScreen.SetActive(true);
        levelSelect.SetActive(false);
        instructionsScreen.SetActive(false);
    }
}
