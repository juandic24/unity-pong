using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CustomSceneManager : MonoBehaviour
{

    //Reference to the panels of the main menu
    [SerializeField] private Transform panelsParent;

    //Reference to the main panel of the menu
    [SerializeField] private GameObject mainPanel;

    //Method when the class is created
    private void OnEnable()
    {
        EscapeToMenuController.OnReturnToMainPanelRequested += ReturnToMainPanel;
    }

    //Method when the class is destroyed
    private void OnDisable()
    {
        EscapeToMenuController.OnReturnToMainPanelRequested -= ReturnToMainPanel;
    }


    // General method to load scenes based on build index
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Returns to the main panel

    public void ReturnToMainPanel()
    {
        // Disable all panels
        foreach (Transform panel in panelsParent)
        {
            panel.gameObject.SetActive(false);
        }

        // Enable main panel
        mainPanel.SetActive(true);
    }

    //Load one specific panel

    public void LoadPanel(GameObject PanelToOpen)
    {
        // Disable all panels
        foreach (Transform panel in panelsParent)
        {
            panel.gameObject.SetActive(false);
        }

        // Enable the requested one
        PanelToOpen.SetActive(true);
    }




    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
