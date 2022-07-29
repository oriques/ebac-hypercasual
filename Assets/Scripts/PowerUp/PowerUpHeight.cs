using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeight : PowerUpBase
{

    [Header("Power Up Height")]
    public float amoutHeight = 2;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void PowerUpStart()
    {
        base.PowerUpStart();
        PlayerController.Instance.ChangeHeight(amoutHeight, PowerUpDuration, animationDuration, ease);

    }



}
