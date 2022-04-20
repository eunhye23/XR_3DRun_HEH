using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;


public class HTweenRot : MonoBehaviour
{
    public RectTransform RTM;
    public Transform TM;

    public Vector3 RotVec3;
    public float fSpeed;

    public bool IsCanvas;
    void Start()
    {
        if(IsCanvas)
        {
            RTM.DORotate(RotVec3, fSpeed, RotateMode.FastBeyond360)
              .SetEase(Ease.Linear)
              .SetLoops(-1);

        }
        else
        {
            TM.DORotate(RotVec3, fSpeed, RotateMode.FastBeyond360)
              .SetEase(Ease.Linear)
              .SetLoops(-1);

        }
    }

}


