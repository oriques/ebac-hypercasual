using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation General")]
    public float scaleDuration = .2f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;
    public int loopTimes = 2;
    public LoopType loopType;

    [Header("Grow Player")]
    public GameObject player;
    public Vector3 size;
    public float durationChange = 1f;
    public Ease easePlayer = Ease.Linear;

    private Vector3 _originalSize;
    private Vector3 _sizeChange;

    private void Start()
    {
        _originalSize = player.transform.localScale;
        _sizeChange = _originalSize + size;
    }
    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(loopTimes, loopType);
    }
    
    public void GrowPlayer()
    {
        player.transform.DOScale(_sizeChange, durationChange).SetEase(easePlayer);
        
       // player.transform.localScale = player.transform.localScale + sizeChange;
    }

}
