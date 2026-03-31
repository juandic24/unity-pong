using UnityEngine;
using UnityEngine.SceneManagement; // Para detectar cambios de escena

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Clips por Escena")]
    public AudioClip MainMenuMusic;
    public AudioClip GameSceneMusic;
    
    [Header("SFX")]
    public AudioClip uiClickSound;

    // Agrega aquí más clips según tus escenas

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Suscribirse al evento de cambio de escena
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Este método se llama automáticamente cuando se carga cualquier escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cambiar música según el nombre de la escena
        switch (scene.name)
        {
            case "MainMenuScene":
                PlayMusic(MainMenuMusic);
                break;
            case "GameScene":
                PlayMusic(GameSceneMusic);
                break;
            default:  
                break;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip != music)
        {
            musicSource.clip = music;
            musicSource.Play();
        }

        musicSource.loop = true;
    }

    public void PlayUIClick()
    {
        PlaySFX(uiClickSound);
    }



    private void OnDestroy()
    {
        // Evitar fugas de memoria al desuscribirse
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

