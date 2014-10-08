using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///IExptTest 的摘要说明
/// </summary>
public interface IExpTest
{

    DataSet Search_ExpSampleType_GridView(string EST_SampleType);//检索样品类型
    IList<ExpSampleType_ExpItems> Search_ExpSampleType_ID(Guid eST_SampleTypeID);//检索样品类型，根据ID
    int Insert_ExpSampleType(ExpSampleType_ExpItems expSampleType_ExpItems);//插入新的样品类型
    int Update_ExpSampleType(ExpSampleType_ExpItems expSampleType_ExpItems);//修改样品类型
    int Delete_ExpSampleType(Guid EST_SampleTypeID);//删除样品类型
    DataSet Search_ExpItems_Gridview(string EI_ExpItem, string EI_ExpCondtition, string EI_ExpMethold);//检索所有实验项目，默认显示
    IList<ExpSampleType_ExpItems> Search_ExpItems_ID(Guid eST_SampleTypeID);//检索实验项目，根据ID
    DataSet Search_ExpItems(ExpSampleType_ExpItems A);//模糊检索实验项目
    int Insert_ExpItems(ExpSampleType_ExpItems A);//插入新的实验项目
    int Update_ExpItems(ExpSampleType_ExpItems A);//修改实验项目
    int Delete_ExpItems(Guid EI_ExpItemID);//删除实验项目
}