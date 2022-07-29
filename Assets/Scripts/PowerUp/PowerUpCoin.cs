using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoin : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 9;

    protected override void PowerUpStart()
    {
        base.PowerUpStart();

        PlayerController.Instance.SetPowerUpText("Coin Collector");
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.ChangeCoinCollectorSize(1);

    }

}
