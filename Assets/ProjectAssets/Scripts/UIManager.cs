using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [BoxGroup("Volume Sliders")]
    [SerializeField] private Slider masterSlider;

    [BoxGroup("Volume Sliders")]
    [SerializeField] private Slider musicSlider;

    [BoxGroup("Volume Sliders")]
    [SerializeField] private Slider sfxSlider;
    public Slider MasterSlider
    {
        get
        {
            return masterSlider;
        }
    }
    public Slider MusicSlider
    {
        get
        {
            return musicSlider;
        }
    }
    public Slider SfxSlider
    {
        get
        {
            return sfxSlider;
        }
    }
}
