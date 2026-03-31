using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    private DifficultyLevel difficulty;
    private GameMode gameMode;

    public static event Action<DifficultyLevel> DifficultyChangeRequested;
    public static event Action<GameMode> GameModeChangeRequested;


    public void OnDifficultyChanged(int index)
    {

        difficulty = (DifficultyLevel)index;
        DifficultyChangeRequested?.Invoke(difficulty);
    }

     public void OnGamemodeChanged(int index)
    {

        gameMode = (GameMode)index;
        GameModeChangeRequested?.Invoke(gameMode);
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
