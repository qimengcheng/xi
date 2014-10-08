using System;
using System.Data;

/// <summary>
///TrainningYearPlanMgtL 的摘要说明
/// </summary>
public class TrainningYearPlanMgtL
{
    private static readonly ITrainningYearPlanMgt iNET = DALFactory.CreateTrainningYearPlanMgtD();

    public DataSet Search_TrainingYPlanMain(string Condition)
    {
        return iNET.Search_TrainingYPlanMain(Condition);
    }//老员工培训，培训年度计划维护，检索培训年度计划主表


    public int Insert_TrainingYPlanMain(TrainningInfo tInfo)
    {
        return iNET.Insert_TrainingYPlanMain(tInfo);
    }//老员工培训，培训年度计划维护，新增培训年度计划（主表）

    public void Delete_TrainingYPlanMain_TrainingItemDetail(Guid ID)
    {
        iNET.Delete_TrainingYPlanMain_TrainingItemDetail(ID);
    }//老员工培训，培训年度计划维护，删除培训年度计划（主表），同步删除明细表中对应的信息

    public int Insert_TrainingItemDetail(TrainningInfo tInfo)
    {
        return iNET.Insert_TrainingItemDetail(tInfo);
    }//老员工培训，培训年度计划维护，新增培训项目（明细表）

    public int Update_ForSubmit_TrainingYPlanMain(TrainningInfo tInfo)
    {
        return iNET.Update_ForSubmit_TrainingYPlanMain(tInfo);
    }//老员工培训，培训年度计划维护，提交培训年度计划（主表）

    public DataSet Search_OtherTables_TrainingItemDetail(string Condition)
    {
        return iNET.Search_OtherTables_TrainingItemDetail(Condition);
    }//老员工培训，培训年度计划维护，检索年度计划中的培训项目详情

    public int Update_TrainingItemDetail(TrainningInfo tInfo)
    {
        return iNET.Update_TrainingItemDetail(tInfo);
    }//老员工培训，培训年度计划维护，编辑培训项目（明细表）


    public void Delete_TrainingItemDetail(Guid ID)
    {
        iNET.Delete_TrainingItemDetail(ID);
    }//老员工培训，培训年度计划维护，删除培训项目（明细表）

}