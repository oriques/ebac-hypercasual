using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;
using TMPro;
using DG.Tweening;


public class PlayerController : Singleton<PlayerController>
{
    //publics
    [Header ("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;
    public bool invencible;

    [Header("Coin Collector")]
    public GameObject coinCollector;

    [Header("Animaton")]
    public AnimatorManager animatorManager;

    [SerializeField] private BounceHelper _bounceHelper;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    public void Bounce()
    {
        if(_bounceHelper != null)
            _bounceHelper.Bounce();
    } 
    
    public void GrowPlayer()
    {
        if(_bounceHelper != null)
            _bounceHelper.GrowPlayer();
    }
    
    void Update()
    {
        if (!_canRun) return;


        _pos = target.position;
       _pos.y = transform.position.y;
       _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible)
            {
                MoveBack();
                Endgame(AnimatorManager.AnimationType.DEAD);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) Endgame();
        }
    }

    private void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative();            
    }

    private void Endgame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
        GrowPlayer();
    }

    #region POWERUPS

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp (float f)
    {
        _currentSpeed = f;
    }
  public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight (float amount, float PowerUpDuration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), PowerUpDuration);
    }
    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f); 
    }

    public void ChangeCoinCollectorSize(float amount )
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
