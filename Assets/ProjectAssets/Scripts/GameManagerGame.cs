using UnityEngine;
using System;

public class GameManagerGame : GameManager
{
    static public event Action OnGameModeStart;
    [SerializeField] private LevelData[] levels;
    [SerializeField] private float timeLimit = 120; // Tiempo límite en segundos
    private Timer timer;

    private void OnEnable()
    {
        PlayerController.OnPlayerWin += CompleteLevel;
        PlayerController.OnPlayerWin += UnlockNextLevel;
        /*
        PlayerController.OnPlayerWin += timer.Stop;
        PlayerController.OnPlayerLose +=
        */

    }
    private void OnDisable()
    {
        PlayerController.OnPlayerWin -= CompleteLevel;
        PlayerController.OnPlayerWin -= UnlockNextLevel;

    }
    public void StartGameMode()
    {
        OnGameModeStart?.Invoke();
    }
    private void CompleteLevel()
    {
        LevelData.Status = LevelStatus.Completed;
    }
    private void UnlockNextLevel()
    {
        if(LevelData.LevelNumber + 1 < levels.Length)
        {
            levels[LevelData.LevelNumber + 1].Status = LevelStatus.Unlocked;
        }

    }
}
