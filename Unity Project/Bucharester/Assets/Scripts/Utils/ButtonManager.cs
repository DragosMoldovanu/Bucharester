using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main 1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("The End");
    }

    public void OpenSettings()
    {
        panel.SetActive(true);
    }

    public void CloseSettings()
    {
        panel.SetActive(false);
    }

    public void OpenClose()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
