using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Game/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int levelNumber;
    [SerializeField] private Vector2 initialPosition;
    [SerializeField] private LevelStatus status;
    public int LevelNumber
    {
        get
        {
            return levelNumber;
        }
        set
        {
            levelNumber = value;
        }
    }
    public Vector2 InitialPosition
    {
        get
        {
            return initialPosition;
        }
        set
        {
            initialPosition = value;
        }
    }
    public LevelStatus Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }
}

public enum LevelStatus
{
    Locked,
    Unlocked,
    Completed
}
