using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPopup_Loading : HTweenScaleUp
{
    void Start()
    {
        InitDoTween();
        ScaleTweenAnimation();
    }

    void Update()
    {

    }

    private void OnDestroy()
    {
        DestroyDoTween();
    }
}
