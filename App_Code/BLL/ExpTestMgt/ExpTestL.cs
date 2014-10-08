using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///ExpTestL 的摘要说明
/// </summary>
public class ExpTestL
{
    private static readonly IExpTest pspt = DALFactory.CreateExpSampleType_ExpItems();
	public ExpTestL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet Search_ExpSampleType_GridView(string EST_SampleType)//检索样品类型
    {
        return pspt.Search_ExpSampleType_GridView(EST_SampleType);
    }

    public IList<ExpSampleType_ExpItems> Search_ExpSampleType_ID(Guid eST_SampleTypeID)//检索样品类型，根据ID
    {
        return pspt.Search_ExpSampleType_ID(eST_SampleTypeID);
    }

    public int Insert_ExpSampleType(ExpSampleType_ExpItems expSampleType_ExpItems)//插入新的样品类型
    {
        return pspt.Insert_ExpSampleType(expSampleType_ExpItems);
    }

    public int Update_ExpSampleType(ExpSampleType_ExpItems expSampleType_ExpItems)//修改样品类型
    {
        return pspt.Update_ExpSampleType(expSampleType_ExpItems);
    }

    public int Delete_ExpSampleType(Guid EST_SampleTypeID)//删除样品类型
    {
        return pspt.Delete_ExpSampleType(EST_SampleTypeID);
    }

    public IList<ExpSampleType_ExpItems> Search_ExpItems_ID(Guid eST_SampleTypeID)
    {
        return pspt.Search_ExpItems_ID(eST_SampleTypeID);
    }

    public DataSet Search_ExpItems_Gridview(string EI_ExpItem, string EI_ExpCondtition, string EI_ExpMethold)//检索所有实验项目，默认显示
    {
        return pspt.Search_ExpItems_Gridview(EI_ExpItem,EI_ExpCondtition,EI_ExpMethold);
    }

    public DataSet Search_ExpItems(ExpSampleType_ExpItems Exp)//模糊检索实验项目
    {
        return pspt.Search_ExpItems(Exp);
    }

    public int Insert_ExpItems(ExpSampleType_ExpItems A)//插入新的实验项目
    {
        return pspt.Insert_ExpItems(A);
    }

    public int Update_ExpItems(ExpSampleType_ExpItems A)//修改实验项目
    {
        return pspt.Update_ExpItems(A);
    }

    public int Delete_ExpItems(Guid EI_ExpItemID)//删除实验项目
    {
        return pspt.Delete_ExpItems(EI_ExpItemID);
    }
}