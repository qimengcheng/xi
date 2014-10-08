using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///IHRDDetail 的摘要说明
/// </summary>
public interface IHRDDetail
{
    int Insert_HRDDetail(HRDDetailInfo hr);
    int Update_HRDDetail(HRDDetailInfo hr);
    void Delete_HRDDetail(Guid ID);
    DataSet Search_HRDDetail(string condition);
    DataSet SearchByID_HRDDetail_Type_Post(Guid HRDD_ID);
    DataSet SearchDdl_HRDDetail_BDOrganizationSheet();
    DataSet SearchDdl_HRDDetail(string BDOS_Code);
    DataSet SearchDdl_HRDDetail_HREmployeeType();
    IList<HRDDetailInfo> SearchByIDPart_HRDDetail(Guid HRDD_ID);
    int Insert_HRPersonnelChangesRecord(HRDDetailInfo hr);
    DataSet Search_HRPersonnelChangesRecord(Guid HRDD_ID);
    IList<HRDDetailInfo> SearchByIDPartForSalary_HRDDetail(Guid HRDD_ID);
    int Insert_HRSalaryRecord(HRDDetailInfo hr);
    DataSet Search_HRSalaryRecord(Guid HRDD_ID);
    //离职相关
    int Update_HRDDetail_Quit(HRDDetailInfo hr);
    void Delete_HRDDetail_Quit(Guid ID);
    DataSet Search_HRDDetail_Quit(string condition);
    DataSet SearchByID_HRDDetail_Type_Post_Quit(Guid HRDD_ID);
    //奖惩相关
    int Insert_HRRewardsPublishment(HRDDetailInfo hr);
    int Update_HRRewardsPublishment(HRDDetailInfo hr);
    void Delete_HRRewardsPublishment(Guid HRRewards_ID);
    DataSet Search_HRRewardsPublishment(string condition);

    int Update_HRDDetail_Worklength();
    DataSet Search_HRDDetail_Type_Post_Senior(string condition);
}