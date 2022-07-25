using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;
using TMPro;


public class ItemManager : Singleton<ItemManager>
{
    
    public SOInt coins;
    public SOInt coinsUltra;
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextCoinsUltra;


    private void Start()
    {
       Reset();
    }
    private void Reset()
    {
        coins.value = 0;
        coinsUltra.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    public void AddCoinsUltra(int amount = 1)
    {
        coinsUltra.value += amount;
        UpdateUI();
    }
    private void UpdateUI()
    {
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
