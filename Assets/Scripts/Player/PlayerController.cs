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

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
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
           if(!invencible) Endgame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) Endgame();
        }
    }

    private void Endgame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
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
