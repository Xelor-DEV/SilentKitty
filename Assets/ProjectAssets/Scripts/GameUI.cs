using UnityEngine;
using TMPro;

public class GameUI : UIPanelManager
{
    [SerializeField] private TMP_Text timer;
    private GameManagerGame gmGame;
    public GameManagerGame GMGame
    {
        set
        {
            gmGame = value;
        }
    }
    private void OnEnable()
    {
        PlayerController.OnPlayerWin += ShowWinPanel;
        PlayerController.OnPlayerLose += ShowLosePanel;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerWin -= ShowWinPanel;
        PlayerController.OnPlayerLose -= ShowLosePanel;
    }
    public void ShowWinPanel()
    {
        ShowWindow(1);
    }
    public void ShowLosePanel()
    {
        ShowWindow(2);
    }
}
