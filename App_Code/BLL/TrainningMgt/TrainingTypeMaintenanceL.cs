using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///TrainingTypeMaintenanceL 的摘要说明
/// </summary>
public class TrainingTypeMaintenanceL
{
    private static readonly ITrainingTypeMaintenance ineia = DALFactory.CreateTrainingTypeMaintenanceD();
    public int Insert_TrainingTypeTable(TrainningTypeMantenanceInfo ttmInfo)
    {
        return ineia.Insert_TrainingTypeTable(ttmInfo);
    }//老员工培训，培训类型维护，新增培训类型

    public int Update_TrainingTypeTable(TrainningTypeMantenanceInfo ttmInfo)
    {
        return ineia.Update_TrainingTypeTable(ttmInfo);

    }//老员工培训，培训类型维护，编辑培训类型

    public void Delete_TrainingTypeTable(Guid ID)
    {
        ineia.Delete_TrainingTypeTable(ID);
    }//老员工培训，培训类型维护，删除培训类型
    public DataSet Search_TrainingTypeTable(string Condition)
    {
        return ineia.Search_TrainingTypeTable(Condition);
    }//老员工培训，培训类型维护，检索培训类型

    public IList<TrainningTypeMantenanceInfo> SearchByID_TrainingTypeTable(Guid TTT_TypeID)
    {
        return ineia.SearchByID_TrainingTypeTable(TTT_TypeID);
    }//老员工培训，培训类型维护，根据ID进行检索
}