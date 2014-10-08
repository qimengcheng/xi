using System;
using System.Data;

/// <summary>
///HRPItemScoreL 的摘要说明
/// </summary>
public class HRPItemScoreL
{
    private static readonly IHRPItemScore iHR = DALFactory.CreateIHRPItemScore();
	public HRPItemScoreL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Search_HRDDetail_HRPerformAssessType(string condition)
    {
        return iHR.Search_HRDDetail_HRPerformAssessType(condition);
    }
    public int Insert_HRPItemScore(HRPItemScoreInfo hr)
    {
        return iHR.Insert_HRPItemScore(hr);
    }
    public DataSet Search_HRPerformceItem_HRPerformAssessType_HRPerformceDetail(string condition, Guid ID)
    {
        return iHR.Search_HRPerformceItem_HRPerformAssessType_HRPerformceDetail(condition,ID);
    }
    public int Update_HRPItemScore_CHECK(HRPItemScoreInfo hr)
    {
        return iHR.Update_HRPItemScore_CHECK(hr);

    }
    public DataSet Search_HRPItemScore_HRPerformceDetail(Guid HRPD_ID)
    {
        return iHR.Search_HRPItemScore_HRPerformceDetail(HRPD_ID);
    }
    public DataSet Search_HRDDetail_HRPerformAssessType_Year(string condition)
    {
        return iHR.Search_HRDDetail_HRPerformAssessType_Year(condition);
    }
}