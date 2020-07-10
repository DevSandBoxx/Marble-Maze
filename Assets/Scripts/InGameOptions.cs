using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameOptions : MonoBehaviour
{
    bool menuToggled = false;
    [SerializeField]
    GameObject togglePanel;
    GameObject marble;
    GameObject controller;

    void Start()
    {
        marble = GameObject.Find("Marble");
        controller = GameObject.Find("Maze + Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!menuToggled)
            {
                Cursor.lockState = CursorLockMode.None;
                controller.GetComponent<RotateMaze>().enabled = false;
                marble.GetComponent<Rigidbody>().freezeRotation = true;
                togglePanel.SetActive(true);
                menuToggled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                controller.GetComponent<RotateMaze>().enabled = true;
                marble.GetComponent<Rigidbody>().freezeRotation = false;
                menuToggled = false;
                togglePanel.SetActive(false);
            }
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
