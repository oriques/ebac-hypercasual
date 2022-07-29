using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollactableBase
{
    [Header("Power Up")]
    public float PowerUpDuration;

    protected override void Oncollect()
    {
        base.Oncollect();
        PowerUpStart();
    }

    protected virtual void PowerUpStart()
    {
        Invoke(nameof(PowerUpEnd), PowerUpDuration);
        Debug.Log("start power up");
    }

    protected virtual void PowerUpEnd()
    {
        Debug.Log("end power up");
    }





}
 