using MHomiLibrary;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameScene : HSingleton<GameScene>
{

    protected GameScene() { }

    public bool IsPause = false;

    public GameObject pausePanel;
    public GameObject playerDeadPanel;
    public GameObject OptionPanel;
    public TextMeshProUGUI distance_text;
    public TextMeshProUGUI time_text;

    public GameObject StartTimeImg;

    public float StartdelayT;
    public bool IsStartDelay = false;

    private GameObject player;

    private DateTime startTime;

    private void Awake()
    {
        startTime = DateTime.Now;  
        InvokeRepeating("UpdateTime",0f,  0.01f);
    }
    private void Start() 
    {
        GotoLobbyScene();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z + 12.2f);
        distance_text.text = distance.ToString() + "M";

       
    }
    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    private void UpdateTime()
    {
        //time_text.text = string.Format("{0:mm\\: ss\\}", PlayTime());
        time_text.text = PlayTime().ToString() + "m";
    }
    private TimeSpan PlayTime()
    {
        return DateTime.Now - startTime;
    }
    public void StartDelayTime()
    {
        StartdelayT -= Time.deltaTime * 1f;

        if (StartdelayT > 0)
        {
            IsStartDelay = true;

            StartTimeImg.SetActive(true);
        }
        else if (StartdelayT <= 0)
        {
            IsStartDelay = false;
            StartTimeImg.SetActive(false);
        }


    }

    private void GotoLobbyScene()
    {
        if (GameObject.Find("GameInstance") == null)
            SceneManager.LoadScene("0_IntroScene");
    }

    public void GamePause()
    {
        //gamePause시 공통사항들...sound 등
        IsPause = true;

        Time.timeScale = 0;

    }
    public void PlayerDie()
    {
        print("PlayerDie실행됨");
        GamePause();

     
        playerDeadPanel.SetActive(true);
        //gameover 결과 추가....
    }
    public void GamePauseBtn()
    {
        GamePause();
        pausePanel.SetActive(true);      
    }
    
    public void GoToGameBtn()
    {
        if (IsPause)
        {
            Time.timeScale = 1;
            IsPause = false;
            pausePanel.SetActive(false);
            OptionPanel.SetActive(false);
            return;
        }
    }

    public void GoToReGameBtn()
    {
        IsPause = false;
        Time.timeScale = 1;
        //fade in fade out? 넣어야할듯 , UI초기화도 필요
        SceneManager.LoadScene("2_LobbyScene");  //3_GameScene
        
    }

    public void GoToOptionBtn()
    {
        OptionPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GoToBackBtn()
    {
        OptionPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void GoToQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
  

}
