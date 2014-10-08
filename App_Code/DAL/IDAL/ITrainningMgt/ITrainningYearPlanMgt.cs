using System;
using System.Data;

public interface ITrainningYearPlanMgt
{
    void Delete_TrainingItemDetail(Guid ID);
    void Delete_TrainingYPlanMain_TrainingItemDetail(Guid ID);
    int Insert_TrainingItemDetail(TrainningInfo tInfo);
    int Insert_TrainingYPlanMain(TrainningInfo tInfo);
    DataSet Search_OtherTables_TrainingItemDetail(string Condition);
    DataSet Search_TrainingYPlanMain(string Condition);
    int Update_ForSubmit_TrainingYPlanMain(TrainningInfo tInfo);
    int Update_TrainingItemDetail(TrainningInfo tInfo);
}
