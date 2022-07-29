using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up Speed")]
    public float amoutToSpeed;

    protected override void PowerUpStart()
    {
        base.PowerUpStart();

        PlayerController.Instance.SetPowerUpText("Speed Up");
        PlayerController.Instance.PowerUpSpeedUp(amoutToSpeed);
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.ResetSpeed();
    }

}

