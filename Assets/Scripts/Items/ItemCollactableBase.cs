using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "CoinCollector";
    public ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {

            Collect();
        }
    }

    protected virtual void HideItens()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
    }

    protected virtual void Collect()
    {
        HideItens();
        Oncollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }



    protected virtual void Oncollect()
    {
        if (particleSystem != null) particleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}
