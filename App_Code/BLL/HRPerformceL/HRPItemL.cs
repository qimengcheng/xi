using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///HRPItemL 的摘要说明
/// </summary>
public class HRPItemL
{
    private static readonly IHRPItem iHR = DALFactory.CreateIHRPItem();
	public HRPItemL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_HRPerformceItem(HRPItemInfo hr)
    {
        return iHR.Insert_HRPerformceItem(hr);
    }
    public void Delete_HRPerformceItem(Guid ID)
    {
        iHR.Delete_HRPerformceItem(ID);
    }
    public DataSet Search_HRPerformceItem(string condition)
    {
        return iHR.Search_HRPerformceItem(condition);
    }
    public int Update_HRPerformceItem(HRPItemInfo hr)
    {
        return iHR.Update_HRPerformceItem(hr);
    }
    public IList<HRPItemInfo> SearchByID_HRPItem(Guid HRPI_ItemID)
    {
        return iHR.SearchByID_HRPItem(HRPI_ItemID);
    }
    public DataSet Search_HRPerformceItem_HRPerformAssessType(string condition)
    {
        return iHR.Search_HRPerformceItem_HRPerformAssessType(condition);
    }
}