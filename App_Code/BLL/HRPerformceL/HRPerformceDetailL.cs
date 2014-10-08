using System;
using System.Data;

/// <summary>
///HRPerformceDetailL 的摘要说明
/// </summary>
public class HRPerformceDetailL
{
    private static readonly IHRPerformceDetail iHR = DALFactory.CreatIHRPerformceDetail();
	public HRPerformceDetailL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_HRPerformceDetail(HRPerformceDetailInfo hr)
    {
        return iHR.Insert_HRPerformceDetail(hr);
    }
    public int Insert_HRPerformceDetail_HRDD_ID(Guid HRDD_ID, string HRPD_APerson, DateTime HRPD_Atime)
    {
        return iHR.Insert_HRPerformceDetail_HRDD_ID(HRDD_ID, HRPD_APerson, HRPD_Atime);
    }
    public DataSet Search_HRPerformAssessType_HRDDetail_HRPerformceDetail(string condition)
    {
        return iHR.Search_HRPerformAssessType_HRDDetail_HRPerformceDetail(condition);
    }
    public int Update_HRPerformceDetail(HRPerformceDetailInfo hr)
    {
        return iHR.Update_HRPerformceDetail(hr);
    }
    public int Update_HRPerformceDetail_CHECK(HRPerformceDetailInfo hr)
    {
        return iHR.Update_HRPerformceDetail_CHECK(hr);
    }
    public DataSet Search_HRDDetail_HRPerformceDetail(string condition)
    {
        return iHR.Search_HRDDetail_HRPerformceDetail(condition);
    }

    public DataSet Search_HRPerformceDetail(string condition)
    {
        return iHR.Search_HRPerformceDetail(condition);
    }
}