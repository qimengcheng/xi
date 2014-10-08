using System;

/// <summary>
///HRPItemScoreInfo 的摘要说明
/// </summary>
public class HRPItemScoreInfo
{
	public HRPItemScoreInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private Guid hRPIS_ItemID;
    private Guid hRPI_ItemID;
    private Guid hRPD_ID;
    private int hRPIS_ItemScore;
    private int hRPIS_ItemFScore;

    public Guid HRPIS_ItemID
    {
        get { return hRPIS_ItemID; }
        set { hRPIS_ItemID = value; }
    }
    public Guid HRPI_ItemID
    {
        get { return hRPI_ItemID; }
        set { hRPI_ItemID = value; }
    }

    public Guid HRPD_ID
    {
        get { return hRPD_ID; }
        set { hRPD_ID = value; }
    }

    public int HRPIS_ItemScore
    {
        get { return hRPIS_ItemScore; }
        set { hRPIS_ItemScore = value; }
    }
    public int HRPIS_ItemFScore
    {
        get { return hRPIS_ItemFScore; }
        set { hRPIS_ItemFScore = value; }
    }
 
}