using DG.Tweening;
using UnityEngine;

public class AlarmVisual : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AudioSource _sound;
    
    private Tweener _tweener;

    private void OnEnable()
    {
        _alarm.BrokeIntoHouse += Manage;
    }

    private void OnDisable()
    {
        _alarm.BrokeIntoHouse -= Manage;
    }

    private void Start()
    {
        _sound.volume = 0.0f;
        _spriteRenderer.color = Color.white;
    }

    private void Manage(bool isEntered)
    {
        if (isEntered)
            Begin();
        else
            Stop();
    }

    private void Stop()
    {
        if (_tweener != null)
            _tweener.Kill();

        _spriteRenderer.color = Color.white;
        _sound.DOFade(0f, 1f).OnComplete(StopSound);
    }

    private void Begin()
    {
        _sound.Play();
        _sound.DOFade(1f, 4f);
        _tweener = _spriteRenderer.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void StopSound()
    {
        _sound.Stop();
    }
}
