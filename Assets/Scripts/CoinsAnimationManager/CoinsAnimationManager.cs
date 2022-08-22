using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ecco.Core.Singleton;
using DG.Tweening;


public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> itens;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;


    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
      
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartAnimation();
        }
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!itens.Contains(i))
        { 
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimation()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }
        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(

            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }

}
