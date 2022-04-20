using System;
using System.Runtime.InteropServices;



//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//------------------------------------[TCP]------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//

#region [TCP 내캐릭터 생성 완료 및 udpStartREQ및 udpStartAck까지 완료되면 보내는 패킷]
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stLoadEndReq
{
	public stHeader Header;
	public stLoadEndReq(stHeader Header)
	{
		this.Header = Header;
		Header.SetHeader((int)enTCPProtocol.prLoadEndReq, Marshal.SizeOf(typeof(stLoadEndReq)));
	}
};
#endregion

#region [TCP 접속시 게임씬에 있는 유저들 정보 받기]

[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stMapUserInfoAck
{
	public stHeader Header;

	[MarshalAs(UnmanagedType.I4)]
	public int nCount;

	[MarshalAs(UnmanagedType.I2)]
	public short nResult;

	[MarshalAs(UnmanagedType.I2)]
	public short CageStatus;

	[MarshalAs(UnmanagedType.I2)]
	public short CageTime;

	[MarshalAs(UnmanagedType.I2)]
	public short CageMinusSize;

	[MarshalAs(UnmanagedType.I2)]
	public short CageCurSize;

	[MarshalAs(UnmanagedType.I2)]
	public short CageMinSize;


	// 구조체 배열 관련 마샬링 정보
	//https://www.sysnet.pe.kr/Default.aspx?mode=2&sub=0&detail=1&pageno=0&wid=11319&rssMode=1&wtype=0
	//https://www.sysnet.pe.kr/Default.aspx?mode=2&sub=0&pageno=39&detail=1&wid=11319
	// 68 은 stHeroInfo의 사이즈 * 8은 갯수
	//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 68 * (int)eMaxZoneUser.MAX_ZONE_USER)]
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public stHeroInfo[] stInfos;

	public stMapUserInfoAck(stHeader Header,
							 int nCount,
							 short nResult,
							 short CageStatus,
							 short CageTime,
							 short CageMinusSize,
							 short CageCurSize,
							 short CageMinSize,
							 stHeroInfo[] stInfos = null)
	{
		this.Header = Header;
		this.nCount = nCount;
		this.nResult = nResult;
		this.CageStatus = CageStatus;
		this.CageTime = CageTime;
		this.CageMinusSize = CageMinusSize;
		this.CageCurSize = CageCurSize;
		this.CageMinSize = CageMinSize;
		this.stInfos = null;

		Header.SetHeader((int)enTCPProtocol.prMapUserInfoAck, Marshal.SizeOf(typeof(stMapUserInfoAck)));
	}
};
#endregion

#region [TCP 내정보 저장 구조체, 서버로 보내요]
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stHeroInfoReq
{
	public stHeader Header;
	public stHeroInfo stHeroInfo;

	public stHeroInfoReq(stHeader Header, stHeroInfo HeroInfo)
	{
		this.Header = Header;
		this.stHeroInfo = HeroInfo;

		Header.SetHeader((int)enTCPProtocol.prHeroInfoReq, Marshal.SizeOf(typeof(stHeroInfoReq)));
	}
};

/// <summary>
/// 주인공 정보
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stHeroInfo
{
	[MarshalAs(UnmanagedType.I4)]
	public int UID;

	[MarshalAs(UnmanagedType.I4)]
	public int nTeam;

	[MarshalAs(UnmanagedType.I2)]
	public short nSlimeSkin;

	[MarshalAs(UnmanagedType.I2)]
	public short nSlimeType;

	[MarshalAs(UnmanagedType.I4)]
	public int nLevel;

	[MarshalAs(UnmanagedType.I4)]
	public int nHP;

	[MarshalAs(UnmanagedType.R4)]
	public float x;

	[MarshalAs(UnmanagedType.R4)]
	public float y;

	/// <summary>
	/// 컨트롤 타임 키보드? 조이스틱?
	/// </summary>
	[MarshalAs(UnmanagedType.I4)]
	public int nControllType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] NickName;

	public stHeroInfo(int UID = -1,
					  int nTeam = 0,
					  short nSlimeSkin = 0,
					  short nSlimeType = 0,
					  int nLevel = 0,
					  int nScore = 0,
					  float x = 0,
					  float y = 0,
					  int nControllType = 0,
					  byte[] NickName = null)
	{
		this.NickName = null;
		this.nTeam = nTeam;
		this.UID = this.nLevel = this.nHP = 0;
		this.nSlimeSkin = this.nSlimeType = 0;
		this.x = 0.0f;
		this.y = 0.0f;
		this.nControllType = nControllType;
		this.NickName = NickName;
	}
};
#endregion

#region [TCP 연결후 서버로 부터 처음 받은 정보]

[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stConnectAck
{
	public stHeader Header;

	[MarshalAs(UnmanagedType.I4)]
	public int UDPPort;

	[MarshalAs(UnmanagedType.I4)]
	public int Index;

	[MarshalAs(UnmanagedType.I8)]
	public Int64 key;

	/// <summary>
	/// 스폰 위치
	/// </summary>
	[MarshalAs(UnmanagedType.I2)]
	public short x;

	/// <summary>
	/// 스폰 위치
	/// </summary>
	[MarshalAs(UnmanagedType.I2)]
	public short y;

	/// <summary>
	/// 팀종류 (solo, A,B,C,D) 이 정보 받아요
	/// </summary>
	[MarshalAs(UnmanagedType.I4)]
	public int nTeam;

	/// <summary>
	/// 플레이어 종류 (0~4)
	/// </summary>
	[MarshalAs(UnmanagedType.I4)]
	public int nPlayerType;

	// 구조체 생성자는 꼭 인자값이 인수 만큼 넣어 줘야 합니다.
	public stConnectAck(stHeader Header,
						int UDPPort = 0,
						int Index = 0,
						Int64 key = 0,
						short x = 0,
						short y = 0,
						int nTeam = 0,
						int nPlayerType = 0)
	{
		this.Header = Header;
		this.UDPPort = UDPPort;
		this.Index = Index;
		this.key = key;
		this.x = x;
		this.y = y;
		this.nTeam = nTeam;
		this.nPlayerType = nPlayerType;

		Header.SetHeader((int)enTCPProtocol.prConnectAck, Marshal.SizeOf(typeof(stConnectAck)));
	}
};

#endregion

#region [ TCP 헤더 ]
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stHeader
{
	[MarshalAs(UnmanagedType.I4)]
	public int iType;

	[MarshalAs(UnmanagedType.I4)]
	public int iID;

	[MarshalAs(UnmanagedType.I4)]
	public int iLength;

	[MarshalAs(UnmanagedType.I4)]
	public int iCheckSum;


	public stHeader(int iType, int iID, int iLength, int iChecksum)
	{
		this.iType = this.iID = this.iLength = this.iCheckSum = 0;
	}

	public void SetHeader(int id, int len)
	{
		//iType = HMng.I.nGamdID;
		iType = 17;
		iID = id;
		iLength = len;
		iCheckSum = iType + iID + iLength;
	}
};
#endregion
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//------------------------------------[UDP]------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//
#region [UDP 기본 패킷 구조체]
/// <summary>
/// 시작 알림
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct udpStartReq_t
{
	public stUDPHeader Header;

	udpStartReq_t(stUDPHeader header)
	{
		this.Header = header;

		this.Header.SetHeader((int)enUDPProtocol.udpStartReq, Marshal.SizeOf(typeof(udpStartReq_t)));
	}
};

/// <summary>
/// 포트번호 받아요.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct udpStartAck_t
{
	public stUDPHeader Header;

	[MarshalAs(UnmanagedType.I4)]
	public int port;
	udpStartAck_t(stUDPHeader header, int nPort = 0)
	{
		this.Header = header;
		this.port = nPort;

		this.Header.SetHeader((int)enUDPProtocol.udpStartAck, Marshal.SizeOf(typeof(udpStartAck_t)));
	}
};
#endregion

