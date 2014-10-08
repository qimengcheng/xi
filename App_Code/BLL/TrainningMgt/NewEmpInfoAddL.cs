using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///NewEmpInfoAddL 的摘要说明
/// </summary>
public class NewEmpInfoAddL
{
    private static readonly INewEmpInfoAdd ineia = DALFactory.CreateNewEmpInfoAdd();
	public NewEmpInfoAddL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_NETraInfoMainTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Insert_NETraInfoMainTable(neiai);

    }//新增培训信息

    public int Update_ForEdit_NETraInfoMainTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Update_ForEdit_NETraInfoMainTable(neiai);

    }//编辑培训信息

    public bool Delete_NETraInfoMainTable(Guid NETIMT_ID)
    {
        return ineia.Delete_NETraInfoMainTable(NETIMT_ID);
    }//删除培训信息

    public int Update_ForSubmit_NETraInfoMainTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Update_ForSubmit_NETraInfoMainTable(neiai);

    }//提交<编辑>培训信息

    public DataSet Search_NETraInfoMainTable(string Condition)
    {
        return ineia.Search_NETraInfoMainTable(Condition);
    }//根据condition检索NETIMT_State(培训状态)为'已建立'的培训信息

    public IList<NewEmpInfoAddInfo> SearchByID_NETraInfoMainTable(Guid NETIMT_ID)
    {
        return ineia.SearchByID_NETraInfoMainTable(NETIMT_ID);
    }//根据ID检索培训信息,用于取出数据进行编辑

    public int Insert_NETraPeopleChooseTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Insert_NETraPeopleChooseTable(neiai);
    }//新增培训的新员工

    public DataSet Search_ByCondition_ForNETraPeopleChooseTable(string Condition)
    {
        return ineia.Search_ByCondition_ForNETraPeopleChooseTable(Condition);
    }//检索人事档案中的员工（以供选择）

    public DataSet Search_ByCondition_NETraPeopleChooseTable(string Condition)
    {
        return ineia.Search_ByCondition_NETraPeopleChooseTable(Condition);
    }//检索该次培训中的员工

    public bool Delete_NETraPeopleChooseTable(Guid NETPCT_ID)
    {
        return ineia.Delete_NETraPeopleChooseTable(NETPCT_ID);
    }//删除培训的新员工

    public int Insert_NETraItemChooseTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Insert_NETraItemChooseTable(neiai);
    }//新增该次培训的项目

    public DataSet Search_NETraItemChooseTable(string Condition)
    {
        return ineia.Search_NETraItemChooseTable(Condition);
    }//检索该次培训的项目

    public DataSet Search_ForChoose_NETraItemChooseTable(string Condition)
    {
        return ineia.Search_ForChoose_NETraItemChooseTable(Condition);
    }//检索培训的项目

    public bool Delete_NETraItemChooseTable(Guid NETICT_ID)
    {
        return ineia.Delete_NETraItemChooseTable(NETICT_ID);
    }//删除该次培训的某个项目

    public DataSet Search_NETraItemChooseTable_NETrainingItem_BD(string Condition)
    {
        return ineia.Search_NETraItemChooseTable_NETrainingItem_BD(Condition);
    }//检新员工培训主讲人指定，检索培训项目列表

    public DataSet Search_NETraItemChooseTable_NETraPeopleChooseTable_HRDDetail(string Condition)
    {
        return ineia.Search_NETraItemChooseTable_NETraPeopleChooseTable_HRDDetail(Condition);
    }//新员工培训主讲人指定，检索该次培训的某个项目的培训人员

    public DataSet Search_ForTeacher_HRDDetail(string Condition)
    {
        return ineia.Search_ForTeacher_HRDDetail(Condition);
    }//新员工培训主讲人指定，检索所有的主讲人

    public int Update_ForTeacher_NETraItemChooseTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Update_ForTeacher_NETraItemChooseTable(neiai);

    }//新员工培训主讲人指定，安排(更新表中字段)主讲人



    /// <summary>
    /// 新员工培训结果录入
    /// </summary>
    /// <param name="Condition"></param>
    /// <returns></returns>
    public DataSet Search_NETraItemChooseTable_NETraEachItemResultDetail(string Condition)
    {
        return ineia.Search_NETraItemChooseTable_NETraEachItemResultDetail(Condition);
    }//新员工培训结果录入，检索新员工培训项目列表

    public DataSet Search_ForPeopleChoose_NETraItemChooseTable(string Condition)
    {
        return ineia.Search_ForPeopleChoose_NETraItemChooseTable(Condition);
    }//新员工培训结果录入，新员工培训项目列表中点击“录入培训结果”，检索没有录入成绩的员工

    public int Insert_NETraEachItemResultDetail(NewEmpInfoAddInfo neiai)
    {
        return ineia.Insert_NETraEachItemResultDetail(neiai);
    }//新员工培训结果录入，"提交"按钮，插入新员工培训结果详情表

    public int Update_ForStateChange_NNETraInfoMainTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Update_ForStateChange_NNETraInfoMainTable(neiai);
    }//新员工培训结果录入，"提交"按钮，更新新员工培训信息主表的状态

    public int Update_ForTime_NETraItemChooseTable(NewEmpInfoAddInfo neiai)
    {
        return ineia.Update_ForTime_NETraItemChooseTable(neiai);
    }//新员工培训结果录入，"提交"按钮，更新该培训项目的信息
}