using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EscapeToMenuController : MonoBehaviour
{
     //Static reference to current instance
    public static EscapeToMenuController instance;

    public static event Action OnReturnToMainPanelRequested;


    private void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        else if (instance != this)
        {
            // If instance already exists and it's not this, then destroy this to enforce the singleton.
            Destroy(gameObject);
        }
        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

   private void Update()
    {
        // If the user didnt press a key yet
        if (Keyboard.current == null)
        {
            return;
        }

        // If the user press "esc"
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {   
                //If the scene is not the main menu
                if (SceneManager.GetActiveScene().buildIndex != 0)
                    {
                        //Load the menu
                        LoadScene(0);
                    }
                else //Call event to open main panel
                {
                    OnReturnToMainPanelRequested?.Invoke();
                }
            }
    }
    
    // General method to load scenes based on build index
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
