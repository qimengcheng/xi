using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///TrainningMonthPlanL 的摘要说明
/// </summary>
public class TrainningMonthPlanL
{
    private static readonly ITrainningMonthPlanD iNET = DALFactory.CreateITrainningMonthPlanD();

    public DataSet Search_ForArrange_TrainingItemDetail(string Condition)
    {
        return iNET.Search_ForArrange_TrainingItemDetail(Condition);
    }//老员工培训，安排培训计划，检索培训项目详情列表


    public int Update_ForArrange_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
    {
        return iNET.Update_ForArrange_TrainingItemDetail(ttmInfo);

    }//老员工培训，安排培训计划，更新培训项目详情（提交linkbutton）

    public int Update_ForSave_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
    {
        return iNET.Update_ForSave_TrainingItemDetail(ttmInfo);

    }//老员工培训，安排培训计划，保存培训项目详情（保存按钮）

    public int Insert_OutOfYearPlan_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
    {
        return iNET.Insert_OutOfYearPlan_TrainingItemDetail(ttmInfo);
    }//老员工培训，安排培训计划，新增年度计划外的培训(提交按钮)



    public DataSet Search_ForBindDdlInsertYear()
    {
        return iNET.Search_ForBindDdlInsertYear();
    }//老员工培训，安排培训计划，新增年度计划外的培训前，需要绑定Dropdownlist的年份


    public int Insert_TrainingEachEmRecord(TrainningMonthPlanInfo ttmInfo)
    {
        return iNET.Insert_TrainingEachEmRecord(ttmInfo);
    }//老员工培训，安排培训计划，新增参与某次培训项目的培训员工(提交按钮)

    public void Delete_PeopleIn_TrainingEachEmRecord(Guid ID)
    {
        iNET.Delete_PeopleIn_TrainingEachEmRecord(ID);
    }//老员工培训，安排培训计划，删除参与某次培训项目的培训员工(linkbutton)

    public void Delete_OutOfYearPlan_TrainingItemDetail(Guid ID)
    {
        iNET.Delete_OutOfYearPlan_TrainingItemDetail(ID);
    }//老员工培训，安排培训计划，删除年度计划外的培训(删除linkbutton)

    public DataSet Search_ForEmpChoose_HRDDetail(string Condition)
    {
        return iNET.Search_ForEmpChoose_HRDDetail(Condition);
    }//老员工培训，安排培训计划，检索没有参与某次培训项目的培训员工

    public DataSet Search_HasInEmpChoose_HRDDetail(string Condition)
    {
        return iNET.Search_HasInEmpChoose_HRDDetail(Condition);
    }//老员工培训，安排培训计划，检索参与某次培训项目的培训员工

    public IList<TrainningMonthPlanInfo> SearchByID_ForArrange_TrainingItemDetail(Guid TID_ID)
    {

        return iNET.SearchByID_ForArrange_TrainingItemDetail(TID_ID);
    }//老员工培训，安排培训计划，根据ID检索培训项目详情列表


    ///
    ///培训记录录入
    ///

    public DataSet Search_HRDDetail_TrainingEachEmRecord(string Condition)
    {
        return iNET.Search_HRDDetail_TrainingEachEmRecord(Condition);
    }//老员工培训，培训记录录入，检索参与某次培训项目的培训员工

    public int Update_ForScore_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
    {
        return iNET.Update_ForScore_TrainingItemDetail(ttmInfo);

    }//老员工培训，培训记录录入，提交(更新：培训项目明细表)

    public int Update_ForScore_TrainingEachEmRecord(TrainningMonthPlanInfo ttmInfo)
    {
        return iNET.Update_ForScore_TrainingEachEmRecord(ttmInfo);

    }//老员工培训，培训记录录入，提交(更新：各员工培训结果记录表)

    public void Update_ForUP_TrainingItemDetail(Guid TID_ID, string TID_ResourceName, string TID_ResourceRoute)
    {
        iNET.Update_ForUP_TrainingItemDetail(TID_ID,TID_ResourceName,TID_ResourceRoute);
    }//老员工培训，培训记录录入，上传培训课件

    public void Delete_ForDeleteFile_TrainingItemDetail(Guid TID_ID)
    {
        iNET.Delete_ForDeleteFile_TrainingItemDetail(TID_ID);
    }//老员工培训，培训记录录入，删除培训课件

    public DataSet Search__TrainingEachEmRecord(Guid TID_ID)
    {
        return iNET.Search__TrainingEachEmRecord(TID_ID);
    }//老员工培训，培训记录查看
}