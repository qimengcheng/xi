using System;
using System.Data;
using System.Collections.Generic;


public interface INewEmpInfoAdd
{
    bool Delete_NETraInfoMainTable(Guid NETIMT_ID);
    bool Delete_NETraItemChooseTable(Guid NETICT_ID);
    bool Delete_NETraPeopleChooseTable(Guid NETPCT_ID);
    int Insert_NETraInfoMainTable(NewEmpInfoAddInfo neiai);
    int Insert_NETraItemChooseTable(NewEmpInfoAddInfo neiai);
    int Insert_NETraPeopleChooseTable(NewEmpInfoAddInfo neiai);
    DataSet Search_ByCondition_ForNETraPeopleChooseTable(string Condition);
    DataSet Search_ByCondition_NETraPeopleChooseTable(string Condition);
    DataSet Search_NETraInfoMainTable(string Condition);
    DataSet Search_NETraItemChooseTable(string Condition);
    DataSet Search_ForChoose_NETraItemChooseTable(string Condition);
    IList<NewEmpInfoAddInfo> SearchByID_NETraInfoMainTable(Guid NETIMT_ID);
    int Update_ForEdit_NETraInfoMainTable(NewEmpInfoAddInfo neiai);
    int Update_ForSubmit_NETraInfoMainTable(NewEmpInfoAddInfo neiai);
    DataSet Search_NETraItemChooseTable_NETrainingItem_BD(string Condition);
    DataSet Search_NETraItemChooseTable_NETraPeopleChooseTable_HRDDetail(string Condition);
    DataSet Search_ForTeacher_HRDDetail(string Condition);
    int Update_ForTeacher_NETraItemChooseTable(NewEmpInfoAddInfo neiai);

    DataSet Search_NETraItemChooseTable_NETraEachItemResultDetail(string Condition);
    DataSet Search_ForPeopleChoose_NETraItemChooseTable(string Condition);
    int Insert_NETraEachItemResultDetail(NewEmpInfoAddInfo neiai);
    int Update_ForStateChange_NNETraInfoMainTable(NewEmpInfoAddInfo neiai);
    int Update_ForTime_NETraItemChooseTable(NewEmpInfoAddInfo neiai);

}
