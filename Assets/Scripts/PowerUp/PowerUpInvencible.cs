using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{

    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.Instance.SetPowerUpText("Invencible");
        PlayerController.Instance.SetInvencible();
    }

    protected override void PowerUpEnd()
    {
        base.PowerUpEnd();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.SetInvencible(false);
    }

}

