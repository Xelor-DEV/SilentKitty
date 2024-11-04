using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject player;
    [SerializeField] private LevelData levelData;
    private void Awake()
    {
        LoadLevel();
    }
    private void LoadLevel()
    {
        for (int i = 0; i < levels.Length; ++i)
        {
            levels[i].SetActive(false);
        }
        levels[levelData.LevelNumber].SetActive(true);
        MovePlayer(levelData.InitialPosition);
    }

    private void MovePlayer(Vector2 newPosition)
    {
        player.transform.position = newPosition;
    }
}
