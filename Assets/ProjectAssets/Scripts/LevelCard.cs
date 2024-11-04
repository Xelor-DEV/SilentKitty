using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCard : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private Image levelImage;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Sprite[] statusSprites; // 0: Bloqueado, 1: Desbloqueado, 2: Completado
    [SerializeField] private Button levelButton;

    private GameManagerMainMenu gameManager;

    public GameManagerMainMenu GameManager
    {
        set
        {
            gameManager = value;
        }
    }

    private void Start()
    {
        SetLevelCardUI();

        // Asigna el método OnClickLevel a la acción del botón
        levelButton.onClick.AddListener(OnClickLevel);
    }

    private void SetLevelCardUI()
    {
        levelText.text = (levelData.LevelNumber + 1).ToString();

        switch (levelData.Status)
        {
            case LevelStatus.Locked:
                levelImage.sprite = statusSprites[0];
                levelText.text = "";
                break;

            case LevelStatus.Unlocked:
                levelImage.sprite = statusSprites[1];
                break;

            case LevelStatus.Completed:
                levelImage.sprite = statusSprites[2];
                break;
        }
    }

    private void OnClickLevel()
    {
        // Llama al método del GameManager para configurar el nivel actual
        if (gameManager != null)
        {
            gameManager.SetLevelData(levelData);
        }
    }
}
