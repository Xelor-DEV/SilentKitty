using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [BoxGroup("Managers")]
    [SerializeField] private UIManager uiManager;

    [BoxGroup("Managers")]
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        LoadAudioConfig();
    }
    public void LoadScene(string sceneName)
    {
        DOTween.KillAll();
        SaveAudioConfig();
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SaveAudioConfig()
    {
        if (uiManager != null && audioManager != null)
        {
            audioManager.AudioConfig.MusicVolume = uiManager.MusicSlider.value;
            audioManager.AudioConfig.SfxVolume = uiManager.SfxSlider.value;
            audioManager.AudioConfig.MasterVolume = uiManager.MasterSlider.value;
        }
        else
        {
            Debug.Log("No existe un UIManager ni un AudioManager");
        }
    }

    public void LoadAudioConfig()
    {
        if (uiManager != null && audioManager != null)
        {
            uiManager.MusicSlider.value = audioManager.AudioConfig.MusicVolume;
            uiManager.SfxSlider.value = audioManager.AudioConfig.SfxVolume;
            uiManager.MasterSlider.value = audioManager.AudioConfig.MasterVolume;
            audioManager.SetVolumeOfMusic(uiManager.MusicSlider);
            audioManager.SetVolumeOfSfx(uiManager.SfxSlider);
            audioManager.SetVolumeOfMaster(uiManager.MasterSlider);
        }
        else
        {
            Debug.Log("No existe un UIManager ni un AudioManager");
        }
    }
}
