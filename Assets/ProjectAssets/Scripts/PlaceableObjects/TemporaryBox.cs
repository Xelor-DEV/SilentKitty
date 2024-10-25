using TMPro;
using UnityEngine;

public class TemporaryBox : Box
{
    [SerializeField] private float disappearTime;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Canvas canvas;
    private Timer _timer;

    protected override void Awake()
    {
        base.Awake();
        _timer = new Timer(disappearTime);
        _timer.OnTimerUpdate += UpdateTimerUI;
        _timer.OnTimerComplete += DestroyBox;
    }
    protected override void Start()
    {
        base.Start();
        timerText.text = disappearTime.ToString();
    }
    protected override void Update()
    {
        _timer.Update();
        KeepTextAligned();
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

    private void UpdateTimerUI(float progress)
    {
        float timeRemaining = disappearTime * (1 - progress);
        timerText.text = timeRemaining.ToString("F0");
    }

    private void KeepTextAligned()
    {
        if (canvas != null)
        {
            canvas.transform.rotation = Quaternion.identity;
        }
    }

    private void DestroyBox()
    {
        Destroy(this.gameObject);
    }
}
