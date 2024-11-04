using UnityEngine;

public class GameManagerMainMenu : GameManager
{
    protected override void Start()
    {
        base.Start();
        ResetLevelData();
    }
    public void SetLevelData(LevelData selectedLevel)
    {
        LevelData.LevelNumber = selectedLevel.LevelNumber;
        LevelData.Status = selectedLevel.Status;
        LevelData.InitialPosition = selectedLevel.InitialPosition;
        uiManager.UpdateLevelButton(LevelData);
    }
    public void ResetLevelData()
    {
        LevelData.LevelNumber = 0;
        LevelData.Status = LevelStatus.Locked;
        LevelData.InitialPosition = Vector2.zero;
    }

}
