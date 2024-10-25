using TMPro;
using UnityEngine;

public class TemporaryBox : Box
{
    [SerializeField] private float disappearTime;
    [SerializeField] private TMP_Text timerText;
    private Timer _timer;

    protected override void Awake()
    {
        base.Awake();
        _timer = new Timer(disappearTime);
        _timer.OnTimerUpdate += UpdateTimerUI;
        _timer.OnTimerComplete += DestroyBox;
    }
    protected override void OnEnable()
    {
        GameManagerGame.OnGameModeStart += StartTimer;
    }

    protected override void OnDisable()
    {
        GameManagerGame.OnGameModeStart -= StartTimer;
    }
    public void StartTimer()
    {
        _timer.Start();
    }

    protected override void Update()
    {
        _timer.Update();
    }

    private void UpdateTimerUI(float progress)
    {
        float timeRemaining = disappearTime * (1 - progress);
        timerText.text = timeRemaining.ToString("F2");
    }

    private void DestroyBox()
    {
        Destroy(this.gameObject);
    }
}
