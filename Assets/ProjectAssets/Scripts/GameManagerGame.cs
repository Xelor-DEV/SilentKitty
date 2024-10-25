using UnityEngine;
using System;

public class GameManagerGame : GameManager
{
    static public event Action OnGameModeStart;
    public void StartGameMode()
    {
        OnGameModeStart?.Invoke();
    }
}
