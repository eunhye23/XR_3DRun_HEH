using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Runtime.InteropServices;
using UnityEngine.UI;

public class IntroSecne : MonoBehaviour
{
    // 로딩바 슬라이더
    public Slider LoadingBarSlider;

    private float fSliederValue;
    public float fScrollSpeed;

    void Start()
    {

    }

    void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        fSliederValue += fScrollSpeed * Time.deltaTime;

        LoadingBarSlider.value = Mathf.Lerp(LoadingBarSlider.value, 
                                            fSliederValue, Time.deltaTime * 1.0f);

        if (LoadingBarSlider.value >= 1.0f)
            Invoke("NextScene", 0.5f);
    }

    private void NextScene()
    {
        SceneManager.LoadScene("2_LobbyScene");
    }

    public void OnDstroy()
    {
        //CancelInvoke("UpdateSlider");
    }

}