using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///HRPerfL 的摘要说明
/// </summary>
public class HRPerfL
{
    private static readonly IHRPtype iHR = DALFactory.CreateIHRPtype();
	public HRPerfL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public int Insert_HRPerformAssessType(HRPtypeInfo hr)
    {
        return iHR.Insert_HRPerformAssessType( hr);
    }
    public void Delete_HRPerformAssessType(Guid ID)
    {
        iHR.Delete_HRPerformAssessType(ID);
    }
    public DataSet Search_HRPerformAssessType(string HRPAT_Type)
    {
        return iHR.Search_HRPerformAssessType(HRPAT_Type);
    }
    public int Update_HRPerformAssessType(HRPtypeInfo hr)
    {
        return iHR.Update_HRPerformAssessType(hr);
    }
    public int Update_HRPerformAssessType_Person(HRPtypeInfo hr)
    {
        return iHR.Update_HRPerformAssessType_Person(hr);
    }
    public void Delete_HRPerformAssessType_HRDDetail(Guid ID)
    {
        iHR.Delete_HRPerformAssessType_HRDDetail(ID);
    }
    public int Insert_HRPerformAssessType_HRDDetail(Guid HRDD_ID, Guid HRPAT_ID)
    {
        return iHR.Insert_HRPerformAssessType_HRDDetail(HRDD_ID,HRPAT_ID);
    }
    public IList<HRPtypeInfo> SearchByID_HRPerformAssessType(Guid HRPAT_ID)
    {
        return iHR.SearchByID_HRPerformAssessType(HRPAT_ID);
    }
}