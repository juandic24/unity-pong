using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

    
    //Static reference to current instance
    public static GameController Instance { get; private set; }

    [SerializeField] private DifficultyLevel difficulty;
    [SerializeField] private GameMode gameMode;

    

    
    //Method when the class is created
    private void OnEnable()
    {
        UIManager.DifficultyChangeRequested += OnDifficultyChanged;
        UIManager.GameModeChangeRequested += OnGameModeChanged;
    }

    //Method when the class is destroyed
    private void OnDisable()
    {
        UIManager.DifficultyChangeRequested -= OnDifficultyChanged;
        UIManager.GameModeChangeRequested -= OnGameModeChanged;
    }

    public DifficultyLevel Difficulty

    {
        get => difficulty;
        set
        {
            difficulty = value;
        }
    }

     public GameMode GameMode
    {
        get => gameMode;
        set
        {
            gameMode = value;
        }
    }


    //Method to stay awake the instance

    private void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // If not, set instance to this
            Instance = this;
        }
        else if (Instance != this)
        {
            // If instance already exists and it's not this, then destroy this to enforce the singleton.
            Destroy(gameObject);
        }
        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void OnDifficultyChanged(DifficultyLevel difficulty)
    {
        this.difficulty = difficulty;
    }

    public void OnGameModeChanged(GameMode gameMode)
    {
        this.gameMode = gameMode;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
