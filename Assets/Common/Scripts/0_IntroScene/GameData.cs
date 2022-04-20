using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;
using System.Text;
using System.Runtime.InteropServices;
using System;

[Serializable]
public class HPlayerInfo
{
    /// <summary>
    /// 서버에서 받은 로그인 아이디! 혹은 내가 입력한 아이디
    /// </summary>
    public string sID;

    /// <summary>
    /// 서버에서 받은 실제 유저 구분 아이디
    /// </summary>
    public int nUID;

    /// <summary>
    /// 선택한 캐릭터 정보
    /// </summary>
    public short nPlayerType;

    public int nResult;

    public int nFirst;

    public string sOTP;

    /// <summary>
    /// 플레이어 처음 스폰 위치
    /// </summary>
    public Vector3 SpawnVec3;

    /// <summary>
    /// 이 플레이어가 , 나냐? 너냐? AI 냐
    /// </summary>    
    public E_PLAYER ePlayer;

    public void Init()
    {
        sID = string.Empty;
        nUID = 0;
        nPlayerType = 0;
        nResult = 0;
        nFirst = 0;
        sOTP = string.Empty;
        SpawnVec3 = Vector3.zero;
        ePlayer = E_PLAYER.ME;
    }

    void Start()
    {

    }

    public object Clone()
    {
        HPlayerInfo playerInfo = new HPlayerInfo();

        playerInfo.sID = sID;
        playerInfo.nUID = nUID;
        playerInfo.nPlayerType = nPlayerType;
        playerInfo.nResult = nResult;
        playerInfo.nFirst = nFirst;
        playerInfo.sOTP = sOTP;
        playerInfo.SpawnVec3 = SpawnVec3;
        playerInfo.ePlayer = ePlayer;

        return playerInfo;
    }
}
/// <summary>
/// 서버에서 받은 플레이어 정보 저장 클래스
/// </summary>
[Serializable]
public class GameData : MonoBehaviour
{

    [Header("[서버접속]")]
    [Space(10f)]
    /// <summary>
    /// TCP 연결 아이피
    /// </summary>
    public string sTCPIp;

    /// <summary>
    /// TCP연결포트
    /// </summary>
    public int nTCPPort;

    /// <summary>
    /// UDP 통신할 포트를 서버에서 받아 저장합니다.
    /// 이놈 못 받으면 클라이언트끼리 통신이 안되요! "명심"
    /// </summary>
    public int nUDPPort;

    [Header("[유저정보]")]
    [Space(4f)]
    public HPlayerInfo PlayerInfo;

}
