using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;
using System;

public enum E_PLAYER { ME, OTHER, AI }
public enum E_CONTROL { JOYSTICK, KEYBOARD }

[Serializable]
public class HObj
{
    public List<GameObject> Objs = new List<GameObject>();
}

[Serializable]
public class HPrefabDic : SerializableDictionary<string, HObj> { }


public class GameInstance : HSingleton<GameInstance>
{
    /// <summary>
    /// 프리펩 모음
    /// </summary>
    public HPrefabDic PrefabDic;

    /// <summary>
    /// 고정프레임 변수
    /// </summary>
    public int nFixedFrame;

    /// <summary>
    /// 게임시작 
    /// </summary>
    public bool bGameStart;

    /// <summary>
    /// 잠시멈춤
    /// </summary>
    public bool bPause;

    /// <summary>
    /// 컨트롤 타입 저장
    /// </summary>
    public E_CONTROL eControlType;


    protected GameInstance() { }

    private void Awake()
    {
        // 고정 프레임 vSync를 꺼야. 
        QualitySettings.vSyncCount = 0;

        // 고정 프레임 값
        Application.targetFrameRate = nFixedFrame;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);

        SetAutoControlType();
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void SetAutoControlType()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.OSXEditor)
        {
            eControlType = E_CONTROL.KEYBOARD;
        }

        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            eControlType = E_CONTROL.JOYSTICK;
        }
    }
    /// <summary>
    /// 프리펩 생성
    /// </summary>
    /// <param name="sType"></param>
    /// <param name="nIndex"></param>
    /// <param name="PosV3"></param>
    /// <returns></returns>
    public GameObject CreatePrefab(string sType,
                                   int nIndex,
                                   Vector3 PosV3,
                                   Vector3 Scalev3,
                                   Quaternion Rot)
    {
        GameObject Prefab = PrefabDic[sType].Objs[nIndex];

        if (Prefab)
        {
            GameObject Obj = Instantiate(Prefab, PosV3, Rot);
            Obj.transform.localScale = Scalev3;
            return Obj;
        }

        return null;
    }


    /// <summary>
    /// 팝업창 띄우기
    /// </summary>
    /// <param name="Parent"></param>
    /// <param name="nType"></param>
    /// <returns></returns>
    public bool CreatePopupLoading(Transform Parent, int nType = 0)
    {
        //HSoundMng.Play(E_SOUNLIST.E_EATBULLET);
        GameObject obj = GameInstance.I.CreatePrefab("POPUP",
                                                       nType,
                                                       Vector3.zero,
                                                       Vector3.zero,
                                                       Quaternion.identity);
        if (obj)
        {
            RectTransform RTM = obj.GetComponent<RectTransform>();
            RTM.parent = Parent;

            RTM.sizeDelta = Vector2.zero;

            RTM.anchoredPosition = Vector2.zero;

            return true;

        }

        return false;

    }
}
