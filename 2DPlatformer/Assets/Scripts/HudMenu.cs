using TMPro;
using UnityEngine;

public class HudMenu : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private int _minuteCount;
    private float _secondsCount;

    private void Start()
    {
        gameObject.SetActive(!PauseMenu.IsPaused);
        timerText.text = "0:00";
    }

    private void Update()
    {
        gameObject.SetActive(!PauseMenu.IsPaused);
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        //set timerText UI
        _secondsCount += Time.deltaTime;
        timerText.text = _secondsCount >= 10
            ? $"{_minuteCount}:{(int) _secondsCount}"
            : $"{_minuteCount}:0{(int) _secondsCount}";

        if (!(_secondsCount >= 60)) return;
        _minuteCount++;
        _secondsCount = 0;
    }
}