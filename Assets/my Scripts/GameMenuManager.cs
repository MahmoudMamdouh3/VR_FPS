using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject gameManager; // The spawner
    
    [Header("Menu Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    void Start()
    {
        // Pause the game when it starts
        gameManager.SetActive(false); 
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        gameManager.SetActive(true); // Starts the spawner
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

    // Changes the global game volume
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; 
    }

    public void RestartGame()
    {
        // Reloads the entire scene instantly
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    
    public void ExitGame()
    {
        // This closes the app when built as an APK or EXE
        Application.Quit(); 
        
        // This just prints a message in the Unity Editor so you know the button works
        Debug.Log("Game is exiting!"); 
    }
}