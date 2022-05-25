using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] panels;

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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("The End");
    }

    public void OpenSettings()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(true);
        }
        
    }

    public void CloseSettings()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    public void OpenClose()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(!panel.activeSelf);
        }
            
    }

    public void OpenInventory()
    {
        foreach (GameObject panel in panels)
        {
            if (!panel.activeSelf)
            {
                panel.SetActive(true);
                transform.parent.GetComponent<InventoryManager>().UpdateInventory();
            }
            else
            {
                panel.SetActive(false);
            }
        }
            
    }
}
