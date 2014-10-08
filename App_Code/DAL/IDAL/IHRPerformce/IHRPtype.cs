using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///IHRPtype 的摘要说明
/// </summary>
public interface IHRPtype
{
    int Insert_HRPerformAssessType(HRPtypeInfo hr);
    void Delete_HRPerformAssessType(Guid ID);
    DataSet Search_HRPerformAssessType(string HRPAT_Type);
    int Update_HRPerformAssessType(HRPtypeInfo hr);
    int Update_HRPerformAssessType_Person(HRPtypeInfo hr);
    void Delete_HRPerformAssessType_HRDDetail(Guid ID);
    int Insert_HRPerformAssessType_HRDDetail(Guid HRDD_ID, Guid HRPAT_ID);
    IList<HRPtypeInfo> SearchByID_HRPerformAssessType(Guid HRPAT_ID);
}