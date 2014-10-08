using System;
using System.Collections.Generic;
using System.Data;
public interface ITrainningMonthPlanD
{
    void Delete_PeopleIn_TrainingEachEmRecord(Guid ID);
    void Delete_OutOfYearPlan_TrainingItemDetail(Guid ID);
    int Insert_OutOfYearPlan_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo);
    int Insert_TrainingEachEmRecord(TrainningMonthPlanInfo ttmInfo);
    DataSet Search_ForArrange_TrainingItemDetail(string Condition);
    DataSet Search_ForBindDdlInsertYear();
    DataSet Search_ForEmpChoose_HRDDetail(string Condition);
    DataSet Search_HasInEmpChoose_HRDDetail(string Condition);
    int Update_ForArrange_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo);
    int Update_ForSave_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo);
    IList<TrainningMonthPlanInfo> SearchByID_ForArrange_TrainingItemDetail(Guid TID_ID);
    DataSet Search_HRDDetail_TrainingEachEmRecord(string Condition);
    int Update_ForScore_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo);
    int Update_ForScore_TrainingEachEmRecord(TrainningMonthPlanInfo ttmInfo);
    void Update_ForUP_TrainingItemDetail(Guid TID_ID, string TID_ResourceName, string TID_ResourceRoute);
    void Delete_ForDeleteFile_TrainingItemDetail(Guid TID_ID);
    DataSet Search__TrainingEachEmRecord(Guid TID_ID);
}
