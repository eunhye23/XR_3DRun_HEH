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
enum enTCPProtocol
{
	TCP_PROTOCOL_START = -1,
	prCRYPT,
	prZIP,

	prConnectAck,
	prHeroInfoReq,
	prMapUserInfoAck,           // ��ȿ� ���� �ٸ� ���� ������ �޾ƿɴϴ�.
	prLoadEndReq,
	prInHeroInfoAck,            // �ٸ� ������ ��ȿ� ������ �� ���� ������ ����(���� ������ �ʾƿ�)
	prOutHeroInfoAck,           // ��ȿ� �� �������� ����
	prDieReq, prDieAck,                 // prDieReq :�����׾�����

	prAllCellInfoAck,           // ���̼� ���� �ޱ�(�����ؿ�)
	prAllItemInfoAck,           // ������ ���� �ޱ�

	prItemRezenAck,             // ������ ���� ���� �ޱ�

	prEatItemReq, prEatItemAck,                 // ������ �Ծ����� ó�� 

	prCellRezenAck,             // ���̼�, ���帶�μ��� ������ ����
	prEatCellReq, prEatCellAck,             // ���̼� �Ծ����� �ְ�/�ޱ�

	prCreateBulletCellReq, prCreateBulletCellAck,       // �Ѿ˼� ����

	prEatLandMineCellReq, prEatLandMineCellAck,     // ���ڰ� ���̼� �Ծ����� ��Ŷ �ְ�/�ޱ�
	prLandMineSplitAck,         // 10��° ���ڼ� ���� �� ��Ŷ
	prLandMineBulletCellReq, prLandMineBulletCellAck,    // ���ڼ� �Ѿ� ����� ��Ŷ �ְ�/�ޱ�

	prCageStartAck,             // �پ� ��� ����
	prCageEndAck,               // ������

	// [8_19 �Դ��߰�]
	prCollLandMineCellReq,      //
	prCollLandMineCellAck,      //

	TCP_PROTOCOL_END,
};

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
enum enUDPProtocol
{
	udpCryp = -100,

	UDP_PROTOCOL_START = 0,

	/// <summary>
	/// Ȧ ��Ī ��Ŷ
	/// </summary>
	udpStartReq, udpStartAck,


	/// <summary>
	/// ��Ʈ ������Ʈ�� ��Ŷ
	/// </summary>
	udpUpdatePort,

	UDP_PROTOCOL_END,
};

/// <summary> 
/// UDP��� 
/// </summary> 
[Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
public struct stUDPHeader
{
	/// <summary> 
	/// ��Ŷ ���� ���� ���� 
	/// </summary> 
	[MarshalAs(UnmanagedType.I4)]
	public int iCount;

	[MarshalAs(UnmanagedType.I4)]
	public int iID;

	[MarshalAs(UnmanagedType.I4)]
	public int iLength;

	/// <summary> 
	/// iCount+iLength+iID 
	/// </summary> 
	[MarshalAs(UnmanagedType.I4)]
	public int iCheckSum;

	/// <summary> 
	/// �ڽ��� ���� ���̵� 
	/// </summary> 
	[MarshalAs(UnmanagedType.I4)]
	public int UID;

	/// <summary> 
	/// 0 : �� ���� �ٺ��� 
	/// -100 : �� ���� �ٺ��� 
	/// </summary> 
	[MarshalAs(UnmanagedType.I4)]
	public int TID;

	[MarshalAs(UnmanagedType.I4)]
	public int nKey;


	public stUDPHeader(int iCount = 0, int nID = 0, int iLength = 0, int icheckSum = 0, int UID = 0, int TID = 0, int nKey = 0)
	{
		this.iCount = this.iID = this.iLength = this.iCheckSum = 0;
		this.UID = 0;
		this.TID = 0;
		this.nKey = 0;
	}

	public void SetHeader(int id, int len, int tid = 0)
	{
		iCount = 0;
		iID = id;
		iLength = len;
		iCheckSum = iCount + iID + iLength;
		UID = 0;
		TID = tid;

		nKey = 0;
	}
};