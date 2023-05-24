using DG.Tweening;
using UnityEngine;

public class AlarmVisualController : MonoBehaviour
{
    [SerializeField] private AlarmController _alarmController;
    [SerializeField] private SpriteRenderer _alarmSpriteRenderer;
    [SerializeField] private AudioSource _alarmSound;
    
    private Tweener _tweener;

    private void OnEnable()
    {
        _alarmController.OnHouseEntered += StartAlarm;
        _alarmController.OnHouseExited += StopAlarm;
    }

    private void OnDisable()
    {
        _alarmController.OnHouseEntered -= StartAlarm;
        _alarmController.OnHouseExited -= StopAlarm;
    }

    private void Start()
    {
        _alarmSound.volume = 0.0f;
        _alarmSpriteRenderer.color = Color.white;
    }

    private void StopAlarm(object sender, System.EventArgs e)
    {
        if (_tweener != null)
            _tweener.Kill();

        _alarmSpriteRenderer.color = Color.white;
        _alarmSound.DOFade(0f, 1f).OnComplete(StopAlarmSound);
    }

    private void StartAlarm(object sender, System.EventArgs e)
    {
        _alarmSound.Play();
        _alarmSound.DOFade(1f, 4f);
        _tweener = _alarmSpriteRenderer.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void StopAlarmSound()
    {
        _alarmSound.Stop();
    }
}
