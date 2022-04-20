using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
//using DG.Tweening;

public class LobbyScene : HSingleton<LobbyScene>


//HSingleton<LobbyScene>
{
    protected LobbyScene() { }

    public RectTransform CanvasTM;

    public GameObject OptionPanel;

    /// <summary>
    /// 플레이어 콜렉션
    /// </summary>
    public Player_Collection HeroCollection;

    /// <summary>
    /// 케마라 저장 변수
    /// </summary>
    public Camera cam;

    /// <summary>
    /// 카메라목적지 이동
    /// </summary>
    public Vector3 DestCamPosV3;



    private void Awake()
    {
        DestCamPosV3 = cam.transform.position;
    }


    void Start()
    {
        GotoIntroScene();
    }

    /// <summary>
    /// 로고씬으로 가기^^^ 고고싱
    /// </summary>
    private void GotoIntroScene()
    {
       //if (GameObject.Find("GameInstance") == null)
       //    SceneManager.LoadScene("1_LoginScene");
    }

    void Update()
    {
        //=====================================================================================
        // 마우스 클릭 위치로 카메라 이동
        //=====================================================================================

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 CurrentPositionVec3 = transform.position;
            Vector3 HitRotVec3 = Vector3.zero;
            Vector3 RealTimeMousePosv2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(RealTimeMousePosv2);

            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                //Debug.Log(hit.transform.name);

                int nIndex = Int32.Parse(hit.transform.name);

                DestCamPosV3 = HeroCollection.OffsetList[nIndex].transform.position;

                HeroCollection.EnablePlayer(nIndex);

                // 선택한 캐리터 저장합니다요!
              // GameInstance.I.GData.PlayerInfo.nPlayerType = (short)nIndex;
              // Debug.Log(GameInstance.I.GData.PlayerInfo.nPlayerType);

                //HSoundMng.Play(E_SOUNLIST.E_SHOTBULLET);
            }
        }

        cam.transform.position = Vector3.Lerp(cam.transform.position, DestCamPosV3, 10f * Time.deltaTime);

    }
    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================


    /// <summary>
    /// 게임씬으로고고싱
    /// </summary>
    public void GotoGameScene()
    {
        //HSoundMng.Play(E_SOUNLIST.E_SHOTBULLET);

        if (GameInstance.I.CreatePopupLoading(CanvasTM))
        {
            Debug.Log("개개개개개개개개개");
        }

        Invoke("GotoGameSceneInvoke", 0.5f);
    }

    void GotoGameSceneInvoke()
    {

        SceneManager.LoadScene("3_GameScene");
    }

    public void GoToOptionBtn()
    {
        OptionPanel.SetActive(true);
       
    }
    public void GoToBackBtn()
    {
        OptionPanel.SetActive(false);
        
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
