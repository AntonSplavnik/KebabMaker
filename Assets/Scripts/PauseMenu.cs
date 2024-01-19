using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;

    void Start()
    {
        // pauseMenuUI.SetActive(false);

            // Make sure the pause menu is initially inactive
            // if (pauseMenuUI != null)
            //     pauseMenuUI.SetActive(false);
            // else
            //     Debug.LogError("PauseMenuCanvas is not assigned in the Inspector!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            // Toggle the pause menu visibility
            TogglePauseMenu();
    }

    void TogglePauseMenu()
    {
        // Toggle the active state of the pause menu
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

        // Pause or resume the game time based on the pause menu state
        Time.timeScale = (pauseMenuUI.activeSelf) ? 0f : 1f;
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
