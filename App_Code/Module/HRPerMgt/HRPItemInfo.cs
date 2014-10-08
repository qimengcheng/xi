using System;

/// <summary>
///HRPItemInfo 的摘要说明
/// </summary>
public class HRPItemInfo
{
	public HRPItemInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private Guid hRPI_ItemID;
    private Guid hRPAT_ID;
    private string hRPI_Items;
    private string hRPI_Contents;
    private string hRPI_StanScore;
    private string hRPI_AssStandard;
    private string hRPI_Remarks;
    private bool hRPI_IsDeleted;

    public Guid HRPI_ItemID
    {
        get { return hRPI_ItemID; }
        set { hRPI_ItemID = value; }
    }
    public Guid HRPAT_ID
    {
        get { return hRPAT_ID; }
        set { hRPAT_ID = value; }
    }

    public string HRPI_Items
    {
        get { return hRPI_Items; }
        set { hRPI_Items = value; }
    }
    public string HRPI_Contents
    {
        get { return hRPI_Contents; }
        set { hRPI_Contents = value; }
    }
    public string HRPI_StanScore
    {
        get { return hRPI_StanScore; }
        set { hRPI_StanScore = value; }
    }

    public string HRPI_AssStandard
    {
        get { return hRPI_AssStandard; }
        set { hRPI_AssStandard = value; }
    }
    public string HRPI_Remarks
    {
        get { return hRPI_Remarks; }
        set { hRPI_Remarks = value; }
    }
    public bool HRPI_IsDeleted
    {
        get { return hRPI_IsDeleted; }
        set { hRPI_IsDeleted = value; }
    }
    public HRPItemInfo(string _hRPI_Items, string _hRPI_Contents,string _hRPI_StanScore,string  _hRPI_AssStandard, string _hRPI_Remarks)
    {
        hRPI_Items = _hRPI_Items;
        hRPI_Contents = _hRPI_Contents;
        hRPI_StanScore = _hRPI_StanScore;
        hRPI_AssStandard = _hRPI_AssStandard;
        hRPI_Remarks = _hRPI_Remarks;
    }
}