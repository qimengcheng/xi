using System;
using System.Data;

/// <summary>
///IHRPItemScore 的摘要说明
/// </summary>
public interface IHRPItemScore
{
    DataSet Search_HRDDetail_HRPerformAssessType(string condition);
    int Insert_HRPItemScore(HRPItemScoreInfo hr);
    DataSet Search_HRPerformceItem_HRPerformAssessType_HRPerformceDetail(string condition, Guid ID);
    int Update_HRPItemScore_CHECK(HRPItemScoreInfo hr);
    DataSet Search_HRPItemScore_HRPerformceDetail(Guid HRPD_ID);
    DataSet Search_HRDDetail_HRPerformAssessType_Year(string condition);
}