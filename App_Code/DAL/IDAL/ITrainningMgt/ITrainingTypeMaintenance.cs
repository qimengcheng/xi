using System;
using System.Collections.Generic;
using System.Data;

public interface ITrainingTypeMaintenance
{
    void Delete_TrainingTypeTable(Guid ID);
    int Insert_TrainingTypeTable(TrainningTypeMantenanceInfo ttmInfo);
    DataSet Search_TrainingTypeTable(string Condition);
    IList<TrainningTypeMantenanceInfo> SearchByID_TrainingTypeTable(Guid TTT_TypeID);
    int Update_TrainingTypeTable(TrainningTypeMantenanceInfo ttmInfo);
}
