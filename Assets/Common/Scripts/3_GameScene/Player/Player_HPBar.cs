using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HPBar : MonoBehaviour
{
    // 슬라이더 컨트롤 변수 
    public Slider HpSlider;

    public void SetMaxHealth(int nMaxValue, int health)
    {
        HpSlider.maxValue = nMaxValue;
        HpSlider.value = health;
    }

    public void SetHealth(int health)
    {
        HpSlider.value = health;
    }
}
