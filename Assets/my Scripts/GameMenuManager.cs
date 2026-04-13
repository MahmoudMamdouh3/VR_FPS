using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [Header("Scripts")]
    public TargetSpawner spawnerScript; // ONLY pause the spawner, not the whole game!
    
    [Header("Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    void Start()
    {
        if (spawnerScript != null) spawnerScript.enabled = false; 
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        if (spawnerScript != null) spawnerScript.enabled = true; 
    }

    // NEW: The Pause/Resume feature!
    public void ToggleMenu()
    {
        // If the menu is hidden, show it and pause the spawner
        if (mainMenuPanel.activeSelf == false)
        {
            mainMenuPanel.SetActive(true);
            settingsPanel.SetActive(false); // Make sure settings isn't open
            if (spawnerScript != null) spawnerScript.enabled = false;
        }
        else // If the menu is showing, hide it and resume the spawner
        {
            mainMenuPanel.SetActive(false);
            if (spawnerScript != null) spawnerScript.enabled = true;
        }
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    
    public void ExitGame()
    {
        Application.Quit(); 
        Debug.Log("Game is exiting!"); 
    }
}